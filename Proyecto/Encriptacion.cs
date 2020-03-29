using System;
using System.Text;

namespace Proyecto
{
    public class Encriptacion
    {

        public string Codificacion(string p)
        {

            string plainText = p;

            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            string encodedText = Convert.ToBase64String(plainTextBytes);

            return encodedText;



        }

        public string Decodificacion(string p)
        {
            string encodedText = p;

            var encodedTextBytes = Convert.FromBase64String(encodedText);

            string plainText = Encoding.UTF8.GetString(encodedTextBytes);


            return plainText;

        }
    }
}
