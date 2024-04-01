using E_Posta_Gonderim_API.Application.IRepositories.IKullaniciMailAdresiRepository;
using E_Posta_Gonderim_API.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Application.Features.Queries.KullaniciMailAdresi.GetWhere
{
    internal class KMA_GetWhere_QueryHandler : IRequestHandler<KMA_GetWhere_QueryRequest, KMA_GetWhere_QueryResponse>
    {
        readonly IKMA_ReadRepository _repository;
        public KMA_GetWhere_QueryHandler(IKMA_ReadRepository repository)
        {
            _repository= repository;
        }
        public async Task<KMA_GetWhere_QueryResponse> Handle(KMA_GetWhere_QueryRequest request, CancellationToken cancellationToken)
        {

            var datas = _repository.GetAll();

            if (request.ad != null)
                datas = datas.Where(p => p.Ad == request.ad);
            if (request.soyad != null)
                datas = datas.Where(p => p.Soyad == request.soyad);
            if (request.mailAdresi != null)
                datas = datas.Where(p => p.MailAdresi == request.mailAdresi);
            if (request.cinsiyet!=null)
                datas=datas.Where(p => p.Cinsiyet == request.cinsiyet);
            if(request.unvan!=null)
                datas = datas.Where(p => p.Unvan == request.unvan);
            if (request.isYeri != null)
                datas = datas.Where(p => p.IsYeri == request.isYeri);
            if(request.baslangicTarihi!=null)
                datas = datas.Where(p => p.DogumTarihi >= request.baslangicTarihi);
            if (request.bitisTarihi != null)
                datas = datas.Where(p => p.DogumTarihi <= request.bitisTarihi);

            if (request.Descending)
            {
                datas=datas.OrderByDescending(p => p.Id);
            }

            var response = new KMA_GetWhere_QueryResponse
            {
                KullaniciMailAdresleri = datas
            };
            return await Task.FromResult(response);

        
        }
    }
}
