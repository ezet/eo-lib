﻿using System;
using eZet.EveLib.EveMarketDataLib.Model;
using Newtonsoft.Json;

namespace eZet.EveLib.EveMarketDataLib.JsonConverter {
    public class StationRankJsonConverter : Newtonsoft.Json.JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var result = new StationRank();
            serializer.Converters.Add(new RowCollectionJsonConverter<StationRank.StationRankEntry>());
            result.Stations = serializer.Deserialize<RowCollection<StationRank.StationRankEntry>>(reader);
            return result;
        }

        public override bool CanConvert(Type objectType) {
            throw new NotImplementedException();
        }
    }
}