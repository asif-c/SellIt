using Microsoft.EntityFrameworkCore;
using SellIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellIt.Data
{
    public class SellItContext: DbContext
    {
        public SellItContext(DbContextOptions<SellItContext> options)
            :base(options)
        { }

        public DbSet<Channel> Channels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(x => x.User)
                .WithMany(x => x.CreatedPosts)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Post>()
                .HasMany(x => x.Comments)
                .WithOne(x => x.ParentPost)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Comment>()
                .HasOne(x => x.ParentPost)
                .WithMany(x => x.Comments);
                


            modelBuilder.Entity<Channel>()
                .HasMany(x => x.Posts)
                .WithOne(x => x.Channel)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(c => c.CreatedChannels)
                .WithOne(x => x.Admin)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<User>()
                .HasMany(c => c.Comments)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
