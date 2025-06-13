using Temp.DTOs;

public interface IDbService
{
    Task<GalleryExhibitionsDTO> GetGalleryExhibitionsAsync(int galleryId);
    Task AddExhibitionAsync(AddExhibitionDTO dto);
}