using System;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace UiS.Dat240.Lab2
{
    // This class should inherit from the EntityFramework DbContext
    public class ShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Filename=Shop.db");
        }
        
        public DbSet<FoodItem> FoodItems {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            FakeData.Init();

            modelBuilder.Entity<FoodItem>().HasData(FakeData.FoodItems);
        }
    }

    internal class FakeData
    {
        public static FoodItem[] FoodItems { get; private set; }

        internal static void Init()
        {
            var foodItemId = 1;
              FoodItems = new Faker<FoodItem>()
                .RuleFor(i=>i.Id, _ => foodItemId++)
                .RuleFor(i=>i.Name, f=>f.Lorem.Sentence(3,2))
                .RuleFor(i=>i.Description, f=>f.Lorem.Sentence(10,10))
                .RuleFor(i=>i.Price, f=>f.Random.Number(50,250) + .99d)
                .RuleFor(i=>i.CookTime, f=>f.Random.Number(5,20))
                .Generate(30).ToArray() ;
        }
    }
}
