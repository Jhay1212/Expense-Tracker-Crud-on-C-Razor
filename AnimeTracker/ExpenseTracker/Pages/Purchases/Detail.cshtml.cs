using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ExpenseTracker.Data;
using ExpenseTracker.Models;
using System.Linq;

namespace ExpenseTracker.Pages
{
    public class PurchaseDetailModel : PageModel
    {
        private readonly ExpensesContext _context;

        public PurchaseDetailModel(ExpensesContext context)
        {
            _context = context;
        }

        public Purchase Purchase { get; set; }

        public IActionResult OnGet(int id)
        {
            Purchase = _context.Purchases.FirstOrDefault(p => p.Id == id);

            if (Purchase == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
