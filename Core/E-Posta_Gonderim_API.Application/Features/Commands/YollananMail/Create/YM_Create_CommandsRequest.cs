using E_Posta_Gonderim_API.Domain.Entities;
using MediatR;

namespace E_Posta_Gonderim_API.Application.Features.Commands.YollananMail.Create
{
    public class YM_Create_CommandsRequest:IRequest<YM_Create_CommandsResponse>
    {
        public string Baslik { get; set; }
        public string Mesaj { get; set; }
        public int[] kullaniciMailAdresi { get; set; }
        public int sirketMailAdresi { get; set; }
    }
}
