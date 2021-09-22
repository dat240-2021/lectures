using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace UiS.Dat240.Lab2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IFoodItemProvider _foodItemProvider;

        public FoodItem[] FoodItems { get; set; } = new FoodItem[0];
        public IndexModel(ILogger<IndexModel> logger, 
                          IFoodItemProvider foodItemProvider)
        {
            _logger = logger;
            _foodItemProvider = foodItemProvider;
        }

        public async void OnGet()
        {
           FoodItems = await _foodItemProvider.GetItems();
        }
    }
}
