using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TweeterBackend.ActionsFilter
{
    public class GlobalActionFilter: IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("OnActionExecuting : globally");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("OnActionExecuted : globally");
        }
    }
}