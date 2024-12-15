using Microsoft.AspNetCore.Mvc;
using ThinkCoreBE.Application;
using ThinkCoreBE.Application.Interfaces;
using ThinkCoreBE.Domain.Entities;

namespace ThinkCoreBE.Api.Controllers
{
    public static class CustomerController
    {
        public static void AddCustomerEndpoints(this WebApplication app)
        {
            app.MapGet("/customers/getAll", GetAllCustomers)
                .AddEndpointFilter<ResultEndpointFilter>()
                .WithName("GetAllCustomers")
                .WithOpenApi();
            
            app.MapDelete("/customers/deleteById", DeleteCustomerById)
                .AddEndpointFilter<ResultEndpointFilter>()
                .WithName("DeleteCustomerById")
                .WithOpenApi();
        }

        private static async Task<Result<IEnumerable<Customer>>> GetAllCustomers(
            ICustomerService customerService,
            CancellationToken cancellationToken)
        {
            // Return a Result<T> (the filter handles final HTTP mapping)
            return await customerService.GetAllCustomersAsync(cancellationToken);
        }

        private static async Task<Result<string>> DeleteCustomerById(
            [FromQuery] long id,
            ICustomerService customerService,
            CancellationToken cancellationToken)
        {
            // Returns a simple success/fail message
            return await customerService.DeleteCustomerByIdAsync(id, cancellationToken);
        }
    }
}
