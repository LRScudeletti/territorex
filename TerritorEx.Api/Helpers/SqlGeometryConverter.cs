using Microsoft.SqlServer.Types;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace TerritorEx.Api.Helpers
{
    public class SqlGeometryConverter : JsonConverter<SqlGeometry>
    {
        public override SqlGeometry Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException($"Unexpected token type. Expected String but got {reader.TokenType}.");
            }

            var geometryString = reader.GetString();
            return SqlGeometry.Parse(geometryString);
        }

        public override void Write(Utf8JsonWriter writer, SqlGeometry value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
