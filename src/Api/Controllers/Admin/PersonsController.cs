using Application.Features.Persons.Commands;
using Application.Features.Persons.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RoadToApi.Controllers.Admin;

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

    [HttpGet("/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _sender.Send(new GetPersonQuery(id));

        return result.Match(
            person =>
            {
                if (person is null)
                {
                    return NotFound();
                }

                return Ok(person);
            },
            errors => Problem(errors)
        );
    }
}