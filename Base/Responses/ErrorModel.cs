using System.Text.Json.Serialization;

namespace ContactManager.Base.Responses;

public class ErrorModel
{
    [JsonPropertyName("statusCode")]
    public int? StatusCode { get; set; }

    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}
