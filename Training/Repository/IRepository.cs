
namespace Training.Repository;
public interface IRepository<T> where T: class {
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task Delete(T entity);
    Task<T?> GetById(Guid id);
    Task<IEnumerable<T>> GetAll();
    Task DeleteWithoutDeleteing(Guid id);
}

