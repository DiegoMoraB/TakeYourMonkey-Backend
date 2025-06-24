namespace testing.Shared.Domain.Repositories;

public interface IBaseRepository<T> 
{
    Task<T?> FindByIdAsync(int id);
    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
    Task<IEnumerable<T>> ListAsync();
}