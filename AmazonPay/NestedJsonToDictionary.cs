﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace AmazonPay
{
    /// <summary>
    /// JsonParser class for recursive parsing of a Dictionary
    /// </summary>
    /// 
    public class NestedJsonToDictionary
    {
        private readonly Dictionary<string, object> dictionary = new Dictionary<string, object>();

        public NestedJsonToDictionary(string json)
        {
            dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(
            json, new JsonParser());
        }
        public Dictionary<string, object> GetDictionary()
        {
            return dictionary;
        }
    }
    public class JsonParser : CustomCreationConverter<IDictionary<string, object>>
    {
        public override IDictionary<string, object> Create(Type objectType)
        {
            return new Dictionary<string, object>();
        }

        public override bool CanConvert(Type objectType)
        {
            // In addition to handling IDictionary<string, object>
            // we want to handle the deserialization of dict value
            // which is of type object
            return objectType == typeof(object) || base.CanConvert(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject
                || reader.TokenType == JsonToken.Null)
                return base.ReadJson(reader, objectType, existingValue, serializer);

            // If the next token is not an object
            // then fall back on standard deserializer (strings, numbers etc.)
            return serializer.Deserialize(reader);
        }
    }
}