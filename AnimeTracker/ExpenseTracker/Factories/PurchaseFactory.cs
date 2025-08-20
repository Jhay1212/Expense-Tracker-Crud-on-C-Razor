using ExpenseTracker.Models;
namespace ExpenseTracker.Factories
{
    
    public class PurchaseFactory {
    public static Purchase CreatePurchase(string productName,
    double productPrice, int quantity=1, string category="")
        {
            return new Purchase
            {
                ProductName = productName,
                ProductPrice = productPrice,
                Quantity = quantity,
                Category = category
            };
        }
    }
}