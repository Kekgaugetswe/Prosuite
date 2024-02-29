using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Domain.Mappers
{
    public partial class ApiObjectMapping :Profile
    {
        public ApiObjectMapping() 
        {
            MapRequests();
            MapResponses();

        }
    }
}
