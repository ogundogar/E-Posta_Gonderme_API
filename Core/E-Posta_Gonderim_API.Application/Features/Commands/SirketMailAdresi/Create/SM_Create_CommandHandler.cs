using E_Posta_Gonderim_API.Application.IRepositories.ISirketMailAdresiRepository;
using E_Posta_Gonderim_API.Application.Repositories;
using E_Posta_Gonderim_API.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Application.Features.Commands.SirketMailAdresi.Create
{
    public class SM_Create_CommandHandler : IRequestHandler<SM_Create_CommandRequest, SM_Create_CommandResponse>
    {
        readonly ISMA_WriteRepository _repository;
        public SM_Create_CommandHandler(ISMA_WriteRepository repository)
        {
            _repository = repository;
        }
        public async Task<SM_Create_CommandResponse> Handle(SM_Create_CommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.SirketMailAdresi sm = new()
            {
                DisplayName = request.DisplayName,
                MailAdresi = request.MailAdresi,
                Sifre = request.Sifre,
                PortNumarasi = request.PortNumarasi,
                Host = request.Host,
                Aciklama = request.Aciklama,
            };
            await _repository.AddAsync(sm);
            await _repository.SaveAsync();
            return new();
        }
    }
}
