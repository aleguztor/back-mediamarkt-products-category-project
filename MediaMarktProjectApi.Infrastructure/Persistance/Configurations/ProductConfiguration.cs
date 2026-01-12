using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MediaMarktProjectApi.Infrastructure.Persistance.Configurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    private readonly DatabaseFacade _database;

    // Inyectamos el DatabaseFacade desde el OnModelCreating
    public ProductConfiguration(DatabaseFacade database)
    {
        _database = database;
    }
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(p => p.Id);

        if (_database.IsSqlServer())
        {
            builder.Property(p => p.Id).HasDefaultValueSql("NEWSEQUENTIALID()").ValueGeneratedOnAdd();
        }
        else
        {
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }

        builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
        builder.Property(p => p.Price).HasPrecision(18, 2);

        builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
    }
}
