using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationSocialMedia.Models;
using WebSocialMedia.Models;


namespace WebApplicationSocialMedia.Services
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 

        }

        public new DbSet<User> Users { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<Like> Likes { get; set; } = null!;
        public DbSet<Community> Communities { get; set; } = null!;        
        public DbSet<CommunityPost> CommunityPosts { get; set; } = null!;
        public DbSet<Friendship> friendship { get; set; } = null!;
        public DbSet<Interest> Interests { get; set; } = null!;
        public DbSet<Organization> Organizations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Community>()
                .HasOne(cm => cm.organizator)
                .WithMany(u => u.communities)
                .HasForeignKey(cm => cm.userID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Friendship>()
                .HasOne(f => f.user)
                .WithMany(u => u.myFriends)
                .HasForeignKey(f => f.userID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Friendship>()
                .HasOne(f => f.friend)
                .WithMany(u => u.imFriend)
                .HasForeignKey(f => f.friendID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Message>()
                .HasOne(m => m.sender)
                .WithMany(u => u.messagesISent)
                .HasForeignKey(m => m.senderID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(m => m.recipient)
                .WithMany(u => u.messagesIRecieve)
                .HasForeignKey(m => m.recipientID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>()
                .HasOne(c => c.author)
                .WithMany(u => u.comments)
                .HasForeignKey(c => c.userID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Like>()
                .HasOne(c => c.author)
                .WithMany(l => l.likes)
                .HasForeignKey(c => c.userID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>()
                .HasOne(c => c.post) 
                .WithMany(p => p.comments) 
                .HasForeignKey(c => c.postID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Comment>()
                .HasOne(c => c.author)
                .WithMany(u => u.comments)
                .HasForeignKey(c => c.userID)
                .OnDelete(DeleteBehavior.Restrict);

            var admin = new IdentityRole
            {
                Id = "1", 
                Name = "Admin",
                NormalizedName = "ADMIN" 
            };

            var user = new IdentityRole
            {
                Id = "2", 
                Name = "User",
                NormalizedName = "USER" 
            };

            builder.Entity<IdentityRole>().HasData(admin, user);
           
        }

    }
}
