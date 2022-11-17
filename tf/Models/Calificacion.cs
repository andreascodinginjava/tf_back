using System;
using System.Collections.Generic;

namespace tf.Models
{
    public partial class Calificacion
    {
        public int IdCalificacion { get; set; }
        public int? RecoPositiva { get; set; }
        public int? RecoNegativa { get; set; }
        public int? CanEstrellas { get; set; }
        public string? Comentario { get; set; }
        public int ConductorFk { get; set; }
    }
}
