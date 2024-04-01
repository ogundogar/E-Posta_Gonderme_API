using E_Posta_Gonderim_API.Application.IRepositories.IKullaniciMailAdresiRepository;
using E_Posta_Gonderim_API.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Application.Features.Commands.KullaniciMailAdresi.Create
{
    public class KMA_Create_CommandHandler : IRequestHandler<KMA_Create_CommandRequest, KMA_Create_CommandResponse>
    {
        readonly IKMA_WriteRepository _repository;

        public KMA_Create_CommandHandler(IKMA_WriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<KMA_Create_CommandResponse> Handle(KMA_Create_CommandRequest request, CancellationToken cancellationToken)
        {
            
            await _repository.AddAsync(new()
            {
                Ad= request.Ad,
                Soyad= request.Soyad,
                MailAdresi=request.MailAdresi,
                DogumTarihi=request.DogumTarihi,
                Cinsiyet=request.Cinsiyet,
                TelefonNumarasi=request.TelefonNumarasi,
                IsYeri =request.IsYeri,
                Unvan=request.Unvan
            });

            await _repository.SaveAsync();
            return new();
        }
       
    }
}
