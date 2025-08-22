
using ExpenseTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using ExpenseTracker.Data;
using ExpenseTracker.Models;
namespace ExpenseTracker.Queries
{

    public interface IQuery<T>
    {
        T Execute();
    }

    public class QueryByPrice : IQuery<IEnumerable<Purchase>>
    {

        private readonly double _price;
        private readonly ExpensesContext _context;

        public QueryByPrice(ExpensesContext context, double price)
        {
            _context = context;
            _price = price;
        }

        public IEnumerable<Purchase> Execute()
        {
            return _context.Purchases.Where(e => e.ProductPrice == _price).ToList();
        }
        
    }

    public class QueryByCategory : IQuery<IEnumerable<Purchase>>
    {
        private readonly string _category;
        private readonly ExpensesContext _context;

        public QueryByCategory(ExpensesContext context, string category)
        {
            _context = context;
            _category = category;
        }

        public IEnumerable<Purchase> Execute()
        {
            return _context.Purchases.Where(p => p.Category == _category).ToList();
        }
    }


    public class QueryByDate : IQuery<IEnumerable<Purchase>>
    {
        private readonly DateOnly _date;
        private readonly ExpensesContext _context;

        public QueryByDate(ExpensesContext context, DateOnly date)
        {
            _context = context;
            _date = date;
        }

        public IEnumerable<Purchase> Execute()
        {
            return _context.Purchases.Where(p => p.DatePurchased == _date).ToList();
        }
        
    }

    
}