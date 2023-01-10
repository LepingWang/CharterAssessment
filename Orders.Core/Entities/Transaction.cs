using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal OrderTotal { get; set; }
        public int customerId { get; set; }
        public DateTime OrderDate { get; set; }

        public Customer Customer { get; set; }
    }
}
