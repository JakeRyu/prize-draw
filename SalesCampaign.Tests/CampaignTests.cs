using System;
using Xunit;

namespace SalesCampaign.Tests
{
    public class CampaignTests
    {
        [Fact]
        public void AddDailyOrderAmounts_AddToCollection_Added()
        {
            var sut = new Campaign();
            var amounts1 = new int[] { 1, 2 };
            var amounts2 = new int[] { 7, 8, 9 };
            var expected = new int[] { 1, 2, 7, 8, 9 };

            sut.AddDailyOrderAmounts(amounts1);
            sut.AddDailyOrderAmounts(amounts2);

            Assert.Equal(expected, sut.GetAllOrderAmounts());
        }

        [Fact]
        public void RunDailyPrizeDraw_LargestTakesAwaySmallest_IncreaseTotalPrizeMoneyByDifference()
        {
            var sut = new Campaign();
            var amounts = new int[] { 1, 2, 7, 8, 9 };
            var expected = 9 - 1;

            sut.AddDailyOrderAmounts(amounts);
            sut.RunDailyPrizeDraw();

            Assert.Equal(expected, sut.GetTotalPrizeMoney());
        }

        [Fact]
        public void RunDailyPrizeDraw_LargestTakesAwaySmallestWithRemaining_IncreaseTotalPrizeMoneyByDifference()
        {
			var sut = new Campaign();
			var amounts1 = new int[] { 1, 2, 3 };
            var amounts2 = new int[] { 10, 20, 30 };
			var expected = 3 - 1;

			sut.AddDailyOrderAmounts(amounts1);
            sut.RunDailyPrizeDraw();
            Assert.Equal(expected, sut.GetTotalPrizeMoney());

			expected += 30 - 2;

            sut.AddDailyOrderAmounts(amounts2);
            sut.RunDailyPrizeDraw();

			Assert.Equal(expected, sut.GetTotalPrizeMoney());
        }

        [Fact]
        public void RunDailyPrizeDraw_AfterDraw_RemoveOneOfSameKindOfLargestAndSmallestOrders()
        {
			var sut = new Campaign();
            var amounts = new int[] { 2, 2, 7, 8, 9, 10, 10, 10 };
            var expected = new int[] { 2, 7, 8, 9, 10, 10 };

			sut.AddDailyOrderAmounts(amounts);
			sut.RunDailyPrizeDraw();

			Assert.Equal(expected, sut.GetAllOrderAmounts());
        }

        [Fact]
		public void AddDailyOrderAmounts_NumberOfOrderExcess_ThrowInvalidOperationException()
        {
            var sut = new Campaign();
            var orders = new int[1000000];
            var additionalOrder = new int[1];

            sut.AddDailyOrderAmounts(orders);

            Assert.Throws<InvalidOperationException>(() => sut.AddDailyOrderAmounts(additionalOrder));
        }

		
    }
}
