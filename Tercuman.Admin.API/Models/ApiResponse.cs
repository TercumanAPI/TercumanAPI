namespace Tercuman.Admin.API.Models;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string Message { get; set; } = "Operation successful";
    public object? Errors { get; set; }

    public static ApiResponse<T> Ok(T data, string message = "Operation successful") => new()
    {
        Success = true,
        Data = data,
        Message = message,
        Errors = null
    };
}
