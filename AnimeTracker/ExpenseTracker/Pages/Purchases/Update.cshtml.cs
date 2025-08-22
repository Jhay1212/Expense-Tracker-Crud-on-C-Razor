using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ExpenseTracker.Models;
using ExpenseTracker.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Pages
{
    public class UpdatePurchaseModel : PageModel
    {
        private readonly ExpensesContext _context;

        [BindProperty]
        public Purchase Purchase { get; set; } = new Purchase();

        public UpdatePurchaseModel(ExpensesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            Purchase = _context.Purchases.FirstOrDefault(p => p.Id == id);
            if (Purchase == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Purchase).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Purchases.Any(p => p.Id == Purchase.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Index");
        }
    }
}
