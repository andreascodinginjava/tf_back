namespace tf.ModelsView
{
    public class InfoCliente
    {
        public int DNI { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string Ciudad { get; set; }
        public string Genero { get; set; }
    }
}
