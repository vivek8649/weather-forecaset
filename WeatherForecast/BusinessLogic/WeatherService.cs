using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecast.DataAccess.BaseDataAdapter;

namespace WeatherForecast.BusinessLogic
{
	public class WeatherService : IWeatherService
	{
		private readonly ICosmosDbService _cosmosDbService;

		public WeatherService(ICosmosDbService cosmosDbService)
		{
			this._cosmosDbService = cosmosDbService;
		}

		public async Task<IEnumerable<string>> GetWeatherSummaries()
		{
			var item = await this._cosmosDbService.GetItemAsync("HelloWorld");
			return item.Weathers;
		}
	}
}

