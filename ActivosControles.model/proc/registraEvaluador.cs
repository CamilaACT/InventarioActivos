using ActivosControles.util.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivosControles.model.proc
{
    public class registraEvaluador
    {

        public static Response evaluador(util.Request.registraEvaluadorRequest evaluador)
        {
            Response res = new Response() { CodigoError = 0, Message = "Sin Resultados", Result = null };

            try
            {

                data.DAO.c_base_datos cb = new data.DAO.c_base_datos();
                System.Data.DataTable dt;
                string strCon = util.Conexion.Conexion.CadenaConexion();

                string[] vector = new string[6];
                cb.sp = "usp_registraEvaluador";
                vector[0] = "@or_codigo,i," + evaluador.or_codigo;
                vector[1] = "@us_usuario,v," + evaluador.us_usuario;
                vector[2] = "@us_contrasenia,v," + evaluador.us_contrasenia;
                vector[3] = "@us_nombre,v," + evaluador.us_nombre;
                vector[4] = "@us_cedula,v," + evaluador.us_cedula;
                vector[5] = "@us_apellido,v," + evaluador.us_apellido;


                dt = cb.consultar(vector, 6, strCon);


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
