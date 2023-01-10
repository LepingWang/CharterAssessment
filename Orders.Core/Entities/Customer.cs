using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public List<Transaction> OrderHistory { get; set; }
    }
}
