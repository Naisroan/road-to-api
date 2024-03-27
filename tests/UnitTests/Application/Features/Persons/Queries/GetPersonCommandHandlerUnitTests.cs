using Application.Features.Persons.Queries;
using Domain.Entities.Persons;
using FluentAssertions;

namespace Application.UnitTests.Features.Persons.Queris.Get;

public class GetPersonQueryHandlerUnitTests
{
    private readonly Mock<IPersonRepository> _mockRepository;

    private readonly GetPersonQueryHandler _handler;

    public GetPersonQueryHandlerUnitTests()
    {
        _mockRepository = new Mock<IPersonRepository>();
        _handler = new GetPersonQueryHandler(_mockRepository.Object);
    }

    [Fact]
    public async void HandleGetPerson_WhenPersonNotExists_ShouldReturnNull()
    {
        // Arrage
        var _query = new GetPersonQuery(Guid.NewGuid());

        // Act
        var result = await _handler.Handle(_query, default);

        // Assert
        result.Value.Should().BeNull();
    }
}