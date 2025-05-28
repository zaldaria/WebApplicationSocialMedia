using WebApplicationSocialMedia.Models;

namespace WebApplicationSocialMedia.Models
{
    public class Interest
    {
        public string interestID { get; set; }
        public string intName { get; set; }
        //public ICollection<UsersWithInterests> users { get; set; }
        public ICollection<User> users { get; set; }
        public Interest()
        {
            users = new List<User>();
        }
    }
}
