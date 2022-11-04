using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TweeterBackend.Contracts.v1;
using TweeterBackend.Domain;
using TweeterBackend.ModelBinding;

namespace TweeterBackend.Controllers.v1
{
    [EnableCors("Version01_CORS_Policy")]
    [Route("api/[controller]")]
    [BindProperties(SupportsGet = true)]
    [Consumes("application/json")]
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


        //[HttpGet("{name:CustomConstraintTest}")]
        //public string Get(string name)
        //{
        //    return $"Hello from Controller {name}";
        //}
        
        [HttpGet("modelBindingPath")]
        public string Get([FromQuery] CustomBinding customBindedInstance)
        {
            return $"id {customBindedInstance.Id} & allrights reserved: {customBindedInstance.AllRight} for cookie value : {customBindedInstance.HelpCookie} with dictionary {customBindedInstance.Locations.Keys}";
        }

        // [HttpGet]
        // public ActionResult<string> Get(string id, bool? isTest)
        // {
        //     if (!isTest.HasValue)
        //     {
        //         ModelState.AddModelError(nameof(isTest),"isTest is required");
        //     }
        //
        //     if (string.IsNullOrEmpty(id))
        //     {
        //         ModelState.AddModelError(nameof(id),"id is required");
        //     }
        //
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }
        //
        //     return $"id {id} & isTest {isTest}";
        // }

        [HttpGet]
        public ActionResult<string> Get([Required] string id, [Required] bool? isTest)
        {
            return $"id {id} & isTest {isTest}";
        }

    }
}