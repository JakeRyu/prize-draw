using System;
using SalesCampaign.Core;
using Autofac;

namespace SalesCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuration for dependency injection
			var builder = new ContainerBuilder();

			builder.RegisterType<DataReader>().As<IDataReader>();
            builder.RegisterType<InputValidator>().As<IInputValidator>();
            builder.RegisterType<Campaign>().As<ICampaign>();
            builder.RegisterType<GetTotalPrizeMoneyCommand>().As<IGetTotalPrizeMoneyCommand>();

			IContainer container = builder.Build();

            Console.WriteLine("Input:");

            try
            {
                using(var scope = container.BeginLifetimeScope())
                {
                    var command = scope.Resolve<IGetTotalPrizeMoneyCommand>();

                    // Main function ------------------------
					var totalMoneyPrize = command.Execute();
                    // --------------------------------------

					Console.WriteLine("Output:");
					Console.WriteLine(totalMoneyPrize);
                } // All instances are automatically disposed on the disposal of scope
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }


}
