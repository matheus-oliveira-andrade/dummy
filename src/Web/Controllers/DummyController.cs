using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;

[ApiController]
[Route("dummy")]
public class DummyController : ControllerBase
{
    private readonly ILogger<DummyController> _logger;

    public DummyController(ILogger<DummyController> logger)
    {
        _logger = logger;
    }

    [HttpGet, Route("persons")]
    public ActionResult<IEnumerable<Person>> GetPersons()
    {
        _logger.LogInformation("Getting all persons");

        var persons = new List<Person>
        {
            new("Maria", new DateTime(1970, 09, 10)),
            new("Joana", new DateTime(1988, 02, 07))
        };

        return Ok(persons);
    }
}