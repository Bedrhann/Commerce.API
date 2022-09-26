namespace FinalProject.Application.Wrappers.NewFolder.Paging
{
    public class BasePagingRequest
    {
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 8;
    }
}
