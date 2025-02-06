using System.ComponentModel.DataAnnotations.Schema;
using WebApplicationSocialMedia.Models;

namespace WebApplicationSocialMedia.Models
{
    public class Message
    {
        public string messageID { get; set; }        
        public string senderID { get; set; }
        public User? sender { get; set; }
        public string recipientID { get; set; }
        public User? recipient { get; set; }        
        public string? text { get; set; }
        public DateTime? sent { get; set; }
        public Message()
        {
            sender = new User();
            recipient = new User();
        }
    }
}
