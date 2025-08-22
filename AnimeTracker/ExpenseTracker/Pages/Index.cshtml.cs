using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ExpenseTracker.Models;
using ExpenseTracker.Data;
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ExpensesContext _context;

        public IList<Purchase> Purchases { get; set; } = new List<Purchase>();

        public IndexModel(ILogger<IndexModel> logger, ExpensesContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var UserId = HttpContext.Session.GetInt32("Id");

            if (UserId == null)
            {
                return RedirectToPage("/User/Login");
            }

            // get all purchases from logged in user
            Purchases = await _context.Purchases
                .Where(p => p.Id == UserId)
                .ToListAsync();

            return Page();
        }
    }
}
