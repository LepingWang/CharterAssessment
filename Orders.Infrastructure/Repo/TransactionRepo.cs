using Orders.Core.Entities;
using Orders.Core.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Repo
{
    public class TransactionRepo: ITransactionRepo
    {
        public IEnumerable<Transaction> FetchAllTransactions()
        {
            //  Load Transaction Data
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            int end = basePath.IndexOf("CharterAssessment")+ "CharterAssessment".Length;
            string startupPath = basePath.Substring(0, end);
            string dataPath = "Orders.Infrastructure/Data/TransactionData.txt";
            string filePath = Path.Combine(startupPath, dataPath);
            
            List<Transaction> orderHistory = new List<Transaction>();
            
            if (File.Exists(filePath))
            {
                var rawData = File.ReadLines(filePath);

                foreach (var line in rawData)
                {
                    string[] items = line.ToString().Split(",");
                    
                    orderHistory.Add(new Transaction()
                    {
                        Id = Convert.ToInt32(items[0]),
                        OrderTotal = Convert.ToDecimal(items[1]),
                        customerId = Convert.ToInt32(items[2]),
                        OrderDate = Convert.ToDateTime(items[3]),
                    });
                }
            }
            else
            {
                throw new Exception(String.Format("No Transaction Data!\n   at\n{0} ",filePath));
            }
            return orderHistory;
        }
    }
}
