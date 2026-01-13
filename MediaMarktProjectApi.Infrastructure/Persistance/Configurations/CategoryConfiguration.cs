namespace MediaMarktProjectApi.Infrastructure.Persistance.Configurations;
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.Name).IsRequired().HasMaxLength(50);

        builder.HasData(
            new Category { Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), Name = "Televisión" },
            new Category { Id = Guid.Parse("a11111e9-2ba9-473a-a40f-e38cb54f9b35"), Name = "Hogar" },
            new Category { Id = Guid.Parse("6050e3c9-5b15-406f-a9a5-077e64da2cff"), Name = "Consolas" },
            new Category { Id = Guid.Parse("bee061d2-d289-4ab3-b012-4aa4e30457cb"), Name = "Telefonía" }
        );
    }
}