using ExpenseTracker.Models;
namespace ExpenseTracker.Factories
{
    
    public class PurchaseFactory {
    public static Purchase CreatePurchase(int userId, string productName,
    double productPrice, int quantity=1, string category="")
        {
            return new Purchase
            {
                UserId = userId,
                ProductName = productName,
                ProductPrice = productPrice,
                Quantity = quantity,
                Category = category
            };
        }
    }
}