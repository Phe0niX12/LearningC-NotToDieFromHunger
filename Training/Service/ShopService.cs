using Training.Model;
using Training.Repository;

namespace Training.Service
{
    public class ShopService(IRepository<Shops> repository) : IService<Shops>
    {
        public async Task<Shops> AddT(Shops entity)
            =>await repository.Add(entity);

        public Task DeleteT(Shops entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteWithoutDeleting(Guid id)
            =>await repository.DeleteWithoutDeleteing(id);

        public async Task<IEnumerable<Shops?>> GetAllTs()
            =>await repository.GetAll();

        public async Task<Shops?> GetTById(Guid id)
            =>await repository.GetById(id);

        public async Task<Shops> UpdateT(Shops entity)
            =>await repository.Update(entity);
    }
}
