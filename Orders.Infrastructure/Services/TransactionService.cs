using Orders.Core.Repo;
using Orders.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Services
{
    public class TransactionService: ITransactionServices
    {
        private readonly ITransactionRepo _transactionRepo;
        public TransactionService(ITransactionRepo transactionRepo)
        {
            _transactionRepo = transactionRepo;
        }


        public string? RewardPerMonth(int customerId)
        {
            var allCustomerTransactions = _transactionRepo.FetchAllTransactions();
            var customerOrderHistory = allCustomerTransactions.Where(t => t.customerId == customerId);
            if (customerOrderHistory == null)
            {
                return null;
            }
            string[] rewardsOfLastThreeMonth = new string[3];
            for (int i = 0; i < 3; i++)
            {
                decimal rewardsOfMonth = 0;
                var customerOrderOfMonth = customerOrderHistory.Where(t => t.OrderDate.Month == DateTime.Now.AddMonths(-i).Month);
                foreach (var order in customerOrderOfMonth)
                {
                    rewardsOfMonth += CountReward(order.OrderTotal);
                }
                DateTime timeOfMonth = DateTime.Now.AddMonths(-i);
                rewardsOfLastThreeMonth[i] = string.Format("  {0}  rewards:  {1}", timeOfMonth.ToString("yyyy,MM"), rewardsOfMonth.ToString());
            }
            return string.Join("\n",rewardsOfLastThreeMonth);
        }

        public decimal? RewardSum(int customerId)
        {
            var allCustomerTransactions = _transactionRepo.FetchAllTransactions();
            var customerOrderHistory = allCustomerTransactions.Where(t => t.customerId == customerId);
            if (customerOrderHistory == null)
            {
                return null;
            }
            decimal rewards = 0;
            foreach (var order in customerOrderHistory)
            {
                rewards += CountReward(order.OrderTotal);
            }

            return rewards;
        }
        public string? CustomerOrderHistory(int customerId)
        {
            var allCustomerTransactions = _transactionRepo.FetchAllTransactions();
            var customerOrderHistory = allCustomerTransactions.Where(t => t.customerId == customerId);
            if (customerOrderHistory == null)
            {
                return null;
            }
            List<string> customerOrders = new List<string>();
            foreach (var order in customerOrderHistory)
            {
                var rewards = CountReward(order.OrderTotal);
                string line = string.Format("{0}  orderAmount: {1}   Rewards: {2}", order.OrderDate.ToString("d"), order.OrderTotal.ToString(), rewards.ToString());
                customerOrders.Add(line);
            }
            return string.Join("\n",customerOrders);
        }

        public decimal CountReward(decimal orderTotal)
        {
            decimal reward = 0;
            if (orderTotal > 100)
            {
                reward += (orderTotal - 100) * 2 + 50;
            }
            else if (orderTotal > 50)
            {
                reward += orderTotal - 50;
            }
            return reward;
        }
    }
}
