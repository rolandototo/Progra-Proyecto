using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Proyecto
{
    
    public class Json
    {

        //Taller.json
        /// //////////////////////////////////////////////////////////////////

        public Cl desCl()
        {
            string DatosTaller = File.ReadAllText(@"taller.json");
            var data = JsonConvert.DeserializeObject<Cl>(DatosTaller);
            return data;
        }
        public string sereCl(Cl b)
        {
            var datos = JsonConvert.SerializeObject(b);
            return datos;
        }


        //Usuarios.json
        /// ///////////////////////////////////////////////////////////////

        public US desUS()
        {
            string DatosUsuarios = File.ReadAllText(@"usuarios.json");
            var data = JsonConvert.DeserializeObject<US>(DatosUsuarios);
            return data;
        }
        public string sereUS(US b)
        {

            var datos = JsonConvert.SerializeObject(b);
            return datos;
        }

    }



    //Taller.json
    /// ///////////////////////////////////////////////////////////////

    public class Veiculo
    {

        public string marca { get; set; }
        public string placa { get; set; }
        public string color { get; set; }
        public string ano { get; set; }
        public string frecuencia { get; set; }
        public List<string> reparaciones { get; set; }
    }
   

    public class Cliente
    {
        public string nombre { get; set; }
        public string dui { get; set; }
        public string correo { get; set; }
        public List<Veiculo> veiculos { get; set; }
    }

    public class Cl
    {
        public List<Cliente> clientes { get; set; }
    }


    //Usuarios.json
    /// ///////////////////////////////////////////////////////////////

    public class Usuario
    {
        public string user { get; set; }
        public string pass { get; set; }
        public string session { get; set; }
    }

    public class US
    {
        public List<Usuario> usuarios { get; set; }
    }

}
