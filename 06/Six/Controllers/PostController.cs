using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Six.Core.Domain;
using Six.Core.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace Six.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly IRepository<Post> _postRepository;
        private readonly InstaContext _context;

        public PostController(ILogger<PostController> logger,
                                IRepository<Post> postRepository,
                                InstaContext context) : base()
        {
            _logger = logger;
            _postRepository = postRepository;
            _context = context;
        }

        [HttpPost]
        public ActionResult CreatePost(string imageUrl, string caption)
        {
            var post = new Post(imageUrl);
            post.Caption = caption;
            _postRepository.Add(post);
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetPosts()
        {
            var posts = _postRepository.Get();
            return Ok(posts);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Post> GetPost(int id) {

            var request = new Core.Feature.Post.Get.Request();
            request.Id = id;
            var handler = new Core.Feature.Post.Get.Handler(_context);
            return handler.Handle(request);

        }
    }
}