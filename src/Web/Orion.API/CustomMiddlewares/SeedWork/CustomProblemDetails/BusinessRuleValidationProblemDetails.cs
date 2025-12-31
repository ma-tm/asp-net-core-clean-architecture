using Orion.Domain.SeedWork;

namespace Orion.API.CustomMiddlewares.SeedWork.CustomProblemDetails
{
    public class BusinessRuleValidationProblemDetails : ProblemDetails
    {
        public List<string> Errors { get; }

        public BusinessRuleValidationProblemDetails(BusinessRuleValidationException exception, string traceId)
        {
            Title = "Business rule validation errors occurred.";
            Status = StatusCodes.Status400BadRequest;
            Type = "https://httpstatuses.com/400";
            Detail = exception.Message;
            Instance = traceId;
            Errors = exception.Errors;
        }
    }
}
