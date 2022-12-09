using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Interfaces;
using Portfolio.Core.Interfaces.UnitOfWork;
using Portfolio.Data.DAL;

namespace Portfolio.Data.Implementations.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;



        private ISkillRepository _skillRepository;


        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ISkillRepository ISkillRepository => _skillRepository ??= new SkillRepository(_dbContext);

        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();
    }
}
