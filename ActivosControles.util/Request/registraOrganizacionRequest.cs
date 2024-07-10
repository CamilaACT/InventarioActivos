using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivosControles.util.Request
{
    public class registraOrganizacionRequest
    {
        public string or_nombre { get; set; }
        public string or_descripcion { get; set; }
        public string us_usuario { get; set; }
        public string us_contrasenia { get; set; }
        public string us_nombre { get; set; }
        public string us_cedula { get; set; }
        public string us_apellido { get; set; }
    }
}
