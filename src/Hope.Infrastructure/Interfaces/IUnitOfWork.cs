namespace Hope.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IMenuRepository MenuRepository { get; }
        IMealRepository MealRepository { get; }
        IOrderRepository OrderRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}
