using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TweeterBackend.Filters
{
    public class GlobalActionFilter: IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Action Filter - Before Sync : globally");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Action Filter - After Sync : globally");
        }
    }
}