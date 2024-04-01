using E_Posta_Gonderim_API.Application.IRepositories.ISirketMailAdresiRepository;
using E_Posta_Gonderim_API.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Application.Features.Commands.SirketMailAdresi.Update
{
    public class SM_Put_CommandHandler : IRequestHandler<SM_Put_CommandRequest, SM_Put_CommandResponse>
    {
        readonly ISMA_WriteRepository _repository;
        public SM_Put_CommandHandler(ISMA_WriteRepository repository)
        {
            _repository = repository;
        }
        public async Task<SM_Put_CommandResponse> Handle(SM_Put_CommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.SirketMailAdresi sm = new()
            {
                Id = request.Id,
                MailAdresi = request.MailAdresi,
                Sifre = request.Sifre,
                PortNumarasi = request.PortNumarasi,
                Host = request.Host,
                Aciklama = request.Aciklama,
            };
            _repository.Update(sm);
            await _repository.SaveAsync();
            return new();
        }
    }
}
