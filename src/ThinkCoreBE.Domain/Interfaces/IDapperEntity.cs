namespace ThinkCoreBE.Domain.Interfaces
{
    public interface IDapperEntity<T>
    {
        public Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        public Task<int> DeleteByIdAsync(long id, string idColumnName, CancellationToken cancellationToken);
    }
}
