using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using WebApplicationSocialMedia.Models;
using WebApplicationSocialMedia.Services;

namespace WebApplicationSocialMedia.Areas.Identity.Pages.Account
{
    public class DeleteAccountModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;
        public DeleteAccountModel(ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }

        //public string? resMessage;
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
