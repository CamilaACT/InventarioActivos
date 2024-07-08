using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivosControles.util.Respuesta
{
    public class Response
    {

        public int CodigoError { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }


    }
}
