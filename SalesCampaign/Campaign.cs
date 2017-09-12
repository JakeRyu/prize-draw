using System;
using System.Collections.Generic;
using SalesCampaign.Core;
using System.Linq;

namespace SalesCampaign
{
    public class Campaign : ICampaign
    {
        private const int TOTAL_NUMBER_OF_ORDERS_LIMIT = 1000000;
        private decimal _totalPrizeMoney; // int can't handle money. use decimal
        private readonly List<int> _orderAmounts;

        public Campaign()
        {
            _orderAmounts = new List<int>();
        }

        public decimal GetTotalPrizeAmount()
        {
            return _totalPrizeMoney;
        }

        public void AddDailyOrders(IEnumerable<int> amounts) //eventually amounts need to be object, not primitive values. Prefer type always
        {
            var estimatedOrderNumber = amounts.Count() + _orderAmounts.Count;
            if (estimatedOrderNumber > TOTAL_NUMBER_OF_ORDERS_LIMIT)
                throw new InvalidOperationException("Order number excess error");

            _orderAmounts.AddRange(amounts);
        }

        public void DrawDailyPrize()
        {
            var largest = _orderAmounts.Max();
            var smallest = _orderAmounts.Min();

            _totalPrizeMoney += largest - smallest;

            var largestItem = _orderAmounts.First(o => o == largest);
            _orderAmounts.Remove(largestItem);

            var smallestItem = _orderAmounts.First(o => o == smallest);
            _orderAmounts.Remove(smallest);
        }

        public IEnumerable<int> GetAllOrders()
        {
            return _orderAmounts;
        }
    }
}
