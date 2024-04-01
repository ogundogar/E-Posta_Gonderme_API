using E_Posta_Gonderim_API.Application.Features.Commands.KullaniciMailAdresi.Create;
using E_Posta_Gonderim_API.Application.IRepositories.IKullaniciMailAdresiRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Posta_Gonderim_API.Application.Features.Commands.KullaniciMailAdresi.Delete
{
    public class KMA_Delete_CommandHandler : IRequestHandler<KMA_Delete_CommandRequest, KMA_Delete_CommandResponse>
    {
        readonly IKMA_WriteRepository _repository;
        public KMA_Delete_CommandHandler(IKMA_WriteRepository repository) {
        _repository=repository;
        }
        public async Task<KMA_Delete_CommandResponse> Handle(KMA_Delete_CommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.RemoveAsync(request.Id);
            await _repository.SaveAsync();
            return new();
        }
    }
}
