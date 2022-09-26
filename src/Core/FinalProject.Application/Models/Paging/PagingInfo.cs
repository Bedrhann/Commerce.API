namespace FinalProject.Application.Models.Paging
{
    public class PagingInfo
    {
        public int TotalData { get; set; }
        public int TotalPage { get; set; }
        public int PageLimit { get; set; }
        public int PageNum { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
    }
}
