namespace TeamworkReporter.TwClient.Api
{
    public class PageInfo
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public PageInfo()
        {
            
        }
        public PageInfo(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}
