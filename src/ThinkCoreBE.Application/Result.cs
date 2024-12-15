namespace ThinkCoreBE.Application
{
    // Generic result wrapper for service-layer operations.
    /// <typeparam name="T">Type of data returned by the service.</typeparam>
    public class Result<T> // 
    {
        public bool Success { get; set; }
        
        public T? Content { get; set; }
        
        public string? ErrorMessage { get; set; }
        
        public static Result<T> Ok(T content) => new() { Success = true, Content = content };
        
        public static Result<T> Fail(string errorMessage) => new() { Success = false, ErrorMessage = errorMessage };
    }
}
