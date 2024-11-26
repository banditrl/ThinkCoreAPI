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
    }
}
