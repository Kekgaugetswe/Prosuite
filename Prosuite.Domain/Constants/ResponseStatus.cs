using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Domain.Constants
{
    public class ResponseStatus
    {
        public const int Ok = 200;
        public const int NotFound = 404;
        public const int ServerError = 500;
        public const int BadRequest = 400;
    }
}
