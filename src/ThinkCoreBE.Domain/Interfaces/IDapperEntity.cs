namespace ThinkCoreBE.Domain.Interfaces
{
    public interface IDapperEntity<T>
    {
        public Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    }
}
