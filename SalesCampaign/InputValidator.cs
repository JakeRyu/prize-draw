using System;
using System.Linq;
using SalesCampaign.Core;

namespace SalesCampaign
{
    public class InputValidator : IInputValidator
    {
		private const int CAMPAIGN_DURATION_LIMIT = 5000;
		private const int DAY_NO_ORDER_LIMIT = 100000;
		private const int ORDER_AMOUNT_LIMIT = 1000000;

        public void ValidateCampaignDuration(int duration)
        {
            if(duration <= 0 || duration > CAMPAIGN_DURATION_LIMIT)
                throw new Exception("Invalid campaign duration");
        }

        public void ValidateDailyOrderAmounts(int[] amounts)
        {
            var noOfOrder = amounts.Length;

            if (noOfOrder < 0 || noOfOrder > DAY_NO_ORDER_LIMIT)
                throw new Exception("Number of order out of range");

            if(amounts.Any(a => a < 0 || a > ORDER_AMOUNT_LIMIT))
                throw new Exception("Order amount out of range");
        }
    }
}
