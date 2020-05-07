using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Proyecto
{
    
    public class Json
    {
       
        //Logs.json
        ///////////////////////////////////////////////////////////////////

        public US desUS() => JsonConvert.DeserializeObject<US>(File.ReadAllText(@"Logs.json"));
        public string sereUS(US b) => JsonConvert.SerializeObject(b);

        //Archivo clientes.json
        ///////////////////////////////////////////////////////////////////
        public ClientClass desCl() => JsonConvert.DeserializeObject<ClientClass>(File.ReadAllText(@"Client.json"));
        public string sereCl(ClientClass b) => JsonConvert.SerializeObject(b);

        //Archivo vehiculos.json
        ///////////////////////////////////////////////////////////////////
        public VehicleClass desVe() => JsonConvert.DeserializeObject<VehicleClass>(File.ReadAllText(@"Veiculo.json"));
        public string sereVe(VehicleClass b) => JsonConvert.SerializeObject(b);

        //Archivo reparaciones.json
        ///////////////////////////////////////////////////////////////////
        public ReparationClass desRe() => JsonConvert.DeserializeObject<ReparationClass>(File.ReadAllText(@"Repa.json"));
        public string sereRe(ReparationClass b) => JsonConvert.SerializeObject(b);
         

        public void Save(int file, string data)
        {

            switch (file)
            {
                case 1:
                    File.WriteAllText(@"Logs.json", data);
                    break;
                case 2:
                    File.WriteAllText(@"Client.json", data);
                    break;
                case 3:
                    File.WriteAllText(@"Veiculo.json", data);
                    break;
                case 4:
                    File.WriteAllText(@"Repa.json", data);
                    break;
            }
        }

    }

    //Lista de Usuarios
    /// ///////////////////////////////////////////////////////////////
    public class US
    {
        public List<Usuario> usuarios { get; set; }
    }
    //////Keys en lista de Usuarios
    public class Usuario
    {
        public string user { get; set; }
        public string pass { get; set; }
        public string session { get; set; }
    }

    //Lista de veiculos
    /// ///////////////////////////////////////////////////////////////
    public class ClientClass
    {
        public List<Clients> clientes { get; set; }
    }
    //////Keys en lista de Clientes
    public class Clients
    {
        public string nomusuario { get; set; }
        public string nombre { get; set; }
        public string dui { get; set; }
        public string correo { get; set; }
        public string numero { get; set; }
        public string visitas { get; set; }
    }
    //Lista de Vehiculos
    /// ///////////////////////////////////////////////////////////////
    public class VehicleClass
    {
        public List<Vehicles> vehiculos { get; set; }
    }
    //////Keys en lista de Vehiculos
    public class Vehicles
    {
        public string entrada { get; set; }
        public string dui { get; set; }
        public string marca { get; set; }
        public string placa { get; set; }
        public string color { get; set; }
        public string año { get; set; }
        public string reparado { get; set; }
    }
    //Lista de reparación
    /// ///////////////////////////////////////////////////////////////
    public class ReparationClass
    {
        public List<Reparation> reparaciones { get; set; }
    }
    //////Keys en lista de reparación
    public class Reparation
    {
        public string reparacion { get; set; }
        public string placa { get; set; }
        public string materiales { get; set; }
        public string costomaterial { get; set; }
        public string horas { get; set; }
        public string costohora { get; set; }
        public string estadodeReparacion { get; set; }
    }
}
