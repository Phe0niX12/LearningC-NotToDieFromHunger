using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.Model;
namespace Training.Contexts {
    public interface IAppDBContext {
        DbSet<Cow> Cows { get; set; }
        DbSet<Farmer> Farmers { get; set; }
        IQueryable<T> AllSqlEntitites<T>() where T : BaseEntity;
        Task<T> AddEntity<T>(T entity) where T : BaseEntity;
        Task<T> UpdateEntity<T>(T entity) where T : BaseEntity;
        Task<T> DeleteEntity<T>(Guid id) where T : BaseEntity;
        Task<T> GetEntityById<T>(Guid id) where T : BaseEntity;
        Task<T> DeleteWithoutDeleting<T>(Guid entityId) where T : BaseEntity;
    }
    public class AppDBContext(DbContextOptions<AppDBContext> options): DbContext(options),IAppDBContext {
        public DbSet<Cow> Cows { get; set; }
        public DbSet<Farmer> Farmers { get; set; }

        public IQueryable<T> AllSqlEntitites<T>() where T: BaseEntity =>Set<T>(); 

        public async Task<T> AddEntity<T>(T entity) where T : BaseEntity {
            await Set<T>().AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateEntity<T>(T entity) where T : BaseEntity {
            Set<T>().Update(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<T> GetEntityById<T>(Guid id) where T : BaseEntity 
        {
            T? entity = await Set<T>().FindAsync(id);
            return entity == null ? throw new InvalidOperationException("No entity to update") : entity;
        }

        public Task<T> DeleteEntity<T>(Guid id) where T : BaseEntity
        {
            throw new NotImplementedException();
        }

        public async Task<T> DeleteWithoutDeleting<T>(Guid entityId) where T : BaseEntity
        {
            T? entity = await Set<T>().FindAsync(entityId);
            if(null == entity)
            {
                throw new InvalidOperationException("No such enitity to delete");
            }
            entity.isDeleted = true;
            await SaveChangesAsync();
            return entity;
            
        }
    }
}
