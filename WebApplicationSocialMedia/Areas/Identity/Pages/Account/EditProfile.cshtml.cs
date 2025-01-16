using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using WebApplicationSocialMedia.DAL;
using WebApplicationSocialMedia.Models;
using WebApplicationSocialMedia.Services;

namespace WebApplicationSocialMedia.Areas.Identity.Pages.Account
{
    public class EditProfileModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;
        public EditProfileModel(ApplicationDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public User editUser { get; set; }
        [BindProperty]
        public string OldPassword { get; set; } 
        [BindProperty]
        public string NewPassword { get; set; } 

        public void OnGet()
        {
            editUser = new User();            
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
                return NotFound(); // ¬озвращаем 404, если пользователь не найден
            }

            existingUser.surname = !string.IsNullOrEmpty(editUser.surname) ? editUser.surname : existingUser.surname;
            existingUser.name = !string.IsNullOrEmpty(editUser.name) ? editUser.name : existingUser.name;
            existingUser.phone = !string.IsNullOrEmpty(editUser.phone) ? editUser.phone : existingUser.phone;
            existingUser.Email = !string.IsNullOrEmpty(editUser.Email) ? editUser.Email : existingUser.Email;
            existingUser.UserName = !string.IsNullOrEmpty(editUser.Email) ? editUser.Email : existingUser.Email;
            existingUser.residence = !string.IsNullOrEmpty(editUser.residence) ? editUser.residence : existingUser.residence;
            existingUser.status = !string.IsNullOrEmpty(editUser.status) ? editUser.status : existingUser.status;
            existingUser.birth = editUser.birth != DateTime.MinValue ? editUser.birth : existingUser.birth;

            if (editUser.ImageFile != null)
            {
                Console.WriteLine("photo");
                using (Stream fs = editUser.ImageFile.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((int)fs.Length);
                        editUser.image = Convert.ToBase64String(bytes);
                    }
                }
            }

            existingUser.image = !string.IsNullOrEmpty(editUser.image) ? editUser.image : existingUser.image;
            existingUser.ImageFile = editUser.ImageFile != null ? editUser.ImageFile : existingUser.ImageFile;

            if (!string.IsNullOrEmpty(OldPassword) && !string.IsNullOrEmpty(NewPassword))
            {
                var changePasswordResult = await _userManager.ChangePasswordAsync(existingUser, OldPassword, NewPassword);
                if (!changePasswordResult.Succeeded)
                {
                    foreach (var error in changePasswordResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return Page();
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("./Profile");
        }
    }
}
