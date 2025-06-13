namespace Temp.DTOs;

public class GalleryExhibitionsDTO
{
    public int GalleryId { get; set; }
    public string Name { get; set; } = null!;
    public DateTime EstablishedDate { get; set; }
    public List<ExhibitionDetailsDTO> Exhibitions { get; set; } = new List<ExhibitionDetailsDTO>();
}

public class ExhibitionDetailsDTO
{
    public string Title { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int NumberOfArtworks { get; set; }
    public List<ArtworkDetailsDTO> Artworks { get; set; } = new List<ArtworkDetailsDTO>();
}

public class ArtworkDetailsDTO
{
    public string Title { get; set; } = null!;
    public int YearCreated { get; set; }
    public decimal InsuranceValue { get; set; }
    public ArtistDTO Artist { get; set; } = null!;
}

public class ArtistDTO
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
}
