namespace UnifiedAvatarOSC
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class AvatarDescriptor
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parameters")]
        public Parameter[] Parameters { get; set; }
    }

    public partial class Parameter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("input", NullValueHandling = NullValueHandling.Ignore)]
        public Put Input { get; set; }

        [JsonProperty("output")]
        public Put Output { get; set; }
    }

    public partial class Put
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }
    }

    public enum TypeEnum { Bool, Float, Int };

    internal static class AvatarDescriptorConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Bool":
                    return TypeEnum.Bool;
                case "Float":
                    return TypeEnum.Float;
                case "Int":
                    return TypeEnum.Int;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.Bool:
                    serializer.Serialize(writer, "Bool");
                    return;
                case TypeEnum.Float:
                    serializer.Serialize(writer, "Float");
                    return;
                case TypeEnum.Int:
                    serializer.Serialize(writer, "Int");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}
