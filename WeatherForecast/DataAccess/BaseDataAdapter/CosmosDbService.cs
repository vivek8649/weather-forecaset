using Microsoft.Azure.Cosmos;
using System.Threading.Tasks;
using WeatherForecast.DataAccess.Documents;

namespace WeatherForecast.DataAccess.BaseDataAdapter
{
	public class CosmosDbService : ICosmosDbService
	{
		private Container _container;

		public CosmosDbService(
			CosmosClient dbClient,
			string databaseName,
			string containerName)
		{
			this._container = dbClient.GetContainer(databaseName, containerName);
		}

		public async Task<TestDocument> GetItemAsync(string id)
		{
			try
			{
				ItemResponse<TestDocument> response = await this._container.ReadItemAsync<TestDocument>(id, new PartitionKey("rasra"));
				return response.Resource;
			}
			catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
			{
				return null;
			}

		}
	}
}
