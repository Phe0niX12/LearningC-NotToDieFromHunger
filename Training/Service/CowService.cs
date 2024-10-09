using Training.Model;
using Training.Repository;

namespace Training.Service {
    public class CowService(IRepository<Cow> repository) : IService<Cow> {
        private IRepository<Cow> _repo = repository;
        public async Task<Cow> AddT(Cow entity)
            => await _repo.Add(entity);

        public Task DeleteT(Cow entity) {
            throw new NotImplementedException();
        }

        public async Task<Cow> DeleteWithoutDeleting(Guid id)
            =>await _repo.DeleteWithoutDeleteing(id);

        public async Task<IEnumerable<Cow>> GetAllTs()
            => await _repo.GetAll();

        public async Task<Cow> GetTById(Guid id) 
            => await _repo.GetById(id);

        public async Task<Cow> UpdateT(Cow entity) 
            => await _repo.Update(entity);

    }
}
