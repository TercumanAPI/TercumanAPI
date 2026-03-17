namespace Tercuman.Admin.API.Models;

public class ApiResponse<T>
{
    public bool Success { get; set; }

    public T? Data { get; set; }

    public string Message { get; set; } = string.Empty;

    public object? Errors { get; set; }

    // SUCCESS RESPONSE
    public static ApiResponse<T> Ok(T data, string message = "Operation successful")
    {
        return new ApiResponse<T>
        {
            Success = true,
            Data = data,
            Message = message,
            Errors = null
        };
    }

    // FAIL RESPONSE
    public static ApiResponse<T> Fail(string message, object? errors = null)
    {
        return new ApiResponse<T>
        {
            Success = false,
            Data = default,
            Message = message,
            Errors = errors
        };
    }
}