namespace SalesCampaign.Core
{
    public interface IDataReader
    {
        int ReadCampaignDuration(string text);
        int[] ReadOrderAmounts(string text);
    }
}
