using IntegrationLibrary.Middleware.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace IntegrationLibrary.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        public RequestDelegate requestDelegate;
        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }
        private static Task HandleException(HttpContext context, Exception ex)
        {
            var errorMessageObject = new Error { Message = "Unknown error", Title = "Clinic application" };
            var statusCode = (int)HttpStatusCode.InternalServerError;
            switch (ex)
            {
                //adding cases for custom exceptions and setting their text and status code
                case ForbiddenAccessException:
                    errorMessageObject.Message = "Invalid api-key. Access Forbidden!";
                    statusCode = (int)HttpStatusCode.Forbidden;
                    break;
                case UnableDeletingUserAccountException:
                    errorMessageObject.Message = "Unable to delete user's account!";
                    statusCode = (int)HttpStatusCode.Conflict;
                    break;

            }
            switch (ex.InnerException)
            {
                case ServiceUnavailableException:
                    errorMessageObject.Message = "Blood Bank is not responding, try again later.";
                    statusCode = (int)HttpStatusCode.ServiceUnavailable;
                    break;
            }
            var errorMessage = JsonConvert.SerializeObject(errorMessageObject);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(errorMessage);
        }
    }
}
