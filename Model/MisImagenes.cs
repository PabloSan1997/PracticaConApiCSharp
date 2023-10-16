using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    public class MisImagenes
    {
       public string Nombre { get; set; }
       public string Autor { get; set; }
       public string UrlImagen { get; set; }
       public Guid Id_imagen { get; set; }
       public string Descripcion { get; set; }

    }
}
