using System;
using System.Security.Cryptography;
using System.Text;


namespace Proyecto
{
    public class Encriptacion
    {
        public static string GetSHA256(string str)
        {
            // (Encriptacion de un solo camino) Manera esattica para encriptar de un solo camina para mayor seguridad creado por la NSA. 
            // Base64 no es encriptacion es solo codificacion y es de 2 caminos.

            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
