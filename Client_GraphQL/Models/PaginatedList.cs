using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_GraphQL.Models
{
    public  class PaginatedList
    {
        public int Count { get; set; }
        public bool? PayloadComplete { get; set; }
        public Guid? MaxId { get; set; }
        public List<Commissions> Records { get; set; }
    }
}
