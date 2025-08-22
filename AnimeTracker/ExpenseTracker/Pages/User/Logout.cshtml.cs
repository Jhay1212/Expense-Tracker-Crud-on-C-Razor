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
    public class LogoutModel : PageModel
    {
        private readonly ExpensesContext _context;


        public void OnGet()
        {
            HttpContext.Session.Clear();
        }


    }
}