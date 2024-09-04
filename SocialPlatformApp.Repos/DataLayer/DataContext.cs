using Microsoft.EntityFrameworkCore;
using SocialPlatformApp.Models.Models;

namespace SocialPlatformApp.Repos.DataLayer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Auth> Auths { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SocialPlatformAppSchema");

            modelBuilder.Entity<User>().ToTable("User").HasKey(u => u.Id);
            modelBuilder.Entity<Friend>().ToTable("Friend").HasKey(f => f.Id);
            modelBuilder.Entity<ChatMessage>().ToTable("ChatMessage").HasKey(c => c.Id);
            modelBuilder.Entity<Post>().ToTable("Post").HasKey(p => p.Id);
            modelBuilder.Entity<Like>().ToTable("Like").HasKey(l => l.Id);
            modelBuilder.Entity<Comment>().ToTable("Comment").HasKey(c => c.Id);
            modelBuilder.Entity<FriendRequest>().ToTable("FriendRequest").HasKey(k => k.Id);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Like)
                .WithOne(l => l.User)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.SentMessages)
                .WithOne(m => m.Sender)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ReceivedMessages)
                .WithOne(m => m.Receiver)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithOne(f => f.User)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
    .HasMany(u => u.FriendsOf)
    .WithOne(f => f.FriendUser)
    .HasForeignKey(f => f.FriendId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
            .HasMany(u => u.FriendRequests)
                .WithOne(f => f.Sender)
              .HasForeignKey(f => f.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
    .HasMany(u => u.ReceivedFriendRequests)
    .WithOne(f => f.Recipient)
    .HasForeignKey(f => f.RecipientId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FriendRequest>()
                .HasOne(o => o.Sender)
                .WithMany(m => m.FriendRequests)
                .HasForeignKey(o => o.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FriendRequest>()
                .HasOne(o => o.Recipient)
                .WithMany(m => m.ReceivedFriendRequests)
                .HasForeignKey(o => o.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Like>()
                .HasOne(l => l.User)
                .WithMany(u => u.Like)
                .HasForeignKey(l => l.UserId);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Post)
                .WithMany(p => p.Likes)
                .HasForeignKey(l => l.PostId);


            modelBuilder.Entity<Friend>()
                .HasOne(f => f.User)
                .WithMany(u => u.Friends)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Friend>()
                .HasOne(f => f.FriendUser)
                .WithMany(f => f.FriendsOf)
                .HasForeignKey(f => f.FriendId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ChatMessage>()
                .HasOne(c => c.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(c => c.SenderId);

            modelBuilder.Entity<ChatMessage>()
                .HasOne(c => c.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(c => c.ReceiverId);


            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Likes)
                .WithOne(l => l.Post)
                .HasForeignKey(l => l.PostId);


            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId);

            modelBuilder.Entity<User>()
               .Property(u => u.Username)
               .HasMaxLength(50)
               .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.FirstName)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.Bio)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.LastUpdatedAt)
                .IsRequired();

            modelBuilder.Entity<Auth>()
                .ToTable("Auth")
                .HasKey(u => u.Id);

        }
    }
}
