using System.Text.Json;
using System.Text.Json.Serialization;

namespace Utils;
public static class ImprimeSaida
{
    private readonly static JsonSerializerOptions options = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
    };

    static ImprimeSaida()
    {
        options.Converters.Add(new JsonStringEnumConverter());
    }

    public static void Imprimir<T>(T? objeto) where T : class
    {
        Console.WriteLine(JsonSerializer.Serialize(objeto, options));
    }
}