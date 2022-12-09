using Portfolio.Core.Entities;
using Portfolio.Core.Interfaces;
using Portfolio.Data.DAL;


namespace Portfolio.Data.Implementations
{
    public class SkillRepository: Repository<Skill>,ISkillRepository
    {
        public SkillRepository(AppDbContext dbContext) : base( dbContext)
        {

        }
    }
}
