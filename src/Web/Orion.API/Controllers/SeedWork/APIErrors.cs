using Microsoft.AspNetCore.Mvc;

namespace Orion.API.Controllers.SeedWork
{
    public static class APIErrors
    {
        public static NotFoundObjectResult RecordNotFound
        {
            get
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Record not found.",
                    Status = 404,
                    Type = "https://httpstatuses.com/404",
                    Detail = "The record you are looking for does not exist or has been deleted.",
                    Instance = Guid.NewGuid().ToString()
                };
                return new NotFoundObjectResult(problemDetails);
            }
        }
    }
}
