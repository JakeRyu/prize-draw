using System.Collections.Generic;

namespace SalesCampaign.Core
{
    public interface ICampaign
    {
        void AddDailyOrderAmounts(int[] amounts);
        IEnumerable<int> GetAllOrderAmounts();
        void RunDailyPrizeDraw();
        int GetTotalPrizeMoney();
    }
}
