namespace Application.Data;

public interface IApplicationDbContext
{
    Task<int> SaveChangesAsync(CancellationToken token = default);

    void ApplyMigrations();
}