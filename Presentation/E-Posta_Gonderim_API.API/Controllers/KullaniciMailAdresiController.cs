using E_Posta_Gonderim_API.Application.Features.Commands.KullaniciMailAdresi.Create;
using E_Posta_Gonderim_API.Application.Features.Commands.KullaniciMailAdresi.Delete;
using E_Posta_Gonderim_API.Application.Features.Commands.KullaniciMailAdresi.Update;
using E_Posta_Gonderim_API.Application.Features.Queries.KullaniciMailAdresi.GetAll;
using E_Posta_Gonderim_API.Application.Features.Queries.KullaniciMailAdresi.GetWhere;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace E_Posta_Gonderim_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciMailAdresiController : Controller
    {
        readonly IMediator _mediator;
        public KullaniciMailAdresiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] KMA_GetAll_QueryRequest request)
        {
            KMA_GetAll_QueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("GetWhere")]
        public async Task<IActionResult> GetWhere([FromQuery] KMA_GetWhere_QueryRequest request)
        {
            KMA_GetWhere_QueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(KMA_Create_CommandRequest request)
        {
            KMA_Create_CommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(KMA_Put_CommandRequest request)
        {
            KMA_Put_CommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] KMA_Delete_CommandRequest request)
        {
            KMA_Delete_CommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
