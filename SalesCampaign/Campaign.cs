using System;
using System.Collections.Generic;
using SalesCampaign.Core;
using System.Linq;

namespace SalesCampaign
{
    public class Campaign : ICampaign
    {
        private const int TOTAL_NUMBER_OF_ORDERS_LIMIT = 1000000;
        private int _totalPrizeMoney;
        private readonly List<int> _orderAmounts;

        public Campaign()
        {
            _orderAmounts = new List<int>();
        }

        public int GetTotalPrizeMoney()
        {
            return _totalPrizeMoney;
        }

        public void AddDailyOrderAmounts(int[] amounts)
        {
            var estimatedOrderNumber = amounts.Length + _orderAmounts.Count();
            if (estimatedOrderNumber > TOTAL_NUMBER_OF_ORDERS_LIMIT)
                throw new InvalidOperationException("Order number excess error");

            _orderAmounts.AddRange(amounts);
        }

        public void RunDailyPrizeDraw()
        {
            var largest = _orderAmounts.Max();
            var smallest = _orderAmounts.Min();

            _totalPrizeMoney += largest - smallest;

            var largestItem = _orderAmounts.Where(o => o == largest).First();
            _orderAmounts.Remove(largestItem);

            var smallestItem = _orderAmounts.Where(o => o == smallest).First();
            _orderAmounts.Remove(smallest);
        }

        public IEnumerable<int> GetAllOrderAmounts()
        {
            return _orderAmounts;
        }
    }
}
