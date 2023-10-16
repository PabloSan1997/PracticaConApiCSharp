namespace WebApplication1.Middleware
{
    public class HeaderImagen
    {

        readonly RequestDelegate next;

        public HeaderImagen(RequestDelegate nx)
        {
            next = nx;
        }
        public async Task Invoke(HttpContext context)
        {
            var ver = context.Request.Headers["entrada"];
            var mira = Environment.GetEnvironmentVariable("MiVariable");
            if (ver == mira)
            {
                await next(context);
            }
            else
            {
                var mensaje = new Respuesta("No tienes permiso para usar esta App");
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(mensaje);
            }
        }
    }
    public static class HeaderImageMiddleware
    {
        public static IApplicationBuilder UseHeaderImage(this IApplicationBuilder builder)
        {

            return builder.UseMiddleware<HeaderImagen>();
        }
    }
    class Respuesta
    {
        public string Mensaje { get; set; }
        public Respuesta(string mensaje)
        {
            Mensaje = mensaje;
        }
    }
}
