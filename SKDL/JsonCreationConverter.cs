using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKDL {

    public class RoundConverter : JsonCreationConverter<Round> {
        protected override Round Create(Type objectType, JObject jObject) {
            if (FieldExists("type", jObject)) {
                var typeName = jObject["type"].ToString();
                switch (typeName) { 
                    case "intro":
                        return new IntroRound();
                    case "image":
                        return new ImageRound(); 
                    case "lyrics":
                        return new LyricsRound();
                    case "words":
                        return new WordRound();
                    default:
                        throw new Exception("Round type could not be found");
                }
            }
            else {
                throw new Exception("Round type could not be found");
            }
        }

        private bool FieldExists(string fieldName, JObject jObject) {
            return jObject[fieldName] != null;
        }
    }

    public abstract class JsonCreationConverter<T> : JsonConverter {
        /// <summary>
        /// Create an instance of objectType, based properties in the JSON object
        /// </summary>
        /// <param name="objectType">type of object expected</param>
        /// <param name="jObject">contents of JSON object that will be deserialized</param>
        /// <returns></returns>
        protected abstract T Create(Type objectType, JObject jObject);

        public override bool CanConvert(Type objectType) {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);

            // Create target object based on JObject
            T target = Create(objectType, jObject);

            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }
}
