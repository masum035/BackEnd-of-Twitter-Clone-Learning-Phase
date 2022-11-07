using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TweeterBackend.ActionsFilter
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
            Console.WriteLine($"Before On Async Action Executing : {_name}");
            await next();
            Console.WriteLine($"After On Async Action Executed : {_name}");
        }
    }
}