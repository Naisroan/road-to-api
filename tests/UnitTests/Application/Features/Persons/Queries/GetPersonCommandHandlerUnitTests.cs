using Application.Features.Persons.Queries;
using FluentAssertions;
using Infrastructure.Persistence;
using MediatR;

namespace Application.UnitTests.Features.Persons.Queris.Get;

public class GetPersonQueryHandlerUnitTests
{
    private readonly ApplicationDbContext _context;

    private readonly GetPersonQueryHandler _handler;

    public GetPersonQueryHandlerUnitTests()
    {
        _context = ApplicationDbContext.MemoryContext(new Mock<IPublisher>().Object);
        _handler = new GetPersonQueryHandler(_context);
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