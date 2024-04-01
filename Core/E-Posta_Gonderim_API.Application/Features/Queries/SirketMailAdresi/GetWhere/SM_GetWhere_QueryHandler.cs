using E_Posta_Gonderim_API.Application.Features.Queries.KullaniciMailAdresi.GetWhere;
using E_Posta_Gonderim_API.Application.IRepositories.ISirketMailAdresiRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Application.Features.Queries.SirketMailAdresi.GetWhere
{
    public class SM_GetWhere_QueryHandler : IRequestHandler<SM_GetWhere_QueryRequest, SM_GetWhere_QueryResponse>
    {
        readonly ISMA_ReadRepository _repository;
        public SM_GetWhere_QueryHandler(ISMA_ReadRepository repository)
        {
            _repository = repository;
        }
        public async Task<SM_GetWhere_QueryResponse> Handle(SM_GetWhere_QueryRequest request, CancellationToken cancellationToken)
        {
            var datas = _repository.GetAll();

            if (request.displayName != null)
                datas = datas.Where(p => p.DisplayName == request.displayName);
            if (request.mailAdresi != null)
                datas = datas.Where(p => p.MailAdresi == request.mailAdresi);
            if (request.sifre != null)
                datas = datas.Where(p => p.Sifre == request.sifre);
            if (request.portNumarasi != null)
                datas = datas.Where(p => p.PortNumarasi == request.portNumarasi);
            if (request.host != null)
                datas = datas.Where(p => p.Host == request.host);
     

            if (request.Descending)
            {
                datas = datas.OrderByDescending(p => p.Id);
            }

            var response = new SM_GetWhere_QueryResponse
            {
                 SirketMailAdresleri= datas
            };
            return await Task.FromResult(response);
        }
    }
}
