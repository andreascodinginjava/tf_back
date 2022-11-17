using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace tf.Models
{
    public partial class transflashContext : DbContext
    {
        public transflashContext()
        {
        }

        public transflashContext(DbContextOptions<transflashContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calificacion> Calificacions { get; set; } = null!;
        public virtual DbSet<Ciudad> Ciudads { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<Conductor> Conductors { get; set; } = null!;
        public virtual DbSet<File> Files { get; set; } = null!;
        public virtual DbSet<Genero> Generos { get; set; } = null!;
        public virtual DbSet<MedioPago> MedioPagos { get; set; } = null!;
        public virtual DbSet<Mercancium> Mercancia { get; set; } = null!;
        public virtual DbSet<Servicio> Servicios { get; set; } = null!;
        public virtual DbSet<TipoMercancium> TipoMercancia { get; set; } = null!;
        public virtual DbSet<TipoVehiculo> TipoVehiculos { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-2EPV9PR\\SQLEXPRESS; Database=transflash; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calificacion>(entity =>
            {
                entity.HasKey(e => e.IdCalificacion)
                    .HasName("PK__califica__E056358F7F024A3B");

                entity.ToTable("calificacion");

                entity.Property(e => e.IdCalificacion)
                    .ValueGeneratedNever()
                    .HasColumnName("idCalificacion");

                entity.Property(e => e.CanEstrellas).HasColumnName("canEstrellas");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("comentario");

                entity.Property(e => e.ConductorFk).HasColumnName("conductor_FK");

                entity.Property(e => e.RecoNegativa).HasColumnName("recoNegativa");

                entity.Property(e => e.RecoPositiva).HasColumnName("recoPositiva");

            });

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => e.IdCiudad)
                    .HasName("PK__ciudad__AEA2A71BE910C033");

                entity.ToTable("ciudad");

                entity.Property(e => e.IdCiudad)
                    .ValueGeneratedNever()
                    .HasColumnName("idCiudad");

                entity.Property(e => e.Ciudad1)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("ciudad");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__cliente__885457EEDE0B315E");

                entity.ToTable("cliente");

                entity.Property(e => e.IdCliente)
                    .ValueGeneratedNever()
                    .HasColumnName("idCliente");

                entity.Property(e => e.ApellidoCliente)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("apellidoCliente");

                entity.Property(e => e.CiudadClienteFk).HasColumnName("ciudadCliente_FK");

                entity.Property(e => e.EmailCliente)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("emailCliente");

                entity.Property(e => e.EstadoCliente)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("estadoCliente");

                entity.Property(e => e.GeneroClienteFk).HasColumnName("generoCliente_FK");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombreCliente");

                entity.Property(e => e.PswCliente)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("pswCliente");

            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.IdColor)
                    .HasName("PK__color__504A3B88342D1D61");

                entity.ToTable("color");

                entity.Property(e => e.IdColor)
                    .ValueGeneratedNever()
                    .HasColumnName("idColor");

                entity.Property(e => e.Color1)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("color");
            });

            modelBuilder.Entity<Conductor>(entity =>
            {
                entity.HasKey(e => e.IdConductor)
                    .HasName("PK__conducto__2E74F8E8FD593E99");

                entity.ToTable("conductor");

                entity.Property(e => e.IdConductor)
                    .ValueGeneratedNever()
                    .HasColumnName("idConductor");

                entity.Property(e => e.ApellidoConductor)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("apellidoConductor");

                entity.Property(e => e.CiudadConductorFk).HasColumnName("ciudadConductor_FK");

                entity.Property(e => e.EmailConductor)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("emailConductor");

                entity.Property(e => e.EstadoConductor)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("estadoConductor");

                entity.Property(e => e.GeneroConductorFk).HasColumnName("generoConductor_FK");

                entity.Property(e => e.MedioPagoFk).HasColumnName("medioPago_FK");

                entity.Property(e => e.NombreConductor)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombreConductor");

                entity.Property(e => e.PswConductor)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("pswConductor");

                entity.Property(e => e.VehiculoFk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("vehiculo_FK");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.HasKey(e => e.IdFile)
                    .HasName("PK__files__775AFE72EA7FA935");

                entity.ToTable("files");

                entity.Property(e => e.IdFile).HasColumnName("idFile");

                entity.Property(e => e.ExtensionFile)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("extensionFile");

                entity.Property(e => e.NombreFile)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreFile");

                entity.Property(e => e.TamanioFile).HasColumnName("tamanioFile");

                entity.Property(e => e.UbicacionFile)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ubicacionFile");

                entity.Property(e => e.VehiculoFk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("vehiculo_FK");

            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("PK__genero__85223DA3A7863CEC");

                entity.ToTable("genero");

                entity.Property(e => e.IdGenero)
                    .ValueGeneratedNever()
                    .HasColumnName("idGenero");

                entity.Property(e => e.Genero1)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("genero");
            });

            modelBuilder.Entity<MedioPago>(entity =>
            {
                entity.HasKey(e => e.IdMedioPago)
                    .HasName("PK__medioPag__4E20BBED3CB1FD3E");

                entity.ToTable("medioPago");

                entity.Property(e => e.IdMedioPago)
                    .ValueGeneratedNever()
                    .HasColumnName("idMedioPago");

                entity.Property(e => e.MedioPago1)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("medioPago");
            });

            modelBuilder.Entity<Mercancium>(entity =>
            {
                entity.HasKey(e => e.IdMercancia)
                    .HasName("PK__mercanci__D59657F345E6580C");

                entity.ToTable("mercancia");

                entity.Property(e => e.IdMercancia)
                    .ValueGeneratedNever()
                    .HasColumnName("idMercancia");

                entity.Property(e => e.ClienteFk).HasColumnName("cliente_FK");

                entity.Property(e => e.NombreMercancia)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombreMercancia");

                entity.Property(e => e.PesoMercancia)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("pesoMercancia");

                entity.Property(e => e.TipoMercanciaFk).HasColumnName("tipoMercancia_FK");

            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.IdServicio)
                    .HasName("PK__servicio__CEB98119BADCDBEB");

                entity.ToTable("servicio");

                entity.Property(e => e.IdServicio)
                    .ValueGeneratedNever()
                    .HasColumnName("idServicio");

                entity.Property(e => e.CiudadFk).HasColumnName("ciudad_FK");

                entity.Property(e => e.ConductorFk).HasColumnName("conductor_FK");

                entity.Property(e => e.DireccionDestino)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("direccionDestino");

                entity.Property(e => e.DireccionOrigen)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("direccionOrigen");

                entity.Property(e => e.FechaServicio)
                    .HasColumnType("date")
                    .HasColumnName("fechaServicio");

                entity.Property(e => e.MercanciaFk).HasColumnName("mercancia_FK");

                entity.Property(e => e.ValorServicio).HasColumnName("valorServicio");

            });

            modelBuilder.Entity<TipoMercancium>(entity =>
            {
                entity.HasKey(e => e.IdTipoMercancia)
                    .HasName("PK__tipoMerc__CEF6AC2BADE40C63");

                entity.ToTable("tipoMercancia");

                entity.Property(e => e.IdTipoMercancia)
                    .ValueGeneratedNever()
                    .HasColumnName("idTipoMercancia");

                entity.Property(e => e.TipoMercancia)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("tipoMercancia");
            });

            modelBuilder.Entity<TipoVehiculo>(entity =>
            {
                entity.HasKey(e => e.IdTipoVehiculo)
                    .HasName("PK__tipoVehi__429A3B816C431612");

                entity.ToTable("tipoVehiculo");

                entity.Property(e => e.IdTipoVehiculo)
                    .ValueGeneratedNever()
                    .HasColumnName("idTipoVehiculo");

                entity.Property(e => e.TipoVehiculo1)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("tipoVehiculo");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.IdVehiculo)
                    .HasName("PK__vehiculo__4868297073386A46");

                entity.ToTable("vehiculo");

                entity.Property(e => e.IdVehiculo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("idVehiculo");

                entity.Property(e => e.Capacidad)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("capacidad");

                entity.Property(e => e.ColorVehiculoFk).HasColumnName("colorVehiculo_FK");

                entity.Property(e => e.TipoVehiculoFk).HasColumnName("tipoVehiculo_FK");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
