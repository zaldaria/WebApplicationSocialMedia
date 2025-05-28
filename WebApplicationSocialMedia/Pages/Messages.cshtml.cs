using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationSocialMedia.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSocialMedia.Services;
using NuGet.Protocol.Plugins;
using Message = WebApplicationSocialMedia.Models.Message;

namespace WebApplicationSocialMedia.Pages
{
    [Authorize]
    public class MessagesModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public User CurrentUser { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public List<Message> UserMessages { get; set; } = new List<Message>();
        public string SelectedUserId { get; set; } = string.Empty;
        public User? SelectedUser { get; set; }
        
        public MessagesModel(UserManager<User> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
            
        }

        public async Task<IActionResult> OnGet(string? userId)
        {
            CurrentUser = await _userManager.GetUserAsync(User);
            
            if (CurrentUser != null)
            {
                Users = await _context.Users
                    .Where(u => u.Id != CurrentUser.Id)
                    .ToListAsync();

                if (!string.IsNullOrEmpty(userId))
                {
                    SelectedUserId = userId; // кому пишем
                    SelectedUser = await _userManager.FindByIdAsync(userId);
                    UserMessages = await _context.Messages
                        .Where(m => (m.senderID == CurrentUser.Id && m.recipientID == userId) ||
                                     (m.senderID == userId && m.recipientID == CurrentUser.Id))
                        .ToListAsync();
                }
            }
            //Console.WriteLine("Current user --- " + CurrentUser?.Id + " " + CurrentUser?.name);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string recipientId, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return RedirectToPage();
            }

            CurrentUser = await _userManager.GetUserAsync(User);
            Console.WriteLine("! Current user --- " + CurrentUser?.Id + " " + CurrentUser?.name);
            Console.WriteLine("! Recipient --- " + recipientId);

            Message message = new Message();
            message.messageID = Guid.NewGuid().ToString();
            
            message.senderID = CurrentUser?.Id;
            message.recipientID = recipientId;
            message.text = text;
            message.sent = DateTime.Now;

            Console.WriteLine(message.senderID + " " + message.recipientID);
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return RedirectToPage("");
        }
    }
}
