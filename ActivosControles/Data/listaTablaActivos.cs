using ActivosControles.util.Request;
using ActivosControles.util.Respuesta;
using System.Data;

namespace ActivosControles.Data
{
    public class listaTablaActivos
    {
        public List<Activotabla> retornalistaActivos(string or_codigo)
        {
            Response respuesta = model.proc.TablaActivo.tablaactivos(or_codigo);
            List<Activotabla> activos = new List<Activotabla>();

            if ( respuesta.CodigoError == -1)
            {
               

                if (respuesta.Result != null)
                {
                    DataTable dataTable = respuesta.Result as DataTable;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            Activotabla activo = new Activotabla
                            {
                                codigo = row["codigo"].ToString(),
                                id = row["id"].ToString(),
                                nombre = row["nombre"].ToString(),
                                estado = row["estado"].ToString()
                            };
                            activos.Add(activo);
                        }
                    }
                }
            }
            
           

            return activos;
        }
    }
}
