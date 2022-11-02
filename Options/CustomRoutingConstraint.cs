using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace TweeterBackend.Options
{
    public class CustomRoutingConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out object value))
            {
                if (value is string stringValue)
                {
                    return stringValue.StartsWith("0");
                }
            }

            return false;
        }
    }
}