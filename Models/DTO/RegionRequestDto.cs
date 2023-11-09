using miniApi.Models.Domain;

namespace miniApi.Models.DTO;

public class RegionRequestDto
{
    public string Code { get; set; }

    public string Name { get; set; }

    public string? RegionImageUrl { get; set; }


    public static Region SetRequestDto(RegionRequestDto data)
    {
        return new Region
        {
            Code = data.Code,
            Name = data.Name,
            RegionImageUrl = data.RegionImageUrl
        };
    }
}