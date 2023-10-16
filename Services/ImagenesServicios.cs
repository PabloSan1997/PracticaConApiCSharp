using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;
namespace WebApplication1.Services
{
    public class ImagenesServicios: IServiceImage
    {
        ContextImagenes context;
        public ImagenesServicios(ContextImagenes cn)
        {
            context = cn;
        }
        public IEnumerable<MisImagenes> LeerImagene()
        {
            return context.misImagenes;
        }
        public MisImagenes LeerImagenUna(Guid id) {
            var elemento = context.misImagenes.Find(id);
            return elemento;
        }
        public async Task AgregarImagen(MisImagenes nuevaImagen)
        {
            context.misImagenes.Add(nuevaImagen);
            await context.SaveChangesAsync();
        }
        public async Task EliminarImagen(Guid id) {
            var buscar = context.misImagenes.Find(id);
            if (buscar != null)
            {
                context.Remove(buscar);
                await context.SaveChangesAsync();
            }
        }
        public async Task EditarImagen(Guid id, MisImagenes image)
        {
            var buscar = context.misImagenes.Find(id);
            if(buscar != null)
            {
                buscar.Autor = image.Autor;
                buscar.UrlImagen = image.UrlImagen;
                buscar.Descripcion = image.Descripcion;
                buscar.Nombre = image.Nombre;
                await context.SaveChangesAsync();
            }
        }
    }
}

public interface IServiceImage
{
    IEnumerable<MisImagenes> LeerImagene();
    MisImagenes LeerImagenUna(Guid id);
    Task AgregarImagen(MisImagenes nuevaImagen);
    Task EliminarImagen(Guid id);
    Task EditarImagen(Guid id, MisImagenes image);

}
