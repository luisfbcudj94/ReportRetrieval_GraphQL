namespace FrontEnd_GraphQL.Helpers.Paging
{
    public class PaginatedList<T>
    {
        public List<T>? Data { get; set; }
        public int PageCount => (int)Math.Ceiling((double)TotalItemCount / PageSize);

        private int _pageNumber;
        public int PageNumber
        {
            get => _pageNumber;
            set
            {
                if (value > 0)
                {
                    _pageNumber = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(PageNumber), "Page number must be greater than zero.");
                }
            }
        }

        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
            set
            {
                if (value > 0)
                {
                    _pageSize = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(PageSize), "Page size must be greater than zero.");
                }
            }
        }
        public int TotalItemCount { get; set; }
        public bool HasPrevious => PageNumber > 1;
        public bool HasNext => PageNumber < PageCount;
    }
}
