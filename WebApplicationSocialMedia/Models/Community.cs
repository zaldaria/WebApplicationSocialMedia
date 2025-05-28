using WebApplicationSocialMedia.Models;

namespace WebApplicationSocialMedia.Models
{
    public class Community
    {
        public string communityID { get; set; }
        public string userID { get; set; }//организатор
        public User organizator { get; set; }
        public string name { get; set; }
        public string? description { get; set; }
        public DateTime? created { get; set; }

        public ICollection<CommunityPost>? communityPosts { get; set; }
        //public ICollection<CommunityMembership>? communityMembership { get; set; }
        public ICollection<User>? members { get; set; }
        public Community()
        {
            organizator = new User();
            communityPosts = new List<CommunityPost>();
            //communityMembership = new List<CommunityMembership>();
            members = new List<User>();
        }
    }
}
