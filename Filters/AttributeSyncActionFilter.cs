using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TweeterBackend.Filters
{
    public class AttributeSyncActionFilter : Attribute, IActionFilter
    {
        private readonly string _name;

        public AttributeSyncActionFilter(string name)
        {
            _name = name;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Action Filter - Before Sync : {_name}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"Action Filter - After Sync : {_name}");
        }
    }
}