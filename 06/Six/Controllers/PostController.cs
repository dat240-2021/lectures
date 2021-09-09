using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Six.Core.Domain;
using System.Collections.Generic;

namespace Six.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;

        public PostController(ILogger<PostController> logger) : base()
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("post")]

        public ActionResult CreatePost(string imageUrl, string caption)
        {

            return Ok();
        }

        [HttpGet]
        [Route("post")]
        public ActionResult<IEnumerable<Post>> GetPosts()
        {
            var posts = new List<Post>();
            return Ok(posts);
        }
    }
}