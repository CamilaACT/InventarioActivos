using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivosControles.util.Request
{
    public class guardarCalificacionrequest
    {
        public string us_codigo { get; set; }
        public string ac_codigo { get; set; }
        public string di_codigo { get; set; }
        public string cr_codigo { get; set; }
        public string pu_puntuacion { get; set; }
    }
}
