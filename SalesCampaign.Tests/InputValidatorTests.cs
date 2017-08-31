using System;
using Xunit;
namespace SalesCampaign.Tests
{
    public class InputValidatorTests
    {
		private const int CAMPAIGN_DURATION_LIMIT = 5000;
		private const int DAY_NO_ORDER_LIMIT = 100000;
		private const int ORDER_AMOUNT_LIMIT = 1000000;

  		[Theory]
        [InlineData(0)]
        [InlineData(CAMPAIGN_DURATION_LIMIT + 1)]
		public void ValidateCampaignDuration_OutOfRange_ThrowException(int duration)
		{
			var sut = new InputValidator();

            Assert.Throws<Exception>(() => sut.ValidateCampaignDuration(duration));
		}

        [Fact]
        public void ValidateDailyOrderAmounts_NumberOfDailyOrderExcess_ThrowNumberOfOrderExcessException()
        {
            var sut = new InputValidator();
            int[] amounts = new int[DAY_NO_ORDER_LIMIT + 1];

            Exception ex =
			    Assert.Throws<Exception>(() => sut.ValidateDailyOrderAmounts(amounts));

            Assert.Equal("Number of order out of range", ex.Message);
        }

        [Fact]
        public void ValidateDailyOrderAmounts_OrderAmountExcess_ThrowOrderAmountExcessException()
        {
            var sut = new InputValidator();
            int[] amounts = new int[2];
            amounts[0] = 10;
            amounts[1] = ORDER_AMOUNT_LIMIT + 1;

            Exception ex = 
                Assert.Throws<Exception>( () => sut.ValidateDailyOrderAmounts(amounts));

            Assert.Equal("Order amount out of range", ex.Message);
        }
    }
}
