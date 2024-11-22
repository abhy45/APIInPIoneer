using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace APIInPIoneer
{
    public class PaginatedResponse<T>
    {
        public List<T> item { get; set; } = new List<T>();
        public int TotalRecord { get; set; }
        public int pageNumber { get; set; }
        public int PageSize { get; set; }

        public PaginatedResponse(IEnumerable<T> items ,int TotalRecord , int pageNumber , int PageSize )
        {
                item=items.ToList();
                this.TotalRecord = TotalRecord;
                 this.pageNumber = pageNumber;
                this.PageSize = PageSize;
        }
    }
}
