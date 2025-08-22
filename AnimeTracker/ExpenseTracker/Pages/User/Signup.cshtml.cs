using Microsoft.AspNetCore.Mvc;
using  Microsoft.AspNetCore.Mvc.RazorPages;
using ExpenseTracker.Factories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ExpenseTracker.Data;

namespace ExpenseTracker.Pages
{
    public class UserSignupModel : PageModel
    {

        private readonly ExpensesContext _context;

        
        [BindProperty]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        public string Email { get; set; } = string.Empty;
        [BindProperty]

         public string Password { get; set; } = string.Empty;

        [BindProperty]

        public double Budget { get; set; }

        public UserSignupModel(ExpensesContext context)
        {
            _context = context;

        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var user = UserFactory.CreateUser( // use the factory method to hide the imolementationm of bject
                Username,
                Email,
                Password,
                Budget
            );
            _context.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");

        }
 }
}