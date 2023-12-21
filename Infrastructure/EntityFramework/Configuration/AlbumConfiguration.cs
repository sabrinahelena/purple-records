using Domain.AggregatesModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configuration;

public class AlbumConfiguration : IEntityTypeConfiguration<AlbumModel>
{
    public void Configure(EntityTypeBuilder<AlbumModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(100);
        builder.Property(x => x.ReleaseDate).IsRequired();
        builder.Property(x => x.Title).IsRequired().HasMaxLength(50);

        // um album tem muitas musicas, e cada musica tem 1 album, com a chave UserId
        builder.HasMany(x => x.Musics)
            .WithOne()
            .HasForeignKey(x => x.UserId);


        // um album tem um usuario, com muitos albums, e chave userId
        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);
    }
}
