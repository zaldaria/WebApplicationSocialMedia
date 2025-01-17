using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationSocialMedia.DAL;
using WebApplicationSocialMedia.Models;
using WebApplicationSocialMedia.Services;

namespace WebApplicationSocialMedia.Areas.Identity.Pages.Account
{
    [Authorize(Roles = "User")]
    public class DeleteAccountModel : PageModel
    {
        private readonly FriendshipDBStorage _friendshipDBStorage;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;
        public DeleteAccountModel(ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _friendshipDBStorage = new FriendshipDBStorage(context);
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingUser = await _userManager.GetUserAsync(User);
            if (existingUser == null)
            {
                return NotFound();
            }

            await _friendshipDBStorage.RemoveAllFriendshipsOfUser(existingUser);
            await _context.SaveChangesAsync();

            var result = await _userManager.DeleteAsync(existingUser);
            if (result.Succeeded)
            {
                await _signInManager.SignOutAsync();
                return RedirectToPage("/Index");
                
            }

            await _context.SaveChangesAsync();
            return Page();
        }
    }
}
