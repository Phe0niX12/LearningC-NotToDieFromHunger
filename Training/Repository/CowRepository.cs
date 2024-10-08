using Microsoft.EntityFrameworkCore;
using Training.Contexts;
using Training.Model;

namespace Training.Repository {
    public class CowRepository(IAppDBContext context) : IRepository<Cow> {
        private IAppDBContext _context = context;

        public async Task<Cow> Add(Cow entity)
            => await _context.AddEntity(entity);

        public Task Delete(Cow entity) {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Cow>> GetAll()
            => await _context.AllSqlEntitites<Cow>().ToListAsync();

        public Task<Cow?> GetById(Guid id) {
            throw new NotImplementedException();
        }

        public Task<Cow> Update(Cow entity) {
            throw new NotImplementedException();
        }
    }
}
