using Microsoft.EntityFrameworkCore;
using Training.Contexts;
using Training.Model;

namespace Training.Repository
{
    public class ShopRepository(IAppDBContext appDBContext) : IRepository<Shops>
    {
        private IAppDBContext _appDBContext = appDBContext;
        public async Task<Shops> Add(Shops entity)
            =>await _appDBContext.AddEntity(entity);

        public Task Delete(Shops entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteWithoutDeleteing(Guid id)
            =>await _appDBContext.DeleteWithoutDeleting<Shops>(id);

        public async Task<IEnumerable<Shops>> GetAll()
            =>await _appDBContext.AllSqlEntitites<Shops>().ToListAsync();

        public async Task<Shops?> GetById(Guid id)
            =>await _appDBContext.GetEntityById<Shops>(id); 

        public async Task<Shops> Update(Shops entity)
            =>await _appDBContext.UpdateEntity(entity);
    }
}
