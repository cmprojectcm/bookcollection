using BookCollection.ApiResponses;
using OpenQA.Selenium;
using System.Net;
using System.Text.Json;

namespace BookCollection.Middleware
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "applciation/json";
            var response = context.Response;
            BaseExceptionResponse apiBaseResponse = new BaseExceptionResponse();

            switch(exception)
            {
                case ApplicationException ex:
                    apiBaseResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    apiBaseResponse.Message = "Application Exception, please retry after sometime.";
                    break;
                case FileNotFoundException ex:
                    apiBaseResponse.StatusCode = (int)HttpStatusCode.NotFound;
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    apiBaseResponse.Message = "The resourse not found";
                    break;
                case Exception ex:
                    apiBaseResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    apiBaseResponse.Message = "Internal Server Error";
                    break;
                default:
                    apiBaseResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    apiBaseResponse.Message = "Internal Server Error";
                    break;

            }
            var exResult = JsonSerializer.Serialize(apiBaseResponse);
            await context.Response.WriteAsync(exResult);
        }
    }
}
