using System.Text.Json;
using System.Text.Json.Serialization;
using MovieDirectorsAPI.Enums;

namespace MovieDirectorsAPI.Converter
{
    public class SexConverter : JsonConverter<Sex>
    {
        public override Sex Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string sexString = reader.GetString().ToLower();
            return sexString switch
            {
                "male" => Sex.Male,
                "female" => Sex.Female,
                _ => Sex.Null
            };
        }

        public override void Write(Utf8JsonWriter writer, Sex value, JsonSerializerOptions options)
        {
            string sexString = value switch
            {
                Sex.Male => "Male",
                Sex.Female => "Female",
                _ => "Null"
            };
            writer.WriteStringValue(sexString);
        }
    }
}
