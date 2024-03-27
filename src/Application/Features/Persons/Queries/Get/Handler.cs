
using Domain.Entities.Persons;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Persons.Queries;

public sealed class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, ErrorOr<Person?>>
{
    private readonly ApplicationDbContext _context;

    public GetPersonQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ErrorOr<Person?>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
    {
        return await _context.Persons.SingleOrDefaultAsync(p => p.Id.Value == request.Id);
    }
}