using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Hosting;

namespace TweeterBackend.Filters
{
    public class AttributeAsyncExceptionFilter : Attribute,IAsyncExceptionFilter
    {
        private readonly string _name;

        public AttributeAsyncExceptionFilter(string name)
        {
            _name = name;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            var exception = context.Exception;
            Console.WriteLine($"Exception Filter - Async : {_name} with {exception.Message}");
        }
    }
}