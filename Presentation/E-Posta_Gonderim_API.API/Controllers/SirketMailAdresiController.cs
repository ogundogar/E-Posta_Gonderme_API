using E_Posta_Gonderim_API.Application.Features.Commands.SirketMailAdresi.Create;
using E_Posta_Gonderim_API.Application.Features.Commands.SirketMailAdresi.Delete;
using E_Posta_Gonderim_API.Application.Features.Commands.SirketMailAdresi.Update;
using E_Posta_Gonderim_API.Application.Features.Queries.SirketMailAdresi.GetAll;
using E_Posta_Gonderim_API.Application.Features.Queries.SirketMailAdresi.GetWhere;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Posta_Gonderim_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SirketMailAdresiController : Controller
    {
        readonly IMediator _mediator;
        public SirketMailAdresiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SM_GetAll_QueryRequest request)
        {
            SM_GetAll_QueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("GetWhere")]
        public async Task<IActionResult> GetWhere([FromQuery] SM_GetWhere_QueryRequest request)
        {
            SM_GetWhere_QueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SM_Create_CommandRequest request)
        {
            SM_Create_CommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(SM_Put_CommandRequest request)
        {
            SM_Put_CommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] SM_Delete_CommandRequest request)
        {
            SM_Delete_CommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
