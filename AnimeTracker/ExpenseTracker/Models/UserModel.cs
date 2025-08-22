using System.ComponentModel.DataAnnotations;
using System;
using BCrypt.Net;

namespace ExpenseTracker.Models
{


    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(12, ErrorMessage = "Username max length is 12")]
        public string Username { get; set; } = "";


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = "";
        [Required]
        [MinLength(8)]
        public string Password { get; set; } = "";

        public double Budget { get; set; } = 100;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public ICollection<Purchase> Purchases { get; } = new List<Purchase>();
        

    }
}
