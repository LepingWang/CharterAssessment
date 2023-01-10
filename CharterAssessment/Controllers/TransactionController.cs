using Microsoft.AspNetCore.Mvc;
using Orders.Core.Services;

namespace CharterAssessmentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionServices _services;

        public TransactionController(ITransactionServices services)
        {
            _services = services;
        }
        [HttpGet]
        [Route("AllRewards/{customerId:int}")]
        public ActionResult<decimal> GetAllRewards(int customerId)
        {
            var rewards = _services.RewardSum(customerId);
            return Ok(rewards);
        }
        [HttpGet]
        [Route("RewardsInLastThreeMonth/{customerId:int}")]
        public ActionResult<string> GetRewardsByMonth(int customerId)
        {
            var res = _services.RewardPerMonth(customerId);
            return Ok(res);
        }
        [HttpGet]
        [Route("OrderHistory/{customerId:int}")]
        public ActionResult<string> GetCustomerOrderHistory(int customerId)
        {
            var res = _services.CustomerOrderHistory(customerId);
            return Ok(res);
        }
    }
}
