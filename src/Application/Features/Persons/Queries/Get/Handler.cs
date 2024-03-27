
using Domain.Entities.Persons;

namespace Application.Features.Persons.Queries;

public sealed class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, ErrorOr<Person?>>
{
    private readonly IPersonRepository _repository;

    public GetPersonQueryHandler(IPersonRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<Person?>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAsync(new PersonId(request.Id));
    }
}