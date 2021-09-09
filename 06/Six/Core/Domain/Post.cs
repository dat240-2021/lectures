using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Six.Core.Domain
{
    public class Post
    {
        public Post(string imageURL)
        {
            ImageURL = imageURL;
        }

        public int Id { get; set; }
        public string ImageURL { get; }
        public string Caption { get; set; }
        public int NumberOfLikes { get; set; }

        public int CommentCount { get; private set; }

        private readonly List<Comment> _comments = new();
        public ReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();
        public void AddComment(string text)
        {
            _comments.Add(new Comment { Text = text });
            CommentCount++;
        }
    }
}