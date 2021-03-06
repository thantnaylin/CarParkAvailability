using CarParkAvailability.DataMangers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkAvailability.Filters
{
    public class TokenAuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public bool IsReusable => false;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool result = true;
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                result = false;
            } 
            string token = string.Empty;

            if (result)
            {
                JwtManager tokenManager = new JwtManager();
                token = context.HttpContext.Request.Headers.First(x => x.Key == "Authorization").Value;
                try
                {
                    string[] tokenArr = token.Split(" ");
                    var claimPrinciple = tokenManager.VerifyToken(tokenArr[1]);
                }
                catch (Exception ex)
                {
                    context.ModelState.AddModelError("Unauthorized", ex.ToString());
                }
            }

            if (!result)
            {
                context.Result = new UnauthorizedObjectResult(context.ModelState);
            }
        }
    }
}
