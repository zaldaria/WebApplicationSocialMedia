using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationSocialMedia.Services;
using WebSocialMedia.Models;

namespace WebApplicationSocialMedia.Areas.Identity.Pages.Account
{
    public class IndexModel : PageModel
    {
        private readonly WebApplicationSocialMedia.Services.ApplicationDbContext _context;

        public IndexModel(WebApplicationSocialMedia.Services.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Message> Message { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Message = await _context.Messages
                .Include(m => m.recipient)
                .Include(m => m.sender).ToListAsync();
        }
    }
}
