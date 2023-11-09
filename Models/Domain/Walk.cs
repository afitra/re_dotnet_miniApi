namespace miniApi.Models.Domain;

public class Walk
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
    public double LengthInKm { get; set; }
    public string? WalkImageUrl { get; set; }

    // Navigation Properties
    public Guid DifficultyId { get; set; }
    public Guid RegionId { get; set; }

    public Difficulty difficulty { get; set; }
    public Region Region { get; set; }
}