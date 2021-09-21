using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using O9d.Json.Formatting;

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, DefaultConfig.Instance);

[MemoryDiagnoser]
public class JsonBenchmarks
{
    static JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy()
    };

    static string Json = @"
        {
            ""access_token"": ""value"",
            ""expires_in"": 3600,
            ""token_type"": ""Bearer"",
            ""scope"": ""payments""
        }
    ";

    [Benchmark]
    public TokenClass? DeserializeSnakeCase() => JsonSerializer.Deserialize<TokenClass>(Json);
}

public class TokenClass
{
    public string? AccessToken { get; set; }
    public int ExpiresIn { get; set; }
    public string? TokenType { get; set; }
    public string? Scope { get; set; }
}
