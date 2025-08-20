using ExpenseTracker.Models;
using BCrypt.Net;
namespace ExpenseTracker.Factories
{
    public class UseFactory
    {
        public static UserModel CreateUser(string username, string email, string password)
        {
            return new UserModel
            {
                Username = username,
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(password),
                DateCreated = DateTime.Now
            };
        }
    };


}