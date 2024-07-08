using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivosControles.util.Conexion
{
    public class Conexion
    {

        private static string servidor = @"localhost\SQLCAMI";
        private static string base_tip = "activos";
        private static string usuario = "sa";
        private static string password = "dsct2004";
        private static string clav_priv = "dfaeiriecmvjhe3943dfadahyeu3456";
        public static string CadenaConexion()
        {
           
            return "Data Source=" + servidor + ";Initial Catalog=" + base_tip + ";User ID=" + usuario + ";Password=" + password;
        }

        public static string CadenaClavePrivada()
        {
            
            return clav_priv.Trim();

        }


    }
}
