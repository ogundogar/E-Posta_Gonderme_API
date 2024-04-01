using MediatR;

namespace E_Posta_Gonderim_API.Application.Features.Commands.YollananMail.Delete
{
    public class YM_Delete_CommandsRequest:IRequest<YM_Delete_CommandsResponse>
    {
        public int Id { get; set; }
    }
}
