using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using Travel.Core.BusinessModels;
using Travel.IService;

namespace Travel.API.Filters
{
    public class Authorize : Attribute, IAuthorizationFilter
    {
        private readonly string[] _allowedRoles;
        private readonly string[] _accessPolicy;

        //public Authorize(string[] allowedRoles, string[] accessPolicy)
        //{
        //    _allowedRoles = allowedRoles ?? throw new ArgumentNullException(nameof(allowedRoles));
        //    _accessPolicy = accessPolicy ?? throw new ArgumentNullException(nameof(accessPolicy));
        //}

        public Authorize(params string[] allowedRoles)
        {
            _allowedRoles = allowedRoles ?? throw new ArgumentNullException(nameof(allowedRoles));
        }

        //public Authorize(params string[] accessPolicy)
        //{
        //    _accessPolicy = _accessPolicy ?? throw new ArgumentNullException(nameof(_accessPolicy));
        //}

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenService = (ITokenService)context.HttpContext.RequestServices.GetService(typeof(ITokenService));

            var result = true;
            string token = string.Empty;
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
                result = false;
            else
            {
                token = context.HttpContext.Request.Headers.First(x => x.Key == "Authorization").Value;
                if (token == null)
                    result = false;
            }
            
            if (result)
            {
                var tokenModel = tokenService.ValidateToken(new TokenModel { Token = token.Split(" ")[1] });
                if (!tokenModel.IsTokenValid)
                {
                    result = false;
                }
                else if(!(_allowedRoles.Any(x => x.ToLower() == tokenModel.Role.ToLower())))
                {
                    result = false;
                }
                else
                {
                    var refreshedToken = tokenService.RefreshJSONWebToken(tokenModel);
                    context.HttpContext.Response.Headers.Add("Authorization", refreshedToken);
                }
            }

            if (!result)
            {
                context.ModelState.AddModelError("UnAuthorized", "You are not authorized");
                context.Result = new UnauthorizedObjectResult(context.ModelState);
            }
        }
    }
}
