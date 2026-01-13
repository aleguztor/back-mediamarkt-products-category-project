namespace MediaMarktProjectApi.Infrastructure.Persistance.Configurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(p => p.Id);
     
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Price).HasPrecision(18, 2);
        builder.Property(p => p.Description).HasMaxLength(250);
        builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
        new Product
        {
            Id = Guid.NewGuid(), 
            Name = "Televisor 4K LG LED",
            Price = 699.99m,
            Description = "65 pulgadas OLED",
            CategoryId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35")
        }, 
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Televisor 4K Samsung QLED",
            Price = 499.99m,
            Description = "60 pulgadas OLED",
            CategoryId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35")
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Bombilla luz LED 20W White",
            Price = 21.99m,
            Description = "Bombilla LED de larga duración con más de 20.000 horas.",
            CategoryId = Guid.Parse("a11111e9-2ba9-473a-a40f-e38cb54f9b35")
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "PS5 Slim",
            Price = 499m,
            Description = "Playstation 5 con 1 mando incluido, color blanco",
            CategoryId = Guid.Parse("6050e3c9-5b15-406f-a9a5-077e64da2cff")
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Switch 2 256GB + MarioBROS",
            Price = 509m,
            Description = "Switch 2 256GB en color negro, azul y rojo Neón",
            CategoryId = Guid.Parse("6050e3c9-5b15-406f-a9a5-077e64da2cff")
        },
         new Product
         {
             Id = Guid.NewGuid(),
             Name = "Samsung Galaxy A56 5G, 8GB RAM",
             Price = 509m,
             Description = "El Samsung Galaxy A56 5G es un dispositivo potente y equilibrado que ofrece un excelente rendimiento, conectividad avanzada y una experiencia visual envolvente. Con un procesador Exynos 1580",
             CategoryId = Guid.Parse("bee061d2-d289-4ab3-b012-4aa4e30457cb")
         }
    );
    }
}