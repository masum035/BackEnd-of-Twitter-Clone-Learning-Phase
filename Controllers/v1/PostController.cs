using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TweeterBackend.Contracts.v1;
using TweeterBackend.Domain;

namespace TweeterBackend.Controllers.v1
{

    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private List<Post> _posts;

        public PostController()
        {
            _posts = new List<Post>();
            for (int i = 0; i < 5; i++)
            {
                _posts.Add(new Post { Id = Guid.NewGuid().ToString() });
            }
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetResult()
        {
            return Ok(_posts);
        }

    }
}
