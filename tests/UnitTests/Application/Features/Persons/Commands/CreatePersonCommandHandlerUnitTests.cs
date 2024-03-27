using Application.Features.Persons.Commands;
using Domain.DomainErrors;
using Domain.Primitives;
using FluentAssertions;
using Infrastructure.Persistence;
using MediatR;

namespace Application.UnitTests.Features.Persons.Commands.Create;

public class CreatePersonCommandHandlerUnitTests
{
    private readonly ApplicationDbContext _context;

    private readonly Mock<IUnitOfWork> _mockUnitOfWork;

    private readonly CreatePersonCommandHandler _handler;

    private readonly CreatePersonCommand _defaultCommand;

    public CreatePersonCommandHandlerUnitTests()
    {
        _context = ApplicationDbContext.MemoryContext(new Mock<IPublisher>().Object);
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _handler = new CreatePersonCommandHandler(_context, _mockUnitOfWork.Object);
        _defaultCommand = new CreatePersonCommand(
            FirstName: Faker.Name.First(),
            MiddleName: Faker.Name.Middle(),
            LastName: Faker.Name.Last(),
            MaternalLastName: Faker.Name.Last(),
            Rfc: "XXXX9805061AB",
            Curp: "XXXX980506ABCCD00"
        );
    }

    [Fact]
    public async void HandleCreatePerson_WhenRfcIsNotEmptyAndHasBadFormat_ShouldReturnReturnValidationError()
    {
        // Arrange
        var command = new CreatePersonCommand(
            Rfc: Faker.Lorem.GetFirstWord(),
            FirstName: Faker.Name.First(),
            MiddleName: default,
            LastName: Faker.Name.Last(),
            MaternalLastName: default,
            Curp: default
        );

        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Type.Should().Be(ErrorType.Validation);
        result.FirstError.Code.Should().Be(DomainErrors.Person.RfcBadFormat.Code);
        result.FirstError.Description.Should().Be(DomainErrors.Person.RfcBadFormat.Description);
    }
}