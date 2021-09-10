namespace Six.Core.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Six.Core.Domain;
    using System.Collections.Generic;
    using System.Linq;

    public interface IPostRepository
    {
        IList<Post> GetPosts();
        void Add(Post post);
    }

    
    public interface IRepository<T>
    {
        IList<T> Get();
        void Add(T entity);
    }

    public class Repository<T> : IRepository<T> where T:class
    {
        protected readonly InstaContext _context;

        public Repository(InstaContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add<T>(entity);
        }

        public IList<T> Get()
        {
            return new List<T>();
        }
    }

    public class PostRepository : Repository<Post>
    {
        public PostRepository(InstaContext context) : base(context)
        {
        }

        public IList<Post> GetPostsWithComments()
        {
            return _context.Posts.Include(p=>p.Comments).ToList();
        }
    }
}