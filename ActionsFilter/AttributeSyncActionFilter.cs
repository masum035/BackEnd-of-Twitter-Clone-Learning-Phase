using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TweeterBackend.ActionsFilter
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
            Console.WriteLine($"OnActionExecuting : {_name}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"OnActionExecuted : {_name}");
        }
    }
}