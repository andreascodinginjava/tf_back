namespace tf.ModelsView
{
    public class ServiciosCliente
    {
        public string NombreConductor { get; set; } = null!;
        public string ApellidoConductor { get; set; } = null!;
        public string NombreMercancia { get; set; } = null!;
        public string TipoMercancia { get; set; } = null!;
        public DateTime FechaServicio { get; set; }
        public string DireccionOrigen { get; set; } = null!;
        public string DireccionDestino { get; set; } = null!;
        public string CiudadServicio { get; set; } = null!;
    }
}
