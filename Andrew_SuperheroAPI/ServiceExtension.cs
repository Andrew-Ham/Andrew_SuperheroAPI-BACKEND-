
using Andrew_SuperheroAPI.Models;
using Andrew_SuperheroAPI.Data;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using AspNetCoreRateLimit;

namespace Andrew_SuperheroAPI
{
    public static class ServiceExtension
    {
        public static void ConfigureHttpCacheHeaders(this IServiceCollection services)
        {
            services.AddResponseCaching();
            services.AddHttpCacheHeaders(
            (expirationOpt) =>
            {
                expirationOpt.MaxAge = 120;
                expirationOpt.CacheLocation = CacheLocation.Private;
            },
                (validationOpt) =>
                {
                    validationOpt.MustRevalidate = true; //once data is changed we must revalidate it again
                }
            );
        }

        public static void ConfigureRateLimiting(this IServiceCollection services)
        {
            var rateLimitRules = new List<RateLimitRule>        //We can have multiple rules
            {
                new RateLimitRule       //Initialise a new rule object that specifies particular properties
                {
                    Endpoint = "*",     //* means every single endpoint
                    Limit = 1,          // This rule means we are limited to only 1 call every 5 seconds at every endpoint!
                    Period = "5s"
                } //,
                //new RateLimitRule       //Can have multiple rules like this. Having 1 is a global rule!
                //{
                //    Endpoint = "*",     
                //    Limit = 100,          
                //    Period = "10m"
                //}
            };
            services.Configure<IpRateLimitOptions>(opt =>
           {
               opt.GeneralRules = rateLimitRules;   //General rule is the rateLimitRule we created above
           });
            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>(); //The services.AddSingleton codes are requried code to support the ASPNetCoreRateLimit library
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }
    }
}