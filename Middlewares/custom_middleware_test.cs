using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace TweeterBackend.Middlewares
{
    public class CustomMiddlewareTest : IMiddleware
    {
        // public CustomMiddlewareTest()
        // {
        //      
        // }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine("Custom Middleware invoked 01");
            await next(context);
            Console.WriteLine("Custom Middleware invoked 02");
        }
    }
}