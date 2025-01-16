using WebApplicationSocialMedia.Models;

namespace WebSocialMedia.Models
{
    public class Friendship
    {
        public string friendshipID { get; set; }
        public string userID { get; set; } // cам пользователь
        public User? user { get; set; }
        public string friendID {  get; set; } // друг
        public User? friend { get; set; }
        public DateTime? created { get; set; }
        public Friendship() {
            user = new User();
            friend = new User();
        }
        
    }
}
