using E_Posta_Gonderim_API.Application.IRepositories.IYollananMailRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Posta_Gonderim_API.Application.Features.Queries.YollananMail.GetWhere
{
    public class YM_GetWhere_QueryHandler : IRequestHandler<YM_GetWhere_QueryRequest, YM_GetWhere_QueryResponse>
    {
        readonly IYM_ReadRepository _repository;
        public YM_GetWhere_QueryHandler(IYM_ReadRepository repository)
        {
            _repository = repository;
        }
        public async Task<YM_GetWhere_QueryResponse> Handle(YM_GetWhere_QueryRequest request, CancellationToken cancellationToken)
        {
            var datas = _repository.GetAll().Include(p => p.KullaniciMailAdresleri).Include(p => p.SirketMailAdresleri).Select(p => new
            {
                p.Id,
                SirketMailAdresi = p.SirketMailAdresleri.MailAdresi,
                KullaniciMailAdresi = p.KullaniciMailAdresleri.Select(k => k.KullaniciMailAdresi.MailAdresi),
                p.Baslik,
                p.Mesaj,
                p.CreateDate
            });

            if (request.sirketMailAdresi != null)
                datas = datas.Where(p => p.SirketMailAdresi == request.sirketMailAdresi);
            if (request.baslik != null)
                datas = datas.Where(p => p.Baslik == request.baslik);
            if (request.tarih != null)
                datas = datas.Where(p => p.CreateDate.Day == request.tarih.Value.Day && p.CreateDate.Month == request.tarih.Value.Month && p.CreateDate.Year == request.tarih.Value.Year);


            if (request.Descending)
            {
                datas = datas.OrderByDescending(p => p.Id);
            }

            var response = new YM_GetWhere_QueryResponse
            {
                YollananMailler = datas
            };
            return await Task.FromResult(response);
        }
    }
}
