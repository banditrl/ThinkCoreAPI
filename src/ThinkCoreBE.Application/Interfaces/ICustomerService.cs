using ThinkCoreBE.Domain.Entities;

namespace ThinkCoreBE.Application.Interfaces
{
    public interface ICustomerService
    {
        public Task<Result<IEnumerable<Customer>>> GetAllCustomersAsync(CancellationToken cancellationToken);
        
        public Task<Result<string>> DeleteCustomerByIdAsync(long id, CancellationToken cancellationToken);
    }
}
