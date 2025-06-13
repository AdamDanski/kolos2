using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Temp.Models;

[Table("Exhibition_Artwork")]
[PrimaryKey(nameof(ExhibitionId), nameof(ArtworkId))]
public class ExhibitionArtwork
{
    public int ExhibitionId { get; set; }
    public int ArtworkId { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal InsuranceValue { get; set; }

    public virtual Exhibition Exhibition { get; set; } = null!;
    public virtual Artwork Artwork { get; set; } = null!;
}