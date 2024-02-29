using Newtonsoft.Json;
using Prosuite.Domain.Contracts.Interfaces.Services.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Prosuite.Infrastructure.Utils
{
    public class JsonSerializationManager : IJsonSerializationManager
    {
        public T Deserialize<T>(string data)
        {
            var results =  JsonConvert.DeserializeObject<T>(data);
            return results;
        }

        public object Deserialize(string data, Type type)
        {
            var results = JsonConvert.DeserializeObject(data, type);
            return results;
        }

        public string Serialize(object data)
        {
            var results =  JsonConvert.SerializeObject(data);
            return results;
        }
    }
}
