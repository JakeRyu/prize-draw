using System.Collections.Generic;

namespace SalesCampaign.Core
{
    public interface ICampaign
    {
        void AddDailyOrders(IEnumerable<int> amounts); //favour interface
        IEnumerable<int> GetAllOrders();
        void DrawDailyPrize();
        decimal GetTotalPrizeAmount();
    }
}
