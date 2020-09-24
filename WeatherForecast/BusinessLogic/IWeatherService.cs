using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.BusinessLogic
{
	public interface IWeatherService
	{
		Task<IEnumerable<string>> GetWeatherSummaries();
	}
}
