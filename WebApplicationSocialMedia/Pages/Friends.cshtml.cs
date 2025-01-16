using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationSocialMedia.DAL;
using WebApplicationSocialMedia.Models;
using WebApplicationSocialMedia.Services;
using WebSocialMedia.Models;

namespace WebApplicationSocialMedia.Pages
{
    [Authorize]
    public class FriendsModel : PageModel
    {
        private readonly UserManager<User> userManager;
        private readonly FriendshipDBStorage _friendshipDbStorage;

        public FriendsModel(ApplicationDbContext _context, UserManager<User> userManager)
        {
            _friendshipDbStorage = new FriendshipDBStorage(_context);
            this.userManager = userManager;
        }

        public List<Friendship>? friendships { get; set; }
        public List<User>? friends { get; set; }
        public User? user;

        public void OnGet() 
        {
            var u = userManager.GetUserAsync(User);
            u.Wait();
            user = u.Result;

            var fr = _friendshipDbStorage.GetAllFriendsOfUser(user);
            fr.Wait();
            friends = fr.Result;

            var fshp = _friendshipDbStorage.GetAllFriendships();
            fshp.Wait();
            friendships = fshp.Result;

        }
        

        //public User? user;
        //public FriendsModel(UserManager<User> userManager)
        //{
        //    this.userManager = userManager;
        //}

        //public void OnGet()
        //{
        //    var task = userManager.GetUserAsync(User);
        //    task.Wait();
        //    user = task.Result;
        //}
    }
}
