using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationSocialMedia.Pages
{
    [Authorize(Roles = "Admin")]
    public class AdministratorModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
