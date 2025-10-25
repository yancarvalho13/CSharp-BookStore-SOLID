using Microsoft.EntityFrameworkCore;
using RestBiblioteca.model;

namespace RestBiblioteca;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books {get; set;}
    public DbSet<Author> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(e =>
        {
            e.ToTable("books");
            e.HasKey(b => b.Id);

            e.Property(b => b.Id)
                .ValueGeneratedOnAdd()
                .HasIdentityOptions(startValue: 1);
            
            e.Property(b => b.Name)
                .HasMaxLength(256)
                .IsRequired();
            
            e.Property(b => b.Category)
                .HasConversion<string>()
                .HasMaxLength(50)
                .IsRequired();

            e.HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            e.HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Author>(e =>
        {
            e.ToTable("authors");
            e.HasKey(a => a.Id);

            e.Property(a => a.Id)
                .ValueGeneratedOnAdd()
                .HasIdentityOptions(startValue: 1);

            e.Property(a => a.Name)
                .HasMaxLength(256)
                .IsRequired();

            e.Property(a => a.BirthDate)
                .IsRequired()
                .HasColumnType("date");
            
            e.Property(a => a.Nationality)
                .HasMaxLength(256)
                .IsRequired();

            e.Navigation(a => a.Books)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        });

        modelBuilder.Entity<Publisher>(e =>
        {
            e.ToTable("publishers");
            e.HasKey(p => p.Id);

            e.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasIdentityOptions(startValue: 1);
            
            e.Property(p => p.Name)
                .HasMaxLength(256)
                .IsRequired();
            
            e.Property(p => p.Country)
                .HasMaxLength(256)
                .IsRequired();

            e.Navigation(p => p.Books)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

        });

        modelBuilder.Entity<User>(e =>
        {
            e.ToTable("users");
            e.HasKey(u => u.Id);

            e.Property(u => u.Id)
                .ValueGeneratedOnAdd()
                .HasIdentityOptions(startValue: 1);

            e.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(256);

            e.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(256);

            e.Property(u => u.Email)
                .HasMaxLength(256)
                .IsRequired();

            e.Property(u => u.BirthDate)
                .IsRequired()
                .HasColumnType("date");

            e.Property(u => u.Role)
                .HasConversion<String>()
                .IsRequired();

            e.OwnsOne(u => u.Adress, nav =>
            {
                nav.Property(a => a.Cep).HasColumnName("cep").HasMaxLength(8);
                nav.Property(a => a.City).HasColumnName("city").HasMaxLength(120);
                nav.Property(a => a.Ddd).HasColumnName("ddd").HasMaxLength(3);
                nav.Property(a => a.Neighborhood).HasColumnName("neighborhood").HasMaxLength(120);
                nav.Property(a => a.Region).HasColumnName("region").HasMaxLength(9);
                nav.Property(a => a.State).HasColumnName("state").HasConversion<string>().HasMaxLength(120);
                nav.Property(a => a.Street).HasColumnName("street").HasMaxLength(120);
                nav.Property(a => a.Uf).HasColumnName("uf").HasConversion<string>().HasMaxLength(2);

            });

        });


    }

}