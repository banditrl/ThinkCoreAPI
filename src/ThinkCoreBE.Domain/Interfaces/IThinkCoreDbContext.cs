namespace ThinkCoreBE.Domain.Interfaces
{
    public interface IThinkCoreDbContext
    {
        public ICustomerContext Customers { get; }
    }
}
