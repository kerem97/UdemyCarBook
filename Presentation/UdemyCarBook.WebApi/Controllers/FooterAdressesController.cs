using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.FooterAddressQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAdressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAdressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> FooterAdressesList()
        {
            var values = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetFooterAdresses(int id)
        {
            var value = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]

        public async Task<IActionResult> CreateFooterAdresses(CreateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer Adresi başarıyla eklendi");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteFooterAdresses(int id)
        {
            await _mediator.Send(new RemoveFooterAddressCommand(id));
            return Ok("Footer Adresi başarıyla silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateFooterAdresses(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer Adresi başarıyla güncellendi");
        }
    }
}
