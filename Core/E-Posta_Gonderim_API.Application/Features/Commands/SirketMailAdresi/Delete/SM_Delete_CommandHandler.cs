using E_Posta_Gonderim_API.Application.IRepositories.ISirketMailAdresiRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Application.Features.Commands.SirketMailAdresi.Delete
{
    public class SM_Delete_CommandHandler : IRequestHandler<SM_Delete_CommandRequest, SM_Delete_CommandResponse>
    {
        readonly ISMA_WriteRepository _repository;
        public SM_Delete_CommandHandler(ISMA_WriteRepository repository)
        {
            _repository= repository;
        }
        public async Task<SM_Delete_CommandResponse> Handle(SM_Delete_CommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.RemoveAsync(request.Id);
            await _repository.SaveAsync();
            return new();
        }
    }
}
