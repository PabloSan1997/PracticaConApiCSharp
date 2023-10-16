

using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1
{
    public class ContextImagenes : DbContext
    {
        public DbSet<MisImagenes> misImagenes { get; set; }
        public ContextImagenes(DbContextOptions<ContextImagenes> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<MisImagenes> initState = new();
            initState.Add(new MisImagenes()
            {
                UrlImagen= "https://img2.rtve.es/i/?w=1600&i=1442912677842.jpg",
                Nombre="Spiderman",
                Autor="Yo",
                Id_imagen=Guid.NewGuid(),
                Descripcion="Es una cachonda"
            });
     
            modelBuilder.Entity<MisImagenes>(p =>
            {
                p.ToTable("MisImagenes");
                p.HasKey(p => p.Id_imagen);
                p.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
                p.Property(p => p.Autor).IsRequired().HasMaxLength(80);
                p.Property(p => p.UrlImagen).IsRequired().HasMaxLength(2000);
                p.Property(p => p.Descripcion).IsRequired().HasMaxLength(1000);
                p.HasData(initState);
            });

        }
    }

}
