using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSocialMedia.Models;
using WebApplicationSocialMedia.Services;

namespace WebApplicationSocialMedia.DAL
{
    public class MessageDbStorage
    {
        private readonly ApplicationDbContext _context;

        public MessageDbStorage(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddMessage(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task<Message?> GetMessageById(string messageId)
        {
            return await _context.Messages
                .FirstOrDefaultAsync(m => m.messageID == messageId);
        }

        public async Task<List<Message>> GetAllMessages()
        {
            return await _context.Messages.ToListAsync();
        }

        public async Task<List<Message>> GetMessagesBetweenUsers(string senderId, string recipientId)
        {
            return await _context.Messages
                .Where(m => (m.senderID == senderId && m.recipientID == recipientId) ||
                            (m.senderID == recipientId && m.recipientID == senderId))
                .OrderBy(m => m.sent)
                .ToListAsync();
        }

        public async Task<List<Message>> GetUserSentMessages(string userId)
        {
            return await _context.Messages
                .Where(m => m.senderID == userId)
                .ToListAsync();
        }

        public async Task<List<Message>> GetUserReceivedMessages(string userId)
        {
            return await _context.Messages
                .Where(m => m.recipientID == userId)
                .ToListAsync();
        }

        //public async Task UpdateMessage(Message message)
        //{
        //    _context.Messages.Update(message);
        //    await _context.SaveChangesAsync();
        //}

        public async Task DeleteMessage(string messageId)
        {
            var message = await GetMessageById(messageId);
            if (message != null)
            {
                _context.Messages.Remove(message);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAllMessagesBetweenUsers(string user1Id, string user2Id)
        {
            var messages = await GetMessagesBetweenUsers(user1Id, user2Id);
            _context.Messages.RemoveRange(messages);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllUserMessages(string userId)
        {
            var sentMessages = await GetUserSentMessages(userId);
            var receivedMessages = await GetUserReceivedMessages(userId);

            _context.Messages.RemoveRange(sentMessages);
            _context.Messages.RemoveRange(receivedMessages);

            await _context.SaveChangesAsync();
        }
    }
}