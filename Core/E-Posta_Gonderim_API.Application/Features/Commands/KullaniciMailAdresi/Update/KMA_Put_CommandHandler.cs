using E_Posta_Gonderim_API.Application.Features.Commands.KullaniciMailAdresi.Delete;
using E_Posta_Gonderim_API.Application.IRepositories.IKullaniciMailAdresiRepository;
using MediatR;

namespace E_Posta_Gonderim_API.Application.Features.Commands.KullaniciMailAdresi.Update
{
    public class KMA_Put_CommandHandler : IRequestHandler<KMA_Put_CommandRequest, KMA_Put_CommandResponse>
    {
        readonly IKMA_WriteRepository _repository;
        public KMA_Put_CommandHandler(IKMA_WriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<KMA_Put_CommandResponse> Handle(KMA_Put_CommandRequest request, CancellationToken cancellationToken)
        {
            E_Posta_Gonderim_API.Domain.Entities.KullaniciMailAdresi KMA = new()
            {
                Id = request.Id,
                Ad = request.Ad,
                Soyad = request.Soyad,
                MailAdresi = request.MailAdresi,
                DogumTarihi = request.DogumTarihi,
                Cinsiyet = request.Cinsiyet,
                TelefonNumarasi = request.TelefonNumarasi,
                IsYeri = request.IsYeri,
                Unvan = request.Unvan,
            };
            _repository.Update(KMA);
            await _repository.SaveAsync();
            return new();
        }
    }
}
