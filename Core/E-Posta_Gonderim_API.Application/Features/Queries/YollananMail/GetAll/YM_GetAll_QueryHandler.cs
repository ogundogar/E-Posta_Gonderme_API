using E_Posta_Gonderim_API.Application.Features.Queries.SirketMailAdresi.GetAll;
using E_Posta_Gonderim_API.Application.IRepositories.IYollananMailRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Application.Features.Queries.YollananMail.GetAll
{
    public class YM_GetAll_QueryHandler : IRequestHandler<YM_GetAll_QueryRequest, YM_GetAll_QueryResponse>
    {
        readonly IYM_ReadRepository _repository;
        public YM_GetAll_QueryHandler(IYM_ReadRepository repository)
        {
            _repository = repository;
        }
        public async Task<YM_GetAll_QueryResponse> Handle(YM_GetAll_QueryRequest request, CancellationToken cancellationToken)
        {
            var datas = _repository.GetAll().Include(p=>p.KullaniciMailAdresleri).Include(p=>p.SirketMailAdresleri).Select(p => new
            {
                p.Id,
                SirketMailAdresi = p.SirketMailAdresleri.MailAdresi,
                KullaniciMailAdresi = p.KullaniciMailAdresleri.Select(k=>k.KullaniciMailAdresi.MailAdresi),
                p.Baslik,
                p.Mesaj,
                p.CreateDate
            });
            if (request.Descending)
            {
                datas = datas.OrderByDescending(p => p.Id);
            }
            var response = new YM_GetAll_QueryResponse
            {
                YollananMailler = datas
            };
            return await Task.FromResult(response);
        }
    }
}
