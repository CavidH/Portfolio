using Portfolio.Core.Interfaces;
using Portfolio.Core.Interfaces.UnitOfWork;
using Portfolio.Data.DAL;

namespace Portfolio.Data.Implementations.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext= dbContext;
        }
        public ISkillRepository ISkillRepository => throw new NotImplementedException();

        public async Task SaveAsync()=>await _dbContext.SaveChangesAsync();
    }
}
