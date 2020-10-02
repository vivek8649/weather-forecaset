using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherForecast.BusinessLogic;

namespace WeatherForecast.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private IWeatherService _weatherService;

		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService service)
		{
			_logger = logger;
			_weatherService = service;
		}

		[HttpGet]
		public async Task<IEnumerable<WeatherForecast>> GetAsync()
		{
			var res = await _weatherService.GetWeatherSummaries();
			// var Summaries = res.ToArray();
			var Summaries = new string[] { "cold", "hot", "humid", "warm", "sunny" };

			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}
