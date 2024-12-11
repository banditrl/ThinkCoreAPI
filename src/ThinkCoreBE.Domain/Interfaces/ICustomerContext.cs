using ThinkCoreBE.Domain.Entities;

namespace ThinkCoreBE.Domain.Interfaces
{
    public interface ICustomerContext : IDapperEntity<Customer>
    {
        public Task<bool> ShouldAddNewCustomer(string cpf, CancellationToken cancellationToken);
    }
}
