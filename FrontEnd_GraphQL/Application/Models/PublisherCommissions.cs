namespace FrontEnd_GraphQL.Application.Models
{
    public class PublisherCommissions
    {
        public int Count { get; set; }
        public bool? PayloadComplete { get; set; }
        public string? MaxCommissionId { get; set; }
        public List<Commissions> Records { get; set; }

        // Paginated
        public int PageCount => (int)Math.Ceiling((double)Count / PageSize);

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

        public bool HasPrevious => PageNumber > 1;
        public bool HasNext => PageNumber < PageCount;
    }
}
