using System.Threading.Tasks;
using WeatherForecast.DataAccess.Documents;

namespace WeatherForecast.DataAccess.BaseDataAdapter
{

	public interface ICosmosDbService
	{
		Task<TestDocument> GetItemAsync(string id);
	}
}
