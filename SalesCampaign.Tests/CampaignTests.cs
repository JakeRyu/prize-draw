using System;
using Xunit;

namespace SalesCampaign.Tests
{
    public class CampaignTests
    {
        [Fact]
        public void AddDailyOrderAmounts_AddToCollection_Added()
        {
            var campaign = new Campaign(); //meaning of sut?
            var amounts1 = new[] { 1, 2 }; 
            var amounts2 = new[] { 7, 8, 9 };
            var expected = new[] { 1, 2, 7, 8, 9 };

            campaign.AddDailyOrders(amounts1);
            campaign.AddDailyOrders(amounts2);

            Assert.Equal(expected, campaign.GetAllOrders());
        }

        [Fact]
        public void RunDailyPrizeDraw_LargestTakesAwaySmallest_IncreaseTotalPrizeMoneyByDifference()
        {
            var campaign = new Campaign();
            var amounts = new[] { 1, 2, 7, 8, 9 };
            var expected = 9 - 1;

            campaign.AddDailyOrders(amounts);   // if campaign doesn't exist without daily order, use
                                                // constructor. var campaign = new Campaign(amounts)
            campaign.DrawDailyPrize();

            Assert.Equal(expected, campaign.GetTotalPrizeAmount());
        }

        [Fact]
        public void RunDailyPrizeDraw_LargestTakesAwaySmallestWithRemaining_IncreaseTotalPrizeMoneyByDifference()
        {
			var sut = new Campaign();
			var amounts1 = new int[] { 1, 2, 3 };
            var amounts2 = new int[] { 10, 20, 30 };
			var expected = 3 - 1;

			sut.AddDailyOrders(amounts1);
            sut.DrawDailyPrize();
            Assert.Equal(expected, sut.GetTotalPrizeAmount());

			expected += 30 - 2;

            sut.AddDailyOrders(amounts2);
            sut.DrawDailyPrize();

			Assert.Equal(expected, sut.GetTotalPrizeAmount());
        }

        [Fact]
        public void RunDailyPrizeDraw_AfterDraw_RemoveOneOfSameKindOfLargestAndSmallestOrders()
        {
			var sut = new Campaign();
            var amounts = new int[] { 2, 2, 7, 8, 9, 10, 10, 10 };
            var expected = new int[] { 2, 7, 8, 9, 10, 10 };

			sut.AddDailyOrders(amounts);
			sut.DrawDailyPrize();

			Assert.Equal(expected, sut.GetAllOrders());
        }

        [Fact]
		public void AddDailyOrderAmounts_NumberOfOrderExcess_ThrowInvalidOperationException()
        {
            var sut = new Campaign();
            var orders = new int[1000000];
            var additionalOrder = new int[1];

            sut.AddDailyOrders(orders);

            Assert.Throws<InvalidOperationException>(() => sut.AddDailyOrders(additionalOrder));
        }

		
    }
}
