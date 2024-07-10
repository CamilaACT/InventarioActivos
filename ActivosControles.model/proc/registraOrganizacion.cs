using ActivosControles.util.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivosControles.model.proc
{
    public class registraOrganizacion
    {
        public static Response organizacion(util.Request.registraOrganizacionRequest organizacion)
        {
            Response res = new Response() { CodigoError = 0, Message = "Sin Resultados", Result = null };

            try
            {

                data.DAO.c_base_datos cb = new data.DAO.c_base_datos();
                System.Data.DataTable dt;
                string strCon = util.Conexion.Conexion.CadenaConexion();

                string[] vector = new string[7];
                cb.sp = "usp_registraOrganizacion";
                vector[0] = "@or_nombre,v," + organizacion.or_nombre;
                vector[1] = "@or_descripcion,v," + organizacion.or_descripcion;
                vector[2] = "@us_usuario,v," + organizacion.us_usuario;
                vector[3] = "@us_contrasenia,v," + organizacion.us_contrasenia;
                vector[4] = "@us_nombre,v," + organizacion.us_nombre;
                vector[5] = "@us_cedula,v," + organizacion.us_cedula;
                vector[6] = "@us_apellido,v," + organizacion.us_apellido;

                dt = cb.consultar(vector,7, strCon);


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
