using E_Posta_Gonderim_API.Application.IRepositories.IKullaniciMailAdresiRepository;
using MediatR;

namespace E_Posta_Gonderim_API.Application.Features.Queries.KullaniciMailAdresi.GetAll
{
    public class KMA_GetAll_QueryHandler : IRequestHandler<KMA_GetAll_QueryRequest, KMA_GetAll_QueryResponse>
    {
        readonly IKMA_ReadRepository _repository;
        public KMA_GetAll_QueryHandler(IKMA_ReadRepository repository)
        {
            _repository = repository;
        }
        public async Task<KMA_GetAll_QueryResponse> Handle(KMA_GetAll_QueryRequest request, CancellationToken cancellationToken)
        {
            var datas = _repository.GetAll().Select(p => new
            {
                p.Id,
                p.Ad,
                p.Soyad,
                p.MailAdresi,
                p.DogumTarihi,
                p.Cinsiyet,
                p.TelefonNumarasi,
                p.IsYeri,
                p.Unvan

            });
            if (request.Descending)
            {
                datas = datas.OrderByDescending(p => p.Id);
            }
            var response = new KMA_GetAll_QueryResponse
            {
                KullaniciMailAdresleri = datas
            };
            return await Task.FromResult(response);
        }
    }
}
