using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Temp.Models;

[Table("Artist")]
public class Artist
{
    [Key]
    public int ArtistId { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; } = null!;

    [MaxLength(100)]
    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public virtual ICollection<Artwork> Artworks { get; set; } = new List<Artwork>();
}