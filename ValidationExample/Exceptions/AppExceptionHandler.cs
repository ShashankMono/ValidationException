using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.DataAnnotations;
using ValidationExample.Models;

namespace ValidationExample.Exceptions
{
    public class AppExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, 
            Exception exception, CancellationToken cancellationToken)
        {
            var response = new ErrorResponse();
            if (exception is StudentNotFoundException)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.Title = "Wrong input";
                response.ExceptionMessage = exception.Message;
            }else if(exception is ValidationException validation)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Title = "Invalid input";
                response.ExceptionMessage = exception.Message;
            }
            else
            {
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Title = "Somthing went wrong";
                response.ExceptionMessage = exception.Message;
            }
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }
}
