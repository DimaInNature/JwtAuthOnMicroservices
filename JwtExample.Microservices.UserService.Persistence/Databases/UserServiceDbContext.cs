namespace JwtExample.Microservices.UserService.Persistence.Databases;

public class UserServiceDbContext : DbContext
{
    public DbSet<UserEntity> Users => Set<UserEntity>();

    public UserServiceDbContext(DbContextOptions<UserServiceDbContext> options)
       : base(options) => Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>()
            .HasIndex(indexExpression: user => user.Id)
            .IsUnique();

        modelBuilder.Entity<UserEntity>()
           .HasData(data: GetUsers());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        base.OnConfiguring(optionsBuilder);

    private List<UserEntity> GetUsers() => new()
    {
         new(username: "Admin", password: "Root", role: "Admin"),
         new(username: "User", password: "Root", role: "User")
    };
}