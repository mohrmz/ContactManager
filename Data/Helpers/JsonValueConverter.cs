using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace ContactManager.Data.Helpers;

public static class JsonValueConverter
{
    public static ValueConverter<T?, string?> Create<T>()
        where T : class
    {
        return new ValueConverter<T?, string?>(
            v => v == null ? null : JsonSerializer.Serialize(v),
            v => v == null ? null : JsonSerializer.Deserialize<T>(v)
        );
    }
}