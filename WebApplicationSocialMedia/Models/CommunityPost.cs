namespace WebApplicationSocialMedia.Models
{
    public class CommunityPost
    {
        public string communityPostID { get; set; }
        public string communityID { get; set; }
        public Community? community { get; set; }
        public string? text { get; set; }
        public DateTime? created { get; set; }
        public CommunityPost()
        {
            community = new Community();
        }
    }
}
