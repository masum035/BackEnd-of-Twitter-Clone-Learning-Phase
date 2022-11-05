using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TweeterBackend.Controllers.v1
{
    [EnableCors("Version01_CORS_Policy")]
    [Route("[controller]")]
    [BindProperties(SupportsGet = true)]
    [Consumes("application/json")]
    [ApiController]
    public class ReturnTypeChekingController: ControllerBase
    {
        // Return Type
        [HttpGet]
        // for swagger endpoint documentation
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get(string x)
        {
            if (string.IsNullOrEmpty(x))
            {
                return BadRequest("null parameter x found");
            }

            throw new Exception("fault happens"); // for checking error
            return Ok($"{x}");
        }
    }
}