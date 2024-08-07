﻿using ActivosControles.util.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivosControles.model.proc
{
    public class validarEscaneo
    {

        public static Response activo(string or_codigo)
        {
            Response res = new Response() { CodigoError = 0, Message = "Sin Resultados", Result = null };

            try
            {

                data.DAO.c_base_datos cb = new data.DAO.c_base_datos();
                System.Data.DataTable dt;
                string strCon = util.Conexion.Conexion.CadenaConexion();

                string[] vector = new string[1];
                cb.sp = "usp_validarEscaneo";
                vector[0] = "@or_codigo,i," + or_codigo;


                dt = cb.consultar(vector, 1, strCon);


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
