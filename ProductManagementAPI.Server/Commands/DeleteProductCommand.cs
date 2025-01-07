using MediatR;

namespace ProductManagementAPI.Server.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
