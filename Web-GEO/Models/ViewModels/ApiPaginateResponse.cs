using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Web_GEO.Models.ViewModels
{
    public class ApiPaginateResponse<T>
    {
        public IEnumerable<T> Data { get; set; }
        public PaginateViewModel Paginate { get; set; }
    }
}
