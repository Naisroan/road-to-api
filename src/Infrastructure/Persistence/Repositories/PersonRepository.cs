using Domain.Entities.Persons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly ApplicationDbContext _cntx;

    public PersonRepository(ApplicationDbContext context)
    {
        _cntx = context;
    }

    public async Task<Person> AddAsync(Person person) => (await _cntx.Persons.AddAsync(person)).Entity;

    public async Task<Person?> GetAsync(PersonId id) => await _cntx.Persons.SingleOrDefaultAsync(p => p.Id == id);
}