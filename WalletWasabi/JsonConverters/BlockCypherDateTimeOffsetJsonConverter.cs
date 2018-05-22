﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace WalletWasabi.JsonConverters
{
	public class BlockCypherDateTimeOffsetJsonConverter : JsonConverter
	{
		/// <inheritdoc />
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(DateTimeOffset);
		}

		/// <inheritdoc />
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			string time = reader.Value.ToString().Trim();
			return DateTimeOffset.Parse(time, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
		}

		/// <inheritdoc />
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteValue(((DateTimeOffset)value).ToString(CultureInfo.InvariantCulture));
		}
	}
}
