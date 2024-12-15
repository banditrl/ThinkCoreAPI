using ThinkCoreBE.Application;

namespace ThinkCoreBE.Api
{
    // An IEndpointFilter that converts a Result<T> object returned from a minimal API endpoint into an HTTP IResult.
    public class ResultEndpointFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(
            EndpointFilterInvocationContext context,
            EndpointFilterDelegate next)
        {
            // Execute the endpoint (or next filter) and capture the result
            var methodResult = await next(context);
            
            // If the endpoint already returns IResult, no extra handling needed
            if (methodResult is IResult directIResult)
                return directIResult;
            
            // If the endpoint result is a Result<T>, map it to IResult
            if (methodResult != null && IsResultOfT(methodResult))
            {
                return ConvertResultToIResult(methodResult);
            }
            
            // If it's neither, return as-is
            return methodResult;
        }
        
        private static bool IsResultOfT(object obj)
        {
            var type = obj.GetType();
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Result<>);
        }
        
        private static IResult ConvertResultToIResult(object resultObj)
        {
            var type = resultObj.GetType();
            
            bool? success = type.GetProperty(nameof(Result<object>.Success))
                                ?.GetValue(resultObj) as bool?;
            if (success == true)
            {
                var content = type.GetProperty(nameof(Result<object>.Content))?.GetValue(resultObj);
                return Results.Ok(content);
            }
            else
            {
                var errorMsg = type.GetProperty(nameof(Result<object>.ErrorMessage))?.GetValue(resultObj) as string;
                return Results.NotFound(new { Error = errorMsg });
            }
        }
    }
}
