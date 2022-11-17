namespace tf.ModelsView
{
    public class HistorialConductor
    {
        public string NombreCliente { get; set; } = null!;
        public string ApellidoCliente { get; set; } = null!;
        public string NombreMercancia { get; set; } = null!;
        public DateTime FechaServicio { get; set; }
        public double ValorServicio { get; set; }
        public string CiudadServicio { get; set; } = null!;
    }
}
