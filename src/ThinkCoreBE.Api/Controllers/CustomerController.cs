using ThinkCoreBE.Application.Interfaces;

namespace ThinkCoreBE.Api.Controllers
{
    public static class CustomerController
    {
        public static void AddCustomerEndpoints(this WebApplication app)
        {
            app.MapGet("/customers/getAll", GetAllCustomers)
                .WithName("GetAllCustomers");
        }

        private static IResult GetAllCustomers(ICustomerService customerService, CancellationToken cancellationToken)
        {
            return Results.Ok(customerService.GetAllCustomersAsync(cancellationToken));
        }
    }
}
