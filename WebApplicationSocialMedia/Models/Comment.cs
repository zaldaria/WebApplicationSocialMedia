using Microsoft.Extensions.Hosting;
using WebApplicationSocialMedia.Models;

namespace WebSocialMedia.Models
{
    public class Comment
    {
        public string commentID { get; set; }
        public string userID { get; set; }
        public User author { get; set; }
        public string postID { get; set; }
        public Post post { get; set; }
        public string? text { get; set; }
        public DateTime? created { get; set; }
        public Comment()
        {
            author = new User();
            post = new Post();
        }

    }
}
