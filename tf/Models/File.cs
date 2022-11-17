using System;
using System.Collections.Generic;

namespace tf.Models
{
    public partial class File
    {
        public int IdFile { get; set; }
        public string NombreFile { get; set; } = null!;
        public string ExtensionFile { get; set; } = null!;
        public double TamanioFile { get; set; }
        public string UbicacionFile { get; set; } = null!;
        public string VehiculoFk { get; set; } = null!;
    }
}
