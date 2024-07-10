using ActivosControles.util.Request;
using ActivosControles.util.Respuesta;

namespace ActivosControles.Data
{
    public class registraEvaluador
    {
        public Response evaluador(registraEvaluadorRequest evaluador)
        {


            return model.proc.registraEvaluador.evaluador(evaluador);
        }
    }
}
