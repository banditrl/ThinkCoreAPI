using ThinkCoreBE.Application.Interfaces;
using ThinkCoreBE.Domain.Entities;
using ThinkCoreBE.Domain.Interfaces;

namespace ThinkCoreBE.Application.Services
{
    public sealed class CustomerService : ICustomerService
    {
        private readonly IThinkCoreDbContext _context;

        public CustomerService(IThinkCoreDbContext context) { _context = context; }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Customers.GetAllAsync(cancellationToken);
        }

        public async Task<int> DeleteCustomerByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var affectedRows = await _context.Customers.DeleteByIdAsync(id, cancellationToken);
            return affectedRows;
        }
    }
}
