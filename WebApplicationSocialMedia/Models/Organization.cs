using WebApplicationSocialMedia.Models;

namespace WebApplicationSocialMedia.Models
{
    public class Organization
    {
        public string organizationID { get; set; }
        public string orgName { get; set; }

        //public ICollection<OrganizationMembership>? orgMembership { get; set; }
        public ICollection<User>? members { get; set; }
        public Organization()
        {
            //orgMembership = new List<OrganizationMembership>();
            members = new List<User>();
        }
    }
}
