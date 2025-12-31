using FluentValidation;
using Orion.API.CustomMiddlewares.SeedWork.CustomProblemDetails;
using Orion.Application.SeedWork.CustomExceptions;
using Orion.Domain.SeedWork;
using System.Net;
using System.Text.Json;

namespace Orion.API.CustomMiddlewares
{
    public class ProblemDetails
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public string Type { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
    }

    public class ValidationProblemDetails
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public string Type { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
    }

    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public ErrorHandlerMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(InvalidRequestException invalidRequestException)
            {
                var problemDetails = GetBadRequestProblemDetails(invalidRequestException);
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.BadRequest; // 400
                await response.WriteAsync(JsonSerializer.Serialize(problemDetails));
            }
            catch(BusinessRuleValidationException businessRuleValidationException)
            {
                var problemDetails = GetBusinessRuleValidationProblemDetails(businessRuleValidationException);
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.BadRequest; // 400
                await response.WriteAsync(JsonSerializer.Serialize(problemDetails));
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; // 500
                var problemDetails = GetProblemDetails(ex);
                await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
            }
        }

        private InvalidRequestProblemDetails GetBadRequestProblemDetails(InvalidRequestException exception)
        {
            string traceId = Guid.NewGuid().ToString();            
            var invalidRequestProblemDetails = new InvalidRequestProblemDetails(exception, traceId);
            return invalidRequestProblemDetails;
        }

        private BusinessRuleValidationProblemDetails GetBusinessRuleValidationProblemDetails(BusinessRuleValidationException exception)
        {
            string traceId = Guid.NewGuid().ToString();
            var businessRuleValidationProblemDetails = new BusinessRuleValidationProblemDetails(exception, traceId);
            return businessRuleValidationProblemDetails;
        }

        private ProblemDetails GetProblemDetails(Exception exception)
        {
            string traceId = Guid.NewGuid().ToString();
            if (_env != null && _env.IsDevelopment())
            {
                return new ProblemDetails
                {
                    Title = exception.Message,
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "https://httpstatuses.com/500",
                    Detail = exception.StackTrace,
                    Instance = traceId
                };
            }
            else
            {
                return new ProblemDetails
                {
                    Title = "Something went wrong. Please try again after some time",
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "https://httpstatuses.com/500",
                    Detail = $"We apologize for inconvenience. Please let us know about error at support@gmail.com. Include traceId: {traceId} in email.",
                    Instance = traceId
                };
            }
        }
    }
}