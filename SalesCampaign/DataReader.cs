using System;
using SalesCampaign.Core;
using System.Linq;

namespace SalesCampaign
{
    public class DataReader : IDataReader, IDisposable
    {
        public int ReadCampaignDuration(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Input required");

            int duration;
            if (!int.TryParse(text, out duration))
                throw new ArgumentException();

            return duration;
        }

        public int[] ReadOrderAmounts(string text)
        {
			if (string.IsNullOrWhiteSpace(text))
				throw new ArgumentException("Input reqruied");
            
            string[] parsed = text.Split(' ');
            int[] values;
			try
			{
				values = parsed.Select(s => int.Parse(s)).ToArray();
			}
            catch
            {
                throw new ArgumentException();
            }
      

            int numberOfOrder = values[0];
            int numberOfAmountEntry = values.Length - 1;

            if (numberOfOrder != numberOfAmountEntry)
                throw new FormatException("Number of order do not match with number of entries");

            // Copy order amount only
            var orderAmounts = new int[values.Length - 1];
            for (var i = 1; i <= numberOfOrder; i++)
                orderAmounts[i - 1] = values[i];

            return orderAmounts;
        }

		public void Dispose()
		{
			// Clean up resources
		}
    }
}
