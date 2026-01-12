using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MediaMarktProjectApi.Infrastructure.Persistance.Configurations;
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    private readonly DatabaseFacade _database;

    // Inyectamos el DatabaseFacade desde el OnModelCreating
    public CategoryConfiguration(DatabaseFacade database)
    {
        _database = database;
    }
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(c => c.Id);

        if (_database.IsSqlServer())
        {
            builder.Property(p => p.Id).HasDefaultValueSql("NEWSEQUENTIALID()").ValueGeneratedOnAdd();
        }
        else
        {
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
    }
}
