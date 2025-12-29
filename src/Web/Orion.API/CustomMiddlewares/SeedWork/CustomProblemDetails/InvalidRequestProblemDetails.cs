using Orion.Application.SeedWork.CustomExceptions;

namespace Orion.API.CustomMiddlewares.SeedWork.CustomProblemDetails
{
    public class InvalidRequestProblemDetails : ProblemDetails
    {
        public List<string> Errors { get; set; }

        public InvalidRequestProblemDetails(InvalidRequestException invalidRequestException, string traceId)
        {
            Title = "Request validation error";
            Status = StatusCodes.Status400BadRequest;
            Type = "https://httpstatuses.com/400";            
            Errors = invalidRequestException.Errors;
            Instance = traceId;
        }
    }
}
