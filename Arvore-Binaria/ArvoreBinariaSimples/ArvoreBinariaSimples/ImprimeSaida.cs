using System.Text.Json;
using System.Text.Json.Serialization;

public static class ImprimeSaida
{
    private static JsonSerializerOptions options = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
    };

    public static void Imprimir<T>(T? objeto) where T : class
    {
        Console.WriteLine(JsonSerializer.Serialize(objeto, options));
    }
}