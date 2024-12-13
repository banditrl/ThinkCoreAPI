using ThinkCoreBE.Domain.Entities;

namespace ThinkCoreBE.Application.Interfaces
{
    public interface ICustomerService
    {
        public Task<IEnumerable<Customer>> GetAllCustomersAsync(CancellationToken cancellationToken);
        public Task<int> DeleteCustomerByIdAsync(long id, CancellationToken cancellationToken);
    }
}
