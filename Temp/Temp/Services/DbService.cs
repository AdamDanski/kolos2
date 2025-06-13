using Microsoft.EntityFrameworkCore;
using Temp.Data;
using Temp.DTOs;
using Temp.Exceptions;
using Temp.Models;

namespace Temp.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<GalleryExhibitionsDTO> GetGalleryExhibitionsAsync(int galleryId)
    {
        var gallery = await _context.Galleries
            .Include(g => g.Exhibitions)
            .ThenInclude(e => e.ExhibitionArtworks)
            .ThenInclude(ea => ea.Artwork)
            .ThenInclude(a => a.Artist)
            .Where(g => g.GalleryId == galleryId)
            .Select(g => new GalleryExhibitionsDTO
            {
                GalleryId = g.GalleryId,
                Name = g.Name,
                EstablishedDate = g.EstablishedDate,
                Exhibitions = g.Exhibitions.Select(e => new ExhibitionDetailsDTO
                {
                    Title = e.Title,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    NumberOfArtworks = e.NumberOfArtworks,
                    Artworks = e.ExhibitionArtworks.Select(ea => new ArtworkDetailsDTO
                    {
                        Title = ea.Artwork.Title,
                        YearCreated = ea.Artwork.YearCreated,
                        InsuranceValue = ea.InsuranceValue,
                        Artist = new ArtistDTO
                        {
                            FirstName = ea.Artwork.Artist.FirstName,
                            LastName = ea.Artwork.Artist.LastName,
                            BirthDate = ea.Artwork.Artist.BirthDate
                        }
                    }).ToList()
                }).ToList()
            })
            .FirstOrDefaultAsync();

        if (gallery == null)
            throw new NotFoundException($"Gallery with ID {galleryId} not found");

        return gallery;
    }
    
    public async Task AddExhibitionAsync(AddExhibitionDTO dto)
    {
        var gallery = await _context.Galleries
            .FirstOrDefaultAsync(g => g.Name == dto.Gallery);

        if (gallery == null)
            throw new NotFoundException($"Gallery '{dto.Gallery}' not found");

        var artworks = await _context.Artworks
            .Where(a => dto.Artworks.Select(aw => aw.ArtworkId).Contains(a.ArtworkId))
            .ToListAsync();

        if (artworks.Count != dto.Artworks.Count)
            throw new BadRequestException("One or more artworks not found");

        var exhibition = new Exhibition
        {
            GalleryId = gallery.GalleryId,
            Title = dto.Title,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            NumberOfArtworks = dto.Artworks.Count
        };

        _context.Exhibitions.Add(exhibition);
        await _context.SaveChangesAsync();

        var exhibitionArtworks = dto.Artworks.Select(aw => new ExhibitionArtwork
        {
            ExhibitionId = exhibition.ExhibitionId,
            ArtworkId = aw.ArtworkId,
            InsuranceValue = aw.InsuranceValue
        }).ToList();

        _context.ExhibitionArtworks.AddRange(exhibitionArtworks);
        await _context.SaveChangesAsync();
    }

}