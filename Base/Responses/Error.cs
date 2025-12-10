using System.Text.Json.Serialization;

namespace ContactManager.Base.Responses;

public sealed class Error 
{
    private readonly object? _data;

    public int StatusCode { get; }

    public string Code { get; }

    public string Message { get; }

    internal static Error None => new Error(string.Empty, string.Empty, 500);

    internal static Error? Null => null;

    [JsonConstructor]
    public Error(string code, string message, int statusCode)
    {
        Code = code;
        Message = message;
        StatusCode = statusCode;
    }

    public Error(string code, string message, int statusCode, object data)
        : this(code, message, statusCode)
    {
        _data = data;
    }

    public T? GetData<T>() where T : class
    {
        return _data as T;
    }

    public static implicit operator string(Error error)
    {
        return error?.Code ?? string.Empty;
    }
}