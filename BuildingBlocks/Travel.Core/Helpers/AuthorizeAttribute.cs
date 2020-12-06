using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Travel.Entities.Entity;

namespace Travel.Core.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];

            if(user == null)
            {
                //not logged in
                context.Result = new JsonResult(new { Message = "UnAuthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
