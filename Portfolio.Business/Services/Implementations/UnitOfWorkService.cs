using Portfolio.Business.Services.Interfaces;
using Portfolio.Core.Interfaces.UnitOfWork;

namespace Portfolio.Business.Services.Implementations
{
    public class UnitOfWorkService : IUnitOfWorkService

    {
        private readonly IUnitOfWork _unitOfWork;



        private ISkillService _skillService;


        public UnitOfWorkService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ISkillService SkillService => _skillService ??= new SkillService(_unitOfWork);
    }
}
