using WebApplicationSocialMedia.Models;

namespace WebApplicationSocialMedia.Models
{
    public class Post
    {
        public string postID { get; set; }
        public string authorID { get; set; }
        public User author { get; set; }
        public string? text { get; set; }
        public DateTime? created { get; set; }

        public ICollection<Comment>? comments { get; set; }
        public ICollection<Like>? likes { get; set; }
        public Post()
        {
            author = new User();
            comments = new List<Comment>();
            likes = new List<Like>();
        }
    }
}

