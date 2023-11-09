using Microsoft.AspNetCore.Mvc;
using miniApi.Data;

namespace miniApi.Controllers;

// localhost:port/api/regions
[Route("api/[controller]")]
[ApiController]
public class RegionsController : ControllerBase
{
    private readonly DatabaseConnection dbContext;

    [ActivatorUtilitiesConstructor]
    public RegionsController(DatabaseConnection dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    // GET
    [HttpGet]
    public IActionResult GetAll()
    {
        if (dbContext == null) return StatusCode(500, "Internal Server Error: dbContext is null");
        var regions = dbContext.Regions.ToList();
        if (regions == null) return NotFound();

        return Ok(regions);
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var regions = dbContext.Regions.Find(id);
        // var regions = dbContext.Regions.FirstOrDefault(x => x.Id == id);
        if (regions == null) return NotFound();

        return Ok(regions);
    }
}