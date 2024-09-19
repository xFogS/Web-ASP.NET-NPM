using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web_Testing_etc.Models.Cars
{
    public class PaginationViewModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPage => (int)Math.Ceiling(TotalItems / (double)PageSize);
        public int TotalItems { get; set; }

        public bool HasPrevPage { get; set; }
        public bool HasNextPage { get; set; }
    }
}
