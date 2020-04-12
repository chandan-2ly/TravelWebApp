using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Travel.Core
{
    public class SwaggerMessageHandler
    {
        private readonly RequestDelegate _next;

        public SwaggerMessageHandler(RequestDelegate next)
        {
            _next = next;
        }

        //public async Task Invoke(HttpContext context)
        //{
        //    if (context.Request.Path.ToString().Equals("/swagger/index.html"))
        //    {
        //        if (context.Request.QueryString.HasValue)
        //        {
        //            if(V)
        //        }
        //    }
        //}
    }
}
