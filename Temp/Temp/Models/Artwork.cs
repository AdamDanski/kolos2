using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Temp.Models;

[Table("Artwork")]
public class Artwork
{
    [Key]
    public int ArtworkId { get; set; }

    [ForeignKey(nameof(Artist))]
    public int ArtistId { get; set; }

    [MaxLength(100)]
    public string Title { get; set; } = null!;

    public int YearCreated { get; set; }

    public virtual Artist Artist { get; set; } = null!;
    public virtual ICollection<ExhibitionArtwork> ExhibitionArtworks { get; set; } = new List<ExhibitionArtwork>();
}