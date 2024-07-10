using ActivosControles.util.Request;
using ActivosControles.util.Respuesta;

namespace ActivosControles.Data
{
    public class registraOrganizacion
    {
        public Response organizacion(registraOrganizacionRequest organizacion)
        {
            

           return model.proc.registraOrganizacion.organizacion(organizacion);
        }
    }
}
