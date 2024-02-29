using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Domain.Contracts.Interfaces.Services.Infrastructure.Utils
{
    public interface IRestClientManager
    {
        T Get<T>(string url, Dictionary<string, string> headers);
        void Get(string url, Dictionary<string, string> headers);
        void Post(string url, object data, Dictionary<string, string> headers);
        T Post<T>(object data, string url, Dictionary<string, string> headers);
    }
}
