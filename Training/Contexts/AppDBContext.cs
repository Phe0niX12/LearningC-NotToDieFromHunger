using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.Model;
namespace Training.Contexts {
    public interface IAppDBContext {
        DbSet<Cow> Cows { get; set; }
        IQueryable<T> AllSqlEntitites<T>() where T : BaseEntity;
        Task<T> AddEntity<T>(T entity) where T : BaseEntity;
        Task<T> UpdateEntity<T>(T entity) where T : BaseEntity;
    }
    public class AppDBContext(DbContextOptions<AppDBContext> options): DbContext(options),IAppDBContext {
        public DbSet<Cow> Cows { get; set; }
        
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
    }
}
