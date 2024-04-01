using E_Posta_Gonderim_API.Application.Features.Commands.YollananMail.Create;
using E_Posta_Gonderim_API.Application.Features.Commands.YollananMail.Delete;
using E_Posta_Gonderim_API.Application.Features.Queries.YollananMail.GetAll;
using E_Posta_Gonderim_API.Application.Features.Queries.YollananMail.GetWhere;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Posta_Gonderim_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YollananMailController : Controller
    {
        readonly IMediator _mediator;
        public YollananMailController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] YM_GetAll_QueryRequest request)
        {
            YM_GetAll_QueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("GetWhere")]
        public async Task<IActionResult> GetWhere([FromQuery] YM_GetWhere_QueryRequest request)
        {
            YM_GetWhere_QueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(YM_Create_CommandsRequest request)
        {
            YM_Create_CommandsResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] YM_Delete_CommandsRequest request)
        {
            YM_Delete_CommandsResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
