using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TweeterBackend.Filters
{
    public class AttributeAsyncResourceFilter : Attribute, IAsyncResourceFilter
    {
        private readonly string _name;

        public AttributeAsyncResourceFilter(string name)
        {
            _name = name;
        }

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            Console.WriteLine($"Resource Filter - Before Async : {_name}");
            await next();
            Console.WriteLine($"Resource Filter - After Async : {_name}");
        }
    }
}