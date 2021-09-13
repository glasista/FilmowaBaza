using FilmowaBaza.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json;

namespace FilmowaBaza.API.Middleware
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _request;
        private readonly ILogger<ExceptionsMiddleware> _logger;

        public ExceptionsMiddleware(RequestDelegate request, ILogger<ExceptionsMiddleware> logger)
        {
            this._request = request;
            this._logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        { 
            try 
            {
                await _request(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                await HandleException(context, e);
            }
        }

        private static Task HandleException(HttpContext context, Exception exception)
        {
            var errorCode = nameof(HttpStatusCode.InternalServerError);
            var statusCode = HttpStatusCode.InternalServerError;
            var message = exception.Message;

            if(exception is UnauthorizedAccessException)
            {
                errorCode = nameof(HttpStatusCode.Unauthorized);
                statusCode = HttpStatusCode.Unauthorized;
            }
            else if( exception is AppException moviesAppException)
            {
                statusCode = moviesAppException.ErrorCode.StatusCode;
                errorCode = moviesAppException.ErrorCode.Message;
                message = string.IsNullOrEmpty(moviesAppException.Message) ? errorCode : moviesAppException.Message;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            var response = JsonSerializer.Serialize(new { errorCode, message });
            return context.Response.WriteAsync(response);
        }
    }
}
