using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Five
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new InstaContext()) {

                Console.WriteLine("Post with comment");
                var post = new Post("https://example.com/wohjkasd") {
                    // ImageURL = "https://example.com/wohjkasd",
                    Caption = "Captoion",
                    NumberOfLikes = 3,
                };
                post.AddComment("WooHoo! \\o/ ╰(*°▽°*)╯");


                db.Add(post);

                db.SaveChanges();

                Console.WriteLine("Reading posts");

                var posts = db.Posts
                    .Include(p=>p.Comments)
                    .OrderBy(p=>p.Id)
                    .ToList();

                foreach(var p in posts) {
                    Console.WriteLine($"{p.Id}: {p.Caption} {p.CommentCount}");

                    foreach (var c in p.Comments ?? Enumerable.Empty<Comment>()) {
                        Console.WriteLine(c.Text);
                    }
                }

                // posts.First().Caption = "Changed";
                // db.Add(new Post { Caption ="New post to be deleted"});

                // db.SaveChanges();

                // posts = db.Posts
                //     .OrderBy(p=>p.Id)
                //     .ToList();

                // foreach(var p in posts) {
                //     Console.WriteLine($"{p.Id}: {p.Caption}");
                // }
                // Console.WriteLine("Deleting");
                // var postToDelete = db.Posts
                //     .OrderBy(p=>p.Id)
                //     .Last();
                // db.Remove(postToDelete);
                // db.SaveChanges();

                // posts = db.Posts
                //     .OrderBy(p=>p.Id)
                //     .ToList();

                // foreach(var p in posts) {
                //     Console.WriteLine($"{p.Id}: {p.Caption}");
                // }

                // var p2 = from p in db.Posts
                //             where p.Id > 6 
                //             select p.ImageURL;
            }
        }
    }
}
