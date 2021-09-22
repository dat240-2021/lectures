using System.Threading.Tasks;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace UiS.Dat240.Lab2.Services {

    public class FoodItemProvider : IFoodItemProvider
    {
        private readonly ShopContext _db;

        public FoodItemProvider(ShopContext db)
        {
            _db = db;
        }

        public async Task<FoodItem[]> GetItems()
        {
            return await _db.FoodItems.ToArrayAsync();
            //  return Task.FromResult( new Faker<FoodItem>()
            //     .RuleFor(i=>i.Name, f=>f.Lorem.Sentence(3,2))
            //     .RuleFor(i=>i.Description, f=>f.Lorem.Sentence(10,10))
            //     .RuleFor(i=>i.Price, f=>f.Random.Number(50,250) + .99d)
            //     .RuleFor(i=>i.CookTime, f=>f.Random.Number(5,20))
            //     .Generate(30).ToArray() );
        }
        public Task AddFoodItem(FoodItem item)
        {
            throw new System.NotImplementedException();
        }

        public Task<FoodItem> GetFoodItem(int id)
        {
            throw new System.NotImplementedException();
        }


        public Task RemoveFoodItem(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateFoodItem(int id, FoodItem item)
        {
            throw new System.NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

}