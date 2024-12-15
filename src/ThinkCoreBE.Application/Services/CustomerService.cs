using ThinkCoreBE.Application.Interfaces;
using ThinkCoreBE.Domain.Entities;
using ThinkCoreBE.Domain.Interfaces;

namespace ThinkCoreBE.Application.Services
{
    public sealed class CustomerService : ICustomerService
    {
        private readonly IThinkCoreDbContext _context;

        public CustomerService(IThinkCoreDbContext context) { _context = context; }

        public async Task<Result<IEnumerable<Customer>>> GetAllCustomersAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var customers = await _context.Customers.GetAllAsync(cancellationToken);
                return Result<IEnumerable<Customer>>.Ok(customers);
            }
            catch (Exception ex)
            {
                // Log if needed
                return Result<IEnumerable<Customer>>.Fail($"Error fetching customers: {ex.Message}");
            }
        }

        public async Task<Result<string>> DeleteCustomerByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            try
            {
                var affectedRows = await _context.Customers.DeleteByIdAsync(id, cancellationToken);
                if (affectedRows > 0)
                {
                    return Result<string>.Ok("Customer deleted successfully.");
                }
                else
                {
                    return Result<string>.Fail("Customer not found");
                }
            }
            catch (Exception ex)
            {
                // Log if needed
                return Result<string>.Fail($"Error deleting customer: {ex.Message}");
            }
        }
    }
}
