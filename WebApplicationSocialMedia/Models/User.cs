using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationSocialMedia.Models
{
    public class User : IdentityUser
    {
        public string surname { get; set; } = "";
        public string name { get; set; } = "";
        public string? patronymic { get; set; } = "";
        public DateOnly birth { get; set; } = DateOnly.MaxValue;
        public string? residence { get; set; } = "";
        public string? phone { get; set; } = "";
        public string? status { get; set; } = "";
        public DateTime created { get; set; } = DateTime.Now;
        public string? image { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public ICollection<Organization>? organizations { get; set; }
        public ICollection<Post>? posts { get; set; }
        public ICollection<Message>? messagesISent { get; set; }
        public ICollection<Message>? messagesIRecieve { get; set; }
        public ICollection<Comment>? comments { get; set; }
        public ICollection<Like>? likes { get; set; }
        public ICollection<Friendship>? myFriends { get; set; }
        public ICollection<Friendship>? imFriend { get; set; }
        public ICollection<Interest>? interests { get; set; }
        public ICollection<Community>? communities { get; set; }
        public ICollection<Community>? isOrganizator { get; set; }

        public User()
        {
            organizations = new List<Organization>();
            posts = new List<Post>();
            messagesISent = new List<Message>();
            messagesIRecieve = new List<Message>();
            comments = new List<Comment>();
            likes = new List<Like>();
            myFriends = new List<Friendship>();
            imFriend = new List<Friendship>();
            interests = new List<Interest>();
            communities = new List<Community>();
            isOrganizator = new List<Community>();
        }

    }
}
