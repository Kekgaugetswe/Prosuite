using Prosuite.Domain.Contracts.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Domain.Contracts.Interfaces.Services.Domain
{
    public interface IValidatorBase<T> where T : BaseRequest
    {
        List<string> Validate(T data);
    }
}
