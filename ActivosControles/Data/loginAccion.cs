using ActivosControles.util.Request;
using ActivosControles.util.Respuesta;
using ActivosControles.model.proc;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;



namespace ActivosControles.Data
{
    public class loginAccion
    {

        public usuariosesion log(usuario usua)
        {
            usuariosesion actual = new usuariosesion();
            Response res = login.log(usua);

            if(res.CodigoError == -1)
            {
                actual.CodigoError = -1;
                string[] parts = res.Message.Split('|');

                actual.us_id = parts[0];

                actual.or_id = parts[1];

            }
            else
            {
                actual.CodigoError = 1;
            }


            return actual;
        }
    }
}
