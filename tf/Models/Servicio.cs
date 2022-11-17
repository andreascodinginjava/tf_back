using System;
using System.Collections.Generic;

namespace tf.Models
{
    public partial class Servicio
    {
        public int IdServicio { get; set; }
        public DateTime FechaServicio { get; set; }
        public double ValorServicio { get; set; }
        public string DireccionOrigen { get; set; } = null!;
        public string DireccionDestino { get; set; } = null!;
        public int MercanciaFk { get; set; }
        public int ConductorFk { get; set; }
        public int CiudadFk { get; set; }
    }
}
