using System;
using System.ComponentModel.DataAnnotations;
namespace AnimeTracker.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        public string Profile { get; set; }

        public DateOnly DateCreated;

        public List<Anime> Animes { get; set; }


        public User()
        {
            String name = "kjau";
        }
    }
}