namespace AnimeTracker.Models
{
    public class User
    {
        public int Id;
        public string Username { get; set; }


        public string Email { get; set; }

        public string Password { get; set; }

        public string Profile { get; set; }

        public DateTime DateCreated;


        public User()
        {
            String name = "kjau";
        }
    }
}