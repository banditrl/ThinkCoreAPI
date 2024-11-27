using System.Data;
using Dapper;
using ThinkCoreBE.Domain.Interfaces;

namespace ThinkCoreBE.Infrastructure.Persistance
{
    public class DapperEntity<T> : IDapperEntity<T> where T : class
    {
        private readonly IDbConnection _connection;

        public DapperEntity(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var sql = $"SELECT * FROM \"{typeof(T).Name}s\"";
            return await _connection.QueryAsync<T>(sql, cancellationToken);
        }
    }
}
