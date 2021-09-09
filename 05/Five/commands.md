# Commands used during lecture

mkdir 05                                                    
cd 05                                                       
dotnet new console -o Five                                  
cd .\Five\                                                  
code .                                                      
dotnet add package Microsoft.EntityFramework.Sqlite         
dotnet add package Microsoft.EntityFrameworkCore.Sqlite     
dotnet tool install --global dotnet-ef                      
dotnet add package Microsoft.EntityFrameworkCore.Design     
dotnet ef migrations add InitialCreate_Post                 
dotnet ef database update                                   
dotnet run                                                  
dotnet ef migrations add Comments                           
dotnet run                                                  
dotnet ef database update                                   
dotnet run                                                  
dotnet ef migrations add RequireImageUrl                    
dotnet ef database update                                   
dotnet run                                                  
dotnet ef migrations add CommentCOunt                       
dotnet ef database update                                   
dotnet run                                                  
dotnet ef migrations add CommentReadOnly                    