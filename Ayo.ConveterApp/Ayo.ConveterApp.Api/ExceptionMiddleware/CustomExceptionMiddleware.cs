using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ayo.ConveterApp.Api.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Ayo.ConveterApp.Api.ExceptionMiddleware
{

    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;

        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex).ConfigureAwait(false);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            List<Error> ErrorList = new List<Error>();
            ErrorList.Add(new Error { 
            
                Message = exception.Message
            });
          
            context.Response.ContentType = "application/json";
            int statusCode = (int)HttpStatusCode.OK;
            JsonSerializer.Serialize(ErrorList);
            var result = JsonSerializer.Serialize(ErrorList);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(result);
        }

    }
}
