using Training.Model;
using Training.Repository;

namespace Training.Service
{
    public class FarmerService(IRepository<Farmer> repository) : IService<Farmer>
    {
        IRepository<Farmer> _repository = repository;
        public async Task<Farmer> AddT(Farmer entity)
            =>await _repository.Add(entity);

        public async Task DeleteT(Farmer entity)
            =>await _repository.Delete(entity);

        public async Task DeleteWithoutDeleting(Guid id)
            =>await _repository.DeleteWithoutDeleteing(id);

        public async Task<IEnumerable<Farmer?>> GetAllTs()
            => await _repository.GetAll();

        public async Task<Farmer?> GetTById(Guid id)
            => await _repository.GetById(id);

        public async Task<Farmer> UpdateT(Farmer entity)
            =>await _repository.Update(entity);
    }
}
