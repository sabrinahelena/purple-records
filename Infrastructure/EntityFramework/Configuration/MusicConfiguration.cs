using Domain.AggregatesModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Configuration;

public class MusicConfiguration : IEntityTypeConfiguration<MusicModel>
{
    public void Configure(EntityTypeBuilder<MusicModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(100);
        builder.Property(x => x.ReleaseDate).IsRequired();
        builder.Property(x => x.Title).IsRequired().HasMaxLength(50);

    }
}
