using Portfolio.Core.Entities;

namespace Portfolio.Business.Services.Interfaces
{
    public interface ISkillService
    {
        Task<List<Skill>> GetAllAsync();
    }
}
