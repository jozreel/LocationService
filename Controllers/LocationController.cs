using Microsoft.AspNetCore.Mvc;
using LocationService.Models;
using LocationService.Db;
namespace LocationService.Controllers;


[ApiController]
[Route("[controller]")]
public class LocationController : ControllerBase
{

    private readonly ILogger<LocationController> _logger;

    public LocationController(ILogger<LocationController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetLocation")]
    public ActionResult<Location[]> Get()
    {
        try {
            LocationDb db = new LocationDb();
           
            //could be passed via querystring;
            var res =  db.GetLocationAvailability(10, 12);
            return  res.ToArray();
        } catch (Exception ex) {
            _logger.LogError(ex.Message);
            return BadRequest();
        }
    }
}
