using Portfolio.Business.Services.Interfaces;
using Portfolio.Core.Entities;
using Portfolio.Core.Interfaces.UnitOfWork;

namespace Portfolio.Business.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SkillService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Skill>> GetAllAsync()=> await _unitOfWork.SkillRepository.GetAllAsync();
       
    }
}
