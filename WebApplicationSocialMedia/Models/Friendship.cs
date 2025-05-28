using WebApplicationSocialMedia.Models;

namespace WebApplicationSocialMedia.Models
{
    public class Friendship
    {
        public string friendshipID { get; set; }
        public string userID { get; set; } // c�� ������������
        public User? user { get; set; }
        public string friendID {  get; set; } // ����
        public User? friend { get; set; }
        public DateTime? created { get; set; }
        public Friendship() {
            user = new User();
            friend = new User();
        }
        
    }
}
