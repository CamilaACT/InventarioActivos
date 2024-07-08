using ActivosControles.util.Respuesta;
using ActivosControles.util.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ActivosControles.model.proc
{
    public class login
    {

        public static Response log(usuario usarioLog)
        {
            Response res = new Response() { CodigoError = 0, Message = "Sin Resultados", Result = null };

            try
            {

                    data.DAO.c_base_datos cb = new data.DAO.c_base_datos();
                    System.Data.DataTable dt;
                    string strCon = util.Conexion.Conexion.CadenaConexion();

                    string[] vector = new string[2];
                    cb.sp = "usp_login";//poner el nombre correcto
                    vector[0] = "@us_login,v," + usarioLog.login;
                    vector[1] = "@us_password,v," + usarioLog.contrasenia;


        
                    dt = cb.consultar(vector, 2, strCon);


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
