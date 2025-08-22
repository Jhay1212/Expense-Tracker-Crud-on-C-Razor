using Microsoft.AspNetCore.Mvc;
using  Microsoft.AspNetCore.Mvc.RazorPages;
using ExpenseTracker.Models;
using ExpenseTracker.Factories;
using ExpenseTracker.Data;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Pages
{
    public class UserLoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; } = "";

        [BindProperty]
        public String Password { get; set; } = "";

        private readonly ExpensesContext _context;
        public UserLoginModel(ExpensesContext context)
        {
            _context = context;
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace("Password"))
            {
                ModelState.AddModelError("", "Username or Password cannot be empty");
                return Page();
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == Username);

            if(user.Password != null && BCrypt.Net.BCrypt.Verify(Password, user.Password)) 
            {
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetInt32("Id", user.Id);
                Console.WriteLine($"Account logged in {HttpContext.Session.GetString("Username")}");
            
              return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError("", "Invalid credentials"); // check if user does exist and if input is correct
                return Page();
            }

   
        }
    }
}