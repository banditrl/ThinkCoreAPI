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
        }

        private static async Task<IResult> GetAllCustomers(ICustomerService customerService, CancellationToken cancellationToken)
        {
            var customers = await customerService.GetAllCustomersAsync(cancellationToken);
            return Results.Ok(customers);
        }

    }
}
