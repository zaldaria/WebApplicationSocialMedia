using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationSocialMedia.Models;

namespace WebApplicationSocialMedia.Pages
{
    [Authorize]
    public class FriendsModel : PageModel
    {
        private readonly UserManager<User> userManager;

        public User? user;
        public FriendsModel(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public void OnGet()
        {
            var task = userManager.GetUserAsync(User);
            task.Wait();
            user = task.Result;
        }
    }
}
