using Microsoft.EntityFrameworkCore;
using Temp.Models;

namespace Temp.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options) { }

    public DbSet<Gallery> Galleries { get; set; }
    public DbSet<Exhibition> Exhibitions { get; set; }
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<ExhibitionArtwork> ExhibitionArtworks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Gallery
        modelBuilder.Entity<Gallery>().HasData(
            new Gallery
            {
                GalleryId = 1,
                Name = "Modern Art Gallery",
                EstablishedDate = new DateTime(2000, 5, 10)
            },
            new Gallery
                {
                    GalleryId = 2,
                    Name = "Modern Art Space",
                    EstablishedDate = new DateTime(2001, 9, 12)
                }
        );

        // Artist
        modelBuilder.Entity<Artist>().HasData(
            new Artist
            {
                ArtistId = 1,
                FirstName = "Pablo",
                LastName = "Picasso",
                BirthDate = new DateTime(1881, 10, 25)
            },
            new Artist
            {
                ArtistId = 2,
                FirstName = "Frida",
                LastName = "Kahlo",
                BirthDate = new DateTime(1907, 7, 6)
            }
        );

        // Artwork
        modelBuilder.Entity<Artwork>().HasData(
            new Artwork
            {
                ArtworkId = 1,
                ArtistId = 1,
                Title = "Les Demoiselles d'Avignon",
                YearCreated = 1907
            },
            new Artwork
            {
                ArtworkId = 2,
                ArtistId = 2,
                Title = "The Two Fridas",
                YearCreated = 1939
            }
        );

        // Exhibition
        modelBuilder.Entity<Exhibition>().HasData(
            new Exhibition
            {
                ExhibitionId = 1,
                GalleryId = 1,
                Title = "Masterpieces of the 20th Century",
                StartDate = new DateTime(2025, 6, 1),
                EndDate = new DateTime(2025, 6, 30),
                NumberOfArtworks = 2
            }
        );

        // Exhibition_Artwork
        modelBuilder.Entity<ExhibitionArtwork>().HasData(
            new ExhibitionArtwork
            {
                ExhibitionId = 1,
                ArtworkId = 1,
                InsuranceValue = 1500000m
            },
            new ExhibitionArtwork
            {
                ExhibitionId = 1,
                ArtworkId = 2,
                InsuranceValue = 1300000m
            }
        );
    }
}
