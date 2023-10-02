using Microsoft.AspNetCore.Mvc;

namespace Lab01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LabController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<LabController> _logger;

        public LabController(ILogger<LabController> logger)
        {
            _logger = logger;
        }


        [HttpGet()]
        [Route("Version")]
        public String Version()
        {
            return "V15";
        }

        [HttpGet()]
        [Route("HostId")]
        public String HostId()
        {
            return System.Net.Dns.GetHostName() + "\n";
        }

        [Route("GetEnv")]
        public string GetEnv(string key)
        {
            return key + "=" +
                (Environment.GetEnvironmentVariable(key) ?? "") + "\n";
            
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [Route("AddHistory")]
        public string AddHistory()
        {
            _logger.LogInformation("AddHistory");

            try
            {
                var path = "/var/Lab/logs";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var file = $"{path}/{DateTime.Now.ToString("ddMMyyyy_HH_mm_ss")}.log";

                System.IO.File.WriteAllText(file, "Log de pruebas");

                return "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en AddHistory");
                return "ERROR";
            }
        }
    }
}