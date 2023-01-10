# Web API for Assessment
API in folder *CharterAssessment* 

Transaction data stored in **Orders.Infrastructure.Data.TransactionData.txt**
## 1.AllRewards
Input:custormerId   
return one decimal , which is the sum of all customer rewards in the last 90 days
## 2.RewardsInLastThreeMonth
Input:customerId  
return string , showing customer rewards per Month
## 3.OrderHistory
Input:customerId  
return string , showing all transactions in the last 90 days

### customerId range: [1, 6]
### the number of transactions: 30
