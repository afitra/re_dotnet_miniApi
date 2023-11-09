using miniApi.Models.Domain;

namespace miniApi.Models.DTO;

public class RegionDto
{
    public Guid Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public string? RegionImageUrl { get; set; }


    public static RegionDto SetSingleData(Region data)
    {
        return new RegionDto
        {
            Id = data.Id,
            Code = data.Code,
            Name = data.Name,
            RegionImageUrl = data.RegionImageUrl
        };
    }

    public static List<RegionDto> SetArrayData(List<Region> data)
    {
        var regionDtos = new List<RegionDto>();

        foreach (var item in data)
            regionDtos.Add(new RegionDto
            {
                Id = item.Id,
                Code = item.Code,
                Name = item.Name,
                RegionImageUrl = item.RegionImageUrl
            });

        return regionDtos;
    }
}