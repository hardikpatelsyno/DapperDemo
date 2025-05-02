using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Models
{
    public class DatatableResponse<T>
    {
        public int Draw { get; set; } // A unique identifier for each request
        public int RecordsTotal { get; set; } // Total number of records (before filtering)
        public int RecordsFiltered { get; set; } // Total number of records after filtering
        public List<T> Data { get; set; } // The actual data to display in the DataTable
    }


}
