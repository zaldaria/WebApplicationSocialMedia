using Microsoft.EntityFrameworkCore;
using WebApplicationSocialMedia.Models;
using WebApplicationSocialMedia.Services;

namespace WebApplicationSocialMedia.DAL
{
    public class FriendshipDBStorage
    {
        private readonly ApplicationDbContext _context;

        public FriendshipDBStorage(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddFriendship(Friendship friendship)
        {
            _context.friendship.Add(friendship);
            _context.SaveChanges();
        }
        public Friendship? GetFriendship(string friendship_id)
        {
            Friendship? fr = _context.friendship.FirstOrDefault(f => f.friendshipID == friendship_id);
            return fr;
        }
        public User? GetFriend(string fr_id)
        {
            Friendship? fr = GetFriendship(fr_id);
            User? user = null;
            if (fr != null) _context.Users.FirstOrDefault(u => u.Id.ToString() == fr.friendID);
            return user;
        }
        public async Task<List<Friendship>> GetAllFriendships()
        {
            var fr = await _context.friendship.ToListAsync();            
            return fr;
        }
        public async Task<List<Friendship>> GetAllFriendshipsOfUser(User user)
        {
            var fr = await _context.friendship.Where(f => (f.userID == user.Id || f.friendID == user.Id)).ToListAsync();
            return fr;
        }
        public async Task<List<User>> GetAllFriendsOfUser(User user)
        {
            var friendships = await GetAllFriendshipsOfUser(user);
            var friendIDs = friendships.Select(f => f.userID == user.Id ? f.friendID : f.userID).ToList();
            var friends = await _context.Users.Where(u => friendIDs.Contains(u.Id.ToString())).ToListAsync();
            return friends;
        }
        public void RemoveFriendship(Friendship frshp)
        {
            _context.friendship.Remove(frshp);
            _context.SaveChanges();
        }
        public async Task RemoveAllFriendshipsOfUser(User user)
        {
            var friendships = await GetAllFriendshipsOfUser(user);
            foreach (var friendship in friendships)
            {
                RemoveFriendship(friendship);
            }
        }
        
    }
}
