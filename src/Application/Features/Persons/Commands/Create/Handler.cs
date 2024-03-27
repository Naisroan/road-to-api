using Domain.DomainErrors;
using Domain.Entities.Persons;
using Domain.Primitives;
using Domain.ValueObjects;
using Infrastructure.Persistence;

namespace Application.Features.Persons.Commands;

public sealed class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, ErrorOr<Person>>
{
    private readonly ApplicationDbContext _context;

    private readonly IUnitOfWork _unitOfWork;

    public CreatePersonCommandHandler(ApplicationDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Person>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        Rfc? rfc = Rfc.Create(request.Rfc);
        Curp? curp = Curp.Create(request.Curp);

        if (!string.IsNullOrEmpty(request.Rfc) && rfc is null)
        {
            return DomainErrors.Person.RfcBadFormat;
        }

        if (!string.IsNullOrEmpty(request.Curp) && curp is null)
        {
            return DomainErrors.Person.CurpBadFormat;
        }

        var person = new Person
        (
            firstName: request.FirstName!,
            middleName: request.MiddleName,
            lastName: request.LastName!,
            maternalLastName: request.MaternalLastName,
            rfc: rfc,
            curp: curp,
            active: true
        );

        var response = (await _context.Persons.AddAsync(person)).Entity;
        await _unitOfWork.SaveChangesAsync();

        return response;
    }
}
