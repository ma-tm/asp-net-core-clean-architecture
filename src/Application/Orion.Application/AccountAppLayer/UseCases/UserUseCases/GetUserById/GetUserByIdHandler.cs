using MediatR;

namespace Orion.Application.AccountAppLayer.UseCases.UserUseCases.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var user = new GetUserByIdResponse
            {
                Id = request.Id,
                Name = "M.A"
            };
            return user;
        }
    }
}
