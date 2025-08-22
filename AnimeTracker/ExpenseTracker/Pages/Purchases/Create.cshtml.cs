using ExpenseTracker.Data;
using Microsoft.AspNetCore.Mvc;
using  Microsoft.AspNetCore.Mvc.RazorPages;
using ExpenseTracker.Models;
using ExpenseTracker.Factories;

namespace ExpenseTracker.Pages
{
    

    public class CreateModel : PageModel
    {
        private readonly ExpensesContext _context;
        public string? UserCookie { get; set; }




        [BindProperty]
        public Purchase Purchase { get; set; } = new Purchase();

        public CreateModel(ExpensesContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var userId = HttpContext.Session.GetInt32("Id");

            var p = PurchaseFactory.CreatePurchase(
                userId.Value,
                Purchase.ProductName,
                Purchase.ProductPrice,
                Purchase.Quantity,
                Purchase.Category
            );

            _context.Purchases.Add(p);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
