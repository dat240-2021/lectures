using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Six.Core.Domain;

namespace Six.Core.Infrastructure
{
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
           
        }

        public InstaContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Combine(path, "instaweb.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
            // options.LogTo(Console.WriteLine);
            // options.EnableSensitiveDataLogging();
        }

    }
}