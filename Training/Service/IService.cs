namespace Training.Service {
    public interface IService<T> {
        Task<T> AddT(T entity);
        Task<T> UpdateT(T entity);
        Task DeleteT(T entity);
        Task<T?> GetTById(Guid id);
        Task<IEnumerable<T?>> GetAllTs();
        Task DeleteWithoutDeleting(Guid id);
    }
}
