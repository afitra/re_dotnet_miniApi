using Microsoft.AspNetCore.Mvc;
using miniApi.Data;
using miniApi.Models.DTO;

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

        var result = RegionDto.SetArrayData(regions);
        return Ok(result);
    }

    // GET
    [HttpGet]
    [Route("{id:Guid}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var regions = dbContext.Regions.Find(id);
        // var regions = dbContext.Regions.FirstOrDefault(x => x.Id == id);
        if (regions == null) return NotFound();
        var result = RegionDto.SetSingleData(regions);

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Create(RegionRequestDto request)
    {
        var regionDomainModel = RegionRequestDto.SetRequestDto(request);

        dbContext.Regions.Add(regionDomainModel);
        dbContext.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id },
            RegionDto.SetSingleData(regionDomainModel));
    }


    [HttpPut]
    [Route("{id:Guid}")]
    public IActionResult UpdateById([FromRoute] Guid id, [FromBody] RegionRequestDto request)
    {
        var region = dbContext.Regions.Find(id);
        if (region == null) return NotFound();

        region.Code = request.Code;
        region.Name = request.Name;
        region.RegionImageUrl = request.RegionImageUrl;
        dbContext.SaveChanges();

        var result = RegionDto.SetSingleData(region);
        return Ok(result);
    }
}