using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.Services
{
    public interface ITransactionServices
    {
        string? RewardPerMonth(int customerId);
        decimal? RewardSum(int customerId);

        string? CustomerOrderHistory(int customerId);
    }
}
