using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationSocialMedia.DAL;
using WebApplicationSocialMedia.Models;
using WebApplicationSocialMedia.Services;

namespace WebApplicationSocialMedia.Pages
{
    [Authorize(Roles = "Admin")]
    public class AdministratorModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly FriendshipDBStorage _friendshipDBStorage;
        private readonly ApplicationDbContext _context;
        public AdministratorModel(ApplicationDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
            _friendshipDBStorage = new FriendshipDBStorage(context);
        }
        public List<User> users { get; set; } = new List<User>();
        public User currentUser {  get; set; }
        public async void OnGet()
        {
            var u = _userManager.Users.ToListAsync();
            u.Wait();
            users = u.Result;

            var existingUser = await _userManager.GetUserAsync(User);
            currentUser = existingUser;

        }
        public async Task<IActionResult> OnPostDelete(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            
            if (user != null)
            {
                await _friendshipDBStorage.RemoveAllFriendshipsOfUser(user);
                await _context.SaveChangesAsync();

                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage(); 
                }
                
            }
            return Page();
        }
    }
}
