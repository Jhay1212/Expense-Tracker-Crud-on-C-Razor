using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ExpenseTracker.Pages
{
    public class PurchaseDeleteModel : PageModel
    {
        private readonly ExpensesContext _context;

        public PurchaseDeleteModel(ExpensesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Purchase Purchase { get; set; } = null!;

        // Show purchase details before deletion (GET)
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Purchase = await _context.Purchases
                .FirstOrDefaultAsync(p => p.Id == id);

            if (Purchase == null)
            {
                return NotFound();
            }

            return Page();
        }

        // Delete the purchase 
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var purchase = await _context.Purchases.FindAsync(id);

            if (purchase == null)
            {
                return NotFound();
            }

            _context.Purchases.Remove(purchase);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
