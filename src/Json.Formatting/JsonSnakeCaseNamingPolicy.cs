using System.Text.Json;
using O9d.Json.Formatting;

namespace O9d.Json.Formatting
{
    public sealed class JsonSnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => name.ToSnakeCase();
    }
}
