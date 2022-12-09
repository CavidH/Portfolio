using Portfolio.Business.Services.Interfaces;
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
    }
}
