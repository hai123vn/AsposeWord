using API.Dtos;
using Aspose.Words;
using Aspose.Words.Reporting;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWebHostEnvironment _environment;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWebHostEnvironment environment)
    {
        _logger = logger;
        _environment = environment;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("Test")]
    public async Task<IActionResult> Test()
    {
        // The path to the documents directory.
        // string dataDir = Path.Combine(_environment.ContentRootPath, "upload\\helloword.doc");

        // Load the template document.
        Document doc = new Document();

        // Create an instance of sender class to set it's properties.
        Sender sender = new Sender { Name = "LINQ Reporting Engine", Message = "Hello World" };

        // Create a Reporting Engine.
        ReportingEngine engine = new ReportingEngine();

        // Execute the build report.
        engine.BuildReport(doc, sender, "sender");

        string outputDir = "output"; // Thay thế giá trị này bằng đường dẫn thư mục chứa tài liệu kết quả
        string outputFilePath = Path.Combine(outputDir);

        // Save the finished document to disk.
        doc.Save(outputFilePath);
        return Ok(new { FilePath = outputFilePath });
    }


}
