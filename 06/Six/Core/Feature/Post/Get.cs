using Six.Core.Infrastructure;
using Six.Core.Domain;

namespace Six.Core.Feature.Post
{

    public class Get
    {
        public class Request
        {
            public int Id { get; set; }
        }

        public class Handler
        {
            private readonly InstaContext _context;

            public Handler(InstaContext context)
            {
                _context = context;
            }

            public Domain.Post Handle(Request request)
            {
                return _context.Find<Domain.Post>(request.Id);
            }
        }


    }
}