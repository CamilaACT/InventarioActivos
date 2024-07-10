using ActivosControles.util.Respuesta;
using System.Data;

namespace ActivosControles.Data
{
    public class listadoEvaluadores
    {

        public List<Evaluador> retornalistaEvaluadores(string or_codigo)
        {
            Response respuesta = model.proc.listadoEvaluadores.evaluadorlista(or_codigo);


            List<Evaluador> evaluadores = new List<Evaluador>();



            if (respuesta.CodigoError == -1)
            {


                if (respuesta.Result != null)
                {
                    DataTable dataTable = respuesta.Result as DataTable;

                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {

                            Evaluador evaluadornuevo = new Evaluador();
                            evaluadornuevo.nombre = row["nombre"].ToString();
                            evaluadornuevo.cedula = row["cedula"].ToString();
                            evaluadornuevo.usuario = row["usuario"].ToString();
                            evaluadornuevo.id = row["id"].ToString();
                            evaluadores.Add(evaluadornuevo);
                        }
                    }
                }
            }



            return evaluadores;
        }

    }
}
