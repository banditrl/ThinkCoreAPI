using System.Data;
using ThinkCoreBE.Domain.Interfaces;
using ThinkCoreBE.Infrastructure.Persistance.CustomQueries;

namespace ThinkCoreBE.Infrastructure.Persistance
{
    public class ThinkCoreDbContext : IThinkCoreDbContext
    {
        private readonly IDbConnection _connection;

        public ThinkCoreDbContext(IDbConnection connection)
        {
            _connection = connection;

            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public ICustomerContext Customers => new CustomerContext(_connection);
    }
}
