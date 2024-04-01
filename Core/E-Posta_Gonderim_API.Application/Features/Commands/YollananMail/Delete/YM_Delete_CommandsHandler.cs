using E_Posta_Gonderim_API.Application.IRepositories.IYollananMailRepository;
using MediatR;

namespace E_Posta_Gonderim_API.Application.Features.Commands.YollananMail.Delete
{
    public class YM_Delete_CommandsHandler : IRequestHandler<YM_Delete_CommandsRequest, YM_Delete_CommandsResponse>
    {
        readonly IYM_WriteRepository _repository;
        public YM_Delete_CommandsHandler(IYM_WriteRepository repository)
        {
            _repository = repository;
        }
        public async Task<YM_Delete_CommandsResponse> Handle(YM_Delete_CommandsRequest request, CancellationToken cancellationToken)
        {
            await _repository.RemoveAsync(request.Id);
            await _repository.SaveAsync();
            return new();
        }
    }
}
