using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Temp.Models;

[Table("Exhibition")]
public class Exhibition
{
    [Key]
    public int ExhibitionId { get; set; }

    [ForeignKey(nameof(Gallery))]
    public int GalleryId { get; set; }

    [MaxLength(100)]
    public string Title { get; set; } = null!;

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public int NumberOfArtworks { get; set; }

    public virtual Gallery Gallery { get; set; } = null!;
    public virtual ICollection<ExhibitionArtwork> ExhibitionArtworks { get; set; } = new List<ExhibitionArtwork>();
}