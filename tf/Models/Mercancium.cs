using System;
using System.Collections.Generic;

namespace tf.Models
{
    public partial class Mercancium
    {
        public int IdMercancia { get; set; }
        public string PesoMercancia { get; set; } = null!;
        public string NombreMercancia { get; set; } = null!;
        public int TipoMercanciaFk { get; set; }
        public int ClienteFk { get; set; }

    }
}
