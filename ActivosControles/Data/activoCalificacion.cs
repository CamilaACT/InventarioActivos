using ActivosControles.util.Request;

namespace ActivosControles.Data
{
    public class activoCalificacion
    {

        public void calificarActivo(guardarCalificacionrequest calificacion)
        {

            model.proc.guardarCalificacion.activo(calificacion);
        }
    }
}
