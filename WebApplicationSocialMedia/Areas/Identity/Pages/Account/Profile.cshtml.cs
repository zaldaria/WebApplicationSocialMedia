using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationSocialMedia.DAL;
using WebApplicationSocialMedia.Models;
using WebApplicationSocialMedia.Services;

namespace WebApplicationSocialMedia.Areas.Identity.Pages.Account
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly FriendshipDBStorage _friendshipDbStorage;
        private readonly UserManager<User> _userManager;
        
        public ProfileModel(ApplicationDbContext context, UserManager<User> userManager)
        {
            _friendshipDbStorage = new FriendshipDBStorage(context);
            _userManager = userManager;            
        }

        public User currentUser { get; set; } 
       
        public int CntFriends { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var existingUser = await _userManager.GetUserAsync(User);

            var friendship_list = await _friendshipDbStorage.GetAllFriendshipsOfUser(existingUser);
            CntFriends = friendship_list.Count();

            currentUser = existingUser;

            return Page();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("./EditProfile");
        }
    }
}
