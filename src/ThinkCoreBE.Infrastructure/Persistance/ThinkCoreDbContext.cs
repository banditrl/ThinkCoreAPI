using System.Data;
using ThinkCoreBE.Domain.Interfaces;
using ThinkCoreBE.Infrastructure.Persistance.CustomQueries;

namespace ThinkCoreBE.Infrastructure.Persistance
{
    public class ThinkCoreDbContext : IThinkCoreDbContext, IDisposable
    {
        private readonly IDbConnection _connection;

        public ThinkCoreDbContext(IDbConnection connection)
        {
            _connection = connection;
        }

        public ICustomerContext Customers => new CustomerContext(_connection);

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
