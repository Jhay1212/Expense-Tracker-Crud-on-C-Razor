using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ExpenseTracker.Models;
using ExpenseTracker.Data;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Queries;


namespace ExpenseTracker.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ExpensesContext _context;

        [BindProperty(SupportsGet = true)] // get search value from form
        public string Search { get; set; } // get the filter value
        [BindProperty(SupportsGet = true)]

        public string Filter { get; set; }

        public IList<Purchase> Purchase { get; set; } = new List<Purchase>();

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
            var _query = _context.Purchases.Where(p => p.UserId == UserId.Value ).AsQueryable();
            
            if (!string.IsNullOrEmpty(Search))
            {
                _query = _query.Where(p => p.ProductName.Contains(Search));
            }

            if (!string.IsNullOrEmpty(Filter))
            {
                switch (Filter.ToLower())
                {
                    case "price":
                        _query = _query.OrderBy(p => p.ProductPrice);
                        break;
                    case "category":
                        _query = _query.OrderBy(p => p.Category);
                        break;
                    case "date":
                        _query = _query.OrderBy(p => p.DatePurchased);
                        break;
                }
            }
            // get all purchases from logged in user or based from filter or search
            Purchase = await _query.ToListAsync();
        

            return Page();
        }
    }
}
