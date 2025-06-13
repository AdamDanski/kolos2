using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Temp.Models;

[Table("Gallery")]
public class Gallery
{
    [Key]
    public int GalleryId { get; set; }

    [MaxLength(50)]
    public string Name { get; set; } = null!;

    public DateTime EstablishedDate { get; set; }

    public virtual ICollection<Exhibition> Exhibitions { get; set; } = new List<Exhibition>();
}