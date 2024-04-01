using MediatR;

namespace E_Posta_Gonderim_API.Application.Features.Queries.KullaniciMailAdresi.GetAll
{
    public class KMA_GetAll_QueryRequest : IRequest<KMA_GetAll_QueryResponse>
    {
        public bool Descending { get; set; }
    }
}
