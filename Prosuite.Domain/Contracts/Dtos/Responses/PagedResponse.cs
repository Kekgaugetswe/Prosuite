using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Domain.Contracts.Dtos.Responses
{
    public class PagedResponse<TModel> : BaseResponse
    {
        const int MaxPageSize = 50;
        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int CurrentPage { get; set; }
        public int NextPage { get; set; }
        public int PreviousPage { get; set; }

        public string DisplayingText { get; set; }

        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public IList<TModel> Items { get; set; }

        public PagedResponse()
        {
            Items = new List<TModel>();
        }
    }
}
