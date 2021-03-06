﻿using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{
    public class WeatherForecastRequiredPropertyConverter : JsonConverter<WeatherForecast>
    {
        public override WeatherForecast Read(
            ref Utf8JsonReader reader,
            Type type,
            JsonSerializerOptions options)
        {
            // Don't pass in options when recursively calling Deserialize.
            WeatherForecast value = JsonSerializer.Deserialize<WeatherForecast>(ref reader);

            // Check for required fields set by values in JSON
            if (value.Date == default)
            {
                throw new JsonException("Required property not received in the JSON");
            };
            return value;
        }

        public override void Write(
            Utf8JsonWriter writer,
            WeatherForecast value, JsonSerializerOptions options)
        {
            // Don't pass in options when recursively calling Serialize.
            JsonSerializer.Serialize(writer, value);
        }
    }
}
