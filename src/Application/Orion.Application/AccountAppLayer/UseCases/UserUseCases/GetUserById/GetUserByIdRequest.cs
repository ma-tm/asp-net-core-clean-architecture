using MediatR;

namespace Orion.Application.AccountAppLayer.UseCases.UserUseCases.GetUserById
{
    public class GetUserByIdRequest : IRequest<GetUserByIdResponse>
    {
        public int Id { get; set; }
    }
}
