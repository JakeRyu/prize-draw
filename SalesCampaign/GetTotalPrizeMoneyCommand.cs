using System;
using SalesCampaign.Core;

namespace SalesCampaign
{
	class GetTotalPrizeMoneyCommand : IGetTotalPrizeMoneyCommand
	{
		private readonly IDataReader _dataReader;
		private readonly IInputValidator _validator;
		private readonly ICampaign _campaign;

		public GetTotalPrizeMoneyCommand(IDataReader dataReader,
										IInputValidator validator,
										ICampaign campaign)
		{
			_dataReader = dataReader;
			_validator = validator;
			_campaign = campaign;
		}

		public decimal Execute()
		{
			var duration = _dataReader.ReadCampaignDuration(Console.ReadLine());

			_validator.ValidateCampaignDuration(duration);

			for (var day = 1; day <= duration; day++)
			{
				int[] amounts = _dataReader.ReadOrderAmounts(Console.ReadLine());

				_validator.ValidateDailyOrderAmounts(amounts);

				_campaign.AddDailyOrders(amounts);

				_campaign.DrawDailyPrize();
			}

			return _campaign.GetTotalPrizeAmount();
		}
	}
}
