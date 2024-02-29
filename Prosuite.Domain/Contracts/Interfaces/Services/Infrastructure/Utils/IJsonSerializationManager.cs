using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Domain.Contracts.Interfaces.Services.Infrastructure.Utils
{
    public interface IJsonSerializationManager
    {
        string Serialize(object data);

        T Deserialize<T>(string data);

        object Deserialize(string data, Type type);
    }
}
