using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;

namespace API.Extension
{
    public class GlobalExceptionalHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
         HttpContext httpContext,
         Exception exception,
         CancellationToken cancellationToken)
        {
            _ = new GenericResponse<string>();
            GenericResponse<string>? problemDetails;
            if (exception is BadRequestException)
            {
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                problemDetails = new GenericResponse<string>
                {
                    ResponseCode = "99",
                    ResponseMsg = exception.Message
                };
                await httpContext
                    .Response
                    .WriteAsJsonAsync(problemDetails, cancellationToken);
                return true;
            }

            Log.Error(
                $"An error occurred while processing your request: {exception.Message}");

            problemDetails = new GenericResponse<string>()
            {
                ResponseCode = "55",
                ResponseMsg = "An error occurred, our team is looking into it"
            };

            await httpContext
                .Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}