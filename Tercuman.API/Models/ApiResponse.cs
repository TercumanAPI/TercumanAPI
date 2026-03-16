namespace Tercuman.API.Models;

public class ApiResponse
{
    public bool Success { get; set; }
    public object? Data { get; set; }
    public string Message { get; set; } = string.Empty;

    public static ApiResponse Ok(object? data = null, string message = "İşlem başarılı")
        => new() { Success = true, Data = data, Message = message };

    public static ApiResponse Fail(string message, object? data = null)
        => new() { Success = false, Data = data, Message = message };
}
