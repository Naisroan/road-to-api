namespace Domain.Entities.Persons;

public interface IPersonRepository
{
    Task<Person?> GetAsync(PersonId id);

    Task<Person> AddAsync(Person person);
}