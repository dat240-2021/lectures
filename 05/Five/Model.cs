using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace Five
{
    public class Post
    {
        public Post(string imageURL)
        {
            ImageURL = imageURL;
        }

        public int Id { get; set; }
        public string ImageURL { get; private set; }
        public string Caption { get; set; }
        public int NumberOfLikes { get; set; }

        public int CommentCount { get; private set; }

        protected List<Comment> _comments { get; set; } = new List<Comment>();
        public ReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();
        public void AddComment(string text)
        {
            _comments.Add(new Comment { Text = text });
            CommentCount++;
        }
    }

    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Post Post { get; set; }
    }

    public class InstaContext : DbContext
    {

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public string DbPath { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .Property(p => p.ImageURL)
                .IsRequired();
            modelBuilder.Entity<Post>()
                .Property(p=>p.Comments)
                .HasField("_comments");

            
        }

        public InstaContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Combine(path, "insta.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
            // options.LogTo(Console.WriteLine);
            // options.EnableSensitiveDataLogging();
        }

    }

}