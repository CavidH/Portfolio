namespace Portfolio.Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        public ISkillRepository SkillRepository { get; }

        Task SaveAsync();
    }
}
