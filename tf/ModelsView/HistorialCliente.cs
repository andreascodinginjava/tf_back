namespace tf.ModelsView
{
    public class HistorialCliente
    {
        public string NombreConductor { get; set; } = null!;
        public string ApellidoConductor { get; set; } = null!;
        public string NombreMercancia { get; set; } = null!;
        public DateTime FechaServicio { get; set; }
        public double ValorServicio { get; set; }
        public string CiudadServicio { get; set; } = null!;
    }
}
