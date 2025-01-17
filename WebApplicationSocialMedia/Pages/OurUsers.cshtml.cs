using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationSocialMedia.Models;

namespace WebApplicationSocialMedia.Pages
{
    public class OurUsersModel : PageModel
    {
        private readonly UserManager<User> _userManager;        
        public OurUsersModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public List<User> users { get; set; } = new List<User>();
        public int cnt
        {
            get { return users.Count <= 5 ? users.Count : 5; }
            set { }
        }
        public async void OnGet()
        {
            var u = _userManager.Users.ToListAsync();
            u.Wait();
            users = u.Result;
        }
    }
}