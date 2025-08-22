using ExpenseTracker.Models;
using BCrypt.Net;
namespace ExpenseTracker.Factories
{
    public class UserFactory
    {
        // Created factory method to abstract the creation of the user 
        public static UserModel CreateUser( string username, string email, string password, double budget)
        {
            return new UserModel
            {
                
                Username = username,
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(password), // hashed the password before saving to db
                Budget = budget,
                DateCreated = DateTime.Now,
            };
        }
    };


}