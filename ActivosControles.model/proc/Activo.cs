using ActivosControles.util.Request;
using ActivosControles.util.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivosControles.model.proc
{
    public class Activo
    {
        public static Response activo(util.Request.activorequest activo)
        {
            Response res = new Response() { CodigoError = 0, Message = "Sin Resultados", Result = null };

            try
            {

                data.DAO.c_base_datos cb = new data.DAO.c_base_datos();
                System.Data.DataTable dt;
                string strCon = util.Conexion.Conexion.CadenaConexion();

                string[] vector = new string[4];
                cb.sp = "usp_activo";
                vector[0] = "@us_codigo,v," + activo.us_codigo;
                vector[1] = "@or_codigo,i," + activo.or_codigo;
                vector[2] = "@ta_codigo,v," + activo.ta_codigo;
                vector[3] = "@ac_nombre,v," + activo.ac_nombre;


                dt = cb.consultar(vector, 4, strCon);


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
