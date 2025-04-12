using ArtExhibitionSystem.Application.Exceptions;
using Microsoft.IdentityModel.SecurityTokenService;
using System.Net;

namespace ArtSystem.Api.Middleware
{
    public class ExceptionMiddleware
    {
        readonly RequestDelegate _requestDelegate;
        public ExceptionMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionsAsync(httpContext, ex);

            }
        }

        private async static Task<Task> HandleExceptionsAsync(HttpContext httpContext, Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            switch (ex)
            {
                case NotFoundException NotFound:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case BadRequestException BadRequest:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            };
            httpContext.Response.StatusCode = (int)statusCode;
            var response = new
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = ex.Message
            };
            return httpContext.Response.WriteAsJsonAsync(response);
        }
    }
}

