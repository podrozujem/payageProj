using HospitalLibrary.Middleware.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HospitalLibrary.Middleware
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
                case NotExistingUserAccountException:
                    errorMessageObject.Message = "User account does not exist.";
                    statusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                case IncorrectEmailFormatException:
                    errorMessageObject.Message = "Incorrect email format.";
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case EmptyFieldExistedException:
                    errorMessageObject.Message = "Some fields are left blank.";
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;

            }
            var errorMessage = JsonConvert.SerializeObject(errorMessageObject);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(errorMessage);
        }
    }
}
