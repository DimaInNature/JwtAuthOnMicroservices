namespace JwtExample.Microservices.ProductService.Persistence.Databases;

public class ProductServiceDbContext : DbContext
{
    public DbSet<ProductEntity> Products => Set<ProductEntity>();

    public ProductServiceDbContext(DbContextOptions<ProductServiceDbContext> options)
       : base(options) => Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductEntity>()
            .HasIndex(indexExpression: product => product.Id)
            .IsUnique();

        modelBuilder.Entity<ProductEntity>()
           .HasData(data: GetProducts());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        base.OnConfiguring(optionsBuilder);

    private List<ProductEntity> GetProducts() => new()
    {
        new(name: "Milk", "Just white milk"),
        new(name: "Juice", "Apple juice")
    };
}