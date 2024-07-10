using ActivosControles.util.Request;
using ActivosControles.util.Respuesta;

namespace ActivosControles.Data
{
    public class validarEscaneo
    {
        public List<string> validar(string or_codigo)
        {
            Response res = model.proc.validarEscaneo.activo(or_codigo);
            List<string> result = new List<string>();

            if (res.CodigoError == -1)
            {
                string[] parts = res.Message.Split('|');

                result.AddRange(parts);
            }

            return result;
        }
    }
}
