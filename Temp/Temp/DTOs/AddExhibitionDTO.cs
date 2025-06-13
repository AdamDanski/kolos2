namespace Temp.DTOs;

public class AddExhibitionDTO
{
    public string Title { get; set; } = null!;
    public string Gallery { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<AddArtworkDTO> Artworks { get; set; } = new List<AddArtworkDTO>();
}

public class AddArtworkDTO
{
    public int ArtworkId { get; set; }
    public decimal InsuranceValue { get; set; }
}