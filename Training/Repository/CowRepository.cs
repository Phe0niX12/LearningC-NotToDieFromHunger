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

        public async Task DeleteWithoutDeleteing(Guid id)
            => await _context.DeleteWithoutDeleting<Cow>(id);

        public async Task<IEnumerable<Cow>> GetAll()
            => await _context.AllSqlEntitites<Cow>().Include(c => c.Farmer).ToListAsync();

        public async Task<Cow?> GetById(Guid id) => 
            await _context.GetEntityById<Cow>(id);

        public async Task<Cow> Update(Cow entity)
            => await _context.UpdateEntity(entity);
    }
}
