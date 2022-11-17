using System;
using System.Collections.Generic;

namespace tf.Models
{
    public partial class Conductor
    {

        public int IdConductor { get; set; }
        public string NombreConductor { get; set; } = null!;
        public string ApellidoConductor { get; set; } = null!;
        public string EmailConductor { get; set; } = null!;
        public string PswConductor { get; set; } = null!;
        public string EstadoConductor { get; set; } = null!;
        public int CiudadConductorFk { get; set; }
        public int GeneroConductorFk { get; set; }
        public string VehiculoFk { get; set; } = null!;
        public int? MedioPagoFk { get; set; }
    }
}
