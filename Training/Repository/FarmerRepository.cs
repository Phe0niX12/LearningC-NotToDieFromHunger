using Microsoft.EntityFrameworkCore;
using Training.Contexts;
using Training.Model;

namespace Training.Repository
{
    public class FarmerRepository(IAppDBContext appDBContext) : IRepository<Farmer>
    {
        private IAppDBContext _appDBContext = appDBContext;
        public async Task<Farmer> Add(Fa entity)
            => await _appDBContext.AddEntity(entity);

        public Farmer Delete(Farmer entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteWithoutDeleteing(Guid id)
            => await _appDBContext.DeleteWithoutDeleting<Farmer>(id);

        public async Task<IEnumerable<Farmer>> GetAll()
            =>await _appDBContext.AllSqlEntitites<Farmer>().ToListAsync();

        public async Task<Farmer?> GetById(Guid id)
            => await _appDBContext.GetEntityById<Farmer>(id);

        public async Task<Farmer> Update(Farmer entity)
            => await _appDBContext.UpdateEntity(entity);
    }
}
