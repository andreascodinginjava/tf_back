using System;
using System.Collections.Generic;

namespace tf.Models
{
    public partial class Cliente
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; } = null!;
        public string ApellidoCliente { get; set; } = null!;
        public string EmailCliente { get; set; } = null!;
        public string PswCliente { get; set; } = null!;
        public string EstadoCliente { get; set; } = null!;
        public int CiudadClienteFk { get; set; }
        public int GeneroClienteFk { get; set; }
    }
}
