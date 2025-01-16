using WebApplicationSocialMedia.Models;

namespace WebSocialMedia.Models
{
    public class Like
    {
        public string likeID { get; set; }
        public string userID { get; set; }
        public User author { get; set; }
        public string postID { get; set; }
        public Post post { get; set; }
        public DateTime? created { get; set; }
        public Like()
        {
            author = new User();
            post = new Post();
        }
    }
    
}
