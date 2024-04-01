using E_Posta_Gonderim_API.Application.IRepositories.IKullaniciMailAdresiRepository;
using E_Posta_Gonderim_API.Application.IRepositories.ISirketMailAdresiRepository;
using E_Posta_Gonderim_API.Application.IRepositories.IYollananMailRepository;
using E_Posta_Gonderim_API.Application.Services;
using E_Posta_Gonderim_API.Domain.Entities;
using MediatR;

namespace E_Posta_Gonderim_API.Application.Features.Commands.YollananMail.Create
{
    public class YM_Create_CommandsHandler : IRequestHandler<YM_Create_CommandsRequest, YM_Create_CommandsResponse>
    {
        readonly IYM_WriteRepository _repository;
        readonly IMailService _mailService;
        readonly IKMA_ReadRepository _kmaRepository;
        readonly ISMA_ReadRepository _smaRepository;
        public YM_Create_CommandsHandler(IYM_WriteRepository repository, IMailService mailService, IKMA_ReadRepository kmaRepository, ISMA_ReadRepository smaRepository)
        {
            _repository = repository;
            _mailService = mailService;
            _kmaRepository = kmaRepository;
            _smaRepository = smaRepository;
        }
        public async Task<YM_Create_CommandsResponse> Handle(YM_Create_CommandsRequest request, CancellationToken cancellationToken)
        {

            var sma = await _smaRepository.GetByIdAsync(request.sirketMailAdresi);
            foreach (var item in request.kullaniciMailAdresi)
            {
                var kma = await _kmaRepository.GetByIdAsync(item);
                Domain.Entities.YollananMail ym = new(){
                    Baslik = request.Baslik,
                    Mesaj = request.Mesaj,
                    KullaniciMailAdresleri = new HashSet<KullaniciMailAdresi_YollananMail>(){new(){KullaniciMailAdresiId=kma.Id}}, 
                    SirketMailId = sma.Id
                };
                await _mailService.SendMessageAsync(kma.MailAdresi, kma.Ad, kma.Soyad, sma.DisplayName, sma.MailAdresi, sma.Sifre, sma.PortNumarasi, sma.Host, request.Baslik, request.Mesaj);
                await _repository.AddAsync(ym);
            }
            
            await _repository.SaveAsync();
            return new();
        }
    }
}
