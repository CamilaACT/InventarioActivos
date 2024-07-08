using ActivosControles.util.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivosControles.model.proc
{
    public class guardarCalificacion
    {

        public static Response activo(util.Request.guardarCalificacionrequest activo)
        {
            Response res = new Response() { CodigoError = 0, Message = "Sin Resultados", Result = null };

            try
            {

                data.DAO.c_base_datos cb = new data.DAO.c_base_datos();
                System.Data.DataTable dt;
                string strCon = util.Conexion.Conexion.CadenaConexion();

                string[] vector = new string[5];
                cb.sp = "usp_guardaCalificacion";
                vector[0] = "@us_codigo,i," + activo.us_codigo;
                vector[1] = "@ac_codigo,i," + activo.ac_codigo;
                vector[2] = "@di_codigo,i," + activo.di_codigo;
                vector[3] = "@cr_codigo,i," + activo.cr_codigo;
                vector[4] = "@pu_puntuacion,i," + activo.pu_puntuacion;

                dt = cb.consultar(vector, 5, strCon);


                res.CodigoError = cb.valo_erro;
                if (res.CodigoError == -1)
                {

                    res.Message = "OK";
                    res.Message = cb.valo_resp;
                    res.Result = dt;

                }
                else
                {
                    res.Message = "Que pena me da tu caso";
                    res.Message = cb.valo_resp;
                }

            }
            catch (Exception ex)
            {
                res.CodigoError = -100;
                res.Message = "Error inesperado";
                res.Message = ex.Message;
            }
            return res;



        }
    }
}
