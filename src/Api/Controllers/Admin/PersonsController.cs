using Application.Commands.Persons.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Admin;

[Route("admin/[controller]")]
[ApiController]
public class PersonsController : ApiBaseController
{
    private readonly ISender _sender;

    public PersonsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePersonCommand request)
    {
        var result = await _sender.Send(request);

        return result.Match(
            person => Ok(result.Value),
            errors => Problem(errors)
        );
    }
}