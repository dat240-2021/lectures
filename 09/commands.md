# Commands used during the lecture
cd .\UiS.Dat240.Lab2
dotnet watch run
dotnet ef migrations add FoodItem
dotnet ef database update
dotnet ef migrations add FoodItemTestData
dotnet ef database update
dotnet watch run