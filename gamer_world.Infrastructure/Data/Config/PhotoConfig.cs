using gamer_world.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gamer_world.Infrastructure.Data.Config;


public class PhotoConfig : IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
        builder.Property(x => x.ImageName).IsRequired();
        builder.HasData(new Photo { Id = 1, ImageName = "Test", ProductId = 1 });
    }
}