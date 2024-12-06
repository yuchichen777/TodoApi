﻿namespace TodoApi.Authentication
{
     public class ApiKeyMiddleware
     {
          private readonly RequestDelegate _next;
          private const string APIKEY = "X-API-KEY";

          public ApiKeyMiddleware(RequestDelegate next)
          {
               _next = next;
          }

          public async Task InvokeAsync(HttpContext context)
          {
               if (!context.Request.Headers.TryGetValue(APIKEY, out var extractedApiKey))
               {
                    context.Response.StatusCode = 401; // Unauthorized
                    await context.Response.WriteAsync("API Key was not provided.");
                    return;
               }

               var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();

               var apiKey = appSettings.GetValue<string>(APIKEY);

               if (!apiKey.Equals(extractedApiKey))
               {
                    context.Response.StatusCode = 401; // Unauthorized
                    await context.Response.WriteAsync("Unauthorized client.");
                    return;
               }

               await _next(context);
          }
     }
}
