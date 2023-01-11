using Application.Something.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUi.Controllers;

[ApiController]
public class SampleController : ControllerBase
{
    private readonly IMediator _mediator;

    public SampleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("do-something/{id}")]
    public async Task<IActionResult> DoSomething(string id)
    {
        return Ok(await _mediator.Send(new DoSomething.DoSomethingCommand(id)));
    }
}