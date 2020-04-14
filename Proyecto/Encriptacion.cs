using System;
using System.Text;

namespace Proyecto
{
    public class Encriptacion
    {

        public string Codificacion(string p) => Convert.ToBase64String(Encoding.UTF8.GetBytes(p));
       

        public string Decodificacion(string p) => Encoding.UTF8.GetString(Convert.FromBase64String(p));

    }
}
