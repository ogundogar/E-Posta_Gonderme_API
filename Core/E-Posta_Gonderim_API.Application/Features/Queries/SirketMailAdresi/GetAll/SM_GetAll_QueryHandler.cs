using E_Posta_Gonderim_API.Application.IRepositories.ISirketMailAdresiRepository;
using MediatR;


namespace E_Posta_Gonderim_API.Application.Features.Queries.SirketMailAdresi.GetAll
{
    public class SM_GetAll_QueryHandler : IRequestHandler<SM_GetAll_QueryRequest, SM_GetAll_QueryResponse>
    {
        readonly ISMA_ReadRepository _repository;
        public SM_GetAll_QueryHandler(ISMA_ReadRepository repository) 
        { 
        _repository= repository;
        }
        public async Task<SM_GetAll_QueryResponse> Handle(SM_GetAll_QueryRequest request, CancellationToken cancellationToken)
        {
            var datas = _repository.GetAll().Select(p => new
            {
                p.Id,
                p.DisplayName,
                p.MailAdresi,
                p.Sifre,
                p.PortNumarasi,
                p.Host,
                p.Aciklama,
            });

            if (request.Descending)
            {
                datas = datas.OrderByDescending(p => p.Id);
            }
            var response = new SM_GetAll_QueryResponse
            {
                SirketMailAdresleri = datas
            };
            return await Task.FromResult(response);

        }
    }
}
