namespace Portfolio.Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        public ISkillRepository ISkillRepository { get; }

        Task SaveAsync();
    }
}
