using Microsoft.AspNetCore.Mvc;
using ThinkCoreBE.Application.Interfaces;

namespace ThinkCoreBE.Api.Controllers
{
    public static class CustomerController
    {
        public static void AddCustomerEndpoints(this WebApplication app)
        {
            app.MapGet("/customers/getAll", GetAllCustomers)
                .WithName("GetAllCustomers")
                .WithOpenApi();
            
            app.MapDelete("/customers/deleteById", DeleteCustomerById)
                .WithName("DeleteCustomerById")
                .WithOpenApi();
        }

        private static async Task<IResult> GetAllCustomers(ICustomerService customerService, CancellationToken cancellationToken)
        {
            var customers = await customerService.GetAllCustomersAsync(cancellationToken);
            return Results.Ok(customers);
        }

        private static async Task<IResult> DeleteCustomerById([FromQuery] long id, ICustomerService customerService, CancellationToken cancellationToken)
        {
            var deletedCount = await customerService.DeleteCustomerByIdAsync(id, cancellationToken);
            if (deletedCount > 0) 
                return Results.Ok(new { Message = "Customer deleted successfully." });
            else 
                return Results.NotFound(new { Message = "Customer not found." });
        }
    }
}
