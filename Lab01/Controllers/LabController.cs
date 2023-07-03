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

        [HttpGet(Name = "Version")]
        public Srting Version()
        {
            return "V13" ;
        }

        [Route("AddHistory")]
        public string AddHistory()
        {
            _logger.LogInformation("AddHistory");

            try
            {
                var path = "/var/logs";

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
