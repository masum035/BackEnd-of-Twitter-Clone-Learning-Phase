using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TweeterBackend.Filters
{
    public class AttributeAsyncActionFilter:Attribute,IAsyncActionFilter
    {
        private readonly string _name;

        public AttributeAsyncActionFilter(string name)
        {
            _name = name;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine($"Action Filter - Before Async : {_name}");
            await next();
            Console.WriteLine($"Action Filter - After Async : {_name}");
        }
    }
}