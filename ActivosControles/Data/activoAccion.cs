using ActivosControles.util.Request;

namespace ActivosControles.Data
{
    public class activoAccion
    {

        public void guardarActivos(activorequest activo)
        {

            model.proc.Activo.activo(activo);
        }
    }
}
