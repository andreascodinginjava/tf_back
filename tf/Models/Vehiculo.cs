using System;
using System.Collections.Generic;

namespace tf.Models
{
    public partial class Vehiculo
    {
        public string IdVehiculo { get; set; } = null!;
        public string Capacidad { get; set; } = null!;
        public int ColorVehiculoFk { get; set; }
        public int TipoVehiculoFk { get; set; }
    }
}
