namespace SalesCampaign.Core
{
    public interface IInputValidator
    {
        void ValidateCampaignDuration(int duration);
        void ValidateDailyOrderAmounts(int[] amounts);
    }
}
