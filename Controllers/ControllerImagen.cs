using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/misimagenes")]
    public class ControllerImagen : ControllerBase
    {
        IServiceImage servicioImagen;

        public ControllerImagen(IServiceImage servicio)
        {
            servicioImagen = servicio;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(servicioImagen.LeerImagene());
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult Conectdb([FromServices] ContextImagenes co)
        {
            co.Database.EnsureCreated();
            return Ok("Conectado a la base de datos :)");
        }
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetOne([FromRoute] Guid id) {
            var data = servicioImagen.LeerImagenUna(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpPost]
        public IActionResult Post([FromBody] MisImagenes nuevaData)
        {
            servicioImagen.AgregarImagen(nuevaData);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put([FromBody] MisImagenes imagenEditar)
        {
            servicioImagen.EditarImagen(imagenEditar.Id_imagen, imagenEditar);
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            servicioImagen.EliminarImagen(id);
            return Ok();
        }
    }
}
