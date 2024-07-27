using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JaMPeApp.Models
{
    public partial class GestionEmpContext : DbContext
    {
        public GestionEmpContext()
        {
        }

        public GestionEmpContext(DbContextOptions<GestionEmpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActivoFijo> ActivoFijos { get; set; } = null!;
        public virtual DbSet<AjustInventario> AjustInventarios { get; set; } = null!;
        public virtual DbSet<AjustInventarioDet> AjustInventarioDets { get; set; } = null!;
        public virtual DbSet<Almacen> Almacens { get; set; } = null!;
        public virtual DbSet<AlmacenAutoridad> AlmacenAutoridads { get; set; } = null!;
        public virtual DbSet<AnalisisCosto> AnalisisCostos { get; set; } = null!;
        public virtual DbSet<Articulo> Articulos { get; set; } = null!;
        public virtual DbSet<ArticuloAlmacen> ArticuloAlmacens { get; set; } = null!;
        public virtual DbSet<ArticuloAnalisisCosto> ArticuloAnalisisCostos { get; set; } = null!;
        public virtual DbSet<ArticuloAnalisisCostoDet> ArticuloAnalisisCostoDets { get; set; } = null!;
        public virtual DbSet<ArticuloMarinaMar> ArticuloMarinaMars { get; set; } = null!;
        public virtual DbSet<ArticuloPorKit> ArticuloPorKits { get; set; } = null!;
        public virtual DbSet<ArticuloSugerido> ArticuloSugeridos { get; set; } = null!;
        public virtual DbSet<ArticuloUnidad> ArticuloUnidads { get; set; } = null!;
        public virtual DbSet<AuditoriaFactura> AuditoriaFacturas { get; set; } = null!;
        public virtual DbSet<Autoridad> Autoridads { get; set; } = null!;
        public virtual DbSet<Banco> Bancos { get; set; } = null!;
        public virtual DbSet<Biene> Bienes { get; set; } = null!;
        public virtual DbSet<BienesEquipamiento> BienesEquipamientos { get; set; } = null!;
        public virtual DbSet<Billete> Billetes { get; set; } = null!;
        public virtual DbSet<Boton> Botons { get; set; } = null!;
        public virtual DbSet<CajaChica> CajaChicas { get; set; } = null!;
        public virtual DbSet<CajaChicaDet> CajaChicaDets { get; set; } = null!;
        public virtual DbSet<Carrocerium> Carroceria { get; set; } = null!;
        public virtual DbSet<Cheque> Cheques { get; set; } = null!;
        public virtual DbSet<ChequeActivo> ChequeActivos { get; set; } = null!;
        public virtual DbSet<ChequeCajaChica> ChequeCajaChicas { get; set; } = null!;
        public virtual DbSet<ChequeCompra> ChequeCompras { get; set; } = null!;
        public virtual DbSet<ChequeCuentum> ChequeCuenta { get; set; } = null!;
        public virtual DbSet<ChequeGasto> ChequeGastos { get; set; } = null!;
        public virtual DbSet<ChequeItbi> ChequeItbis { get; set; } = null!;
        public virtual DbSet<ChequePrestamo> ChequePrestamos { get; set; } = null!;
        public virtual DbSet<CierreCaja> CierreCajas { get; set; } = null!;
        public virtual DbSet<CierreCajaBillete> CierreCajaBilletes { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<ClienteDatosVehiculo> ClienteDatosVehiculos { get; set; } = null!;
        public virtual DbSet<ClientePlantilla> ClientePlantillas { get; set; } = null!;
        public virtual DbSet<ClienteRnc> ClienteRncs { get; set; } = null!;
        public virtual DbSet<ClienteTipo> ClienteTipos { get; set; } = null!;
        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<Comandum> Comanda { get; set; } = null!;
        public virtual DbSet<Combustible> Combustibles { get; set; } = null!;
        public virtual DbSet<Compra> Compras { get; set; } = null!;
        public virtual DbSet<CompraDet> CompraDets { get; set; } = null!;
        public virtual DbSet<Comprobante> Comprobantes { get; set; } = null!;
        public virtual DbSet<ComprobanteDisp> ComprobanteDisps { get; set; } = null!;
        public virtual DbSet<ComprobanteTipo> ComprobanteTipos { get; set; } = null!;
        public virtual DbSet<Conciliacion> Conciliacions { get; set; } = null!;
        public virtual DbSet<CondPago> CondPagos { get; set; } = null!;
        public virtual DbSet<Conversion> Conversions { get; set; } = null!;
        public virtual DbSet<ConversionDetalle> ConversionDetalles { get; set; } = null!;
        public virtual DbSet<Cotizacion> Cotizacions { get; set; } = null!;
        public virtual DbSet<CotizacionDet> CotizacionDets { get; set; } = null!;
        public virtual DbSet<CreditoAutorizado> CreditoAutorizados { get; set; } = null!;
        public virtual DbSet<Cuenta> Cuentas { get; set; } = null!;
        public virtual DbSet<Cuentum> Cuenta { get; set; } = null!;
        public virtual DbSet<CuotaDet> CuotaDets { get; set; } = null!;
        public virtual DbSet<CuotaTipoPago> CuotaTipoPagos { get; set; } = null!;
        public virtual DbSet<Cuotum> Cuota { get; set; } = null!;
        public virtual DbSet<Departamento> Departamentos { get; set; } = null!;
        public virtual DbSet<DepartamentoAutoridad> DepartamentoAutoridads { get; set; } = null!;
        public virtual DbSet<Deposito> Depositos { get; set; } = null!;
        public virtual DbSet<DepositoCierreCaja> DepositoCierreCajas { get; set; } = null!;
        public virtual DbSet<Depreciacion> Depreciacions { get; set; } = null!;
        public virtual DbSet<DespachoFactura> DespachoFacturas { get; set; } = null!;
        public virtual DbSet<DistribuirFactura> DistribuirFacturas { get; set; } = null!;
        public virtual DbSet<Efectivo> Efectivos { get; set; } = null!;
        public virtual DbSet<EfectivoAdelanto> EfectivoAdelantos { get; set; } = null!;
        public virtual DbSet<EfectivoCompra> EfectivoCompras { get; set; } = null!;
        public virtual DbSet<EfectivoGasto> EfectivoGastos { get; set; } = null!;
        public virtual DbSet<EntradaDiario> EntradaDiarios { get; set; } = null!;
        public virtual DbSet<EntradaDiarioAud> EntradaDiarioAuds { get; set; } = null!;
        public virtual DbSet<EntradaDiarioDet> EntradaDiarioDets { get; set; } = null!;
        public virtual DbSet<EntradaDiarioGen> EntradaDiarioGens { get; set; } = null!;
        public virtual DbSet<EntradasDeDiario> EntradasDeDiarios { get; set; } = null!;
        public virtual DbSet<Equipamiento> Equipamientos { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<FacturaAnuladaComentario> FacturaAnuladaComentarios { get; set; } = null!;
        public virtual DbSet<FacturaCombinacione> FacturaCombinaciones { get; set; } = null!;
        public virtual DbSet<FacturaDatosVehiculo> FacturaDatosVehiculos { get; set; } = null!;
        public virtual DbSet<FacturaDet> FacturaDets { get; set; } = null!;
        public virtual DbSet<FacturaDetAnuladum> FacturaDetAnulada { get; set; } = null!;
        public virtual DbSet<FacturaUsuairoPrefactura> FacturaUsuairoPrefacturas { get; set; } = null!;
        public virtual DbSet<FormatoFactura> FormatoFacturas { get; set; } = null!;
        public virtual DbSet<GananciaPerdidum> GananciaPerdida { get; set; } = null!;
        public virtual DbSet<Gasto> Gastos { get; set; } = null!;
        public virtual DbSet<General> Generals { get; set; } = null!;
        public virtual DbSet<GrupoReporte> GrupoReportes { get; set; } = null!;
        public virtual DbSet<GrupoReportesAutoridad> GrupoReportesAutoridads { get; set; } = null!;
        public virtual DbSet<Guarnicion> Guarnicions { get; set; } = null!;
        public virtual DbSet<Habitacion> Habitacions { get; set; } = null!;
        public virtual DbSet<ImpEtiquetum> ImpEtiqueta { get; set; } = null!;
        public virtual DbSet<ImpresionComanda> ImpresionComandas { get; set; } = null!;
        public virtual DbSet<Itbi> Itbis { get; set; } = null!;
        public virtual DbSet<LlamadasAgendum> LlamadasAgenda { get; set; } = null!;
        public virtual DbSet<LlamadasCliente> LlamadasClientes { get; set; } = null!;
        public virtual DbSet<LlamadasClientesCobro> LlamadasClientesCobros { get; set; } = null!;
        public virtual DbSet<LlamadasMotivo> LlamadasMotivos { get; set; } = null!;
        public virtual DbSet<LogErrore> LogErrores { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<MarcaModArt> MarcaModArts { get; set; } = null!;
        public virtual DbSet<MarcaVendedor> MarcaVendedors { get; set; } = null!;
        public virtual DbSet<MaterialesPorArticulo> MaterialesPorArticulos { get; set; } = null!;
        public virtual DbSet<Mesa> Mesas { get; set; } = null!;
        public virtual DbSet<Mesero> Meseros { get; set; } = null!;
        public virtual DbSet<Misc> Miscs { get; set; } = null!;
        public virtual DbSet<Modelo> Modelos { get; set; } = null!;
        public virtual DbSet<MovInventario> MovInventarios { get; set; } = null!;
        public virtual DbSet<Nacionalidad> Nacionalidads { get; set; } = null!;
        public virtual DbSet<NotaCr> NotaCrs { get; set; } = null!;
        public virtual DbSet<NotaCrDet> NotaCrDets { get; set; } = null!;
        public virtual DbSet<NotaDb> NotaDbs { get; set; } = null!;
        public virtual DbSet<NotaDbCompra> NotaDbCompras { get; set; } = null!;
        public virtual DbSet<NotaDbDet> NotaDbDets { get; set; } = null!;
        public virtual DbSet<Opestatus> Opestatuses { get; set; } = null!;
        public virtual DbSet<Oplog> Oplogs { get; set; } = null!;
        public virtual DbSet<OrdenCompra> OrdenCompras { get; set; } = null!;
        public virtual DbSet<OrdenCompraDet> OrdenCompraDets { get; set; } = null!;
        public virtual DbSet<OrdenProduccion> OrdenProduccions { get; set; } = null!;
        public virtual DbSet<OrdenProduccionArtUsado> OrdenProduccionArtUsados { get; set; } = null!;
        public virtual DbSet<OrdenProduccionImprimir> OrdenProduccionImprimirs { get; set; } = null!;
        public virtual DbSet<OrdenProduccionTemp> OrdenProduccionTemps { get; set; } = null!;
        public virtual DbSet<OrdenProduccionTempImprimir> OrdenProduccionTempImprimirs { get; set; } = null!;
        public virtual DbSet<Pantalla> Pantallas { get; set; } = null!;
        public virtual DbSet<PantallaAutoridad> PantallaAutoridads { get; set; } = null!;
        public virtual DbSet<Plan> Plans { get; set; } = null!;
        public virtual DbSet<Plantum> Planta { get; set; } = null!;
        public virtual DbSet<Precio> Precios { get; set; } = null!;
        public virtual DbSet<Prepago> Prepagos { get; set; } = null!;
        public virtual DbSet<PrepagoDet> PrepagoDets { get; set; } = null!;
        public virtual DbSet<Prestamo> Prestamos { get; set; } = null!;
        public virtual DbSet<Privilegio> Privilegios { get; set; } = null!;
        public virtual DbSet<Punto> Puntos { get; set; } = null!;
        public virtual DbSet<PuntoAutorizado> PuntoAutorizados { get; set; } = null!;
        public virtual DbSet<QCuentasAuxiliare> QCuentasAuxiliares { get; set; } = null!;
        public virtual DbSet<QCuentasCierreAnual> QCuentasCierreAnuals { get; set; } = null!;
        public virtual DbSet<QCuentasCierreMensual> QCuentasCierreMensuals { get; set; } = null!;
        public virtual DbSet<QCuentasEstado> QCuentasEstados { get; set; } = null!;
        public virtual DbSet<QEntradasDeDiario> QEntradasDeDiarios { get; set; } = null!;
        public virtual DbSet<QEntradasDeDiarioA1> QEntradasDeDiarioA1s { get; set; } = null!;
        public virtual DbSet<QEntradasDeDiarioA2> QEntradasDeDiarioA2s { get; set; } = null!;
        public virtual DbSet<QEntradasDeDiarioB> QEntradasDeDiarioBs { get; set; } = null!;
        public virtual DbSet<QEntradasDeDiarioBc> QEntradasDeDiarioBcs { get; set; } = null!;
        public virtual DbSet<QEntradasDeDiarioC> QEntradasDeDiarioCs { get; set; } = null!;
        public virtual DbSet<QEntradasDeDiarioGen> QEntradasDeDiarioGens { get; set; } = null!;
        public virtual DbSet<RecGasto> RecGastos { get; set; } = null!;
        public virtual DbSet<RecGastoNcnd> RecGastoNcnds { get; set; } = null!;
        public virtual DbSet<RecGastoRecurrente> RecGastoRecurrentes { get; set; } = null!;
        public virtual DbSet<ReciboCompra> ReciboCompras { get; set; } = null!;
        public virtual DbSet<ReciboPago> ReciboPagos { get; set; } = null!;
        public virtual DbSet<ReciboPagoDet> ReciboPagoDets { get; set; } = null!;
        public virtual DbSet<ReciboTipoPago> ReciboTipoPagos { get; set; } = null!;
        public virtual DbSet<Reporte> Reportes { get; set; } = null!;
        public virtual DbSet<ReqMovInventario> ReqMovInventarios { get; set; } = null!;
        public virtual DbSet<Reserva> Reservas { get; set; } = null!;
        public virtual DbSet<ReservaAnulada> ReservaAnuladas { get; set; } = null!;
        public virtual DbSet<ReservaDet> ReservaDets { get; set; } = null!;
        public virtual DbSet<ReservaHospedaje> ReservaHospedajes { get; set; } = null!;
        public virtual DbSet<Sala> Salas { get; set; } = null!;
        public virtual DbSet<SistemaActualizacion> SistemaActualizacions { get; set; } = null!;
        public virtual DbSet<Suplidor> Suplidors { get; set; } = null!;
        public virtual DbSet<SuplidorArticulo> SuplidorArticulos { get; set; } = null!;
        public virtual DbSet<Tarifa> Tarifas { get; set; } = null!;
        public virtual DbSet<TempCierreCajaBillete> TempCierreCajaBilletes { get; set; } = null!;
        public virtual DbSet<TipoActivoFijo> TipoActivoFijos { get; set; } = null!;
        public virtual DbSet<TipoBiene> TipoBienes { get; set; } = null!;
        public virtual DbSet<TipoHabitacion> TipoHabitacions { get; set; } = null!;
        public virtual DbSet<TipoHospedaje> TipoHospedajes { get; set; } = null!;
        public virtual DbSet<TipoPago> TipoPagos { get; set; } = null!;
        public virtual DbSet<Traccion> Traccions { get; set; } = null!;
        public virtual DbSet<Unidad> Unidads { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<UsuarioComputadora> UsuarioComputadoras { get; set; } = null!;
        public virtual DbSet<VArticulo> VArticulos { get; set; } = null!;
        public virtual DbSet<VArticulo1> VArticulos1 { get; set; } = null!;
        public virtual DbSet<VFactura> VFacturas { get; set; } = null!;
        public virtual DbSet<VOrigenCuentum> VOrigenCuenta { get; set; } = null!;
        public virtual DbSet<VRepLo1> VRepLo1s { get; set; } = null!;
        public virtual DbSet<VRepLo2> VRepLo2s { get; set; } = null!;
        public virtual DbSet<VRepLo3> VRepLo3s { get; set; } = null!;
        public virtual DbSet<VRepLo4> VRepLo4s { get; set; } = null!;
        public virtual DbSet<ValorCodigo> ValorCodigos { get; set; } = null!;
        public virtual DbSet<Vencimiento> Vencimientos { get; set; } = null!;
        public virtual DbSet<Vendedor> Vendedors { get; set; } = null!;
        public virtual DbSet<VistaEstadoCxC> VistaEstadoCxCs { get; set; } = null!;
        public virtual DbSet<VistaEstadoSuplidor> VistaEstadoSuplidors { get; set; } = null!;
        public virtual DbSet<VistaFacturaTipoPago> VistaFacturaTipoPagos { get; set; } = null!;
        public virtual DbSet<VistaFacturasRecibo> VistaFacturasRecibos { get; set; } = null!;
        public virtual DbSet<VistaFacturasSinCierre> VistaFacturasSinCierres { get; set; } = null!;
        public virtual DbSet<VistaGastosComprasNcf> VistaGastosComprasNcfs { get; set; } = null!;
        public virtual DbSet<VistaTipopagoCierrecaja> VistaTipopagoCierrecajas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Password=PedroJ85;Persist Security Info=True;User ID=sa;Initial Catalog=GestionEmp ;Data Source=DESKTOP-NCKVQ6L\\MSSQLSERVER2019", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivoFijo>(entity =>
            {
                entity.HasKey(e => e.ActivoFijoId)
                    .HasName("aaaaaActivoFijo_PK")
                    .IsClustered(false);

                entity.ToTable("ActivoFijo");

                entity.HasIndex(e => e.ActivoFijoId, "ActivoFijo_ID");

                entity.HasIndex(e => e.SuplidorId, "SuplidorActivoFijo");

                entity.HasIndex(e => e.SuplidorId, "Suplidor_ID");

                entity.HasIndex(e => e.TipoActivoFijoId, "TipoActivoFijoActivoFijo");

                entity.HasIndex(e => e.TipoActivoFijoId, "TipoActivoFijo_ID");

                entity.Property(e => e.ActivoFijoId).HasColumnName("ActivoFijo_ID");

                entity.Property(e => e.ActivoFijoBalance)
                    .HasColumnType("money")
                    .HasColumnName("ActivoFijo_Balance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ActivoFijoDepreciacionAnual)
                    .HasColumnName("ActivoFijo_DepreciacionAnual")
                    .HasDefaultValueSql("((0))")
                    .HasComment("% de depreciacion anual");

                entity.Property(e => e.ActivoFijoDepreciacionBalance)
                    .HasColumnType("money")
                    .HasColumnName("ActivoFijo_DepreciacionBalance")
                    .HasDefaultValueSql("((0))")
                    .HasComment("Monto Depreciado");

                entity.Property(e => e.ActivoFijoDesc)
                    .HasMaxLength(100)
                    .HasColumnName("ActivoFijo_Desc");

                entity.Property(e => e.ActivoFijoEstatus)
                    .HasColumnName("ActivoFijo_Estatus")
                    .HasComment("1=Activo, 0=Inactivo");

                entity.Property(e => e.ActivoFijoFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("ActivoFijo_Fecha")
                    .HasComment("Fecha de Adquisicion");

                entity.Property(e => e.ActivoFijoItbis)
                    .HasColumnType("money")
                    .HasColumnName("ActivoFijo_ITBIS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ActivoFijoNcf)
                    .HasMaxLength(50)
                    .HasColumnName("ActivoFijo_NCF");

                entity.Property(e => e.ActivoFijoSiCheque)
                    .HasColumnName("ActivoFijo_SiCheque")
                    .HasComment("Yes= tiene cheque No= No TIene Cheque");

                entity.Property(e => e.ActivoFijoValor)
                    .HasColumnType("money")
                    .HasColumnName("ActivoFijo_Valor")
                    .HasDefaultValueSql("((0))")
                    .HasComment("Valor del Activo Fijo");

                entity.Property(e => e.SuplidorId)
                    .HasColumnName("Suplidor_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TipoActivoFijoId)
                    .HasColumnName("TipoActivoFijo_ID")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Suplidor)
                    .WithMany(p => p.ActivoFijos)
                    .HasForeignKey(d => d.SuplidorId)
                    .HasConstraintName("ActivoFijo_FK00");

                entity.HasOne(d => d.TipoActivoFijo)
                    .WithMany(p => p.ActivoFijos)
                    .HasForeignKey(d => d.TipoActivoFijoId)
                    .HasConstraintName("ActivoFijo_FK01");
            });

            modelBuilder.Entity<AjustInventario>(entity =>
            {
                entity.ToTable("AjustInventario");

                entity.Property(e => e.AjustInventarioId).HasColumnName("AjustInventario_ID");

                entity.Property(e => e.AjustInventarioEstatus).HasColumnName("AjustInventario_Estatus");

                entity.Property(e => e.AjustInventarioFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("AjustInventario_Fecha");

                entity.Property(e => e.AjustInventarioFechaCierre)
                    .HasColumnType("datetime")
                    .HasColumnName("AjustInventario_FechaCierre");

                entity.Property(e => e.AjustInventarioMontoEntrada)
                    .HasColumnType("money")
                    .HasColumnName("AjustInventario_MontoEntrada");

                entity.Property(e => e.AjustInventarioMontoSalida)
                    .HasColumnType("money")
                    .HasColumnName("AjustInventario_MontoSalida");

                entity.Property(e => e.AjustInventarioNo).HasColumnName("AjustInventario_No");

                entity.Property(e => e.AlmacenId).HasColumnName("Almacen_ID");

                entity.Property(e => e.DepartamentoId).HasColumnName("Departamento_ID");

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");

                entity.HasOne(d => d.Almacen)
                    .WithMany(p => p.AjustInventarios)
                    .HasForeignKey(d => d.AlmacenId)
                    .HasConstraintName("FK_AjustInventario_Almacen");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.AjustInventarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_AjustInventario_Usuario");
            });

            modelBuilder.Entity<AjustInventarioDet>(entity =>
            {
                entity.ToTable("AjustInventarioDet");

                entity.Property(e => e.AjustInventarioDetId).HasColumnName("AjustInventarioDet_ID");

                entity.Property(e => e.AjustInventarioDetCantidad).HasColumnName("AjustInventarioDet_Cantidad");

                entity.Property(e => e.AjustInventarioDetCosto)
                    .HasColumnType("money")
                    .HasColumnName("AjustInventarioDet_Costo");

                entity.Property(e => e.AjustInventarioDetFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("AjustInventarioDet_Fecha");

                entity.Property(e => e.AjustInventarioId).HasColumnName("AjustInventario_ID");

                entity.Property(e => e.ArticuloId).HasColumnName("Articulo_ID");

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");

                entity.HasOne(d => d.AjustInventario)
                    .WithMany(p => p.AjustInventarioDets)
                    .HasForeignKey(d => d.AjustInventarioId)
                    .HasConstraintName("FK_AjustInventarioDet_AjustInventario");
            });

            modelBuilder.Entity<Almacen>(entity =>
            {
                entity.HasKey(e => e.AlmacenId)
                    .HasName("aaaaaAlmacen_PK")
                    .IsClustered(false);

                entity.ToTable("Almacen");

                entity.HasIndex(e => e.AlmacenId, "Marca_ID");

                entity.Property(e => e.AlmacenId).HasColumnName("Almacen_ID");

                entity.Property(e => e.AlmacenDesc)
                    .HasMaxLength(100)
                    .HasColumnName("Almacen_Desc");

                entity.Property(e => e.AlmacenPrecioNo).HasColumnName("Almacen_PrecioNo");
            });

            modelBuilder.Entity<AlmacenAutoridad>(entity =>
            {
                entity.HasKey(e => new { e.AlmacenId, e.AutoridadId })
                    .HasName("aaaaaAlmacen_Autoridad_PK")
                    .IsClustered(false);

                entity.ToTable("Almacen_Autoridad");

                entity.HasIndex(e => e.AutoridadId, "Autoridad_ID");

                entity.HasIndex(e => e.AlmacenId, "Departamento_ID");

                entity.Property(e => e.AlmacenId).HasColumnName("Almacen_ID");

                entity.Property(e => e.AutoridadId).HasColumnName("Autoridad_ID");
            });

            modelBuilder.Entity<AnalisisCosto>(entity =>
            {
                entity.ToTable("AnalisisCosto");

                entity.Property(e => e.AnalisisCostoId).HasColumnName("AnalisisCosto_ID");

                entity.Property(e => e.CocidaCosto).HasColumnType("money");

                entity.Property(e => e.CostoUnitario).HasColumnType("money");

                entity.Property(e => e.CotizacionId).HasColumnName("Cotizacion_ID");

                entity.Property(e => e.DescDestinoCosto).HasColumnType("money");

                entity.Property(e => e.DescMolinoCosto).HasColumnType("money");

                entity.Property(e => e.DietaCosto).HasColumnType("money");

                entity.Property(e => e.ImpuestoCosto).HasColumnType("money");

                entity.Property(e => e.LlenadaCosto).HasColumnType("money");

                entity.Property(e => e.MateriaPrimaCosto).HasColumnType("money");

                entity.Property(e => e.MoliendaCosto).HasColumnType("money");

                entity.Property(e => e.SacosCosto).HasColumnType("money");

                entity.Property(e => e.SubidaCosto).HasColumnType("money");

                entity.Property(e => e.TotalCosto).HasColumnType("money");

                entity.Property(e => e.TranCampoCosto).HasColumnType("money");

                entity.Property(e => e.TranDestinoCosto).HasColumnType("money");

                entity.HasOne(d => d.Cotizacion)
                    .WithMany(p => p.AnalisisCostos)
                    .HasForeignKey(d => d.CotizacionId)
                    .HasConstraintName("FK_AnalisisCosto_Cotizacion");
            });

            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => e.ArticuloId)
                    .HasName("aaaaaArticulo_PK")
                    .IsClustered(false);

                entity.ToTable("Articulo");

                entity.HasIndex(e => e.ArticuloId, "Articulo_ID");

                entity.HasIndex(e => e.DepartamentoId, "Departamento_ID");

                entity.HasIndex(e => e.MarcaId, "Marca_ID");

                entity.HasIndex(e => e.ModeloId, "Modelo_ID");

                entity.HasIndex(e => e.UnidadId, "Unidad_ID");

                entity.Property(e => e.ArticuloId).HasColumnName("Articulo_ID");

                entity.Property(e => e.ArticuloCd)
                    .HasMaxLength(30)
                    .HasColumnName("Articulo_CD");

                entity.Property(e => e.ArticuloConvertible).HasColumnName("Articulo_Convertible");

                entity.Property(e => e.ArticuloCosto).HasColumnName("Articulo_Costo");

                entity.Property(e => e.ArticuloCostoCodigo)
                    .HasMaxLength(50)
                    .HasColumnName("Articulo_CostoCodigo");

                entity.Property(e => e.ArticuloCostoProm).HasColumnName("Articulo_CostoProm");

                entity.Property(e => e.ArticuloDesc)
                    .HasMaxLength(80)
                    .HasColumnName("Articulo_Desc");

                entity.Property(e => e.ArticuloFabricado).HasColumnName("Articulo_Fabricado");

                entity.Property(e => e.ArticuloGanancia2).HasColumnName("Articulo_Ganancia2");

                entity.Property(e => e.ArticuloGananciaMinima).HasColumnName("Articulo_GananciaMinima");

                entity.Property(e => e.ArticuloIdArt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Articulo_IdArt");

                entity.Property(e => e.ArticuloImgRuta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Articulo_ImgRuta");

                entity.Property(e => e.ArticuloInventario).HasColumnName("Articulo_Inventario");

                entity.Property(e => e.ArticuloPartNo)
                    .HasMaxLength(30)
                    .HasColumnName("Articulo_PartNo");

                entity.Property(e => e.ArticuloSiComanda).HasColumnName("Articulo_SiComanda");

                entity.Property(e => e.ArticuloSiFactNegativo).HasColumnName("Articulo_SiFactNegativo");

                entity.Property(e => e.ArticuloSiGuarnicion).HasColumnName("Articulo_SiGuarnicion");

                entity.Property(e => e.ArticuloSiItbis).HasColumnName("Articulo_SiITBIS");

                entity.Property(e => e.ArticuloSiItbisincluido).HasColumnName("Articulo_SiITBISIncluido");

                entity.Property(e => e.ArticuloSiKit).HasColumnName("Articulo_SiKit");

                entity.Property(e => e.ArticuloSiPeso).HasColumnName("Articulo_SiPeso");

                entity.Property(e => e.ArticuloSiVencimiento).HasColumnName("Articulo_SiVencimiento");

                entity.Property(e => e.ArticuloStatus).HasColumnName("Articulo_Status");

                entity.Property(e => e.DepartamentoId).HasColumnName("Departamento_ID");

                entity.Property(e => e.MarcaId).HasColumnName("Marca_ID");

                entity.Property(e => e.ModeloId).HasColumnName("Modelo_ID");

                entity.Property(e => e.UnidadId).HasColumnName("Unidad_ID");

                entity.Property(e => e.UpsizeTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("upsize_ts");
            });

            modelBuilder.Entity<ArticuloAlmacen>(entity =>
            {
                entity.HasKey(e => new { e.ArticuloId, e.AlmacenId })
                    .HasName("aaaaaArticuloAlmacen_PK")
                    .IsClustered(false);

                entity.ToTable("ArticuloAlmacen");

                entity.HasIndex(e => e.AlmacenId, "Almacen_ID");

                entity.HasIndex(e => e.ArticuloId, "Articulo_ID");

                entity.Property(e => e.ArticuloId).HasColumnName("Articulo_ID");

                entity.Property(e => e.AlmacenId).HasColumnName("Almacen_ID");

                entity.Property(e => e.ArticuloAlmacenCantMaxima).HasColumnName("ArticuloAlmacen_CantMaxima");

                entity.Property(e => e.ArticuloAlmacenCantReOrden).HasColumnName("ArticuloAlmacen_CantReOrden");

                entity.Property(e => e.ArticuloAlmacenExistencia).HasColumnName("ArticuloAlmacen_Existencia");

                entity.Property(e => e.ArticuloAlmacenUbicacion)
                    .HasMaxLength(50)
                    .HasColumnName("ArticuloAlmacen_Ubicacion");

                entity.Property(e => e.UpsizeTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("upsize_ts");
            });

            modelBuilder.Entity<ArticuloAnalisisCosto>(entity =>
            {
                entity.ToTable("ArticuloAnalisisCosto");

                entity.Property(e => e.ArticuloAnalisisCostoId).HasColumnName("ArticuloAnalisisCosto_ID");

                entity.Property(e => e.ArticuloId).HasColumnName("Articulo_ID");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.LabelInfo1)
                    .HasColumnType("text")
                    .HasColumnName("Label_info_1");

                entity.Property(e => e.LabelInfo2)
                    .HasColumnType("text")
                    .HasColumnName("Label_info_2");

                entity.HasOne(d => d.Articulo)
                    .WithMany(p => p.ArticuloAnalisisCostos)
                    .HasForeignKey(d => d.ArticuloId)
                    .HasConstraintName("FK_ArticuloAnalisisCosto_Articulo");
            });

            modelBuilder.Entity<ArticuloAnalisisCostoDet>(entity =>
            {
                entity.ToTable("ArticuloAnalisisCostoDet");

                entity.Property(e => e.ArticuloAnalisisCostoDetId).HasColumnName("ArticuloAnalisisCostoDet_ID");

                entity.Property(e => e.ArticuloAnalisisCostoId).HasColumnName("ArticuloAnalisisCosto_ID");

                entity.Property(e => e.ArticuloId).HasColumnName("Articulo_ID");

                entity.Property(e => e.UnidadId).HasColumnName("Unidad_ID");

                entity.HasOne(d => d.ArticuloAnalisisCosto)
                    .WithMany(p => p.ArticuloAnalisisCostoDets)
                    .HasForeignKey(d => d.ArticuloAnalisisCostoId)
                    .HasConstraintName("FK_ArticuloAnalisisCostoDet_ArticuloAnalisisCosto");

                entity.HasOne(d => d.Articulo)
                    .WithMany(p => p.ArticuloAnalisisCostoDets)
                    .HasForeignKey(d => d.ArticuloId)
                    .HasConstraintName("FK_ArticuloAnalisisCostoDet_Articulo");

                entity.HasOne(d => d.Unidad)
                    .WithMany(p => p.ArticuloAnalisisCostoDets)
                    .HasForeignKey(d => d.UnidadId)
                    .HasConstraintName("FK_ArticuloAnalisisCostoDet_Unidad");
            });

            modelBuilder.Entity<ArticuloMarinaMar>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ArticuloMarinaMar");

                entity.Property(e => e.Costo).HasColumnName("Costo ");

                entity.Property(e => e.Descripción).HasMaxLength(255);

                entity.Property(e => e.Localización).HasMaxLength(255);

                entity.Property(e => e.Referencia).HasMaxLength(255);

                entity.Property(e => e.Unidad).HasMaxLength(255);
            });

            modelBuilder.Entity<ArticuloPorKit>(entity =>
            {
                entity.HasKey(e => e.ArticuloPorKitId)
                    .HasName("aaaaaArticuloPorKit_PK")
                    .IsClustered(false);

                entity.ToTable("ArticuloPorKit");

                entity.HasIndex(e => e.ArticuloPorKitId, "MaterialesPorArticulo_ID");

                entity.Property(e => e.ArticuloPorKitId).HasColumnName("ArticuloPorKit_ID");

                entity.Property(e => e.ArticuloIdHijo)
                    .HasColumnName("Articulo_ID_Hijo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ArticuloIdPadre)
                    .HasColumnName("Articulo_ID_Padre")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ArticuloPorKitCant)
                    .HasColumnName("ArticuloPorKit_Cant")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UnidadId).HasColumnName("Unidad_ID");

                entity.Property(e => e.UpsizeTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("upsize_ts");

                entity.HasOne(d => d.Unidad)
                    .WithMany(p => p.ArticuloPorKits)
                    .HasForeignKey(d => d.UnidadId)
                    .HasConstraintName("FK_ArticuloPorKit_Unidad");
            });

            modelBuilder.Entity<ArticuloSugerido>(entity =>
            {
                entity.HasKey(e => e.ArticuloSugeridoId)
                    .HasName("aaaaaArticuloSugerido_PK")
                    .IsClustered(false);

                entity.ToTable("ArticuloSugerido");

                entity.HasIndex(e => e.ArticuloSugeridoId, "ArticuloPorKit_ID")
                    .IsUnique();

                entity.Property(e => e.ArticuloSugeridoId).HasColumnName("ArticuloSugerido_ID");

                entity.Property(e => e.ArticuloIdHijo)
                    .HasColumnName("Articulo_ID_Hijo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ArticuloIdPadre)
                    .HasColumnName("Articulo_ID_Padre")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ArticuloSugeridoCant)
                    .HasColumnName("ArticuloSugerido_Cant")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpsizeTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("upsize_ts");
            });

            modelBuilder.Entity<ArticuloUnidad>(entity =>
            {
                entity.HasKey(e => new { e.ArticuloId, e.UnidadId })
                    .HasName("aaaaaArticuloUnidad_PK")
                    .IsClustered(false);

                entity.ToTable("ArticuloUnidad");

                entity.HasIndex(e => e.ArticuloId, "Articulo_ID");

                entity.HasIndex(e => e.UnidadId, "Unidad_ID");

                entity.Property(e => e.ArticuloId).HasColumnName("Articulo_ID");

                entity.Property(e => e.UnidadId).HasColumnName("Unidad_ID");

                entity.Property(e => e.ArticuloUnidadRatio).HasColumnName("ArticuloUnidad_Ratio");

                entity.Property(e => e.UpsizeTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("upsize_ts");
            });

            modelBuilder.Entity<AuditoriaFactura>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Auditoria_Factura");

                entity.Property(e => e.AlmacenId).HasColumnName("Almacen_ID");

                entity.Property(e => e.ClienteId).HasColumnName("Cliente_ID");

                entity.Property(e => e.ComprobanteTipoId).HasColumnName("ComprobanteTipo_ID");

                entity.Property(e => e.CondPagoId).HasColumnName("CondPago_ID");

                entity.Property(e => e.CreditoAutorizadoId).HasColumnName("CreditoAutorizado_ID");

                entity.Property(e => e.FacturaBalance)
                    .HasColumnType("money")
                    .HasColumnName("Factura_Balance");

                entity.Property(e => e.FacturaCliente)
                    .HasMaxLength(50)
                    .HasColumnName("Factura_Cliente");

                entity.Property(e => e.FacturaComentario)
                    .HasMaxLength(250)
                    .HasColumnName("Factura_Comentario");

                entity.Property(e => e.FacturaComprobante)
                    .HasMaxLength(20)
                    .HasColumnName("Factura_Comprobante");

                entity.Property(e => e.FacturaComprobanteFechaVen)
                    .HasColumnType("datetime")
                    .HasColumnName("Factura_ComprobanteFechaVen");

                entity.Property(e => e.FacturaDatos)
                    .HasMaxLength(150)
                    .HasColumnName("Factura_Datos");

                entity.Property(e => e.FacturaDescto)
                    .HasColumnType("money")
                    .HasColumnName("Factura_Descto");

                entity.Property(e => e.FacturaEstatus).HasColumnName("Factura_Estatus");

                entity.Property(e => e.FacturaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Factura_Fecha");

                entity.Property(e => e.FacturaFechaCierre)
                    .HasColumnType("datetime")
                    .HasColumnName("Factura_FechaCierre");

                entity.Property(e => e.FacturaFechaEntrega)
                    .HasColumnType("datetime")
                    .HasColumnName("Factura_FechaEntrega");

                entity.Property(e => e.FacturaFechaReAbre)
                    .HasColumnType("datetime")
                    .HasColumnName("Factura_FechaReAbre");

                entity.Property(e => e.FacturaId).HasColumnName("Factura_ID");

                entity.Property(e => e.FacturaItbis)
                    .HasColumnType("money")
                    .HasColumnName("Factura_ITBIS");

                entity.Property(e => e.FacturaMontoCambio)
                    .HasColumnType("money")
                    .HasColumnName("Factura_MontoCambio");

                entity.Property(e => e.FacturaMontoImpuesto)
                    .HasColumnType("money")
                    .HasColumnName("Factura_MontoImpuesto");

                entity.Property(e => e.FacturaMontoPagado)
                    .HasColumnType("money")
                    .HasColumnName("Factura_MontoPagado");

                entity.Property(e => e.FacturaMontoRetIsr)
                    .HasColumnType("money")
                    .HasColumnName("Factura_MontoRetISR");

                entity.Property(e => e.FacturaNif)
                    .HasMaxLength(16)
                    .HasColumnName("Factura_NIF");

                entity.Property(e => e.FacturaNo)
                    .HasMaxLength(20)
                    .HasColumnName("Factura_No");

                entity.Property(e => e.FacturaNoImpreso).HasColumnName("Factura_NoImpreso");

                entity.Property(e => e.FacturaNoImpresoPreFac).HasColumnName("Factura_NoImpresoPreFac");

                entity.Property(e => e.FacturaSiBeneficio).HasColumnName("Factura_SiBeneficio");

                entity.Property(e => e.FacturaSiCobrable).HasColumnName("Factura_SiCobrable");

                entity.Property(e => e.FacturaUsuarioCierra).HasColumnName("Factura_UsuarioCierra");

                entity.Property(e => e.FacturaUsuarioReAbre).HasColumnName("Factura_UsuarioReAbre");

                entity.Property(e => e.FechaCambio)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Cambio");

                entity.Property(e => e.HabitacionId).HasColumnName("Habitacion_ID");

                entity.Property(e => e.MesaId).HasColumnName("Mesa_ID");

                entity.Property(e => e.PcCambio)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PC_Cambio");

                entity.Property(e => e.ProgramaCambio)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Programa_Cambio");

                entity.Property(e => e.ReservaId).HasColumnName("Reserva_ID");

                entity.Property(e => e.Secuencia).ValueGeneratedOnAdd();

                entity.Property(e => e.UsuarioCambio).HasColumnName("Usuario_Cambio");

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");

                entity.Property(e => e.UsuarioIdAnulador).HasColumnName("Usuario_ID_Anulador");

                entity.Property(e => e.VendedorId).HasColumnName("Vendedor_ID");
            });

            modelBuilder.Entity<Autoridad>(entity =>
            {
                entity.HasKey(e => e.AutoridadId)
                    .HasName("aaaaaAutoridad_PK")
                    .IsClustered(false);

                entity.ToTable("Autoridad");

                entity.HasIndex(e => e.AutoridadId, "Autoridad_ID");

                entity.HasIndex(e => e.PantallaId, "PantallaAutoridad");

                entity.HasIndex(e => e.PantallaId, "Pantalla_ID");

                entity.Property(e => e.AutoridadId)
                    .ValueGeneratedNever()
                    .HasColumnName("Autoridad_ID");

                entity.Property(e => e.AutoridadDesc)
                    .HasMaxLength(25)
                    .HasColumnName("Autoridad_Desc");

                entity.Property(e => e.PantallaId).HasColumnName("Pantalla_ID");

                entity.HasOne(d => d.Pantalla)
                    .WithMany(p => p.Autoridads)
                    .HasForeignKey(d => d.PantallaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Autoridad_FK00");

                entity.HasMany(d => d.Privilegios)
                    .WithMany(p => p.Autoridads)
                    .UsingEntity<Dictionary<string, object>>(
                        "PrivilegiosAutoridad",
                        l => l.HasOne<Privilegio>().WithMany().HasForeignKey("PrivilegiosId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Privilegios_Autoridad_Privilegios"),
                        r => r.HasOne<Autoridad>().WithMany().HasForeignKey("AutoridadId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Privilegios_Autoridad_Privilegios_Autoridad"),
                        j =>
                        {
                            j.HasKey("AutoridadId", "PrivilegiosId");

                            j.ToTable("Privilegios_Autoridad");

                            j.IndexerProperty<short>("AutoridadId").HasColumnName("Autoridad_ID");

                            j.IndexerProperty<short>("PrivilegiosId").HasColumnName("Privilegios_ID");
                        });
            });

            modelBuilder.Entity<Banco>(entity =>
            {
                entity.HasKey(e => e.BancoId)
                    .HasName("aaaaaBanco_PK")
                    .IsClustered(false);

                entity.ToTable("Banco");

                entity.HasIndex(e => e.BancoId, "Banco_ID");

                entity.HasIndex(e => e.CuentaId, "CuentaBanco");

                entity.HasIndex(e => e.CuentaId, "Cuenta_ID");

                entity.Property(e => e.BancoId).HasColumnName("Banco_ID");

                entity.Property(e => e.BancoBalance)
                    .HasColumnType("money")
                    .HasColumnName("Banco_Balance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BancoCta)
                    .HasMaxLength(50)
                    .HasColumnName("Banco_Cta");

                entity.Property(e => e.BancoEstatus).HasColumnName("Banco_Estatus");

                entity.Property(e => e.BancoNoCheque)
                    .HasColumnName("Banco_NoCheque")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BancoNoTrans)
                    .HasColumnName("Banco_NoTrans")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BancoNombre)
                    .HasMaxLength(50)
                    .HasColumnName("Banco_Nombre");

                entity.Property(e => e.CuentaId)
                    .HasColumnName("Cuenta_ID")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Cuenta)
                    .WithMany(p => p.Bancos)
                    .HasForeignKey(d => d.CuentaId)
                    .HasConstraintName("Banco_FK00");
            });

            modelBuilder.Entity<Biene>(entity =>
            {
                entity.HasKey(e => e.BienesId);

                entity.Property(e => e.BienesId).HasColumnName("Bienes_ID");

                entity.Property(e => e.BienesDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Bienes_Desc");

                entity.Property(e => e.BienesEstatus).HasColumnName("Bienes_Estatus");

                entity.Property(e => e.BienesImgRuta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Bienes_ImgRuta");

                entity.Property(e => e.CarroceriaId).HasColumnName("Carroceria_ID");

                entity.Property(e => e.Cilindrada)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ColorId).HasColumnName("Color_ID");

                entity.Property(e => e.CombustibleId).HasColumnName("Combustible_ID");

                entity.Property(e => e.Kilometraje)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MarcaId).HasColumnName("Marca_ID");

                entity.Property(e => e.ModeloId).HasColumnName("Modelo_ID");

                entity.Property(e => e.NumChasi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumMotor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PolizaSeguro)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoBienesId).HasColumnName("TipoBienes_ID");

                entity.Property(e => e.TraccionId).HasColumnName("Traccion_ID");

                entity.Property(e => e.Version)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BienesEquipamiento>(entity =>
            {
                entity.HasKey(e => new { e.EquipamientoId, e.BienesId });

                entity.Property(e => e.EquipamientoId).HasColumnName("Equipamiento_ID");

                entity.Property(e => e.BienesId).HasColumnName("Bienes_ID");

                entity.Property(e => e.EquipamentoCantidad).HasColumnName("Equipamento_Cantidad");

                entity.HasOne(d => d.Bienes)
                    .WithMany(p => p.BienesEquipamientos)
                    .HasForeignKey(d => d.BienesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BienesEquipamientos_Bienes");

                entity.HasOne(d => d.Equipamiento)
                    .WithMany(p => p.BienesEquipamientos)
                    .HasForeignKey(d => d.EquipamientoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BienesEquipamientos_Equipamiento");
            });

            modelBuilder.Entity<Billete>(entity =>
            {
                entity.ToTable("Billete");

                entity.Property(e => e.BilleteId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Billete_ID");

                entity.Property(e => e.BilleteValor).HasColumnName("Billete_Valor");
            });

            modelBuilder.Entity<Boton>(entity =>
            {
                entity.HasKey(e => new { e.AutoridadId, e.PantallaId })
                    .HasName("aaaaaBoton_PK")
                    .IsClustered(false);

                entity.ToTable("Boton");

                entity.HasIndex(e => e.AutoridadId, "AutoridadBoton");

                entity.HasIndex(e => e.AutoridadId, "Autoridad_ID");

                entity.HasIndex(e => e.PantallaId, "PantallaBoton");

                entity.HasIndex(e => e.PantallaId, "Pantalla_ID");

                entity.Property(e => e.AutoridadId).HasColumnName("Autoridad_ID");

                entity.Property(e => e.PantallaId).HasColumnName("Pantalla_ID");
            });

            modelBuilder.Entity<CajaChica>(entity =>
            {
                entity.HasKey(e => e.CajaChicaId)
                    .HasName("aaaaaCajaChica_PK")
                    .IsClustered(false);

                entity.ToTable("CajaChica");

                entity.HasIndex(e => e.CajaChicaId, "CajaChica_ID");

                entity.Property(e => e.CajaChicaId).HasColumnName("CajaChica_ID");

                entity.Property(e => e.CajaChicaBalance)
                    .HasColumnType("money")
                    .HasColumnName("CajaChica_Balance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CajaChicaEstatus).HasColumnName("CajaChica_Estatus");

                entity.Property(e => e.CajaChicaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("CajaChica_Fecha");

                entity.Property(e => e.CajaChicaMonto)
                    .HasColumnType("money")
                    .HasColumnName("CajaChica_Monto")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<CajaChicaDet>(entity =>
            {
                entity.HasKey(e => e.CajaChicaDetId)
                    .HasName("aaaaaCajaChicaDet_PK")
                    .IsClustered(false);

                entity.ToTable("CajaChicaDet");

                entity.HasIndex(e => e.CajaChicaId, "CajaChicaCajaChicaDet");

                entity.HasIndex(e => e.CajaChicaDetId, "CajaChicaDet_ID");

                entity.HasIndex(e => e.CajaChicaId, "CajaChica_ID");

                entity.HasIndex(e => e.GastoId, "GastoCajaChicaDet");

                entity.HasIndex(e => e.GastoId, "Gasto_ID");

                entity.Property(e => e.CajaChicaDetId).HasColumnName("CajaChicaDet_ID");

                entity.Property(e => e.CajaChicaDetComentario)
                    .HasMaxLength(100)
                    .HasColumnName("CajaChicaDet_Comentario");

                entity.Property(e => e.CajaChicaDetFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("CajaChicaDet_Fecha");

                entity.Property(e => e.CajaChicaDetItbis)
                    .HasColumnType("money")
                    .HasColumnName("CajaChicaDet_ITBIS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CajaChicaDetMonto)
                    .HasColumnType("money")
                    .HasColumnName("CajaChicaDet_Monto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CajaChicaDetNcf)
                    .HasMaxLength(50)
                    .HasColumnName("CajaChicaDet_NCF");

                entity.Property(e => e.CajaChicaDetSiBeneficio).HasColumnName("CajaChicaDet_SiBeneficio");

                entity.Property(e => e.CajaChicaId)
                    .HasColumnName("CajaChica_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GastoId)
                    .HasColumnName("Gasto_ID")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.CajaChica)
                    .WithMany(p => p.CajaChicaDets)
                    .HasForeignKey(d => d.CajaChicaId)
                    .HasConstraintName("CajaChicaDet_FK00");

                entity.HasOne(d => d.Gasto)
                    .WithMany(p => p.CajaChicaDets)
                    .HasForeignKey(d => d.GastoId)
                    .HasConstraintName("CajaChicaDet_FK01");
            });

            modelBuilder.Entity<Carrocerium>(entity =>
            {
                entity.HasKey(e => e.CarroceriaId);

                entity.Property(e => e.CarroceriaId).HasColumnName("Carroceria_ID");

                entity.Property(e => e.CarroceriaDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Carroceria_Desc");

                entity.Property(e => e.CarroceriaEstatus).HasColumnName("Carroceria_Estatus");

                entity.Property(e => e.SucursalId).HasColumnName("Sucursal_ID");
            });

            modelBuilder.Entity<Cheque>(entity =>
            {
                entity.HasKey(e => e.ChequeId)
                    .HasName("aaaaaCheque_PK")
                    .IsClustered(false);

                entity.ToTable("Cheque");

                entity.HasIndex(e => e.BancoId, "BancoCheque");

                entity.HasIndex(e => e.BancoId, "Banco_ID");

                entity.HasIndex(e => e.ChequeId, "Cheque_ID");

                entity.HasIndex(e => e.SuplidorId, "SuplidorCheque");

                entity.HasIndex(e => e.SuplidorId, "Suplidor_ID");

                entity.Property(e => e.ChequeId).HasColumnName("Cheque_ID");

                entity.Property(e => e.BancoId)
                    .HasColumnName("Banco_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ChequeAnulado).HasColumnName("Cheque_Anulado");

                entity.Property(e => e.ChequeBeneficiario)
                    .HasMaxLength(100)
                    .HasColumnName("Cheque_Beneficiario");

                entity.Property(e => e.ChequeConcepto)
                    .HasMaxLength(100)
                    .HasColumnName("Cheque_Concepto");

                entity.Property(e => e.ChequeConciliacion)
                    .HasMaxLength(7)
                    .HasColumnName("Cheque_Conciliacion");

                entity.Property(e => e.ChequeFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Cheque_Fecha");

                entity.Property(e => e.ChequeNo)
                    .HasColumnName("Cheque_No")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ChequePrinted).HasColumnName("Cheque_Printed");

                entity.Property(e => e.ChequeValor)
                    .HasColumnType("money")
                    .HasColumnName("Cheque_Valor")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SuplidorId)
                    .HasColumnName("Suplidor_ID")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Banco)
                    .WithMany(p => p.Cheques)
                    .HasForeignKey(d => d.BancoId)
                    .HasConstraintName("Cheque_FK00");

                entity.HasOne(d => d.Suplidor)
                    .WithMany(p => p.Cheques)
                    .HasForeignKey(d => d.SuplidorId)
                    .HasConstraintName("Cheque_FK01");
            });

            modelBuilder.Entity<ChequeActivo>(entity =>
            {
                entity.HasKey(e => new { e.ChequeId, e.ChequeLinAf })
                    .HasName("aaaaaChequeActivo_PK")
                    .IsClustered(false);

                entity.ToTable("ChequeActivo");

                entity.HasIndex(e => e.ActivoFijoId, "ActivoFijoChequeActivo");

                entity.HasIndex(e => e.ChequeId, "ChequeChequeActivo");

                entity.HasIndex(e => e.ChequeId, "Cheque_ID");

                entity.HasIndex(e => e.ActivoFijoId, "Gastos_ID");

                entity.Property(e => e.ChequeId).HasColumnName("Cheque_ID");

                entity.Property(e => e.ChequeLinAf)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Cheque_LinAF");

                entity.Property(e => e.ActivoFijoId)
                    .HasColumnName("ActivoFijo_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ChequeMontoAf)
                    .HasColumnType("money")
                    .HasColumnName("Cheque_MontoAF")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<ChequeCajaChica>(entity =>
            {
                entity.HasKey(e => new { e.ChequeId, e.ChequeLinCc })
                    .HasName("aaaaaChequeCajaChica_PK")
                    .IsClustered(false);

                entity.ToTable("ChequeCajaChica");

                entity.HasIndex(e => e.CajaChicaId, "CajaChicaChequeCajaChica");

                entity.HasIndex(e => e.ChequeId, "ChequeChequeCajaChica");

                entity.HasIndex(e => e.ChequeId, "Cheque_ID");

                entity.HasIndex(e => e.CajaChicaId, "Gastos_ID");

                entity.Property(e => e.ChequeId).HasColumnName("Cheque_ID");

                entity.Property(e => e.ChequeLinCc)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Cheque_LinCC");

                entity.Property(e => e.CajaChicaId)
                    .HasColumnName("CajaChica_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ChequeMontoCc)
                    .HasColumnType("money")
                    .HasColumnName("Cheque_MontoCC")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.CajaChica)
                    .WithMany(p => p.ChequeCajaChicas)
                    .HasForeignKey(d => d.CajaChicaId)
                    .HasConstraintName("ChequeCajaChica_FK00");

                entity.HasOne(d => d.Cheque)
                    .WithMany(p => p.ChequeCajaChicas)
                    .HasForeignKey(d => d.ChequeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ChequeCajaChica_FK01");
            });

            modelBuilder.Entity<ChequeCompra>(entity =>
            {
                entity.HasKey(e => new { e.ChequeId, e.ChequeLinCi })
                    .HasName("aaaaaChequeCompras_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.ChequeId, "ChequeChequeCompras");

                entity.HasIndex(e => e.CompraId, "ChequeDetCompra_ID");

                entity.HasIndex(e => e.ChequeId, "Cheque_ID");

                entity.HasIndex(e => e.CompraId, "CompraChequeCompras");

                entity.Property(e => e.ChequeId).HasColumnName("Cheque_ID");

                entity.Property(e => e.ChequeLinCi)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Cheque_LinCI");

                entity.Property(e => e.ChequeDesctoCi)
                    .HasColumnType("money")
                    .HasColumnName("Cheque_DesctoCI")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ChequeMontoCi)
                    .HasColumnType("money")
                    .HasColumnName("Cheque_MontoCI")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompraId)
                    .HasColumnName("Compra_ID")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Cheque)
                    .WithMany(p => p.ChequeCompras)
                    .HasForeignKey(d => d.ChequeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ChequeCompras_FK00");

                entity.HasOne(d => d.Compra)
                    .WithMany(p => p.ChequeCompras)
                    .HasForeignKey(d => d.CompraId)
                    .HasConstraintName("ChequeCompras_FK01");
            });

            modelBuilder.Entity<ChequeCuentum>(entity =>
            {
                entity.HasKey(e => new { e.ChequeId, e.ChequeLinCta })
                    .HasName("aaaaaChequeCuenta_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.ChequeId, "ChequeChequeCuenta");

                entity.HasIndex(e => e.ChequeId, "Cheque_ID");

                entity.HasIndex(e => e.CuentaId, "CuentaChequeCuenta");

                entity.HasIndex(e => e.CuentaId, "Cuenta_ID");

                entity.Property(e => e.ChequeId).HasColumnName("Cheque_ID");

                entity.Property(e => e.ChequeLinCta)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Cheque_LinCta");

                entity.Property(e => e.ChequeMontoCta)
                    .HasColumnType("money")
                    .HasColumnName("Cheque_MontoCta")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentaId)
                    .HasColumnName("Cuenta_ID")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<ChequeGasto>(entity =>
            {
                entity.HasKey(e => new { e.ChequeId, e.ChequeLinGa })
                    .HasName("aaaaaChequeGastos_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.ChequeId, "ChequeChequeGastos");

                entity.HasIndex(e => e.RecGastoId, "ChequeDetCompra_ID");

                entity.HasIndex(e => e.ChequeId, "Cheque_ID");

                entity.HasIndex(e => e.RecGastoId, "RecGastoChequeGastos");

                entity.Property(e => e.ChequeId).HasColumnName("Cheque_ID");

                entity.Property(e => e.ChequeLinGa)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Cheque_LinGA");

                entity.Property(e => e.ChequeMontoGa)
                    .HasColumnType("money")
                    .HasColumnName("Cheque_MontoGA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RecGastoId)
                    .HasColumnName("RecGasto_ID")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Cheque)
                    .WithMany(p => p.ChequeGastos)
                    .HasForeignKey(d => d.ChequeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ChequeGastos_FK00");

                entity.HasOne(d => d.RecGasto)
                    .WithMany(p => p.ChequeGastos)
                    .HasForeignKey(d => d.RecGastoId)
                    .HasConstraintName("ChequeGastos_FK01");
            });

            modelBuilder.Entity<ChequeItbi>(entity =>
            {
                entity.HasKey(e => new { e.ChequeId, e.ChequeLinIt })
                    .HasName("aaaaaChequeITBIS_PK")
                    .IsClustered(false);

                entity.ToTable("ChequeITBIS");

                entity.HasIndex(e => e.ChequeId, "ChequeChequeITBIS");

                entity.HasIndex(e => e.ItbisId, "ChequeDetCompra_ID");

                entity.HasIndex(e => e.ChequeId, "Cheque_ID");

                entity.HasIndex(e => e.ItbisId, "ITBISChequeITBIS");

                entity.Property(e => e.ChequeId).HasColumnName("Cheque_ID");

                entity.Property(e => e.ChequeLinIt)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Cheque_LinIT");

                entity.Property(e => e.ChequeMontoIt)
                    .HasColumnType("money")
                    .HasColumnName("Cheque_MontoIT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ItbisId)
                    .HasColumnName("ITBIS_ID")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Cheque)
                    .WithMany(p => p.ChequeItbis)
                    .HasForeignKey(d => d.ChequeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ChequeITBIS_FK00");

                entity.HasOne(d => d.Itbis)
                    .WithMany(p => p.ChequeItbis)
                    .HasForeignKey(d => d.ItbisId)
                    .HasConstraintName("ChequeITBIS_FK01");
            });

            modelBuilder.Entity<ChequePrestamo>(entity =>
            {
                entity.HasKey(e => new { e.ChequeId, e.ChequeLinPr })
                    .HasName("aaaaaChequePrestamos_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.ChequeId, "ChequeChequePrestamos");

                entity.HasIndex(e => e.PrestamoId, "ChequeDetCompra_ID");

                entity.HasIndex(e => e.ChequeId, "Cheque_ID");

                entity.HasIndex(e => e.PrestamoId, "PrestamoChequePrestamos");

                entity.Property(e => e.ChequeId).HasColumnName("Cheque_ID");

                entity.Property(e => e.ChequeLinPr)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Cheque_LinPR");

                entity.Property(e => e.ChequeMontoPr)
                    .HasColumnType("money")
                    .HasColumnName("Cheque_MontoPR")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PrestamoId)
                    .HasColumnName("Prestamo_ID")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Cheque)
                    .WithMany(p => p.ChequePrestamos)
                    .HasForeignKey(d => d.ChequeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ChequePrestamos_FK00");

                entity.HasOne(d => d.Prestamo)
                    .WithMany(p => p.ChequePrestamos)
                    .HasForeignKey(d => d.PrestamoId)
                    .HasConstraintName("ChequePrestamos_FK01");
            });

            modelBuilder.Entity<CierreCaja>(entity =>
            {
                entity.HasKey(e => e.CierreCajaId)
                    .HasName("aaaaaCierreCaja_PK")
                    .IsClustered(false);

                entity.ToTable("CierreCaja");

                entity.HasIndex(e => e.CierreCajaId, "CierreCaja_ID");

                entity.HasIndex(e => e.DepositoId, "Deposito_ID");

                entity.HasIndex(e => e.UsuarioId, "UsuarioCierreCaja");

                entity.HasIndex(e => e.UsuarioId, "Usuario_ID");

                entity.Property(e => e.CierreCajaId).HasColumnName("CierreCaja_ID");

                entity.Property(e => e.CierreCajaCerrada).HasColumnName("CierreCaja_Cerrada");

                entity.Property(e => e.CierreCajaEfectivoCajero)
                    .HasColumnType("money")
                    .HasColumnName("CierreCaja_EfectivoCajero");

                entity.Property(e => e.CierreCajaEfectivoSistema)
                    .HasColumnType("money")
                    .HasColumnName("CierreCaja_EfectivoSistema");

                entity.Property(e => e.CierreCajaFechaFinal)
                    .HasColumnType("datetime")
                    .HasColumnName("CierreCaja_FechaFinal");

                entity.Property(e => e.CierreCajaFechaHora)
                    .HasColumnType("datetime")
                    .HasColumnName("CierreCaja_FechaHora");

                entity.Property(e => e.CierreCajaFechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("CierreCaja_FechaInicio");

                entity.Property(e => e.CierreCajaMonto)
                    .HasColumnType("money")
                    .HasColumnName("CierreCaja_Monto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CierreCajaMontoNc)
                    .HasColumnType("money")
                    .HasColumnName("CierreCaja_MontoNC")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CierreCajaMontoPagoEfectivo)
                    .HasColumnType("money")
                    .HasColumnName("CierreCaja_MontoPagoEfectivo");

                entity.Property(e => e.CierreCajaMontoPrePago)
                    .HasColumnType("money")
                    .HasColumnName("CierreCaja_MontoPrePago");

                entity.Property(e => e.CierreCajaMontoUsado)
                    .HasColumnType("money")
                    .HasColumnName("CierreCaja_MontoUsado")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CierreCajaSaldoInicial)
                    .HasColumnType("money")
                    .HasColumnName("CierreCaja_SaldoInicial");

                entity.Property(e => e.DepositoId)
                    .HasColumnName("Deposito_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UsuarioId)
                    .HasColumnName("Usuario_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UsuarioIdCierre).HasColumnName("Usuario_ID_Cierre");

                entity.Property(e => e.UsuarioIdReAbre).HasColumnName("Usuario_ID_ReAbre");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.CierreCajas)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("CierreCaja_FK00");
            });

            modelBuilder.Entity<CierreCajaBillete>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BilleteId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Billete_ID");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CierreCajaId).HasColumnName("CierreCaja_ID");

                entity.HasOne(d => d.Billete)
                    .WithMany()
                    .HasForeignKey(d => d.BilleteId)
                    .HasConstraintName("FK_CierreCajaBilletes_Billete");

                entity.HasOne(d => d.CierreCaja)
                    .WithMany()
                    .HasForeignKey(d => d.CierreCajaId)
                    .HasConstraintName("FK_CierreCajaBilletes_CierreCaja");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.ClienteId)
                    .HasName("aaaaaCliente_PK")
                    .IsClustered(false);

                entity.ToTable("Cliente");

                entity.HasIndex(e => e.ClienteTipoId, "ClienteTIpo_ID");

                entity.HasIndex(e => e.ClienteTipoId, "ClienteTipoCliente");

                entity.HasIndex(e => e.ClienteId, "Cliente_ID");

                entity.HasIndex(e => e.ComprobanteTipoId, "ComprobanteTipo_ID");

                entity.HasIndex(e => e.CondPagoId, "CondPagoCliente");

                entity.HasIndex(e => e.CondPagoId, "CondPago_ID");

                entity.HasIndex(e => e.PlanId, "Plan_ID");

                entity.HasIndex(e => e.VendedorId, "VendedorCliente");

                entity.HasIndex(e => e.VendedorId, "Vendedor_ID");

                entity.Property(e => e.ClienteId).HasColumnName("Cliente_ID");

                entity.Property(e => e.ClienteAutCredito).HasColumnName("Cliente_AutCredito");

                entity.Property(e => e.ClienteBalance)
                    .HasColumnType("money")
                    .HasColumnName("Cliente_Balance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ClienteCedula)
                    .HasMaxLength(20)
                    .HasColumnName("Cliente_Cedula");

                entity.Property(e => e.ClienteCodigo)
                    .HasMaxLength(20)
                    .HasColumnName("Cliente_Codigo");

                entity.Property(e => e.ClienteComentario)
                    .HasMaxLength(255)
                    .HasColumnName("Cliente_Comentario");

                entity.Property(e => e.ClienteContacto)
                    .HasMaxLength(50)
                    .HasColumnName("Cliente_Contacto");

                entity.Property(e => e.ClienteDescto)
                    .HasColumnName("Cliente_Descto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ClienteDir1)
                    .HasMaxLength(50)
                    .HasColumnName("Cliente_Dir1");

                entity.Property(e => e.ClienteDir2)
                    .HasMaxLength(50)
                    .HasColumnName("Cliente_Dir2");

                entity.Property(e => e.ClienteEmail)
                    .HasMaxLength(50)
                    .HasColumnName("Cliente_Email");

                entity.Property(e => e.ClienteFax)
                    .HasMaxLength(13)
                    .HasColumnName("Cliente_Fax");

                entity.Property(e => e.ClienteLimiteCredito)
                    .HasColumnType("money")
                    .HasColumnName("Cliente_LimiteCredito")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ClienteNombre)
                    .HasMaxLength(50)
                    .HasColumnName("Cliente_Nombre");

                entity.Property(e => e.ClientePrecioNo).HasColumnName("Cliente_PrecioNo");

                entity.Property(e => e.ClienteSiRetieneIsr).HasColumnName("Cliente_SiRetieneISR");

                entity.Property(e => e.ClienteStatus).HasColumnName("Cliente_Status");

                entity.Property(e => e.ClienteTel)
                    .HasMaxLength(13)
                    .HasColumnName("Cliente_Tel");

                entity.Property(e => e.ClienteTipoId)
                    .HasColumnName("ClienteTipo_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ClienteTotalPuntos).HasColumnName("Cliente_TotalPuntos");

                entity.Property(e => e.ComprobanteTipoId).HasColumnName("ComprobanteTipo_ID");

                entity.Property(e => e.CondPagoId)
                    .HasColumnName("CondPago_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PlanId).HasColumnName("Plan_ID");

                entity.Property(e => e.VendedorId)
                    .HasColumnName("Vendedor_ID")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.ClienteTipo)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.ClienteTipoId)
                    .HasConstraintName("Cliente_FK00");

                entity.HasOne(d => d.CondPago)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.CondPagoId)
                    .HasConstraintName("Cliente_FK01");

                entity.HasOne(d => d.Vendedor)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.VendedorId)
                    .HasConstraintName("Cliente_FK02");
            });

            modelBuilder.Entity<ClienteDatosVehiculo>(entity =>
            {
                entity.HasKey(e => e.ClienteId)
                    .HasName("aaaaaCliente_DatosVehiculo_PK")
                    .IsClustered(false);

                entity.ToTable("Cliente_DatosVehiculo");

                entity.HasIndex(e => e.ClienteId, "ClienteCliente_DatosVehiculo")
                    .IsUnique();

                entity.HasIndex(e => e.ClienteId, "Factura_ID")
                    .IsUnique();

                entity.Property(e => e.ClienteId)
                    .ValueGeneratedNever()
                    .HasColumnName("Cliente_ID");

                entity.Property(e => e.ClienteDatosVehiculoAno)
                    .HasMaxLength(255)
                    .HasColumnName("ClienteDatosVehiculo_Ano");

                entity.Property(e => e.ClienteDatosVehiculoChasis)
                    .HasMaxLength(255)
                    .HasColumnName("ClienteDatosVehiculo_Chasis");

                entity.Property(e => e.ClienteDatosVehiculoMarca)
                    .HasMaxLength(255)
                    .HasColumnName("ClienteDatosVehiculo_Marca");

                entity.Property(e => e.ClienteDatosVehiculoModelo)
                    .HasMaxLength(255)
                    .HasColumnName("ClienteDatosVehiculo_Modelo");

                entity.HasOne(d => d.Cliente)
                    .WithOne(p => p.ClienteDatosVehiculo)
                    .HasForeignKey<ClienteDatosVehiculo>(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Cliente_DatosVehiculo_FK00");
            });

            modelBuilder.Entity<ClientePlantilla>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Cliente_Plantilla");

                entity.Property(e => e.ClientePrecioNo).HasColumnName("Cliente_PrecioNo");

                entity.Property(e => e.ClienteTipoId).HasColumnName("ClienteTipo_ID");

                entity.Property(e => e.ComprobanteTipoId).HasColumnName("ComprobanteTipo_ID");

                entity.Property(e => e.CondPagoId).HasColumnName("CondPago_ID");

                entity.Property(e => e.PlanId).HasColumnName("Plan_ID");
            });

            modelBuilder.Entity<ClienteRnc>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Cliente_RNC");

                entity.Property(e => e.ClienteDireccion1)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Cliente_Direccion1");

                entity.Property(e => e.ClienteDireccion2)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Cliente_Direccion2");

                entity.Property(e => e.ClienteNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Cliente_Nombre");

                entity.Property(e => e.ClienteRnc1)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("Cliente_RNC");

                entity.Property(e => e.ClienteTelefono)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Cliente_Telefono");
            });

            modelBuilder.Entity<ClienteTipo>(entity =>
            {
                entity.HasKey(e => e.ClienteTipoId)
                    .HasName("aaaaaClienteTipo_PK")
                    .IsClustered(false);

                entity.ToTable("ClienteTipo");

                entity.HasIndex(e => e.ClienteTipoId, "ClienteTipo_ID");

                entity.Property(e => e.ClienteTipoId).HasColumnName("ClienteTipo_ID");

                entity.Property(e => e.ClienteTipoDesc)
                    .HasMaxLength(50)
                    .HasColumnName("ClienteTipo_Desc");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("Color");

                entity.Property(e => e.ColorId).HasColumnName("Color_ID");

                entity.Property(e => e.ColorCodigoColor)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("Color_CodigoColor");

                entity.Property(e => e.ColorDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Color_Desc");
            });

            modelBuilder.Entity<Comandum>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ArticuloId).HasColumnName("Articulo_ID");

                entity.Property(e => e.ComandaCantidad).HasColumnName("Comanda_Cantidad");

                entity.Property(e => e.ComandaEstatus).HasColumnName("Comanda_Estatus");

                entity.Property(e => e.ComandaFechaAnulada)
                    .HasColumnType("datetime")
                    .HasColumnName("Comanda_FechaAnulada");

                entity.Property(e => e.ComandaFechaDespacha)
                    .HasColumnType("datetime")
                    .HasColumnName("Comanda_FechaDespacha");

                entity.Property(e => e.ComandaFechaEntrega)
                    .HasColumnType("datetime")
                    .HasColumnName("Comanda_FechaEntrega");

                entity.Property(e => e.ComandaFechaEnvio)
                    .HasColumnType("datetime")
                    .HasColumnName("Comanda_FechaEnvio");

                entity.Property(e => e.ComandaFechaRecive)
                    .HasColumnType("datetime")
                    .HasColumnName("Comanda_FechaRecive");

                entity.Property(e => e.ComandaId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Comanda_ID");

                entity.Property(e => e.FacturaDetId).HasColumnName("FacturaDet_ID");

                entity.Property(e => e.ImpresionComandaId).HasColumnName("ImpresionComanda_ID");

                entity.Property(e => e.UsuarioAnulaId).HasColumnName("UsuarioAnula_ID");

                entity.Property(e => e.UsuarioDespachaId).HasColumnName("UsuarioDespacha_ID");

                entity.Property(e => e.UsuarioEntregaId).HasColumnName("UsuarioEntrega_ID");

                entity.Property(e => e.UsuarioEnviaId).HasColumnName("UsuarioEnvia_ID");

                entity.Property(e => e.UsuarioRecibeId).HasColumnName("UsuarioRecibe_ID");
            });

            modelBuilder.Entity<Combustible>(entity =>
            {
                entity.ToTable("Combustible");

                entity.Property(e => e.CombustibleId).HasColumnName("Combustible_ID");

                entity.Property(e => e.CombustibleDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Combustible_Desc");

                entity.Property(e => e.CombustibleEstatus).HasColumnName("Combustible_Estatus");

                entity.Property(e => e.SucursalId).HasColumnName("Sucursal_ID");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.CompraId)
                    .HasName("aaaaaCompra_PK")
                    .IsClustered(false);

                entity.ToTable("Compra");

                entity.HasIndex(e => e.AlmacenId, "Almacen_ID");

                entity.HasIndex(e => e.CompraId, "Compra_ID");

                entity.HasIndex(e => e.CondPagoId, "CondPago_ID");

                entity.HasIndex(e => e.OrdenCompraId, "OrdenCompra_ID");

                entity.HasIndex(e => e.SuplidorId, "SuplidorCompra");

                entity.HasIndex(e => e.SuplidorId, "Suplidor_ID");

                entity.Property(e => e.CompraId).HasColumnName("Compra_ID");

                entity.Property(e => e.AlmacenId).HasColumnName("Almacen_ID");

                entity.Property(e => e.CompraBalance)
                    .HasColumnType("money")
                    .HasColumnName("Compra_Balance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompraComentario)
                    .HasMaxLength(255)
                    .HasColumnName("Compra_Comentario");

                entity.Property(e => e.CompraDescto)
                    .HasColumnType("money")
                    .HasColumnName("Compra_Descto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompraEstatus)
                    .HasColumnName("Compra_Estatus")
                    .HasComment("Yes = Abierta, No = Cerrada");

                entity.Property(e => e.CompraFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Compra_Fecha");

                entity.Property(e => e.CompraFechaRegistrada)
                    .HasColumnType("datetime")
                    .HasColumnName("Compra_FechaRegistrada");

                entity.Property(e => e.CompraItbis)
                    .HasColumnType("money")
                    .HasColumnName("Compra_ITBIS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompraNcf)
                    .HasMaxLength(20)
                    .HasColumnName("Compra_NCF");

                entity.Property(e => e.CompraNo)
                    .HasMaxLength(20)
                    .HasColumnName("Compra_No");

                entity.Property(e => e.CompraTasa)
                    .HasColumnName("Compra_Tasa")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CondPagoId)
                    .HasColumnName("CondPago_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenCompraId).HasColumnName("OrdenCompra_ID");

                entity.Property(e => e.ProveedorInformar).HasColumnName("Proveedor_Informar");

                entity.Property(e => e.SuplidorId)
                    .HasColumnName("Suplidor_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpsizeTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("upsize_ts");
            });

            modelBuilder.Entity<CompraDet>(entity =>
            {
                entity.HasKey(e => new { e.CompraId, e.CompraDetId })
                    .HasName("aaaaaCompraDet_PK")
                    .IsClustered(false);

                entity.ToTable("CompraDet");

                entity.HasIndex(e => e.ArticuloId, "ArticuloCompraDet");

                entity.HasIndex(e => e.ArticuloId, "Articulo_ID");

                entity.HasIndex(e => e.CompraId, "CompraCompraDet");

                entity.HasIndex(e => e.CompraDetId, "Compra_DetID");

                entity.HasIndex(e => e.CompraId, "Compra_ID");

                entity.HasIndex(e => e.UnidadId, "Unidad_ID");

                entity.Property(e => e.CompraId).HasColumnName("Compra_ID");

                entity.Property(e => e.CompraDetId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Compra_DetID");

                entity.Property(e => e.ArticuloFechaVenc)
                    .HasColumnType("date")
                    .HasColumnName("Articulo_FechaVenc");

                entity.Property(e => e.ArticuloId)
                    .HasColumnName("Articulo_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompraComentario)
                    .HasMaxLength(250)
                    .HasColumnName("Compra_Comentario");

                entity.Property(e => e.CompraCostoAnt)
                    .HasColumnType("money")
                    .HasColumnName("Compra_CostoAnt")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompraDetMontoGp)
                    .HasColumnType("money")
                    .HasColumnName("CompraDet_MontoGP");

                entity.Property(e => e.CompraDetNo)
                    .HasColumnName("CompraDet_No")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompraItbis)
                    .HasColumnType("money")
                    .HasColumnName("Compra_ITBIS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompraPrecio)
                    .HasColumnType("money")
                    .HasColumnName("Compra_Precio")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompraQty)
                    .HasColumnName("Compra_Qty")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompraQtyDev)
                    .HasColumnName("Compra_QtyDev")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompraSiCambioCosto).HasColumnName("Compra_SiCambioCosto");

                entity.Property(e => e.CompraSiItbisinc).HasColumnName("Compra_SiITBISInc");

                entity.Property(e => e.UnidadId).HasColumnName("Unidad_ID");

                entity.Property(e => e.UpsizeTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("upsize_ts");

                entity.HasOne(d => d.Articulo)
                    .WithMany(p => p.CompraDets)
                    .HasForeignKey(d => d.ArticuloId)
                    .HasConstraintName("CompraDet_FK00");

                entity.HasOne(d => d.Compra)
                    .WithMany(p => p.CompraDets)
                    .HasForeignKey(d => d.CompraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CompraDet_FK01");
            });

            modelBuilder.Entity<Comprobante>(entity =>
            {
                entity.HasKey(e => e.ComprobanteTipoId)
                    .HasName("aaaaaComprobante_PK")
                    .IsClustered(false);

                entity.ToTable("Comprobante");

                entity.HasIndex(e => e.ComprobanteTipoId, "ComprobanteTipoComprobante")
                    .IsUnique();

                entity.HasIndex(e => e.ComprobanteInicial, "Numero_Inicial");

                entity.Property(e => e.ComprobanteTipoId)
                    .ValueGeneratedNever()
                    .HasColumnName("ComprobanteTipo_ID");

                entity.Property(e => e.ComprobanteFinal)
                    .HasColumnName("Comprobante_Final")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ComprobanteInicial)
                    .HasColumnName("Comprobante_Inicial")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ComprobanteUltimoUsado)
                    .HasColumnName("Comprobante_UltimoUsado")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.ComprobanteTipo)
                    .WithOne(p => p.Comprobante)
                    .HasForeignKey<Comprobante>(d => d.ComprobanteTipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Comprobante_FK00");
            });

            modelBuilder.Entity<ComprobanteDisp>(entity =>
            {
                entity.HasKey(e => new { e.ComprobanteTipoId, e.Ncf })
                    .HasName("aaaaaComprobanteDisp_PK")
                    .IsClustered(false);

                entity.ToTable("ComprobanteDisp");

                entity.HasIndex(e => e.ComprobanteTipoId, "ComprobanteTipoComprobanteDisp");

                entity.HasIndex(e => e.ComprobanteTipoId, "TipoComprobante_ID");

                entity.Property(e => e.ComprobanteTipoId).HasColumnName("ComprobanteTipo_ID");

                entity.Property(e => e.Ncf)
                    .HasMaxLength(19)
                    .HasColumnName("NCF");

                entity.HasOne(d => d.ComprobanteTipo)
                    .WithMany(p => p.ComprobanteDisps)
                    .HasForeignKey(d => d.ComprobanteTipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ComprobanteDisp_FK00");
            });

            modelBuilder.Entity<ComprobanteTipo>(entity =>
            {
                entity.HasKey(e => e.ComprobanteTipoId)
                    .HasName("aaaaaComprobanteTipo_PK")
                    .IsClustered(false);

                entity.ToTable("ComprobanteTipo");

                entity.Property(e => e.ComprobanteTipoId)
                    .ValueGeneratedNever()
                    .HasColumnName("ComprobanteTipo_ID");

                entity.Property(e => e.ComprobanteDesc)
                    .HasMaxLength(50)
                    .HasColumnName("Comprobante_Desc");

                entity.Property(e => e.ComprobanteDondeUsar)
                    .HasMaxLength(1)
                    .HasColumnName("Comprobante_DondeUsar");

                entity.Property(e => e.ComprobanteFechaVen)
                    .HasColumnType("datetime")
                    .HasColumnName("Comprobante_FechaVen");

                entity.Property(e => e.ComprobanteNoitbis).HasColumnName("Comprobante_NOITBIS");

                entity.Property(e => e.ComprobanteSiFechaVen).HasColumnName("Comprobante_SiFechaVen");

                entity.Property(e => e.ComprobanteTextoInicial)
                    .HasMaxLength(9)
                    .HasColumnName("Comprobante_TextoInicial");
            });

            modelBuilder.Entity<Conciliacion>(entity =>
            {
                entity.HasKey(e => new { e.ConciliacionNo, e.BancoId })
                    .HasName("aaaaaConciliacion_PK")
                    .IsClustered(false);

                entity.ToTable("Conciliacion");

                entity.HasIndex(e => e.BancoId, "BancoConciliacion");

                entity.HasIndex(e => e.BancoId, "Banco_ID");

                entity.Property(e => e.ConciliacionNo)
                    .HasMaxLength(7)
                    .HasColumnName("Conciliacion_No");

                entity.Property(e => e.BancoId).HasColumnName("Banco_ID");

                entity.Property(e => e.ConciliacionMontoFinal)
                    .HasColumnType("money")
                    .HasColumnName("Conciliacion_MontoFinal")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Banco)
                    .WithMany(p => p.Conciliacions)
                    .HasForeignKey(d => d.BancoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Conciliacion_FK00");
            });

            modelBuilder.Entity<CondPago>(entity =>
            {
                entity.HasKey(e => e.CondPagoId)
                    .HasName("aaaaaCondPago_PK")
                    .IsClustered(false);

                entity.ToTable("CondPago");

                entity.HasIndex(e => e.CondPagoId, "CondPago_ID");

                entity.Property(e => e.CondPagoId).HasColumnName("CondPago_ID");

                entity.Property(e => e.CondPagoDesc)
                    .HasMaxLength(50)
                    .HasColumnName("CondPago_Desc");

                entity.Property(e => e.CondPagoDias)
                    .HasColumnName("CondPago_Dias")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Conversion>(entity =>
            {
                entity.HasKey(e => e.ConversionId)
                    .HasName("aaaaaConversion_PK")
                    .IsClustered(false);

                entity.ToTable("Conversion");

                entity.HasIndex(e => e.ArticuloId, "Articulo_ID");

                entity.HasIndex(e => e.ConversionId, "Conversion_ID");

                entity.HasIndex(e => e.UsuarioId, "UsuarioConversion");

                entity.HasIndex(e => e.UsuarioId, "Usuario_ID");

                entity.Property(e => e.ConversionId).HasColumnName("Conversion_ID");

                entity.Property(e => e.ArticuloId)
                    .HasColumnName("Articulo_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ConversionCant)
                    .HasColumnName("Conversion_Cant")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UsuarioId)
                    .HasColumnName("Usuario_ID")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Conversions)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("Conversion_FK00");
            });

            modelBuilder.Entity<ConversionDetalle>(entity =>
            {
                entity.HasKey(e => e.ConversionDetalleId)
                    .HasName("aaaaaConversionDetalle_PK")
                    .IsClustered(false);

                entity.ToTable("ConversionDetalle");

                entity.HasIndex(e => e.ArticuloId, "Articulo_ID");

                entity.HasIndex(e => e.ConversionId, "ConversionConversionDetalle");

                entity.HasIndex(e => e.ConversionDetalleId, "ConversionDetalle_ID");

                entity.HasIndex(e => e.ConversionId, "Conversion_ID");

                entity.Property(e => e.ConversionDetalleId).HasColumnName("ConversionDetalle_ID");

                entity.Property(e => e.ArticuloId)
                    .HasColumnName("Articulo_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ConversionDetalleCant)
                    .HasColumnName("ConversionDetalle_Cant")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ConversionDetallePrecio)
                    .HasColumnType("money")
                    .HasColumnName("ConversionDetalle_Precio")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ConversionId)
                    .HasColumnName("Conversion_ID")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Conversion)
                    .WithMany(p => p.ConversionDetalles)
                    .HasForeignKey(d => d.ConversionId)
                    .HasConstraintName("ConversionDetalle_FK00");
            });

            modelBuilder.Entity<Cotizacion>(entity =>
            {
                entity.HasKey(e => e.CotizacionId)
                    .HasName("aaaaaCotizacion_PK")
                    .IsClustered(false);

                entity.ToTable("Cotizacion");

                entity.HasIndex(e => e.AlmacenId, "Almacen_ID");

                entity.HasIndex(e => e.ClienteId, "ClienteCotizacion");

                entity.HasIndex(e => e.ClienteId, "Cliente_Id");

                entity.HasIndex(e => e.CondPagoId, "CondPagoCotizacion");

                entity.HasIndex(e => e.CondPagoId, "CondPago_ID");

                entity.HasIndex(e => e.CotizacionId, "Factura_ID");

                entity.HasIndex(e => e.FacturaId, "Factura_ID1");

                entity.HasIndex(e => e.OrdenProduccionId, "OrdenProduccion_ID");

                entity.HasIndex(e => e.VendedorId, "VendedorCotizacion");

                entity.HasIndex(e => e.VendedorId, "Vendedor_ID");

                entity.Property(e => e.CotizacionId).HasColumnName("Cotizacion_ID");

                entity.Property(e => e.AlmacenId).HasColumnName("Almacen_ID");

                entity.Property(e => e.ClienteId)
                    .HasColumnName("Cliente_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CondPagoId)
                    .HasColumnName("CondPago_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CotizacionBalance)
                    .HasColumnType("money")
                    .HasColumnName("Cotizacion_Balance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CotizacionCliente)
                    .HasMaxLength(50)
                    .HasColumnName("Cotizacion_Cliente");

                entity.Property(e => e.CotizacionDatos)
                    .HasMaxLength(150)
                    .HasColumnName("Cotizacion_Datos");

                entity.Property(e => e.CotizacionDescto)
                    .HasColumnType("money")
                    .HasColumnName("Cotizacion_Descto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CotizacionFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Cotizacion_Fecha");

                entity.Property(e => e.CotizacionItbis)
                    .HasColumnType("money")
                    .HasColumnName("Cotizacion_ITBIS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CotizacionNo)
                    .HasMaxLength(20)
                    .HasColumnName("Cotizacion_No");

                entity.Property(e => e.FacturaId)
                    .HasColumnName("Factura_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionId)
                    .HasColumnName("OrdenProduccion_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.VendedorId)
                    .HasColumnName("Vendedor_ID")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<CotizacionDet>(entity =>
            {
                entity.HasKey(e => new { e.CotizacionId, e.CotizacionDetId })
                    .HasName("aaaaaCotizacionDet_PK")
                    .IsClustered(false);

                entity.ToTable("CotizacionDet");

                entity.HasIndex(e => e.ArticuloId, "Articulo_ID");

                entity.HasIndex(e => e.CotizacionId, "CotizacionCotizacionDet");

                entity.HasIndex(e => e.CotizacionDetId, "Cotizacion_DetID");

                entity.HasIndex(e => e.CotizacionId, "Factura_ID");

                entity.HasIndex(e => e.OrdenProduccionId, "OrdenProduccion_ID");

                entity.HasIndex(e => e.UnidadId, "Unidad_ID");

                entity.Property(e => e.CotizacionId).HasColumnName("Cotizacion_ID");

                entity.Property(e => e.CotizacionDetId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Cotizacion_DetID");

                entity.Property(e => e.ArticuloId)
                    .HasColumnName("Articulo_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CotizacionComentario)
                    .HasMaxLength(250)
                    .HasColumnName("Cotizacion_Comentario");

                entity.Property(e => e.CotizacionComentarioMemo)
                    .HasColumnType("ntext")
                    .HasColumnName("Cotizacion_ComentarioMemo");

                entity.Property(e => e.CotizacionDetNo).HasColumnName("CotizacionDet_No");

                entity.Property(e => e.CotizacionItbis)
                    .HasColumnType("money")
                    .HasColumnName("Cotizacion_ITBIS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CotizacionPrecio)
                    .HasColumnType("money")
                    .HasColumnName("Cotizacion_Precio")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CotizacionQty)
                    .HasColumnName("Cotizacion_Qty")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionId)
                    .HasColumnName("OrdenProduccion_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UnidadId).HasColumnName("Unidad_ID");

                entity.Property(e => e.UpsizeTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("upsize_ts");

                entity.HasOne(d => d.Cotizacion)
                    .WithMany(p => p.CotizacionDets)
                    .HasForeignKey(d => d.CotizacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CotizacionDet_FK00");
            });

            modelBuilder.Entity<CreditoAutorizado>(entity =>
            {
                entity.HasKey(e => e.CreditoAutorizadoId)
                    .HasName("aaaaaCreditoAutorizado_PK")
                    .IsClustered(false);

                entity.ToTable("CreditoAutorizado");

                entity.HasIndex(e => e.ClienteId, "ClienteCreditoAutorizado");

                entity.HasIndex(e => e.ClienteId, "Cliente_ID");

                entity.HasIndex(e => e.CondPagoId, "CondPagoCreditoAutorizado");

                entity.HasIndex(e => e.CondPagoId, "CondPago_ID");

                entity.HasIndex(e => e.CreditoAutorizadoId, "CreditoAutorizado_ID");

                entity.HasIndex(e => e.UsuarioId, "UsuarioCreditoAutorizado");

                entity.HasIndex(e => e.UsuarioId, "Ususario_ID");

                entity.Property(e => e.CreditoAutorizadoId).HasColumnName("CreditoAutorizado_ID");

                entity.Property(e => e.ClienteId)
                    .HasColumnName("Cliente_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CondPagoId)
                    .HasColumnName("CondPago_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreditoAutorizadoEstatus)
                    .HasColumnName("CreditoAutorizado_Estatus")
                    .HasComment("Yes=Libre para usar, No=Usado en una factura");

                entity.Property(e => e.CreditoAutorizadoFechaHora)
                    .HasColumnType("datetime")
                    .HasColumnName("CreditoAutorizado_FechaHora");

                entity.Property(e => e.UsuarioId)
                    .HasColumnName("Usuario_ID")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CuentasAjusteInventario).HasColumnName("Cuentas_AjusteInventario");

                entity.Property(e => e.CuentasCajaChica)
                    .HasColumnName("Cuentas_CajaChica")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentasCapital)
                    .HasColumnName("Cuentas_Capital")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentasCxC)
                    .HasColumnName("Cuentas_CxC")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentasCxCprestamo)
                    .HasColumnName("Cuentas_CxCPrestamo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentasCxP)
                    .HasColumnName("Cuentas_CxP")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentasDepreciacion)
                    .HasColumnName("Cuentas_Depreciacion")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentasDescCompra).HasColumnName("Cuentas_DescCompra");

                entity.Property(e => e.CuentasEfectivo)
                    .HasColumnName("Cuentas_Efectivo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentasGananciaPerdida)
                    .HasColumnName("Cuentas_GananciaPerdida")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentasImpuesto)
                    .HasColumnName("Cuentas_Impuesto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentasInteresPrestamo)
                    .HasColumnName("Cuentas_InteresPrestamo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentasItbisporPagar)
                    .HasColumnName("Cuentas_ITBISPorPagar")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentasItbisretenido)
                    .HasColumnName("Cuentas_ITBISRetenido")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentasNc)
                    .HasColumnName("Cuentas_NC")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentasNc2).HasColumnName("Cuentas_NC2");

                entity.Property(e => e.CuentasNd)
                    .HasColumnName("Cuentas_ND")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentasPrepago).HasColumnName("Cuentas_Prepago");

                entity.Property(e => e.CuentasRetIsr).HasColumnName("Cuentas_RetISR");

                entity.Property(e => e.CuentasRetencion)
                    .HasColumnName("Cuentas_Retencion")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Cuentum>(entity =>
            {
                entity.HasKey(e => e.CuentaId)
                    .HasName("aaaaaCuenta_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.CuentaId, "Cuenta_ID1");

                entity.Property(e => e.CuentaId).HasColumnName("Cuenta_ID");

                entity.Property(e => e.CuentaDesc)
                    .HasMaxLength(50)
                    .HasColumnName("Cuenta_Desc");

                entity.Property(e => e.CuentaIdorigen)
                    .HasColumnName("Cuenta_IDOrigen")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentaNo)
                    .HasMaxLength(10)
                    .HasColumnName("Cuenta_No");

                entity.Property(e => e.CuentaSiPrimaria)
                    .HasColumnName("Cuenta_SiPrimaria")
                    .HasComment("Si es primaria es que no puede ser borrada, pues es obligatoria para los demas modulos");

                entity.Property(e => e.CuentaSufijo)
                    .HasMaxLength(50)
                    .HasColumnName("Cuenta_Sufijo");
            });

            modelBuilder.Entity<CuotaDet>(entity =>
            {
                entity.HasKey(e => new { e.CuotaId, e.PrestamoId, e.CuotaDetSec })
                    .HasName("aaaaaCuotaDet_PK")
                    .IsClustered(false);

                entity.ToTable("CuotaDet");

                entity.HasIndex(e => e.CuotaId, "CuotaCuotaDet");

                entity.HasIndex(e => e.PrestamoId, "FactTipoPago_ID");

                entity.HasIndex(e => e.CuotaId, "Factura_ID");

                entity.HasIndex(e => e.PrestamoId, "PrestamoCuotaDet");

                entity.Property(e => e.CuotaId).HasColumnName("Cuota_ID");

                entity.Property(e => e.PrestamoId).HasColumnName("Prestamo_ID");

                entity.Property(e => e.CuotaDetSec)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CuotaDet_Sec");

                entity.Property(e => e.CuotaDetMontoCapital)
                    .HasColumnType("money")
                    .HasColumnName("CuotaDet_MontoCapital")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuotaDetMontoInteres)
                    .HasColumnType("money")
                    .HasColumnName("CuotaDet_MontoInteres")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Cuota)
                    .WithMany(p => p.CuotaDets)
                    .HasForeignKey(d => d.CuotaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CuotaDet_FK00");

                entity.HasOne(d => d.Prestamo)
                    .WithMany(p => p.CuotaDets)
                    .HasForeignKey(d => d.PrestamoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CuotaDet_FK01");
            });

            modelBuilder.Entity<CuotaTipoPago>(entity =>
            {
                entity.HasKey(e => new { e.CuotaId, e.TipoPagoId, e.CuotaTipoPagoSec })
                    .HasName("aaaaaCuotaTipoPago_PK")
                    .IsClustered(false);

                entity.ToTable("CuotaTipoPago");

                entity.HasIndex(e => e.CuotaId, "CuotaCuotaTipoPago");

                entity.HasIndex(e => e.NotaCrId, "NotaCr_ID");

                entity.HasIndex(e => e.CuotaId, "Recibo_ID");

                entity.HasIndex(e => e.TipoPagoId, "TipoPagoCuotaTipoPago");

                entity.HasIndex(e => e.TipoPagoId, "TipoPago_ID");

                entity.Property(e => e.CuotaId).HasColumnName("Cuota_ID");

                entity.Property(e => e.TipoPagoId).HasColumnName("TipoPago_ID");

                entity.Property(e => e.CuotaTipoPagoSec)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CuotaTipoPago_Sec");

                entity.Property(e => e.CuotaTipoPagoCom)
                    .HasMaxLength(100)
                    .HasColumnName("CuotaTipoPago_Com");

                entity.Property(e => e.CuotaTipoPagoMonto)
                    .HasColumnType("money")
                    .HasColumnName("CuotaTipoPago_Monto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NotaCrId)
                    .HasColumnName("NotaCr_ID")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Cuota)
                    .WithMany(p => p.CuotaTipoPagos)
                    .HasForeignKey(d => d.CuotaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CuotaTipoPago_FK00");

                entity.HasOne(d => d.NotaCr)
                    .WithMany(p => p.CuotaTipoPagos)
                    .HasForeignKey(d => d.NotaCrId)
                    .HasConstraintName("CuotaTipoPago_FK01");

                entity.HasOne(d => d.TipoPago)
                    .WithMany(p => p.CuotaTipoPagos)
                    .HasForeignKey(d => d.TipoPagoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CuotaTipoPago_FK02");
            });

            modelBuilder.Entity<Cuotum>(entity =>
            {
                entity.HasKey(e => e.CuotaId)
                    .HasName("aaaaaCuota_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.CierreCajaId, "CierreCaja_ID");

                entity.HasIndex(e => e.CuotaId, "Cuota_ID");

                entity.HasIndex(e => e.UsuarioId, "UsuarioCuota");

                entity.HasIndex(e => e.UsuarioId, "Usuario_ID");

                entity.HasIndex(e => e.VendedorId, "VendedorCuota");

                entity.HasIndex(e => e.VendedorId, "Vendedor_ID");

                entity.Property(e => e.CuotaId).HasColumnName("Cuota_ID");

                entity.Property(e => e.CierreCajaId).HasColumnName("CierreCaja_ID");

                entity.Property(e => e.CuotaComentario)
                    .HasMaxLength(255)
                    .HasColumnName("Cuota_Comentario");

                entity.Property(e => e.CuotaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Cuota_Fecha");

                entity.Property(e => e.CuotaMonto)
                    .HasColumnType("money")
                    .HasColumnName("Cuota_Monto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuotaNo)
                    .HasMaxLength(255)
                    .HasColumnName("Cuota_No");

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");

                entity.Property(e => e.VendedorId).HasColumnName("Vendedor_ID");

                entity.HasOne(d => d.CierreCaja)
                    .WithMany(p => p.Cuota)
                    .HasForeignKey(d => d.CierreCajaId)
                    .HasConstraintName("Cuota_FK00");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Cuota)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("Cuota_FK01");

                entity.HasOne(d => d.Vendedor)
                    .WithMany(p => p.Cuota)
                    .HasForeignKey(d => d.VendedorId)
                    .HasConstraintName("Cuota_FK02");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.DepartamentoId)
                    .HasName("aaaaaDepartamento_PK")
                    .IsClustered(false);

                entity.ToTable("Departamento");

                entity.HasIndex(e => e.CuentaId, "Cuenta_ID");

                entity.HasIndex(e => e.DepartamentoId, "Departamento_ID");

                entity.Property(e => e.DepartamentoId).HasColumnName("Departamento_ID");

                entity.Property(e => e.CuentaId).HasColumnName("Cuenta_ID");

                entity.Property(e => e.CuentaIdcosto).HasColumnName("Cuenta_IDCosto");

                entity.Property(e => e.CuentaIdventa).HasColumnName("Cuenta_IDVenta");

                entity.Property(e => e.DepartamentoDefecto).HasColumnName("Departamento_Defecto");

                entity.Property(e => e.DepartamentoDesc)
                    .HasMaxLength(50)
                    .HasColumnName("Departamento_Desc");

                entity.Property(e => e.DepartamentoEstatus).HasColumnName("Departamento_Estatus");

                entity.Property(e => e.DepartamentoUbicacion)
                    .HasMaxLength(50)
                    .HasColumnName("Departamento_Ubicacion");
            });

            modelBuilder.Entity<DepartamentoAutoridad>(entity =>
            {
                entity.HasKey(e => new { e.DepartamentoId, e.AutoridadId })
                    .HasName("aaaaaDepartamento_Autoridad_PK")
                    .IsClustered(false);

                entity.ToTable("Departamento_Autoridad");

                entity.HasIndex(e => e.AutoridadId, "AutoridadDepartamento_Autoridad");

                entity.HasIndex(e => e.AutoridadId, "Autoridad_ID");

                entity.HasIndex(e => e.DepartamentoId, "Departamento_ID");

                entity.Property(e => e.DepartamentoId).HasColumnName("Departamento_ID");

                entity.Property(e => e.AutoridadId).HasColumnName("Autoridad_ID");

                entity.HasOne(d => d.Autoridad)
                    .WithMany(p => p.DepartamentoAutoridads)
                    .HasForeignKey(d => d.AutoridadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Departamento_Autoridad_FK00");
            });

            modelBuilder.Entity<Deposito>(entity =>
            {
                entity.HasKey(e => e.DepositoId)
                    .HasName("aaaaaDeposito_PK")
                    .IsClustered(false);

                entity.ToTable("Deposito");

                entity.HasIndex(e => e.BancoId, "BancoDeposito");

                entity.HasIndex(e => e.BancoId, "Banco_ID");

                entity.HasIndex(e => e.DepositoId, "Deposito_ID");

                entity.Property(e => e.DepositoId).HasColumnName("Deposito_ID");

                entity.Property(e => e.BancoId)
                    .HasColumnName("Banco_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DepositoComentario)
                    .HasMaxLength(50)
                    .HasColumnName("Deposito_Comentario");

                entity.Property(e => e.DepositoConciliacion)
                    .HasMaxLength(7)
                    .HasColumnName("Deposito_Conciliacion");

                entity.Property(e => e.DepositoFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Deposito_Fecha");

                entity.Property(e => e.DepositoMonto)
                    .HasColumnType("money")
                    .HasColumnName("Deposito_Monto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DepositoNo)
                    .HasColumnName("Deposito_No")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Banco)
                    .WithMany(p => p.Depositos)
                    .HasForeignKey(d => d.BancoId)
                    .HasConstraintName("Deposito_FK00");
            });

            modelBuilder.Entity<DepositoCierreCaja>(entity =>
            {
                entity.HasKey(e => new { e.DepositoId, e.CierreCajaId })
                    .HasName("aaaaaDepositoCierreCaja_PK")
                    .IsClustered(false);

                entity.ToTable("DepositoCierreCaja");

                entity.HasIndex(e => e.CierreCajaId, "CierreCajaDepositoCierreCaja");

                entity.HasIndex(e => e.CierreCajaId, "CierreCaja_ID");

                entity.HasIndex(e => e.DepositoId, "DepositoDepositoCierreCaja");

                entity.HasIndex(e => e.DepositoId, "Deposito_ID");

                entity.Property(e => e.DepositoId).HasColumnName("Deposito_ID");

                entity.Property(e => e.CierreCajaId).HasColumnName("CierreCaja_ID");

                entity.Property(e => e.DepositoCierreCajaMonto)
                    .HasColumnType("money")
                    .HasColumnName("DepositoCierreCaja_Monto");

                entity.HasOne(d => d.CierreCaja)
                    .WithMany(p => p.DepositoCierreCajas)
                    .HasForeignKey(d => d.CierreCajaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DepositoCierreCaja_FK00");

                entity.HasOne(d => d.Deposito)
                    .WithMany(p => p.DepositoCierreCajas)
                    .HasForeignKey(d => d.DepositoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DepositoCierreCaja_FK01");
            });

            modelBuilder.Entity<Depreciacion>(entity =>
            {
                entity.HasKey(e => e.DepreciacionId)
                    .HasName("aaaaaDepreciacion_PK")
                    .IsClustered(false);

                entity.ToTable("Depreciacion");

                entity.HasIndex(e => e.DepreciacionId, "Depreciacion_ID");

                entity.HasIndex(e => e.TipoActivoFijoId, "TipoActivoFijo_ID");

                entity.Property(e => e.DepreciacionId).HasColumnName("Depreciacion_ID");

                entity.Property(e => e.DepreciacionAno)
                    .HasColumnName("Depreciacion_Ano")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DepreciacionMes)
                    .HasColumnName("Depreciacion_Mes")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DepreciacionMonto)
                    .HasColumnType("money")
                    .HasColumnName("Depreciacion_Monto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DepreciacionSiBeneficio).HasColumnName("Depreciacion_SiBeneficio");

                entity.Property(e => e.TipoActivoFijoId)
                    .HasColumnName("TipoActivoFijo_ID")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<DespachoFactura>(entity =>
            {
                entity.HasKey(e => e.DespachoFacturaId)
                    .HasName("aaaaaDespachoFactura_PK")
                    .IsClustered(false);

                entity.ToTable("DespachoFactura");

                entity.HasIndex(e => e.DespachoFacturaId, "DespachoFactura_ID");

                entity.HasIndex(e => e.FacturaDetId, "FacturaDetDespachoFactura");

                entity.HasIndex(e => e.FacturaDetId, "FacturaDet_ID");

                entity.Property(e => e.DespachoFacturaId).HasColumnName("DespachoFactura_ID");

                entity.Property(e => e.DespachoFacturaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("DespachoFactura_Fecha");

                entity.Property(e => e.FacturaDetCant).HasColumnName("FacturaDet_Cant");

                entity.Property(e => e.FacturaDetId).HasColumnName("FacturaDet_ID");

                entity.Property(e => e.UpsizeTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("upsize_ts");

                entity.HasOne(d => d.FacturaDet)
                    .WithMany(p => p.DespachoFacturas)
                    .HasForeignKey(d => d.FacturaDetId)
                    .HasConstraintName("DespachoFactura_FK00");
            });

            modelBuilder.Entity<DistribuirFactura>(entity =>
            {
                entity.HasKey(e => e.DistribuirFacturaId)
                    .HasName("aaaaaDistribuirFactura_PK")
                    .IsClustered(false);

                entity.ToTable("DistribuirFactura");

                entity.HasIndex(e => e.DistribuirFacturaId, "DistribuirFactura_ID");

                entity.HasIndex(e => e.FacturaId, "FacturaDistribuirFactura");

                entity.HasIndex(e => e.FacturaId, "Factura_ID");

                entity.Property(e => e.DistribuirFacturaId).HasColumnName("DistribuirFactura_ID");

                entity.Property(e => e.DistribuirFacturaEstatus)
                    .HasColumnName("DistribuirFactura_Estatus")
                    .HasComment("Yes=Debe, No=Pago");

                entity.Property(e => e.DistribuirFacturaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("DistribuirFactura_Fecha");

                entity.Property(e => e.DistribuirFacturaMonto)
                    .HasColumnType("money")
                    .HasColumnName("DistribuirFactura_Monto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaId)
                    .HasColumnName("Factura_ID")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Factura)
                    .WithMany(p => p.DistribuirFacturas)
                    .HasForeignKey(d => d.FacturaId)
                    .HasConstraintName("DistribuirFactura_FK00");
            });

            modelBuilder.Entity<Efectivo>(entity =>
            {
                entity.HasKey(e => e.EfectivoId)
                    .HasName("aaaaaEfectivo_PK")
                    .IsClustered(false);

                entity.ToTable("Efectivo");

                entity.HasIndex(e => e.CierreCajaId, "Banco_ID");

                entity.HasIndex(e => e.EfectivoId, "Cheque_ID");

                entity.HasIndex(e => e.SuplidorId, "SuplidorEfectivo");

                entity.HasIndex(e => e.SuplidorId, "Suplidor_ID");

                entity.HasIndex(e => e.UsuarioId, "UsuarioEfectivo");

                entity.HasIndex(e => e.UsuarioId, "Usuario_ID");

                entity.Property(e => e.EfectivoId).HasColumnName("Efectivo_ID");

                entity.Property(e => e.CierreCajaId)
                    .HasColumnName("CierreCaja_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EfectivoAnulado).HasColumnName("Efectivo_Anulado");

                entity.Property(e => e.EfectivoConcepto)
                    .HasMaxLength(100)
                    .HasColumnName("Efectivo_Concepto");

                entity.Property(e => e.EfectivoFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Efectivo_Fecha");

                entity.Property(e => e.EfectivoNo)
                    .HasColumnName("Efectivo_No")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EfectivoPrinted).HasColumnName("Efectivo_Printed");

                entity.Property(e => e.EfectivoValor)
                    .HasColumnType("money")
                    .HasColumnName("Efectivo_Valor")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SuplidorId)
                    .HasColumnName("Suplidor_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UsuarioId)
                    .HasColumnName("Usuario_ID")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Suplidor)
                    .WithMany(p => p.Efectivos)
                    .HasForeignKey(d => d.SuplidorId)
                    .HasConstraintName("Efectivo_FK01");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Efectivos)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("Efectivo_FK02");
            });

            modelBuilder.Entity<EfectivoAdelanto>(entity =>
            {
                entity.HasKey(e => new { e.EfectivoId, e.EfectivoLinAd })
                    .HasName("aaaaaEfectivoAdelanto_PK")
                    .IsClustered(false);

                entity.ToTable("EfectivoAdelanto");

                entity.HasIndex(e => e.EfectivoId, "Cheque_ID");

                entity.Property(e => e.EfectivoId).HasColumnName("Efectivo_ID");

                entity.Property(e => e.EfectivoLinAd)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Efectivo_LinAD");

                entity.Property(e => e.EfectivoMontoAd)
                    .HasColumnType("money")
                    .HasColumnName("Efectivo_MontoAD")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<EfectivoCompra>(entity =>
            {
                entity.HasKey(e => new { e.EfectivoId, e.EfectivoLinCi })
                    .HasName("aaaaaEfectivoCompras_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.CompraId, "ChequeDetCompra_ID");

                entity.HasIndex(e => e.EfectivoId, "Cheque_ID");

                entity.HasIndex(e => e.CompraId, "CompraEfectivoCompras");

                entity.HasIndex(e => e.EfectivoId, "EfectivoEfectivoCompras");

                entity.Property(e => e.EfectivoId).HasColumnName("Efectivo_ID");

                entity.Property(e => e.EfectivoLinCi)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Efectivo_LinCI");

                entity.Property(e => e.CompraId)
                    .HasColumnName("Compra_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EfectivoDesctoCi)
                    .HasColumnType("money")
                    .HasColumnName("Efectivo_DesctoCI")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EfectivoMontoCi)
                    .HasColumnType("money")
                    .HasColumnName("Efectivo_MontoCI")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Compra)
                    .WithMany(p => p.EfectivoCompras)
                    .HasForeignKey(d => d.CompraId)
                    .HasConstraintName("EfectivoCompras_FK00");

                entity.HasOne(d => d.Efectivo)
                    .WithMany(p => p.EfectivoCompras)
                    .HasForeignKey(d => d.EfectivoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EfectivoCompras_FK01");
            });

            modelBuilder.Entity<EfectivoGasto>(entity =>
            {
                entity.HasKey(e => new { e.EfectivoId, e.EfectivoLinGa })
                    .HasName("aaaaaEfectivoGastos_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.RecGastoId, "ChequeDetCompra_ID");

                entity.HasIndex(e => e.EfectivoId, "Cheque_ID");

                entity.HasIndex(e => e.EfectivoId, "EfectivoEfectivoGastos");

                entity.HasIndex(e => e.RecGastoId, "RecGastoEfectivoGastos");

                entity.Property(e => e.EfectivoId).HasColumnName("Efectivo_ID");

                entity.Property(e => e.EfectivoLinGa)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Efectivo_LinGA");

                entity.Property(e => e.EfectivoMontoGa)
                    .HasColumnType("money")
                    .HasColumnName("Efectivo_MontoGA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RecGastoId)
                    .HasColumnName("RecGasto_ID")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Efectivo)
                    .WithMany(p => p.EfectivoGastos)
                    .HasForeignKey(d => d.EfectivoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EfectivoGastos_FK00");

                entity.HasOne(d => d.RecGasto)
                    .WithMany(p => p.EfectivoGastos)
                    .HasForeignKey(d => d.RecGastoId)
                    .HasConstraintName("EfectivoGastos_FK01");
            });

            modelBuilder.Entity<EntradaDiario>(entity =>
            {
                entity.HasKey(e => e.EntradaDiarioId)
                    .HasName("aaaaaEntradaDiario_PK")
                    .IsClustered(false);

                entity.ToTable("EntradaDiario");

                entity.HasIndex(e => e.EntradaDiarioId, "EntradaDiario_ID");

                entity.Property(e => e.EntradaDiarioId)
                    .ValueGeneratedNever()
                    .HasColumnName("EntradaDiario_ID");

                entity.Property(e => e.EntradaDiarioComentario)
                    .HasMaxLength(200)
                    .HasColumnName("EntradaDiario_Comentario");

                entity.Property(e => e.EntradaDiarioFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("EntradaDiario_Fecha");

                entity.Property(e => e.EntradaDiarioNo)
                    .HasColumnName("EntradaDiario_No")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EntradaDiarioSiAuto).HasColumnName("EntradaDiario_SiAuto");

                entity.Property(e => e.EntradaDiarioSiPosteada).HasColumnName("EntradaDiario_SiPosteada");
            });

            modelBuilder.Entity<EntradaDiarioAud>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EntradaDiarioAud");

                entity.Property(e => e.Codigo).HasMaxLength(250);

                entity.Property(e => e.CuentaDesc)
                    .HasMaxLength(250)
                    .HasColumnName("Cuenta_Desc");

                entity.Property(e => e.CuentaNo)
                    .HasMaxLength(250)
                    .HasColumnName("Cuenta_No");

                entity.Property(e => e.Desc2).HasMaxLength(250);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.NoDoc).HasMaxLength(250);

                entity.Property(e => e.Tipo).HasMaxLength(250);
            });

            modelBuilder.Entity<EntradaDiarioDet>(entity =>
            {
                entity.HasKey(e => e.EntradaDiarioDetId)
                    .HasName("aaaaaEntradaDiarioDet_PK")
                    .IsClustered(false);

                entity.ToTable("EntradaDiarioDet");

                entity.HasIndex(e => e.CuentaId, "CuentaEntradaDiarioDet");

                entity.HasIndex(e => e.CuentaId, "Cuenta_ID");

                entity.HasIndex(e => e.EntradaDiarioDetId, "EntradaDiarioDet_ID");

                entity.HasIndex(e => e.EntradaDiarioId, "EntradaDiarioEntradaDiarioDet");

                entity.HasIndex(e => e.EntradaDiarioId, "EntradaDiario_ID");

                entity.Property(e => e.EntradaDiarioDetId).HasColumnName("EntradaDiarioDet_ID");

                entity.Property(e => e.CuentaId)
                    .HasColumnName("Cuenta_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EntradaDiarioCredito)
                    .HasColumnType("money")
                    .HasColumnName("EntradaDiario_Credito")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EntradaDiarioDebito)
                    .HasColumnType("money")
                    .HasColumnName("EntradaDiario_Debito")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EntradaDiarioId)
                    .HasColumnName("EntradaDiario_ID")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Cuenta)
                    .WithMany(p => p.EntradaDiarioDets)
                    .HasForeignKey(d => d.CuentaId)
                    .HasConstraintName("EntradaDiarioDet_FK00");

                entity.HasOne(d => d.EntradaDiario)
                    .WithMany(p => p.EntradaDiarioDets)
                    .HasForeignKey(d => d.EntradaDiarioId)
                    .HasConstraintName("EntradaDiarioDet_FK01");
            });

            modelBuilder.Entity<EntradaDiarioGen>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EntradaDiarioGen");

                entity.HasIndex(e => e.Fecha, "Fecha");

                entity.Property(e => e.CuentaDesc)
                    .HasMaxLength(255)
                    .HasColumnName("Cuenta_Desc");

                entity.Property(e => e.CuentaNo)
                    .HasMaxLength(255)
                    .HasColumnName("Cuenta_No");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Orden).HasMaxLength(255);
            });

            modelBuilder.Entity<EntradasDeDiario>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EntradasDeDiario");

                entity.HasIndex(e => e.CuentaNo, "Cuenta_No");

                entity.HasIndex(e => e.Fecha, "Fecha");

                entity.Property(e => e.CuentaDesc)
                    .HasMaxLength(255)
                    .HasColumnName("Cuenta_Desc");

                entity.Property(e => e.CuentaNo)
                    .HasMaxLength(255)
                    .HasColumnName("Cuenta_No");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Orden).HasMaxLength(255);
            });

            modelBuilder.Entity<Equipamiento>(entity =>
            {
                entity.ToTable("Equipamiento");

                entity.Property(e => e.EquipamientoId).HasColumnName("Equipamiento_ID");

                entity.Property(e => e.EquipamientoDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Equipamiento_Desc");

                entity.Property(e => e.EquipamientoEstatus).HasColumnName("Equipamiento_Estatus");

                entity.Property(e => e.SucursalId).HasColumnName("Sucursal_ID");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.FacturaId)
                    .HasName("aaaaaFactura_PK")
                    .IsClustered(false);

                entity.ToTable("Factura");

                entity.HasIndex(e => e.AlmacenId, "Almacen_ID");

                entity.HasIndex(e => e.ClienteId, "ClienteFactura");

                entity.HasIndex(e => e.ClienteId, "Cliente_Id");

                entity.HasIndex(e => e.ComprobanteTipoId, "ComprobanteTipoFactura");

                entity.HasIndex(e => e.ComprobanteTipoId, "ComprobanteTipo_ID");

                entity.HasIndex(e => e.CondPagoId, "CondPagoFactura");

                entity.HasIndex(e => e.CondPagoId, "CondPago_ID");

                entity.HasIndex(e => e.CreditoAutorizadoId, "CreditoAutorizado_ID");

                entity.HasIndex(e => e.FacturaId, "Factura_ID");

                entity.HasIndex(e => e.FacturaNo, "Factura_No")
                    .IsUnique();

                entity.HasIndex(e => e.HabitacionId, "Habitacion_ID");

                entity.HasIndex(e => e.ReservaId, "Reserva_ID");

                entity.HasIndex(e => e.VendedorId, "VendedorFactura");

                entity.HasIndex(e => e.VendedorId, "Vendedor_ID");

                entity.Property(e => e.FacturaId).HasColumnName("Factura_ID");

                entity.Property(e => e.AlmacenId).HasColumnName("Almacen_ID");

                entity.Property(e => e.ClienteId)
                    .HasColumnName("Cliente_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ComprobanteTipoId)
                    .HasColumnName("ComprobanteTipo_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CondPagoId)
                    .HasColumnName("CondPago_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreditoAutorizadoId)
                    .HasColumnName("CreditoAutorizado_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaBalance)
                    .HasColumnType("money")
                    .HasColumnName("Factura_Balance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaCliente)
                    .HasMaxLength(50)
                    .HasColumnName("Factura_Cliente");

                entity.Property(e => e.FacturaComentario)
                    .HasMaxLength(250)
                    .HasColumnName("Factura_Comentario");

                entity.Property(e => e.FacturaComprobante)
                    .HasMaxLength(20)
                    .HasColumnName("Factura_Comprobante");

                entity.Property(e => e.FacturaComprobanteFechaVen)
                    .HasColumnType("datetime")
                    .HasColumnName("Factura_ComprobanteFechaVen");

                entity.Property(e => e.FacturaDatos)
                    .HasMaxLength(150)
                    .HasColumnName("Factura_Datos");

                entity.Property(e => e.FacturaDescto)
                    .HasColumnType("money")
                    .HasColumnName("Factura_Descto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaEstatus)
                    .HasColumnName("Factura_Estatus")
                    .HasComment("Yes = Abierta    No= Cerrada");

                entity.Property(e => e.FacturaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Factura_Fecha");

                entity.Property(e => e.FacturaFechaCierre)
                    .HasColumnType("datetime")
                    .HasColumnName("Factura_FechaCierre");

                entity.Property(e => e.FacturaFechaEntrega)
                    .HasColumnType("datetime")
                    .HasColumnName("Factura_FechaEntrega");

                entity.Property(e => e.FacturaFechaReAbre)
                    .HasColumnType("datetime")
                    .HasColumnName("Factura_FechaReAbre");

                entity.Property(e => e.FacturaItbis)
                    .HasColumnType("money")
                    .HasColumnName("Factura_ITBIS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaMontoCambio)
                    .HasColumnType("money")
                    .HasColumnName("Factura_MontoCambio");

                entity.Property(e => e.FacturaMontoImpuesto)
                    .HasColumnType("money")
                    .HasColumnName("Factura_MontoImpuesto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaMontoPagado)
                    .HasColumnType("money")
                    .HasColumnName("Factura_MontoPagado");

                entity.Property(e => e.FacturaMontoRetIsr)
                    .HasColumnType("money")
                    .HasColumnName("Factura_MontoRetISR");

                entity.Property(e => e.FacturaNif)
                    .HasMaxLength(16)
                    .HasColumnName("Factura_NIF");

                entity.Property(e => e.FacturaNo)
                    .HasMaxLength(20)
                    .HasColumnName("Factura_No");

                entity.Property(e => e.FacturaNoImpreso)
                    .HasColumnName("Factura_NoImpreso")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaNoImpresoPreFac).HasColumnName("Factura_NoImpresoPreFac");

                entity.Property(e => e.FacturaSiBeneficio).HasColumnName("Factura_SiBeneficio");

                entity.Property(e => e.FacturaSiCobrable).HasColumnName("Factura_SiCobrable");

                entity.Property(e => e.FacturaUsuarioCierra).HasColumnName("Factura_UsuarioCierra");

                entity.Property(e => e.FacturaUsuarioReAbre).HasColumnName("Factura_UsuarioReAbre");

                entity.Property(e => e.HabitacionId).HasColumnName("Habitacion_ID");

                entity.Property(e => e.MesaId).HasColumnName("Mesa_ID");

                entity.Property(e => e.ReservaId).HasColumnName("Reserva_ID");

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");

                entity.Property(e => e.UsuarioIdAnulador)
                    .HasColumnName("Usuario_ID_Anulador")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UsuarioIdAud).HasColumnName("Usuario_ID_Aud");

                entity.Property(e => e.VendedorId)
                    .HasColumnName("Vendedor_ID")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Mesa)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.MesaId)
                    .HasConstraintName("FK_Factura_Mesa");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_Factura_Usuario");

                entity.HasMany(d => d.Mesas)
                    .WithMany(p => p.FacturasNavigation)
                    .UsingEntity<Dictionary<string, object>>(
                        "FacturaMesa",
                        l => l.HasOne<Mesa>().WithMany().HasForeignKey("MesaId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_FacturaMesas_Mesa"),
                        r => r.HasOne<Factura>().WithMany().HasForeignKey("FacturaId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_FacturaMesas_Factura"),
                        j =>
                        {
                            j.HasKey("FacturaId", "MesaId");

                            j.ToTable("FacturaMesas");

                            j.IndexerProperty<int>("FacturaId").HasColumnName("Factura_ID");

                            j.IndexerProperty<int>("MesaId").HasColumnName("Mesa_ID");
                        });
            });

            modelBuilder.Entity<FacturaAnuladaComentario>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Factura_Anulada_Comentario");

                entity.Property(e => e.FacturaComentarioNula)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Factura_Comentario_Nula");

                entity.Property(e => e.FacturaFechaNula)
                    .HasColumnType("datetime")
                    .HasColumnName("Factura_FechaNula");

                entity.Property(e => e.FacturaId).HasColumnName("Factura_ID");

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");
            });

            modelBuilder.Entity<FacturaCombinacione>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => new { e.FacturaIdBase, e.FacturaIdCombinada }, "IX_FacturaCombinaciones")
                    .IsUnique();

                entity.Property(e => e.ClienteId).HasColumnName("Cliente_ID");

                entity.Property(e => e.FacturaIdBase).HasColumnName("Factura_ID_base");

                entity.Property(e => e.FacturaIdCombinada).HasColumnName("Factura_ID_combinada");

                entity.Property(e => e.FacturaMonto)
                    .HasColumnType("money")
                    .HasColumnName("Factura_monto");

                entity.Property(e => e.FacturaNoCombinada)
                    .HasMaxLength(20)
                    .HasColumnName("Factura_No_Combinada")
                    .IsFixedLength();

                entity.Property(e => e.FechaCombinacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Combinacion");

                entity.Property(e => e.FechaFactura)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Factura");

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");
            });

            modelBuilder.Entity<FacturaDatosVehiculo>(entity =>
            {
                entity.HasKey(e => e.FacturaId)
                    .HasName("aaaaaFactura_DatosVehiculo_PK")
                    .IsClustered(false);

                entity.ToTable("Factura_DatosVehiculo");

                entity.HasIndex(e => e.FacturaId, "FacturaFactura_DatosVehiculo")
                    .IsUnique();

                entity.Property(e => e.FacturaId)
                    .ValueGeneratedNever()
                    .HasColumnName("Factura_ID");

                entity.Property(e => e.FacturaDatosVehiculoAno)
                    .HasMaxLength(255)
                    .HasColumnName("FacturaDatosVehiculo_Ano");

                entity.Property(e => e.FacturaDatosVehiculoChasis)
                    .HasMaxLength(255)
                    .HasColumnName("FacturaDatosVehiculo_Chasis");

                entity.Property(e => e.FacturaDatosVehiculoKilometraje).HasColumnName("FacturaDatosVehiculo_Kilometraje");

                entity.Property(e => e.FacturaDatosVehiculoMarca)
                    .HasMaxLength(255)
                    .HasColumnName("FacturaDatosVehiculo_Marca");

                entity.Property(e => e.FacturaDatosVehiculoModelo)
                    .HasMaxLength(255)
                    .HasColumnName("FacturaDatosVehiculo_Modelo");

                entity.HasOne(d => d.Factura)
                    .WithOne(p => p.FacturaDatosVehiculo)
                    .HasForeignKey<FacturaDatosVehiculo>(d => d.FacturaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Factura_DatosVehiculo_FK00");
            });

            modelBuilder.Entity<FacturaDet>(entity =>
            {
                entity.HasKey(e => e.FacturaDetId)
                    .HasName("aaaaaFacturaDet_PK")
                    .IsClustered(false);

                entity.ToTable("FacturaDet");

                entity.HasIndex(e => e.ArticuloId, "ArticuloFacturaDet");

                entity.HasIndex(e => e.ArticuloId, "Articulo_ID");

                entity.HasIndex(e => e.OrdenProduccionId, "FacturaDetOrdenProduccion_ID");

                entity.HasIndex(e => e.FacturaDetNo, "FacturaDet_No");

                entity.HasIndex(e => e.FacturaId, "FacturaFacturaDet");

                entity.HasIndex(e => e.FacturaDetId, "Factura_DetID");

                entity.HasIndex(e => e.FacturaId, "Factura_ID");

                entity.HasIndex(e => e.UnidadId, "Unidad_ID");

                entity.HasIndex(e => e.UsuarioId, "UsuarioFacturaDet");

                entity.HasIndex(e => e.UsuarioId, "Usuario_ID");

                entity.HasIndex(e => e.VendedorId, "VendedorFacturaDet");

                entity.HasIndex(e => e.VendedorId, "Vendedor_ID");

                entity.Property(e => e.FacturaDetId).HasColumnName("Factura_DetID");

                entity.Property(e => e.ArticuloId)
                    .HasColumnName("Articulo_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaComentario)
                    .HasMaxLength(500)
                    .HasColumnName("Factura_Comentario");

                entity.Property(e => e.FacturaComentarioMemo)
                    .HasMaxLength(500)
                    .HasColumnName("Factura_ComentarioMemo");

                entity.Property(e => e.FacturaCosto)
                    .HasColumnType("money")
                    .HasColumnName("Factura_Costo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaDetCantDesp).HasColumnName("FacturaDet_CantDesp");

                entity.Property(e => e.FacturaDetComandaImpresa).HasColumnName("FacturaDet_ComandaImpresa");

                entity.Property(e => e.FacturaDetComision).HasColumnName("FacturaDet_Comision");

                entity.Property(e => e.FacturaDetDescto)
                    .HasColumnType("money")
                    .HasColumnName("FacturaDet_Descto");

                entity.Property(e => e.FacturaDetFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("FacturaDet_Fecha");

                entity.Property(e => e.FacturaDetNo)
                    .HasColumnName("FacturaDet_No")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaDetSiComanda).HasColumnName("FacturaDet_SiComanda");

                entity.Property(e => e.FacturaId)
                    .HasColumnName("Factura_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaItbis)
                    .HasColumnType("money")
                    .HasColumnName("Factura_ITBIS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaPrecio)
                    .HasColumnType("money")
                    .HasColumnName("Factura_Precio")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaPrecioAnt)
                    .HasColumnType("money")
                    .HasColumnName("Factura_PrecioAnt")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaQty)
                    .HasColumnName("Factura_Qty")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaQtyDev)
                    .HasColumnName("Factura_QtyDev")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MeseroId).HasColumnName("Mesero_ID");

                entity.Property(e => e.OrdenProduccionId)
                    .HasColumnName("OrdenProduccion_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionQty)
                    .HasColumnName("OrdenProduccion_Qty")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UnidadId).HasColumnName("Unidad_ID");

                entity.Property(e => e.UsuarioId)
                    .HasColumnName("Usuario_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.VendedorId).HasColumnName("Vendedor_ID");
            });

            modelBuilder.Entity<FacturaDetAnuladum>(entity =>
            {
                entity.HasKey(e => new { e.FacturaId, e.FacturaDetId })
                    .HasName("aaaaaFacturaDet_Anulada_PK")
                    .IsClustered(false);

                entity.ToTable("FacturaDet_Anulada");

                entity.HasIndex(e => e.ArticuloId, "Articulo_ID");

                entity.HasIndex(e => e.FacturaId, "FacturaFacturaDet_Anulada");

                entity.HasIndex(e => e.FacturaDetId, "Factura_DetID");

                entity.HasIndex(e => e.FacturaId, "Factura_ID");

                entity.HasIndex(e => e.OrdenProduccionId, "OrdenProduccion_ID");

                entity.HasIndex(e => e.UnidadId, "Unidad_ID");

                entity.HasIndex(e => e.UsuarioId, "UsuarioFacturaDet_Anulada");

                entity.HasIndex(e => e.UsuarioId, "Usuario_ID");

                entity.HasIndex(e => e.VendedorId, "VendedorFacturaDet_Anulada");

                entity.HasIndex(e => e.VendedorId, "Vendedor_ID");

                entity.Property(e => e.FacturaId).HasColumnName("Factura_ID");

                entity.Property(e => e.FacturaDetId).HasColumnName("Factura_DetID");

                entity.Property(e => e.ArticuloId)
                    .HasColumnName("Articulo_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaComentario)
                    .HasMaxLength(250)
                    .HasColumnName("Factura_Comentario");

                entity.Property(e => e.FacturaComentarioMemo)
                    .HasMaxLength(250)
                    .HasColumnName("Factura_ComentarioMemo");

                entity.Property(e => e.FacturaCosto)
                    .HasColumnType("money")
                    .HasColumnName("Factura_Costo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaDetCantDesp).HasColumnName("FacturaDet_CantDesp");

                entity.Property(e => e.FacturaDetComandaImpresa).HasColumnName("FacturaDet_ComandaImpresa");

                entity.Property(e => e.FacturaDetComision).HasColumnName("FacturaDet_Comision");

                entity.Property(e => e.FacturaDetDescto)
                    .HasColumnType("money")
                    .HasColumnName("FacturaDet_Descto");

                entity.Property(e => e.FacturaDetFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("FacturaDet_Fecha");

                entity.Property(e => e.FacturaDetNo)
                    .HasColumnName("FacturaDet_No")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaDetSiComanda).HasColumnName("FacturaDet_SiComanda");

                entity.Property(e => e.FacturaItbis)
                    .HasColumnType("money")
                    .HasColumnName("Factura_ITBIS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaPrecio)
                    .HasColumnType("money")
                    .HasColumnName("Factura_Precio")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaPrecioAnt)
                    .HasColumnType("money")
                    .HasColumnName("Factura_PrecioAnt")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaQty)
                    .HasColumnName("Factura_Qty")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaQtyDev)
                    .HasColumnName("Factura_QtyDev")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MeseroId).HasColumnName("Mesero_ID");

                entity.Property(e => e.OrdenProduccionId)
                    .HasColumnName("OrdenProduccion_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionQty)
                    .HasColumnName("OrdenProduccion_Qty")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UnidadId).HasColumnName("Unidad_ID");

                entity.Property(e => e.UsuarioId)
                    .HasColumnName("Usuario_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.VendedorId).HasColumnName("Vendedor_ID");
            });

            modelBuilder.Entity<FacturaUsuairoPrefactura>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Factura_Usuairo_Prefactura");

                entity.Property(e => e.FacturaId).HasColumnName("Factura_ID");

                entity.Property(e => e.FechaImpPrefactura)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Imp_Prefactura");

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");
            });

            modelBuilder.Entity<FormatoFactura>(entity =>
            {
                entity.HasKey(e => e.FormatoFacturaId)
                    .HasName("aaaaaFormatoFactura_PK")
                    .IsClustered(false);

                entity.ToTable("FormatoFactura");

                entity.HasIndex(e => e.FormatoFacturaId, "FormatoFactura_ID");

                entity.Property(e => e.FormatoFacturaId)
                    .ValueGeneratedNever()
                    .HasColumnName("FormatoFactura_ID");

                entity.Property(e => e.FormatoFacturaDesc)
                    .HasMaxLength(50)
                    .HasColumnName("FormatoFactura_Desc");

                entity.Property(e => e.FormatoFacturaImpresora)
                    .HasMaxLength(250)
                    .HasColumnName("FormatoFactura_Impresora");

                entity.Property(e => e.FormatoFacturaNoImpresion).HasColumnName("FormatoFactura_NoImpresion");

                entity.Property(e => e.FormatoFacturaNombreReporte)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("FormatoFactura_NombreReporte");
            });

            modelBuilder.Entity<GananciaPerdidum>(entity =>
            {
                entity.HasKey(e => e.GananciaPerdidaId)
                    .HasName("aaaaaGananciaPerdida_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.GananciaPerdidaId, "GanaciaPerdida_ID");

                entity.Property(e => e.GananciaPerdidaId).HasColumnName("GananciaPerdida_ID");

                entity.Property(e => e.GananciaPerdidaDesc)
                    .HasMaxLength(100)
                    .HasColumnName("GananciaPerdida_Desc");

                entity.Property(e => e.GananciaPerdidaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("GananciaPerdida_Fecha");

                entity.Property(e => e.GananciaPerdidaMonto)
                    .HasColumnType("money")
                    .HasColumnName("GananciaPerdida_Monto")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Gasto>(entity =>
            {
                entity.HasKey(e => e.GastoId)
                    .HasName("aaaaaGasto_PK")
                    .IsClustered(false);

                entity.ToTable("Gasto");

                entity.HasIndex(e => e.CuentaId, "CuentaGasto");

                entity.HasIndex(e => e.CuentaId, "Cuenta_ID");

                entity.HasIndex(e => e.GastoClasCode, "Gasto_ClasCode");

                entity.HasIndex(e => e.GastoId, "Gasto_ID");

                entity.Property(e => e.GastoId).HasColumnName("Gasto_ID");

                entity.Property(e => e.CuentaId)
                    .HasColumnName("Cuenta_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GastoClasCode)
                    .HasMaxLength(2)
                    .HasColumnName("Gasto_ClasCode");

                entity.Property(e => e.GastoDesc)
                    .HasMaxLength(50)
                    .HasColumnName("Gasto_Desc");

                entity.Property(e => e.GastoEstatus).HasColumnName("Gasto_Estatus");

                entity.HasOne(d => d.Cuenta)
                    .WithMany(p => p.Gastos)
                    .HasForeignKey(d => d.CuentaId)
                    .HasConstraintName("Gasto_FK00");
            });

            modelBuilder.Entity<General>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("General");

                entity.HasIndex(e => e.GeneralComprobanteTipoId, "General_ComprobanteTipoID");

                entity.Property(e => e.ArticuloIdReserva).HasColumnName("Articulo_ID_Reserva");

                entity.Property(e => e.ComprobanteTipoIdUsuarioFinal).HasColumnName("ComprobanteTipo_ID_UsuarioFinal");

                entity.Property(e => e.GenaralEmailClave)
                    .HasColumnType("text")
                    .HasColumnName("Genaral_EmailClave");

                entity.Property(e => e.GeneralCantDiasFactura)
                    .HasColumnName("General_CantDiasFactura")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralCantKilomServicio).HasColumnName("General_CantKilomServicio");

                entity.Property(e => e.GeneralCantMesServicio).HasColumnName("General_CantMesServicio");

                entity.Property(e => e.GeneralCantPrecios).HasColumnName("General_CantPrecios");

                entity.Property(e => e.GeneralCantidadImpresionFactura).HasColumnName("General_CantidadImpresionFactura");

                entity.Property(e => e.GeneralCapital)
                    .HasColumnType("money")
                    .HasColumnName("General_Capital")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralClienteId).HasColumnName("General_ClienteID");

                entity.Property(e => e.GeneralColorFormas)
                    .HasColumnName("General_ColorFormas")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralComprobante)
                    .HasMaxLength(9)
                    .HasColumnName("General_Comprobante");

                entity.Property(e => e.GeneralComprobanteTipoId)
                    .HasColumnName("General_ComprobanteTipoID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralComprobanteTipoIdProveedorInformar).HasColumnName("General_ComprobanteTipoID_ProveedorInformar");

                entity.Property(e => e.GeneralCondPago).HasColumnName("General_CondPago");

                entity.Property(e => e.GeneralControlaPcPorAlmacen)
                    .HasColumnName("General_ControlaPcPorAlmacen")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralDatosArticulosFactura)
                    .HasColumnName("General_DatosArticulosFactura")
                    .HasDefaultValueSql("((0))")
                    .HasComment("1= Se va ver  0 = No se va a ver");

                entity.Property(e => e.GeneralDireccion)
                    .HasMaxLength(50)
                    .HasColumnName("General_Direccion");

                entity.Property(e => e.GeneralDireccion2)
                    .HasMaxLength(50)
                    .HasColumnName("General_Direccion2");

                entity.Property(e => e.GeneralEmail)
                    .HasMaxLength(50)
                    .HasColumnName("General_Email");

                entity.Property(e => e.GeneralEmailCopia)
                    .HasColumnType("text")
                    .HasColumnName("General_EmailCopia");

                entity.Property(e => e.GeneralEmailHost)
                    .HasColumnType("text")
                    .HasColumnName("General_EmailHost");

                entity.Property(e => e.GeneralEmailLlegada)
                    .HasColumnType("text")
                    .HasColumnName("General_EmailLlegada");

                entity.Property(e => e.GeneralEmailPort)
                    .HasColumnType("text")
                    .HasColumnName("General_EmailPort");

                entity.Property(e => e.GeneralEmailSalida)
                    .HasColumnType("text")
                    .HasColumnName("General_EmailSalida");

                entity.Property(e => e.GeneralEmailUsuario)
                    .HasColumnType("text")
                    .HasColumnName("General_EmailUsuario");

                entity.Property(e => e.GeneralEmpresaDireccion)
                    .HasMaxLength(100)
                    .HasColumnName("General_EmpresaDireccion");

                entity.Property(e => e.GeneralEmpresaNombre)
                    .HasMaxLength(100)
                    .HasColumnName("General_EmpresaNombre");

                entity.Property(e => e.GeneralEtiquetaMarca)
                    .HasMaxLength(255)
                    .HasColumnName("General_EtiquetaMarca");

                entity.Property(e => e.GeneralEtiquetaModelo)
                    .HasMaxLength(255)
                    .HasColumnName("General_EtiquetaModelo");

                entity.Property(e => e.GeneralFactorPietaje)
                    .HasColumnName("General_FactorPietaje")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralFacturaSecuencial).HasColumnName("General_FacturaSecuencial");

                entity.Property(e => e.GeneralFax)
                    .HasMaxLength(50)
                    .HasColumnName("General_Fax");

                entity.Property(e => e.GeneralFechaCierre)
                    .HasColumnType("datetime")
                    .HasColumnName("General_FechaCierre");

                entity.Property(e => e.GeneralFechaCierreAud)
                    .HasColumnType("datetime")
                    .HasColumnName("General_FechaCierreAud");

                entity.Property(e => e.GeneralId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("General_Id");

                entity.Property(e => e.GeneralIfMarca).HasColumnName("General_IfMarca");

                entity.Property(e => e.GeneralImprimeComandaDirecto).HasColumnName("General_ImprimeComandaDirecto");

                entity.Property(e => e.GeneralInstallerName)
                    .HasMaxLength(50)
                    .HasColumnName("General_InstallerName");

                entity.Property(e => e.GeneralItbis)
                    .HasColumnName("General_ITBIS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralMensajeFactura)
                    .HasColumnType("ntext")
                    .HasColumnName("General_MensajeFactura");

                entity.Property(e => e.GeneralMuestraDatosVehiculoCli).HasColumnName("General_MuestraDatosVehiculoCli");

                entity.Property(e => e.GeneralNoCp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("General_NoCP");

                entity.Property(e => e.GeneralNoFactura)
                    .HasColumnName("General_NoFactura")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralNoSeguimiento)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("General_NoSeguimiento");

                entity.Property(e => e.GeneralPantallaQty)
                    .HasColumnName("General_PantallaQty")
                    .HasDefaultValueSql("((0))")
                    .HasComment("1= Pietaje, 2=Metraje");

                entity.Property(e => e.GeneralPrecioPorAlmacen).HasColumnName("General_PrecioPorAlmacen");

                entity.Property(e => e.GeneralPrepagoId).HasColumnName("General_PrepagoId");

                entity.Property(e => e.GeneralRedondeoGanacia)
                    .HasColumnName("General_RedondeoGanacia")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralRetIsr).HasColumnName("General_RetISR");

                entity.Property(e => e.GeneralRnc)
                    .HasMaxLength(50)
                    .HasColumnName("General_RNC");

                entity.Property(e => e.GeneralRutaImg)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("General_RutaImg");

                entity.Property(e => e.GeneralRutaReportes)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("General_RutaReportes");

                entity.Property(e => e.GeneralSiAbonoFact).HasColumnName("General_SiAbonoFact");

                entity.Property(e => e.GeneralSiBloqueaCcajaFacAbierta).HasColumnName("General_SiBloqueaCCajaFacAbierta");

                entity.Property(e => e.GeneralSiCodClienteSec).HasColumnName("General_SiCodClienteSec");

                entity.Property(e => e.GeneralSiCodSuplidorSec).HasColumnName("General_SiCodSuplidorSec");

                entity.Property(e => e.GeneralSiComprobanteObligatorio).HasColumnName("General_SiComprobanteObligatorio");

                entity.Property(e => e.GeneralSiConfirUsuFact).HasColumnName("General_SiConfirUsuFact");

                entity.Property(e => e.GeneralSiDescuentoEnFactura).HasColumnName("General_SiDescuentoEnFactura");

                entity.Property(e => e.GeneralSiEnvíoCorreoAuto).HasColumnName("General_SiEnvíoCorreoAuto");

                entity.Property(e => e.GeneralSiFacturaCambiaPrecio).HasColumnName("General_SiFacturaCambiaPrecio");

                entity.Property(e => e.GeneralSiHotel).HasColumnName("General_SiHotel");

                entity.Property(e => e.GeneralSiPararVentaPorLimite).HasColumnName("General_SiPararVentaPorLimite");

                entity.Property(e => e.GeneralSiPararVentaPorVencimiento).HasColumnName("General_SiPararVentaPorVencimiento");

                entity.Property(e => e.GeneralSiRestaurant).HasColumnName("General_SiRestaurant");

                entity.Property(e => e.GeneralSuplidorGastoMenor)
                    .HasColumnName("General_SuplidorGastoMenor")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralTasaImpuesto)
                    .HasColumnName("General_TasaImpuesto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralTasaRetencion)
                    .HasColumnName("General_TasaRetencion")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralTelefono)
                    .HasMaxLength(50)
                    .HasColumnName("General_Telefono");

                entity.Property(e => e.GeneralTelefono2)
                    .HasMaxLength(50)
                    .HasColumnName("General_Telefono2");

                entity.Property(e => e.GeneralTipoPagoChequeId).HasColumnName("General_TipoPago_ChequeID");

                entity.Property(e => e.GeneralTipoPagoEfectivoId).HasColumnName("General_TipoPago_EfectivoID");

                entity.Property(e => e.GeneralTipoPagoTarjetaId).HasColumnName("General_TipoPago_TarjetaID");

                entity.Property(e => e.GeneralUltimaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("General_UltimaActualizacion");

                entity.Property(e => e.GeneralUltimaCompra)
                    .HasColumnName("General_UltimaCompra")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralUltimaConciliacion)
                    .HasMaxLength(7)
                    .HasColumnName("General_UltimaConciliacion");

                entity.Property(e => e.GeneralUltimaCotizacion)
                    .HasColumnName("General_UltimaCotizacion")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralUltimaEntradaDiario)
                    .HasColumnName("General_UltimaEntradaDiario")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralUltimaFactura)
                    .HasColumnName("General_UltimaFactura")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralUltimaNotaCr)
                    .HasColumnName("General_UltimaNotaCr")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralUltimaNotaDeb)
                    .HasColumnName("General_UltimaNotaDeb")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralUltimaOrdenCompra)
                    .HasColumnName("General_UltimaOrdenCompra")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralUltimoAjusteInventario).HasColumnName("General_UltimoAjusteInventario");

                entity.Property(e => e.GeneralUltimoArticulo).HasColumnName("General_UltimoArticulo");

                entity.Property(e => e.GeneralUltimoCuota).HasColumnName("General_UltimoCuota");

                entity.Property(e => e.GeneralUltimoDeposito)
                    .HasColumnName("General_UltimoDeposito")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralUltimoGasto)
                    .HasColumnName("General_UltimoGasto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralUltimoGastoRecurrente).HasColumnName("General_UltimoGastoRecurrente");

                entity.Property(e => e.GeneralUltimoOrdenProduccion)
                    .HasColumnName("General_UltimoOrdenProduccion")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralUltimoRecCompra)
                    .HasColumnName("General_UltimoRecCompra")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralUltimoRecibo)
                    .HasColumnName("General_UltimoRecibo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GeneralUsaAnalisisCosto).HasColumnName("General_UsaAnalisisCosto");

                entity.Property(e => e.GeneralUsaCierreCaja).HasColumnName("General_UsaCierreCaja");

                entity.Property(e => e.GeneralValorPunto).HasColumnName("General_ValorPunto");
            });

            modelBuilder.Entity<GrupoReporte>(entity =>
            {
                entity.Property(e => e.GrupoReporteId).HasColumnName("GrupoReporte_ID");

                entity.Property(e => e.GrupoReporteDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GrupoReporte_Desc");
            });

            modelBuilder.Entity<GrupoReportesAutoridad>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GrupoReportesAutoridad");

                entity.HasIndex(e => new { e.GrupoReporteId, e.AutoridadId }, "IX_GrupoReportesAutoridad")
                    .IsUnique();

                entity.Property(e => e.AutoridadId).HasColumnName("Autoridad_ID");

                entity.Property(e => e.GrupoReporteId).HasColumnName("GrupoReporte_ID");

                entity.HasOne(d => d.Autoridad)
                    .WithMany()
                    .HasForeignKey(d => d.AutoridadId)
                    .HasConstraintName("FK_GrupoReportesAutoridad_Autoridad");

                entity.HasOne(d => d.GrupoReporte)
                    .WithMany()
                    .HasForeignKey(d => d.GrupoReporteId)
                    .HasConstraintName("FK_GrupoReportesAutoridad_GrupoReportes");
            });

            modelBuilder.Entity<Guarnicion>(entity =>
            {
                entity.ToTable("Guarnicion");

                entity.Property(e => e.GuarnicionId).HasColumnName("Guarnicion_ID");

                entity.Property(e => e.GuarnicionDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Guarnicion_Desc");
            });

            modelBuilder.Entity<Habitacion>(entity =>
            {
                entity.HasKey(e => e.HabitacionId)
                    .HasName("aaaaaHabitacion_PK")
                    .IsClustered(false);

                entity.ToTable("Habitacion");

                entity.HasIndex(e => e.HabitacionId, "Habitacion_ID");

                entity.HasIndex(e => e.PlantaId, "Planta_ID");

                entity.HasIndex(e => e.TipoHabitacionId, "TipoHabitacion_ID");

                entity.Property(e => e.HabitacionId).HasColumnName("Habitacion_ID");

                entity.Property(e => e.HabitacionDesc)
                    .HasMaxLength(255)
                    .HasColumnName("Habitacion_Desc");

                entity.Property(e => e.HabitacionEstado)
                    .HasColumnName("Habitacion_Estado")
                    .HasComment("0=Limpia, 1=Sucia");

                entity.Property(e => e.HabitacionEstatus).HasColumnName("Habitacion_Estatus");

                entity.Property(e => e.PlantaId).HasColumnName("Planta_ID");

                entity.Property(e => e.TipoHabitacionId).HasColumnName("TipoHabitacion_ID");
            });

            modelBuilder.Entity<ImpEtiquetum>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ArticuloCd)
                    .HasMaxLength(30)
                    .HasColumnName("Articulo_CD");

                entity.Property(e => e.ArticuloCostoCodigo)
                    .HasMaxLength(50)
                    .HasColumnName("Articulo_CostoCodigo");

                entity.Property(e => e.ArticuloDesc)
                    .HasMaxLength(50)
                    .HasColumnName("Articulo_Desc");

                entity.Property(e => e.ArticuloFechaCompra)
                    .HasMaxLength(20)
                    .HasColumnName("Articulo_FechaCompra");

                entity.Property(e => e.ArticuloPrecioCodigo)
                    .HasMaxLength(50)
                    .HasColumnName("Articulo_PrecioCodigo");

                entity.Property(e => e.ArticuloSuplidor)
                    .HasMaxLength(100)
                    .HasColumnName("Articulo_Suplidor");

                entity.Property(e => e.GeneralEmpresaNombre)
                    .HasMaxLength(100)
                    .HasColumnName("General_EmpresaNombre");

                entity.Property(e => e.GeneralTelefono)
                    .HasMaxLength(50)
                    .HasColumnName("General_Telefono");

                entity.Property(e => e.GeneralTelefono2)
                    .HasMaxLength(50)
                    .HasColumnName("General_Telefono2");
            });

            modelBuilder.Entity<ImpresionComanda>(entity =>
            {
                entity.Property(e => e.ImpresionComandaId).HasColumnName("ImpresionComanda_ID");

                entity.Property(e => e.DepartamentoId).HasColumnName("Departamento_ID");

                entity.Property(e => e.FacturaDetId).HasColumnName("Factura_DetID");

                entity.Property(e => e.FacturaId).HasColumnName("Factura_ID");

                entity.Property(e => e.FechaComanda).HasColumnType("datetime");

                entity.Property(e => e.FechaImpresa).HasColumnType("datetime");

                entity.HasOne(d => d.Departamento)
                    .WithMany(p => p.ImpresionComanda)
                    .HasForeignKey(d => d.DepartamentoId)
                    .HasConstraintName("FK_ImpresionComandas_Departamento");

                entity.HasOne(d => d.Factura)
                    .WithMany(p => p.ImpresionComanda)
                    .HasForeignKey(d => d.FacturaId)
                    .HasConstraintName("FK_ImpresionComandas_Factura");
            });

            modelBuilder.Entity<Itbi>(entity =>
            {
                entity.HasKey(e => e.ItbisId)
                    .HasName("aaaaaITBIS_PK")
                    .IsClustered(false);

                entity.ToTable("ITBIS");

                entity.HasIndex(e => e.ItbisId, "ITBIS_ID");

                entity.Property(e => e.ItbisId).HasColumnName("ITBIS_ID");

                entity.Property(e => e.ItbisAno)
                    .HasColumnName("ITBIS_Ano")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ItbisEstatus)
                    .HasColumnName("ITBIS_Estatus")
                    .HasComment("Yes = Sin Cheque, No = Pagado con cheque");

                entity.Property(e => e.ItbisMes)
                    .HasColumnName("ITBIS_Mes")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ItbisMonto)
                    .HasColumnType("money")
                    .HasColumnName("ITBIS_Monto")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<LlamadasAgendum>(entity =>
            {
                entity.HasKey(e => e.LlamadasAgendaId)
                    .HasName("aaaaaLlamadasAgenda_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.ClienteId, "Cliente_ID");

                entity.HasIndex(e => e.LlamadasAgendaId, "LlamadasAgenda_ID");

                entity.HasIndex(e => e.LlamadasMotivosId, "LlamadasMotivos_ID");

                entity.HasIndex(e => e.UsuarioId, "Usuario_ID");

                entity.Property(e => e.LlamadasAgendaId).HasColumnName("LlamadasAgenda_ID");

                entity.Property(e => e.ClienteId).HasColumnName("Cliente_ID");

                entity.Property(e => e.LlamadasAgendaComentario)
                    .HasMaxLength(255)
                    .HasColumnName("LlamadasAgenda_Comentario");

                entity.Property(e => e.LlamadasAgendaEstatus).HasColumnName("LlamadasAgenda_Estatus");

                entity.Property(e => e.LlamadasAgendaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("LlamadasAgenda_Fecha");

                entity.Property(e => e.LlamadasMotivosId).HasColumnName("LlamadasMotivos_ID");

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");
            });

            modelBuilder.Entity<LlamadasCliente>(entity =>
            {
                entity.HasKey(e => e.LlamadasClienteId)
                    .HasName("aaaaaLlamadasCliente_PK")
                    .IsClustered(false);

                entity.ToTable("LlamadasCliente");

                entity.HasIndex(e => e.LlamadasAgendaId, "LlamadasAgenda_ID");

                entity.HasIndex(e => e.LlamadasClienteId, "LlamadasCliente_ID");

                entity.HasIndex(e => e.UsuarioId, "Usuario_ID");

                entity.Property(e => e.LlamadasClienteId).HasColumnName("LlamadasCliente_ID");

                entity.Property(e => e.LlamadasAgendaId).HasColumnName("LlamadasAgenda_ID");

                entity.Property(e => e.LlamadasClienteComentario)
                    .HasMaxLength(255)
                    .HasColumnName("LlamadasCliente_Comentario");

                entity.Property(e => e.LlamadasClienteFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("LlamadasCliente_Fecha");

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");
            });

            modelBuilder.Entity<LlamadasClientesCobro>(entity =>
            {
                entity.HasKey(e => e.LlamadasClienteId)
                    .HasName("aaaaaLlamadasClientesCobro_PK")
                    .IsClustered(false);

                entity.ToTable("LlamadasClientesCobro");

                entity.HasIndex(e => e.LlamadasAgendaId, "LlamadasAgenda_ID");

                entity.HasIndex(e => e.UsuarioId, "Usuario_ID");

                entity.Property(e => e.LlamadasClienteId).HasColumnName("LlamadasCliente_ID");

                entity.Property(e => e.LlamadasAgendaId).HasColumnName("LlamadasAgenda_ID");

                entity.Property(e => e.LlamadasClienteComentario)
                    .HasMaxLength(255)
                    .HasColumnName("LlamadasCliente_Comentario");

                entity.Property(e => e.LlamadasClienteFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("LlamadasCliente_Fecha");

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");
            });

            modelBuilder.Entity<LlamadasMotivo>(entity =>
            {
                entity.HasKey(e => e.LlamadasMotivosId)
                    .HasName("aaaaaLlamadasMotivos_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.LlamadasMotivosId, "LlamadasMotivos_ID");

                entity.Property(e => e.LlamadasMotivosId).HasColumnName("LlamadasMotivos_ID");

                entity.Property(e => e.LlamadasMotivosDesc)
                    .HasMaxLength(255)
                    .HasColumnName("LlamadasMotivos_Desc");

                entity.Property(e => e.LlamadasMotivosEstatus).HasColumnName("LlamadasMotivos_Estatus");
            });

            modelBuilder.Entity<LogErrore>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.LogFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Log_Fecha");

                entity.Property(e => e.LogFuncion)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Log_Funcion");

                entity.Property(e => e.LogId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Log_ID");

                entity.Property(e => e.LogMensaje)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Log_Mensaje");

                entity.Property(e => e.LogPantalla)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Log_Pantalla");

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.MarcaId)
                    .HasName("aaaaaMarca_PK")
                    .IsClustered(false);

                entity.ToTable("Marca");

                entity.HasIndex(e => e.MarcaId, "Marca_ID");

                entity.Property(e => e.MarcaId).HasColumnName("Marca_ID");

                entity.Property(e => e.MarcaDesc)
                    .HasMaxLength(100)
                    .HasColumnName("Marca_Desc");
            });

            modelBuilder.Entity<MarcaModArt>(entity =>
            {
                entity.HasKey(e => new { e.ArticuloId, e.MarcaId, e.ModeloId })
                    .HasName("aaaaaMarcaModArt_PK")
                    .IsClustered(false);

                entity.ToTable("MarcaModArt");

                entity.HasIndex(e => e.ArticuloId, "Articulo_ID");

                entity.HasIndex(e => e.MarcaId, "Marca_ID");

                entity.HasIndex(e => e.ModeloId, "ModeloMarcaModArt");

                entity.HasIndex(e => e.ModeloId, "Modelo_ID");

                entity.Property(e => e.ArticuloId).HasColumnName("Articulo_ID");

                entity.Property(e => e.MarcaId).HasColumnName("Marca_ID");

                entity.Property(e => e.ModeloId).HasColumnName("Modelo_ID");

                entity.HasOne(d => d.Modelo)
                    .WithMany(p => p.MarcaModArts)
                    .HasForeignKey(d => d.ModeloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MarcaModArt_FK00");
            });

            modelBuilder.Entity<MarcaVendedor>(entity =>
            {
                entity.HasKey(e => new { e.MarcaId, e.VendedorId })
                    .HasName("aaaaaMarca_Vendedor_PK")
                    .IsClustered(false);

                entity.ToTable("Marca_Vendedor");

                entity.HasIndex(e => e.VendedorId, "VendedorMarca_Vendedor");

                entity.HasIndex(e => e.VendedorId, "Vendedor_ID");

                entity.Property(e => e.MarcaId).HasColumnName("Marca_ID");

                entity.Property(e => e.VendedorId).HasColumnName("Vendedor_ID");

                entity.HasOne(d => d.Vendedor)
                    .WithMany(p => p.MarcaVendedors)
                    .HasForeignKey(d => d.VendedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Marca_Vendedor_FK00");
            });

            modelBuilder.Entity<MaterialesPorArticulo>(entity =>
            {
                entity.HasKey(e => e.MaterialesPorArticuloId)
                    .HasName("aaaaaMaterialesPorArticulo_PK")
                    .IsClustered(false);

                entity.ToTable("MaterialesPorArticulo");

                entity.HasIndex(e => e.MaterialesPorArticuloId, "MaterialesPorArticulo_ID");

                entity.HasIndex(e => e.OpestatusId, "OPEstatus_ID");

                entity.HasIndex(e => e.UnidadId, "Unidad_ID");

                entity.Property(e => e.MaterialesPorArticuloId).HasColumnName("MaterialesPorArticulo_ID");

                entity.Property(e => e.ArticuloIdHijo)
                    .HasColumnName("Articulo_ID_Hijo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ArticuloIdPadre)
                    .HasColumnName("Articulo_ID_Padre")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MaterialesPorArticuloDesc)
                    .HasMaxLength(50)
                    .HasColumnName("MaterialesPorArticulo_Desc");

                entity.Property(e => e.MaterialesPorArticuloFormulaCant)
                    .HasMaxLength(250)
                    .HasColumnName("MaterialesPorArticulo_FormulaCant");

                entity.Property(e => e.MaterialesPorArticuloFormulaMedida1)
                    .HasMaxLength(250)
                    .HasColumnName("MaterialesPorArticulo_FormulaMedida1");

                entity.Property(e => e.MaterialesPorArticuloFormulaMedida2)
                    .HasMaxLength(250)
                    .HasColumnName("MaterialesPorArticulo_FormulaMedida2");

                entity.Property(e => e.MaterialesPorArticuloFormulaMedida3)
                    .HasMaxLength(250)
                    .HasColumnName("MaterialesPorArticulo_FormulaMedida3");

                entity.Property(e => e.OpestatusId).HasColumnName("OPEstatus_ID");

                entity.Property(e => e.UnidadId).HasColumnName("Unidad_ID");
            });

            modelBuilder.Entity<Mesa>(entity =>
            {
                entity.ToTable("Mesa");

                entity.Property(e => e.MesaId).HasColumnName("Mesa_ID");

                entity.Property(e => e.MesaDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Mesa_Desc");

                entity.Property(e => e.MesaEstatus).HasColumnName("Mesa_Estatus");

                entity.Property(e => e.MesaNo).HasColumnName("Mesa_No");

                entity.Property(e => e.SalaId).HasColumnName("Sala_ID");

                entity.HasOne(d => d.Sala)
                    .WithMany(p => p.Mesas)
                    .HasForeignKey(d => d.SalaId)
                    .HasConstraintName("FK_Mesa_Sala");
            });

            modelBuilder.Entity<Mesero>(entity =>
            {
                entity.ToTable("Mesero");

                entity.Property(e => e.MeseroId).HasColumnName("Mesero_ID");

                entity.Property(e => e.MeseroCodigo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Mesero_Codigo");

                entity.Property(e => e.MeseroEstatus).HasColumnName("Mesero_Estatus");

                entity.Property(e => e.MeseroNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Mesero_Nombre");
            });

            modelBuilder.Entity<Misc>(entity =>
            {
                entity.HasKey(e => e.MiscId)
                    .HasName("aaaaaMisc_PK")
                    .IsClustered(false);

                entity.ToTable("Misc");

                entity.HasIndex(e => e.BancoId, "BancoMisc");

                entity.HasIndex(e => e.BancoId, "Banco_ID");

                entity.HasIndex(e => e.CuentaId, "CuentaMisc");

                entity.HasIndex(e => e.CuentaId, "Cuenta_ID");

                entity.HasIndex(e => e.MiscClasCode, "Misc_ClasCode");

                entity.HasIndex(e => e.MiscId, "Misc_ID");

                entity.Property(e => e.MiscId).HasColumnName("Misc_ID");

                entity.Property(e => e.BancoId)
                    .HasColumnName("Banco_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentaId)
                    .HasColumnName("Cuenta_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MiscClasCode)
                    .HasMaxLength(2)
                    .HasColumnName("Misc_ClasCode");

                entity.Property(e => e.MiscComentario)
                    .HasMaxLength(100)
                    .HasColumnName("Misc_Comentario");

                entity.Property(e => e.MiscConciliacion)
                    .HasMaxLength(7)
                    .HasColumnName("Misc_Conciliacion");

                entity.Property(e => e.MiscFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Misc_Fecha");

                entity.Property(e => e.MiscMontoCredito)
                    .HasColumnType("money")
                    .HasColumnName("Misc_MontoCredito")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MiscMontoDebito)
                    .HasColumnType("money")
                    .HasColumnName("Misc_MontoDebito")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MiscNcf)
                    .HasMaxLength(19)
                    .HasColumnName("Misc_NCF")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MiscRnc)
                    .HasMaxLength(255)
                    .HasColumnName("Misc_RNC");
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.HasKey(e => e.ModeloId)
                    .HasName("aaaaaModelo_PK")
                    .IsClustered(false);

                entity.ToTable("Modelo");

                entity.HasIndex(e => e.ModeloId, "Modelo_ID");

                entity.Property(e => e.ModeloId).HasColumnName("Modelo_ID");

                entity.Property(e => e.MarcaId).HasColumnName("Marca_ID");

                entity.Property(e => e.ModeloDesc)
                    .HasMaxLength(100)
                    .HasColumnName("Modelo_Desc");
            });

            modelBuilder.Entity<MovInventario>(entity =>
            {
                entity.HasKey(e => e.MovId)
                    .HasName("aaaaaMovInventario_PK")
                    .IsClustered(false);

                entity.ToTable("MovInventario");

                entity.HasIndex(e => e.AlmacenId, "Almacen_ID");

                entity.HasIndex(e => e.ArticuloId, "Articulo_ID");

                entity.HasIndex(e => e.CuentaId, "Cuenta_ID");

                entity.HasIndex(e => e.MovId, "Mov_ID");

                entity.Property(e => e.MovId).HasColumnName("Mov_ID");

                entity.Property(e => e.AjustInventarioDetId).HasColumnName("AjustInventarioDet_ID");

                entity.Property(e => e.AlmacenId).HasColumnName("Almacen_ID");

                entity.Property(e => e.ArticuloId)
                    .HasColumnName("Articulo_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentaId).HasColumnName("Cuenta_ID");

                entity.Property(e => e.MovCantidad)
                    .HasColumnName("Mov_Cantidad")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MovComentario)
                    .HasMaxLength(250)
                    .HasColumnName("Mov_Comentario");

                entity.Property(e => e.MovFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Mov_Fecha");

                entity.Property(e => e.MovMontoGp)
                    .HasColumnType("money")
                    .HasColumnName("Mov_MontoGP");

                entity.Property(e => e.MovPrecio)
                    .HasColumnType("money")
                    .HasColumnName("Mov_Precio")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MovSiAjuste).HasColumnName("Mov_SiAjuste");

                entity.Property(e => e.MovTipo)
                    .HasColumnName("Mov_Tipo")
                    .HasDefaultValueSql("((0))")
                    .HasComment("1 =Ent,   2=Sal,   3=Ajuste Positivo,  4=Ajuste Negativo");

                entity.Property(e => e.UpsizeTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("upsize_ts");
            });

            modelBuilder.Entity<Nacionalidad>(entity =>
            {
                entity.ToTable("Nacionalidad");

                entity.Property(e => e.NacionalidadId)
                    .ValueGeneratedNever()
                    .HasColumnName("Nacionalidad_ID");

                entity.Property(e => e.NacionalidadDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nacionalidad_Desc");
            });

            modelBuilder.Entity<NotaCr>(entity =>
            {
                entity.HasKey(e => e.NotaCrId)
                    .HasName("aaaaaNotaCr_PK")
                    .IsClustered(false);

                entity.ToTable("NotaCr");

                entity.HasIndex(e => e.FacturaId, "FacturaNotaCr");

                entity.HasIndex(e => e.FacturaId, "Factura_ID");

                entity.HasIndex(e => e.NotaCrId, "NotaCr_ID");

                entity.Property(e => e.NotaCrId).HasColumnName("NotaCr_ID");

                entity.Property(e => e.FacturaId)
                    .HasColumnName("Factura_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NotaCrComentario)
                    .HasMaxLength(200)
                    .HasColumnName("NotaCr_Comentario");

                entity.Property(e => e.NotaCrComprobante)
                    .HasMaxLength(20)
                    .HasColumnName("NotaCr_Comprobante");

                entity.Property(e => e.NotaCrCosto)
                    .HasColumnType("money")
                    .HasColumnName("NotaCr_Costo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NotaCrDescto)
                    .HasColumnType("money")
                    .HasColumnName("NotaCr_Descto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NotaCrFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("NotaCr_Fecha");

                entity.Property(e => e.NotaCrItbis)
                    .HasColumnType("money")
                    .HasColumnName("NotaCr_ITBIS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NotaCrMonto)
                    .HasColumnType("money")
                    .HasColumnName("NotaCr_Monto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NotaCrMontoUsado)
                    .HasColumnName("NotaCr_MontoUsado")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NotaCrNo)
                    .HasMaxLength(20)
                    .HasColumnName("NotaCr_No");

                entity.Property(e => e.UpsizeTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("upsize_ts");

                entity.HasOne(d => d.Factura)
                    .WithMany(p => p.NotaCrs)
                    .HasForeignKey(d => d.FacturaId)
                    .HasConstraintName("NotaCr_FK00");
            });

            modelBuilder.Entity<NotaCrDet>(entity =>
            {
                entity.HasKey(e => e.NotaCrDetId)
                    .HasName("aaaaaNotaCrDet_PK")
                    .IsClustered(false);

                entity.ToTable("NotaCrDet");

                entity.HasIndex(e => e.ArticuloId, "NotaCrDetArticulo_ID");

                entity.HasIndex(e => e.NotaCrDetId, "NotaCrDet_ID");

                entity.HasIndex(e => e.NotaCrId, "NotaCrNotaCrDet");

                entity.HasIndex(e => e.NotaCrId, "NotaCr_ID");

                entity.HasIndex(e => e.UnidadId, "Unidad_ID");

                entity.Property(e => e.NotaCrDetId).HasColumnName("NotaCrDet_ID");

                entity.Property(e => e.ArticuloId)
                    .HasColumnName("Articulo_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaItbis)
                    .HasColumnType("money")
                    .HasColumnName("Factura_ITBIS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaPrecio)
                    .HasColumnType("money")
                    .HasColumnName("Factura_Precio")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FacturaQty)
                    .HasColumnName("Factura_Qty")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NotaCrDetSiCant).HasColumnName("NotaCrDet_SiCant");

                entity.Property(e => e.NotaCrId)
                    .HasColumnName("NotaCr_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UnidadId).HasColumnName("Unidad_ID");

                entity.Property(e => e.UpsizeTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("upsize_ts");

                entity.HasOne(d => d.NotaCr)
                    .WithMany(p => p.NotaCrDets)
                    .HasForeignKey(d => d.NotaCrId)
                    .HasConstraintName("NotaCrDet_FK00");
            });

            modelBuilder.Entity<NotaDb>(entity =>
            {
                entity.HasKey(e => e.NotaDbId)
                    .HasName("aaaaaNotaDb_PK")
                    .IsClustered(false);

                entity.ToTable("NotaDb");

                entity.HasIndex(e => e.CompraId, "CompraNotaDb");

                entity.HasIndex(e => e.CompraId, "Compra_ID");

                entity.HasIndex(e => e.NotaDbId, "NotaCr_ID");

                entity.Property(e => e.NotaDbId).HasColumnName("NotaDb_ID");

                entity.Property(e => e.CompraId)
                    .HasColumnName("Compra_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NotaDbComentario)
                    .HasMaxLength(100)
                    .HasColumnName("NotaDb_Comentario");

                entity.Property(e => e.NotaDbComprobante)
                    .HasMaxLength(20)
                    .HasColumnName("NotaDB_Comprobante");

                entity.Property(e => e.NotaDbDescto)
                    .HasColumnType("money")
                    .HasColumnName("NotaDb_Descto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NotaDbFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("NotaDb_Fecha");

                entity.Property(e => e.NotaDbItbis)
                    .HasColumnType("money")
                    .HasColumnName("NotaDb_ITBIS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NotaDbMonto)
                    .HasColumnType("money")
                    .HasColumnName("NotaDb_Monto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NotaDbMontoUsado)
                    .HasColumnType("money")
                    .HasColumnName("NotaDB_MontoUsado")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NotaDbNo)
                    .HasMaxLength(20)
                    .HasColumnName("NotaDb_NO");

                entity.HasOne(d => d.Compra)
                    .WithMany(p => p.NotaDbs)
                    .HasForeignKey(d => d.CompraId)
                    .HasConstraintName("NotaDb_FK00");
            });

            modelBuilder.Entity<NotaDbCompra>(entity =>
            {
                entity.HasKey(e => e.NotaDbCompraId)
                    .HasName("aaaaaNotaDbCompra_PK")
                    .IsClustered(false);

                entity.ToTable("NotaDbCompra");

                entity.HasIndex(e => e.CompraId, "CompraNotaDbCompra");

                entity.HasIndex(e => e.CompraId, "Compra_ID");

                entity.HasIndex(e => e.NotaDbCompraId, "NotaDbCompra_ID");

                entity.HasIndex(e => e.NotaDbId, "NotaDbNotaDbCompra");

                entity.HasIndex(e => e.NotaDbId, "NotaDb_ID");

                entity.Property(e => e.NotaDbCompraId).HasColumnName("NotaDbCompra_ID");

                entity.Property(e => e.CompraId)
                    .HasColumnName("Compra_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NotaDbCompraFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("NotaDbCompra_Fecha");

                entity.Property(e => e.NotaDbCompraMonto)
                    .HasColumnType("money")
                    .HasColumnName("NotaDbCompra_Monto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NotaDbId)
                    .HasColumnName("NotaDb_ID")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<NotaDbDet>(entity =>
            {
                entity.HasKey(e => e.NotaDbDetId)
                    .HasName("aaaaaNotaDbDet_PK")
                    .IsClustered(false);

                entity.ToTable("NotaDbDet");

                entity.HasIndex(e => e.NotaDbDetId, "NotaCrDet_ID")
                    .IsUnique();

                entity.HasIndex(e => e.NotaDbId, "NotaCr_ID");

                entity.HasIndex(e => e.ArticuloId, "NotaDbDetArticulo_ID");

                entity.HasIndex(e => e.NotaDbId, "NotaDbNotaDbDet");

                entity.HasIndex(e => e.UnidadId, "Unidad_ID");

                entity.Property(e => e.NotaDbDetId).HasColumnName("NotaDbDet_ID");

                entity.Property(e => e.ArticuloId)
                    .HasColumnName("Articulo_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompraItbis)
                    .HasColumnType("money")
                    .HasColumnName("Compra_ITBIS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompraPrecio)
                    .HasColumnType("money")
                    .HasColumnName("Compra_Precio")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompraQty)
                    .HasColumnName("Compra_Qty")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NotaDbDetSiCant).HasColumnName("NotaDbDet_SiCant");

                entity.Property(e => e.NotaDbId).HasColumnName("NotaDb_ID");

                entity.Property(e => e.UnidadId).HasColumnName("Unidad_ID");

                entity.Property(e => e.UpsizeTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("upsize_ts");

                entity.HasOne(d => d.NotaDb)
                    .WithMany(p => p.NotaDbDets)
                    .HasForeignKey(d => d.NotaDbId)
                    .HasConstraintName("NotaDbDet_FK00");
            });

            modelBuilder.Entity<Opestatus>(entity =>
            {
                entity.HasKey(e => e.OpestatusId)
                    .HasName("aaaaaOPEstatus_PK")
                    .IsClustered(false);

                entity.ToTable("OPEstatus");

                entity.Property(e => e.OpestatusId).HasColumnName("OPEstatus_ID");

                entity.Property(e => e.OpestatusDesc)
                    .HasMaxLength(250)
                    .HasColumnName("OPEstatus_Desc");

                entity.Property(e => e.OpestatusOrden).HasColumnName("OPEstatus_Orden");

                entity.Property(e => e.OpestatusTipo).HasColumnName("OPEstatus_Tipo");
            });

            modelBuilder.Entity<Oplog>(entity =>
            {
                entity.HasKey(e => new { e.OrdenProduccionId, e.OpestatusOrden })
                    .HasName("aaaaaOPLog_PK")
                    .IsClustered(false);

                entity.ToTable("OPLog");

                entity.HasIndex(e => e.OpestatusOrden, "OPEstatus_ID");

                entity.Property(e => e.OrdenProduccionId).HasColumnName("OrdenProduccion_ID");

                entity.Property(e => e.OpestatusOrden).HasColumnName("OPEstatus_Orden");

                entity.Property(e => e.OplogFechaHora)
                    .HasColumnType("datetime")
                    .HasColumnName("OPLog_FechaHora");
            });

            modelBuilder.Entity<OrdenCompra>(entity =>
            {
                entity.HasKey(e => e.OrdenCompraId)
                    .HasName("aaaaaOrdenCompra_PK")
                    .IsClustered(false);

                entity.ToTable("OrdenCompra");

                entity.HasIndex(e => e.OrdenCompraId, "Compra_ID");

                entity.HasIndex(e => e.CondPagoId, "CondPagoOrdenCompra");

                entity.HasIndex(e => e.CondPagoId, "CondPago_ID");

                entity.HasIndex(e => e.SuplidorId, "SuplidorOrdenCompra");

                entity.HasIndex(e => e.SuplidorId, "Suplidor_ID");

                entity.Property(e => e.OrdenCompraId).HasColumnName("OrdenCompra_ID");

                entity.Property(e => e.AlmacenId).HasColumnName("Almacen_ID");

                entity.Property(e => e.CondPagoId)
                    .HasColumnName("CondPago_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenCompraComentario)
                    .HasMaxLength(255)
                    .HasColumnName("OrdenCompra_Comentario");

                entity.Property(e => e.OrdenCompraDescto)
                    .HasColumnType("money")
                    .HasColumnName("OrdenCompra_Descto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenCompraEstatus)
                    .HasColumnName("OrdenCompra_Estatus")
                    .HasComment("Yes = Abierta, No = Cerrada");

                entity.Property(e => e.OrdenCompraFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("OrdenCompra_Fecha");

                entity.Property(e => e.OrdenCompraItbis)
                    .HasColumnType("money")
                    .HasColumnName("OrdenCompra_ITBIS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenCompraMonto)
                    .HasColumnType("money")
                    .HasColumnName("OrdenCompra_Monto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenCompraNo)
                    .HasMaxLength(20)
                    .HasColumnName("OrdenCompra_No");

                entity.Property(e => e.OrdenCompraSiCompra).HasColumnName("OrdenCompra_SiCompra");

                entity.Property(e => e.SuplidorId)
                    .HasColumnName("Suplidor_ID")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Almacen)
                    .WithMany(p => p.OrdenCompras)
                    .HasForeignKey(d => d.AlmacenId)
                    .HasConstraintName("FK_OrdenCompra_Almacen");

                entity.HasOne(d => d.CondPago)
                    .WithMany(p => p.OrdenCompras)
                    .HasForeignKey(d => d.CondPagoId)
                    .HasConstraintName("OrdenCompra_FK00");

                entity.HasOne(d => d.Suplidor)
                    .WithMany(p => p.OrdenCompras)
                    .HasForeignKey(d => d.SuplidorId)
                    .HasConstraintName("OrdenCompra_FK01");
            });

            modelBuilder.Entity<OrdenCompraDet>(entity =>
            {
                entity.HasKey(e => e.OrdenCompraDetId)
                    .HasName("aaaaaOrdenCompraDet_PK")
                    .IsClustered(false);

                entity.ToTable("OrdenCompraDet");

                entity.HasIndex(e => e.ArticuloId, "Articulo_ID");

                entity.HasIndex(e => e.OrdenCompraDetId, "Compra_DetID");

                entity.HasIndex(e => e.OrdenCompraId, "Compra_ID");

                entity.HasIndex(e => e.OrdenCompraId, "OrdenCompraOrdenCompraDet");

                entity.HasIndex(e => e.UnidadId, "Unidad_ID");

                entity.Property(e => e.OrdenCompraDetId).HasColumnName("OrdenCompraDet_ID");

                entity.Property(e => e.ArticuloId)
                    .HasColumnName("Articulo_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenCompraDetArticulo)
                    .HasMaxLength(250)
                    .HasColumnName("OrdenCompraDet_Articulo");

                entity.Property(e => e.OrdenCompraDetComentario)
                    .HasMaxLength(250)
                    .HasColumnName("OrdenCompraDet_Comentario");

                entity.Property(e => e.OrdenCompraDetCosto)
                    .HasColumnType("money")
                    .HasColumnName("OrdenCompraDet_Costo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenCompraDetItbis)
                    .HasColumnType("money")
                    .HasColumnName("OrdenCompraDet_ITBIS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenCompraDetQty)
                    .HasColumnName("OrdenCompraDet_Qty")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenCompraDetSiItbisinc).HasColumnName("OrdenCompraDet_SiITBISInc");

                entity.Property(e => e.OrdenCompraId)
                    .HasColumnName("OrdenCompra_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UnidadId).HasColumnName("Unidad_ID");

                entity.HasOne(d => d.OrdenCompra)
                    .WithMany(p => p.OrdenCompraDets)
                    .HasForeignKey(d => d.OrdenCompraId)
                    .HasConstraintName("OrdenCompraDet_FK00");
            });

            modelBuilder.Entity<OrdenProduccion>(entity =>
            {
                entity.HasKey(e => e.OrdenProduccionId)
                    .HasName("aaaaaOrdenProduccion_PK")
                    .IsClustered(false);

                entity.ToTable("OrdenProduccion");

                entity.HasIndex(e => e.AlmacenId, "Almacen_ID");

                entity.HasIndex(e => e.ArticuloId, "Articulo_ID");

                entity.HasIndex(e => e.ClienteId, "ClienteOrdenProduccion");

                entity.HasIndex(e => e.ClienteId, "ClienteOrdenProduccion1");

                entity.HasIndex(e => e.ClienteId, "Cliente_ID");

                entity.HasIndex(e => e.OpestatusId, "OPEstatusOrdenProduccion");

                entity.HasIndex(e => e.OpestatusId, "OPEstatusOrdenProduccion1");

                entity.HasIndex(e => e.OpestatusId, "OPEstatus_ID");

                entity.HasIndex(e => e.OrdenProduccionId, "OrdenProduccion_ID");

                entity.Property(e => e.OrdenProduccionId).HasColumnName("OrdenProduccion_ID");

                entity.Property(e => e.AlmacenId).HasColumnName("Almacen_ID");

                entity.Property(e => e.ArticuloId)
                    .HasColumnName("Articulo_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ClienteId)
                    .HasColumnName("Cliente_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OpestatusId).HasColumnName("OPEstatus_ID");

                entity.Property(e => e.OrdenProduccionAncho)
                    .HasColumnName("OrdenProduccion_Ancho")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionCantDisponible)
                    .HasColumnName("OrdenProduccion_CantDisponible")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionCantOrdenada)
                    .HasColumnName("OrdenProduccion_CantOrdenada")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionCantReportada)
                    .HasColumnName("OrdenProduccion_CantReportada")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionComentario)
                    .HasMaxLength(254)
                    .HasColumnName("OrdenProduccion_Comentario");

                entity.Property(e => e.OrdenProduccionCosto)
                    .HasColumnType("money")
                    .HasColumnName("OrdenProduccion_Costo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("OrdenProduccion_Fecha");

                entity.Property(e => e.OrdenProduccionFondo)
                    .HasColumnName("OrdenProduccion_Fondo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionLargo)
                    .HasColumnName("OrdenProduccion_Largo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionNo)
                    .HasColumnName("OrdenProduccion_No")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionNoAfectaInv).HasColumnName("OrdenProduccion_NoAfectaInv");

                entity.Property(e => e.OrdenProduccionOrden).HasColumnName("OrdenProduccion_Orden");

                entity.Property(e => e.OrdenProduccionSiPospuesto).HasColumnName("OrdenProduccion_SiPospuesto");

                entity.Property(e => e.UpsizeTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("upsize_ts");
            });

            modelBuilder.Entity<OrdenProduccionArtUsado>(entity =>
            {
                entity.HasKey(e => e.OrdenProduccionArtUsadoId)
                    .HasName("aaaaaOrdenProduccionArtUsado_PK")
                    .IsClustered(false);

                entity.ToTable("OrdenProduccionArtUsado");

                entity.HasIndex(e => e.AlmacenId, "AlmacenOrdenProduccionArtUsado");

                entity.HasIndex(e => e.AlmacenId, "Almacen_ID");

                entity.HasIndex(e => e.ArticuloId, "Articulo_ID");

                entity.HasIndex(e => e.OrdenProduccionArtUsadoId, "OrdenProduccionArtUsado_ID");

                entity.HasIndex(e => e.OrdenProduccionId, "OrdenProduccionOrdenProduccionArtUsado");

                entity.HasIndex(e => e.OrdenProduccionId, "OrdenProduccion_ID");

                entity.Property(e => e.OrdenProduccionArtUsadoId).HasColumnName("OrdenProduccionArtUsado_ID");

                entity.Property(e => e.AlmacenId).HasColumnName("Almacen_ID");

                entity.Property(e => e.ArticuloId).HasColumnName("Articulo_ID");

                entity.Property(e => e.OrdenProduccionArtUsadoCant).HasColumnName("OrdenProduccionArtUsado_Cant");

                entity.Property(e => e.OrdenProduccionId).HasColumnName("OrdenProduccion_ID");

                entity.Property(e => e.UpsizeTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("upsize_ts");

                entity.HasOne(d => d.Almacen)
                    .WithMany(p => p.OrdenProduccionArtUsados)
                    .HasForeignKey(d => d.AlmacenId)
                    .HasConstraintName("OrdenProduccionArtUsado_FK00");

                entity.HasOne(d => d.OrdenProduccion)
                    .WithMany(p => p.OrdenProduccionArtUsados)
                    .HasForeignKey(d => d.OrdenProduccionId)
                    .HasConstraintName("OrdenProduccionArtUsado_FK01");
            });

            modelBuilder.Entity<OrdenProduccionImprimir>(entity =>
            {
                entity.HasKey(e => e.OrdenProduccionImprimirId)
                    .HasName("aaaaaOrdenProduccionImprimir_PK")
                    .IsClustered(false);

                entity.ToTable("OrdenProduccionImprimir");

                entity.HasIndex(e => e.OrdenProduccionImprimirId, "OrdernProductionImprimir_ID");

                entity.Property(e => e.OrdenProduccionImprimirId).HasColumnName("OrdenProduccionImprimir_ID");

                entity.Property(e => e.ArticuloCd)
                    .HasMaxLength(30)
                    .HasColumnName("Articulo_CD");

                entity.Property(e => e.ArticuloCosto)
                    .HasColumnName("Articulo_Costo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ArticuloDesc)
                    .HasMaxLength(50)
                    .HasColumnName("Articulo_Desc");

                entity.Property(e => e.ArticuloDesc2)
                    .HasMaxLength(50)
                    .HasColumnName("Articulo_Desc2");

                entity.Property(e => e.Cant).HasDefaultValueSql("((0))");

                entity.Property(e => e.ClienteCodigo)
                    .HasMaxLength(20)
                    .HasColumnName("Cliente_Codigo");

                entity.Property(e => e.ClienteNombre)
                    .HasMaxLength(50)
                    .HasColumnName("Cliente_Nombre");

                entity.Property(e => e.Computadora).HasMaxLength(50);

                entity.Property(e => e.GeneralFactorPietaje)
                    .HasColumnName("General_FactorPietaje")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MaterialesPorArticuloDesc)
                    .HasMaxLength(50)
                    .HasColumnName("MaterialesPorArticulo_Desc");

                entity.Property(e => e.Medida1).HasDefaultValueSql("((0))");

                entity.Property(e => e.Medida2).HasDefaultValueSql("((0))");

                entity.Property(e => e.Medida3).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionAncho)
                    .HasColumnName("OrdenProduccion_Ancho")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionCantOrdenada)
                    .HasColumnName("OrdenProduccion_CantOrdenada")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("OrdenProduccion_Fecha");

                entity.Property(e => e.OrdenProduccionFondo)
                    .HasColumnName("OrdenProduccion_Fondo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionLargo)
                    .HasColumnName("OrdenProduccion_Largo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionNo)
                    .HasColumnName("OrdenProduccion_No")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpsizeTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("upsize_ts");
            });

            modelBuilder.Entity<OrdenProduccionTemp>(entity =>
            {
                entity.HasKey(e => e.OrdenProduccionTempId)
                    .HasName("aaaaaOrdenProduccionTemp_PK")
                    .IsClustered(false);

                entity.ToTable("OrdenProduccionTemp");

                entity.HasIndex(e => e.ArticuloId, "Articulo_ID");

                entity.HasIndex(e => e.ClienteId, "Cliente_ID");

                entity.HasIndex(e => e.OrdenProduccionTempId, "OrdenProduccion_ID");

                entity.Property(e => e.OrdenProduccionTempId).HasColumnName("OrdenProduccionTemp_ID");

                entity.Property(e => e.ArticuloId)
                    .HasColumnName("Articulo_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ClienteId)
                    .HasColumnName("Cliente_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Computadora).HasMaxLength(255);

                entity.Property(e => e.OrdenProduccionTempAncho)
                    .HasColumnName("OrdenProduccionTemp_Ancho")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionTempCantOrdenada)
                    .HasColumnName("OrdenProduccionTemp_CantOrdenada")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionTempCosto)
                    .HasColumnType("money")
                    .HasColumnName("OrdenProduccionTemp_Costo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionTempFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("OrdenProduccionTemp_Fecha");

                entity.Property(e => e.OrdenProduccionTempFondo)
                    .HasColumnName("OrdenProduccionTemp_Fondo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionTempLargo)
                    .HasColumnName("OrdenProduccionTemp_Largo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionTempNo)
                    .HasColumnName("OrdenProduccionTemp_No")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpsizeTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("upsize_ts");
            });

            modelBuilder.Entity<OrdenProduccionTempImprimir>(entity =>
            {
                entity.HasKey(e => e.OrdenProduccionTempImprimirId)
                    .HasName("aaaaaOrdenProduccionTempImprimir_PK")
                    .IsClustered(false);

                entity.ToTable("OrdenProduccionTempImprimir");

                entity.HasIndex(e => e.OrdenProduccionTempImprimirId, "OrdernProductionImprimir_ID");

                entity.Property(e => e.OrdenProduccionTempImprimirId).HasColumnName("OrdenProduccionTempImprimir_ID");

                entity.Property(e => e.ArticuloCd)
                    .HasMaxLength(30)
                    .HasColumnName("Articulo_CD");

                entity.Property(e => e.ArticuloCosto)
                    .HasColumnName("Articulo_Costo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ArticuloDesc)
                    .HasMaxLength(50)
                    .HasColumnName("Articulo_Desc");

                entity.Property(e => e.ArticuloDesc2)
                    .HasMaxLength(50)
                    .HasColumnName("Articulo_Desc2");

                entity.Property(e => e.Cant).HasDefaultValueSql("((0))");

                entity.Property(e => e.ClienteCodigo)
                    .HasMaxLength(20)
                    .HasColumnName("Cliente_Codigo");

                entity.Property(e => e.ClienteNombre)
                    .HasMaxLength(50)
                    .HasColumnName("Cliente_Nombre");

                entity.Property(e => e.Computadora).HasMaxLength(50);

                entity.Property(e => e.GeneralFactorPietaje)
                    .HasColumnName("General_FactorPietaje")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MaterialesPorArticuloDesc)
                    .HasMaxLength(50)
                    .HasColumnName("MaterialesPorArticulo_Desc");

                entity.Property(e => e.Medida1).HasDefaultValueSql("((0))");

                entity.Property(e => e.Medida2).HasDefaultValueSql("((0))");

                entity.Property(e => e.Medida3).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionTempAncho)
                    .HasColumnName("OrdenProduccionTemp_Ancho")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionTempCantOrdenada)
                    .HasColumnName("OrdenProduccionTemp_CantOrdenada")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionTempFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("OrdenProduccionTemp_Fecha");

                entity.Property(e => e.OrdenProduccionTempFondo)
                    .HasColumnName("OrdenProduccionTemp_Fondo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionTempLargo)
                    .HasColumnName("OrdenProduccionTemp_Largo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdenProduccionTempNo)
                    .HasColumnName("OrdenProduccionTemp_No")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpsizeTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("upsize_ts");
            });

            modelBuilder.Entity<Pantalla>(entity =>
            {
                entity.HasKey(e => e.PantallaId)
                    .HasName("aaaaaPantalla_PK")
                    .IsClustered(false);

                entity.ToTable("Pantalla");

                entity.Property(e => e.PantallaId)
                    .ValueGeneratedNever()
                    .HasColumnName("Pantalla_ID");

                entity.Property(e => e.PantallaDesc)
                    .HasMaxLength(50)
                    .HasColumnName("Pantalla_Desc");

                entity.Property(e => e.PantallaGrupo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Pantalla_Grupo");

                entity.Property(e => e.PantallaLinkWeb)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pantalla_LinkWeb");

                entity.Property(e => e.PantallaNombre)
                    .HasMaxLength(50)
                    .HasColumnName("Pantalla_Nombre");

                entity.Property(e => e.PantallaSoloEscritorio).HasColumnName("Pantalla_SoloEscritorio");

                entity.Property(e => e.PantallaTipo)
                    .HasMaxLength(2)
                    .HasColumnName("Pantalla_Tipo");
            });

            modelBuilder.Entity<PantallaAutoridad>(entity =>
            {
                entity.HasKey(e => new { e.AutoridadId, e.PantallaId })
                    .HasName("aaaaaPantalla_Autoridad_PK")
                    .IsClustered(false);

                entity.ToTable("Pantalla_Autoridad");

                entity.HasIndex(e => e.AutoridadId, "AutoridadPantalla_Autoridad");

                entity.HasIndex(e => e.PantallaId, "PantallaPantalla_Autoridad");

                entity.HasIndex(e => e.AutoridadId, "Pantalla_AutoridadAutoridad_ID");

                entity.HasIndex(e => e.PantallaId, "Pantalla_ID");

                entity.Property(e => e.AutoridadId).HasColumnName("Autoridad_ID");

                entity.Property(e => e.PantallaId).HasColumnName("Pantalla_ID");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasKey(e => e.PlanId)
                    .HasName("aaaaaPlan_PK")
                    .IsClustered(false);

                entity.ToTable("Plan");

                entity.HasIndex(e => e.PlanId, "Oferta_ID");

                entity.Property(e => e.PlanId).HasColumnName("Plan_ID");

                entity.Property(e => e.PlanDesc)
                    .HasMaxLength(255)
                    .HasColumnName("Plan_Desc");

                entity.Property(e => e.PlanEstatus).HasColumnName("Plan_Estatus");
            });

            modelBuilder.Entity<Plantum>(entity =>
            {
                entity.HasKey(e => e.PlantaId)
                    .HasName("aaaaaPlanta_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.PlantaId, "Planta_ID");

                entity.Property(e => e.PlantaId).HasColumnName("Planta_ID");

                entity.Property(e => e.PlantaDesc)
                    .HasMaxLength(255)
                    .HasColumnName("Planta_Desc");

                entity.Property(e => e.PlantaEstatus).HasColumnName("Planta_Estatus");
            });

            modelBuilder.Entity<Precio>(entity =>
            {
                entity.HasKey(e => e.PrecioId)
                    .HasName("aaaaaPrecio_PK")
                    .IsClustered(false);

                entity.ToTable("Precio");

                entity.HasIndex(e => e.ArticuloId, "Articulo_ID");

                entity.HasIndex(e => e.PrecioId, "Precio_ID");

                entity.Property(e => e.PrecioId).HasColumnName("Precio_ID");

                entity.Property(e => e.ArticuloId).HasColumnName("Articulo_ID");

                entity.Property(e => e.PrecioCodigo)
                    .HasMaxLength(255)
                    .HasColumnName("Precio_Codigo");

                entity.Property(e => e.PrecioComision).HasColumnName("Precio_Comision");

                entity.Property(e => e.PrecioGanancia).HasColumnName("Precio_Ganancia");

                entity.Property(e => e.PrecioMonto).HasColumnName("Precio_Monto");

                entity.Property(e => e.PrecioNo).HasColumnName("Precio_No");

                entity.Property(e => e.UpsizeTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("upsize_ts");
            });

            modelBuilder.Entity<Prepago>(entity =>
            {
                entity.HasKey(e => e.PrepagoId)
                    .HasName("aaaaaPrepago_PK")
                    .IsClustered(false);

                entity.ToTable("Prepago");

                entity.HasIndex(e => e.ClienteId, "ClientePrepago");

                entity.HasIndex(e => e.ClienteId, "Cliente_ID");

                entity.HasIndex(e => e.ComprobanteTipoId, "ComprobanteTipo_ID");

                entity.HasIndex(e => e.PrepagoId, "Prepago_ID");

                entity.Property(e => e.PrepagoId).HasColumnName("Prepago_ID");

                entity.Property(e => e.ClienteId).HasColumnName("Cliente_ID");

                entity.Property(e => e.ComprobanteTipoId)
                    .HasColumnName("ComprobanteTipo_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PrepagoComprobante)
                    .HasMaxLength(20)
                    .HasColumnName("Prepago_Comprobante");

                entity.Property(e => e.PrepagoFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Prepago_Fecha");

                entity.Property(e => e.PrepagoNo).HasColumnName("Prepago_No");

                entity.Property(e => e.PrepagoNota)
                    .HasMaxLength(250)
                    .HasColumnName("Prepago_Nota");

                entity.Property(e => e.PrepagoValorTotal)
                    .HasColumnType("money")
                    .HasColumnName("Prepago_ValorTotal");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Prepagos)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("Prepago_FK00");

                entity.HasOne(d => d.ComprobanteTipo)
                    .WithMany(p => p.Prepagos)
                    .HasForeignKey(d => d.ComprobanteTipoId)
                    .HasConstraintName("Prepago_FK01");
            });

            modelBuilder.Entity<PrepagoDet>(entity =>
            {
                entity.HasKey(e => e.PrepagoDetId)
                    .HasName("aaaaaPrepagoDet_PK")
                    .IsClustered(false);

                entity.ToTable("PrepagoDet");

                entity.HasIndex(e => e.CierreCajaId, "CierreCaja_ID");

                entity.HasIndex(e => e.PrepagoDetId, "PrepagoDet_ID");

                entity.HasIndex(e => e.PrepagoId, "PrepagoPrepagoDet");

                entity.HasIndex(e => e.PrepagoId, "Prepago_ID");

                entity.HasIndex(e => e.TipoPagoId, "TipoPagoPrepagoDet");

                entity.HasIndex(e => e.TipoPagoId, "TipoPago_ID");

                entity.HasIndex(e => e.UsuarioId, "UsuarioPrepagoDet");

                entity.HasIndex(e => e.UsuarioId, "Usuario_ID");

                entity.Property(e => e.PrepagoDetId).HasColumnName("PrepagoDet_ID");

                entity.Property(e => e.CierreCajaId)
                    .HasColumnName("CierreCaja_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PrepagoDetFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("PrepagoDet_Fecha");

                entity.Property(e => e.PrepagoDetMonto)
                    .HasColumnType("money")
                    .HasColumnName("PrepagoDet_Monto");

                entity.Property(e => e.PrepagoDetMontoConsumido)
                    .HasColumnType("money")
                    .HasColumnName("PrepagoDet_MontoConsumido");

                entity.Property(e => e.PrepagoId).HasColumnName("Prepago_ID");

                entity.Property(e => e.TipoPagoId).HasColumnName("TipoPago_ID");

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");

                entity.HasOne(d => d.Prepago)
                    .WithMany(p => p.PrepagoDets)
                    .HasForeignKey(d => d.PrepagoId)
                    .HasConstraintName("PrepagoDet_FK01");

                entity.HasOne(d => d.TipoPago)
                    .WithMany(p => p.PrepagoDets)
                    .HasForeignKey(d => d.TipoPagoId)
                    .HasConstraintName("PrepagoDet_FK02");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.PrepagoDets)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("PrepagoDet_FK03");
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(e => e.PrestamoId)
                    .HasName("aaaaaPrestamo_PK")
                    .IsClustered(false);

                entity.ToTable("Prestamo");

                entity.HasIndex(e => e.ClienteId, "ClientePrestamo");

                entity.HasIndex(e => e.ClienteId, "Cliente_ID");

                entity.HasIndex(e => e.PrestamoId, "Prestamo_ID");

                entity.Property(e => e.PrestamoId).HasColumnName("Prestamo_ID");

                entity.Property(e => e.ClienteId)
                    .HasColumnName("Cliente_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PrestamoBalance)
                    .HasColumnType("money")
                    .HasColumnName("Prestamo_Balance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PrestamoCapitalPendiente)
                    .HasColumnType("money")
                    .HasColumnName("Prestamo_CapitalPendiente");

                entity.Property(e => e.PrestamoDuracion)
                    .HasColumnName("Prestamo_Duracion")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PrestamoEstatus).HasColumnName("Prestamo_Estatus");

                entity.Property(e => e.PrestamoFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Prestamo_Fecha");

                entity.Property(e => e.PrestamoFechaUltimoPago)
                    .HasColumnType("datetime")
                    .HasColumnName("Prestamo_FechaUltimoPago");

                entity.Property(e => e.PrestamoInteresesPendientes)
                    .HasColumnType("money")
                    .HasColumnName("Prestamo_InteresesPendientes")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PrestamoMonto)
                    .HasColumnType("money")
                    .HasColumnName("Prestamo_Monto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PrestamoMontoCuota)
                    .HasColumnType("money")
                    .HasColumnName("Prestamo_MontoCuota");

                entity.Property(e => e.PrestamoSiPagado).HasColumnName("Prestamo_SiPagado");

                entity.Property(e => e.PrestamoTasaAnual)
                    .HasColumnName("Prestamo_TasaAnual")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PrestamoTipo)
                    .HasColumnName("Prestamo_Tipo")
                    .HasComment("1=Amortizado, 2=No Amortizado, 3=Lineal Mensual");

                entity.Property(e => e.PrestamoTipoPeriodo)
                    .HasColumnName("Prestamo_TipoPeriodo")
                    .HasComment("1=Diario, 2=Semanal, 3=Bisemanal, 4=Quincenal, 5=Mensual");

                entity.Property(e => e.UpsizeTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("upsize_ts");
            });

            modelBuilder.Entity<Privilegio>(entity =>
            {
                entity.HasKey(e => e.PrivilegiosId);

                entity.Property(e => e.PrivilegiosId)
                    .ValueGeneratedNever()
                    .HasColumnName("Privilegios_ID");

                entity.Property(e => e.PrivilegiosDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Privilegios_Desc");

                entity.Property(e => e.PrivilegiosEstatus).HasColumnName("Privilegios_Estatus");
            });

            modelBuilder.Entity<Punto>(entity =>
            {
                entity.HasKey(e => e.PuntoId)
                    .HasName("aaaaaPunto_PK")
                    .IsClustered(false);

                entity.ToTable("Punto");

                entity.HasIndex(e => e.FacturaId, "CierreCaja_ID");

                entity.HasIndex(e => e.PuntoId, "Prepago_ID");

                entity.HasIndex(e => e.UsuarioId, "Usuario_ID");

                entity.Property(e => e.PuntoId).HasColumnName("Punto_ID");

                entity.Property(e => e.FacturaId)
                    .HasColumnName("Factura_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PuntoFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Punto_Fecha");

                entity.Property(e => e.PuntoMonto)
                    .HasColumnType("money")
                    .HasColumnName("Punto_Monto");

                entity.Property(e => e.PuntoMontoDisponible)
                    .HasColumnType("money")
                    .HasColumnName("Punto_MontoDisponible");

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");
            });

            modelBuilder.Entity<PuntoAutorizado>(entity =>
            {
                entity.HasKey(e => e.PuntoAutorizadoId)
                    .HasName("aaaaaPuntoAutorizado_PK")
                    .IsClustered(false);

                entity.ToTable("PuntoAutorizado");

                entity.HasIndex(e => e.ClienteId, "Cliente_ID");

                entity.HasIndex(e => e.UsuarioId, "Usuario_ID");

                entity.Property(e => e.PuntoAutorizadoId).HasColumnName("PuntoAutorizado_ID");

                entity.Property(e => e.ClienteId).HasColumnName("Cliente_ID");

                entity.Property(e => e.PuntoAutorizadoFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("PuntoAutorizado_Fecha");

                entity.Property(e => e.PuntoAutorizadoMonto)
                    .HasColumnType("money")
                    .HasColumnName("PuntoAutorizado_Monto");

                entity.Property(e => e.PuntoAutorizadoMontoConsumido)
                    .HasColumnType("money")
                    .HasColumnName("PuntoAutorizado_MontoConsumido");

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");
            });

            modelBuilder.Entity<QCuentasAuxiliare>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Q_CuentasAuxiliares");

                entity.Property(e => e.CuentaId).HasColumnName("Cuenta_ID");
            });

            modelBuilder.Entity<QCuentasCierreAnual>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Q_CuentasCierreAnual");

                entity.Property(e => e.CuentaId).HasColumnName("Cuenta_ID");

                entity.Property(e => e.CuentaNo)
                    .HasMaxLength(10)
                    .HasColumnName("Cuenta_No");
            });

            modelBuilder.Entity<QCuentasCierreMensual>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Q_CuentasCierreMensual");

                entity.Property(e => e.CuentaId).HasColumnName("Cuenta_ID");

                entity.Property(e => e.CuentaNo)
                    .HasMaxLength(10)
                    .HasColumnName("Cuenta_No");
            });

            modelBuilder.Entity<QCuentasEstado>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Q_Cuentas_Estados");

                entity.Property(e => e.CuentaDesc)
                    .HasMaxLength(50)
                    .HasColumnName("Cuenta_Desc");

                entity.Property(e => e.CuentaDesc1)
                    .HasMaxLength(50)
                    .HasColumnName("Cuenta_Desc1");

                entity.Property(e => e.CuentaDesc2)
                    .HasMaxLength(50)
                    .HasColumnName("Cuenta_Desc2");

                entity.Property(e => e.CuentaId).HasColumnName("Cuenta_ID");

                entity.Property(e => e.CuentaNo)
                    .HasMaxLength(10)
                    .HasColumnName("Cuenta_No");

                entity.Property(e => e.CuentaNo1)
                    .HasMaxLength(10)
                    .HasColumnName("Cuenta_No1");

                entity.Property(e => e.CuentaNo2)
                    .HasMaxLength(10)
                    .HasColumnName("Cuenta_No2");

                entity.Property(e => e.CuentaNo3)
                    .HasMaxLength(10)
                    .HasColumnName("CuentaNo");
            });

            modelBuilder.Entity<QEntradasDeDiario>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Q_EntradasDeDiario");

                entity.Property(e => e.CuentaDesc)
                    .HasMaxLength(255)
                    .HasColumnName("Cuenta_Desc");

                entity.Property(e => e.CuentaNo)
                    .HasMaxLength(255)
                    .HasColumnName("Cuenta_No");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Orden).HasMaxLength(255);
            });

            modelBuilder.Entity<QEntradasDeDiarioA1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Q_EntradasDeDiario_A1");

                entity.Property(e => e.CuentaDesc)
                    .HasMaxLength(50)
                    .HasColumnName("Cuenta_Desc");

                entity.Property(e => e.CuentaNo)
                    .HasMaxLength(10)
                    .HasColumnName("Cuenta_No");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Orden)
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QEntradasDeDiarioA2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Q_EntradasDeDiario_A2");

                entity.Property(e => e.CuentaDesc)
                    .HasMaxLength(50)
                    .HasColumnName("Cuenta_Desc");

                entity.Property(e => e.CuentaNo)
                    .HasMaxLength(10)
                    .HasColumnName("Cuenta_No");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Orden)
                    .HasMaxLength(33)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QEntradasDeDiarioB>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Q_EntradasDeDiario_B");

                entity.Property(e => e.CuentaDesc).HasMaxLength(50);

                entity.Property(e => e.CuentaNo).HasMaxLength(10);

                entity.Property(e => e.Fechas).HasColumnType("datetime");

                entity.Property(e => e.Orden)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QEntradasDeDiarioBc>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Q_EntradasDeDiario_BC");

                entity.Property(e => e.CuentaDesc)
                    .HasMaxLength(255)
                    .HasColumnName("Cuenta_Desc");

                entity.Property(e => e.CuentaNo)
                    .HasMaxLength(255)
                    .HasColumnName("Cuenta_No");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Orden).HasMaxLength(255);
            });

            modelBuilder.Entity<QEntradasDeDiarioC>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Q_EntradasDeDiario_C");

                entity.Property(e => e.CuentaDesc).HasMaxLength(50);

                entity.Property(e => e.CuentaNo).HasMaxLength(10);

                entity.Property(e => e.Fechas).HasColumnType("datetime");

                entity.Property(e => e.Orden)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QEntradasDeDiarioGen>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Q_EntradasDeDiarioGen");

                entity.Property(e => e.CuentaDesc)
                    .HasMaxLength(255)
                    .HasColumnName("Cuenta_Desc");

                entity.Property(e => e.CuentaNo)
                    .HasMaxLength(255)
                    .HasColumnName("Cuenta_No");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Orden).HasMaxLength(255);
            });

            modelBuilder.Entity<RecGasto>(entity =>
            {
                entity.HasKey(e => e.RecGastoId)
                    .HasName("aaaaaRecGasto_PK")
                    .IsClustered(false);

                entity.ToTable("RecGasto");

                entity.HasIndex(e => e.ComprobanteTipoId, "ComprobanteTipo_ID");

                entity.HasIndex(e => e.CondPagoId, "CondPagoRecGasto");

                entity.HasIndex(e => e.CondPagoId, "CondPago_ID");

                entity.HasIndex(e => e.GastoId, "GastoRecGasto");

                entity.HasIndex(e => e.GastoId, "Gasto_ID");

                entity.HasIndex(e => e.RecGastoId, "RecGasto_ID");

                entity.HasIndex(e => e.SuplidorId, "SuplidorRecGasto");

                entity.HasIndex(e => e.SuplidorId, "Suplidor_ID");

                entity.Property(e => e.RecGastoId).HasColumnName("RecGasto_ID");

                entity.Property(e => e.ComprobanteTipoId)
                    .HasColumnName("ComprobanteTipo_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CondPagoId)
                    .HasColumnName("CondPago_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GastoId)
                    .HasColumnName("Gasto_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RecGastoComentario)
                    .HasMaxLength(250)
                    .HasColumnName("RecGasto_Comentario");

                entity.Property(e => e.RecGastoDescto)
                    .HasColumnType("money")
                    .HasColumnName("RecGasto_Descto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RecGastoEstatus)
                    .HasColumnName("RecGasto_Estatus")
                    .HasComment("Yes = No pagada, No = Pagada con cheque");

                entity.Property(e => e.RecGastoFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("RecGasto_Fecha");

                entity.Property(e => e.RecGastoItbis)
                    .HasColumnType("money")
                    .HasColumnName("RecGasto_ITBIS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RecGastoItbisNcnd)
                    .HasColumnType("money")
                    .HasColumnName("RecGasto_ITBIS_NCND");

                entity.Property(e => e.RecGastoItbisretenido)
                    .HasColumnType("money")
                    .HasColumnName("RecGasto_ITBISRetenido")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RecGastoMonto)
                    .HasColumnType("money")
                    .HasColumnName("RecGasto_Monto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RecGastoMontoNcnd)
                    .HasColumnType("money")
                    .HasColumnName("RecGasto_Monto_NCND");

                entity.Property(e => e.RecGastoNcf)
                    .HasMaxLength(20)
                    .HasColumnName("RecGasto_NCF");

                entity.Property(e => e.RecGastoNo)
                    .HasMaxLength(20)
                    .HasColumnName("RecGasto_No");

                entity.Property(e => e.RecGastoSiBeneficio).HasColumnName("RecGasto_SiBeneficio");

                entity.Property(e => e.SuplidorId)
                    .HasColumnName("Suplidor_ID")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<RecGastoNcnd>(entity =>
            {
                entity.HasKey(e => e.RecGastoNcndId)
                    .HasName("aaaaaRecGastoNCND_PK")
                    .IsClustered(false);

                entity.ToTable("RecGastoNCND");

                entity.HasIndex(e => e.RecGastoId, "RecGasto_ID");

                entity.Property(e => e.RecGastoNcndId).HasColumnName("RecGastoNCND_ID");

                entity.Property(e => e.RecGastoId).HasColumnName("RecGasto_ID");

                entity.Property(e => e.RecGastoNcndItbis)
                    .HasColumnType("money")
                    .HasColumnName("RecGastoNCND_ITBIS");

                entity.Property(e => e.RecGastoNcndMonto)
                    .HasColumnType("money")
                    .HasColumnName("RecGastoNCND_Monto");

                entity.Property(e => e.RecGastoNcndNcf)
                    .HasMaxLength(255)
                    .HasColumnName("RecGastoNCND_NCF");
            });

            modelBuilder.Entity<RecGastoRecurrente>(entity =>
            {
                entity.HasKey(e => e.RecGastoRecurrenteId)
                    .HasName("aaaaaRecGastoRecurrente_PK")
                    .IsClustered(false);

                entity.ToTable("RecGastoRecurrente");

                entity.HasIndex(e => e.GastoId, "Gasto_ID");

                entity.HasIndex(e => e.RecGastoRecurrenteId, "RecGasto_ID");

                entity.HasIndex(e => e.SuplidorId, "Suplidor_ID");

                entity.Property(e => e.RecGastoRecurrenteId).HasColumnName("RecGastoRecurrente_ID");

                entity.Property(e => e.GastoId)
                    .HasColumnName("Gasto_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RecGastoRecurrenteComentario)
                    .HasMaxLength(250)
                    .HasColumnName("RecGastoRecurrente_Comentario");

                entity.Property(e => e.RecGastoRecurrenteFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("RecGastoRecurrente_Fecha");

                entity.Property(e => e.RecGastoRecurrenteItbis)
                    .HasColumnType("money")
                    .HasColumnName("RecGastoRecurrente_ITBIS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RecGastoRecurrenteMonto)
                    .HasColumnType("money")
                    .HasColumnName("RecGastoRecurrente_Monto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RecGastoRecurrenteNo)
                    .HasMaxLength(20)
                    .HasColumnName("RecGastoRecurrente_No");

                entity.Property(e => e.SuplidorId)
                    .HasColumnName("Suplidor_ID")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<ReciboCompra>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ReciboCompra");

                entity.Property(e => e.ChequeConcepto)
                    .HasMaxLength(100)
                    .HasColumnName("Cheque_Concepto");

                entity.Property(e => e.ClienteCodigo)
                    .HasMaxLength(20)
                    .HasColumnName("Cliente_Codigo");

                entity.Property(e => e.ClienteDir1)
                    .HasMaxLength(50)
                    .HasColumnName("Cliente_Dir1");

                entity.Property(e => e.ClienteNombre)
                    .HasMaxLength(50)
                    .HasColumnName("Cliente_Nombre");

                entity.Property(e => e.ClienteTel)
                    .HasMaxLength(13)
                    .HasColumnName("Cliente_Tel");

                entity.Property(e => e.CompraDescto)
                    .HasColumnType("money")
                    .HasColumnName("Compra_Descto");

                entity.Property(e => e.CompraNcf)
                    .HasMaxLength(20)
                    .HasColumnName("Compra_NCF");

                entity.Property(e => e.FacturaBalance)
                    .HasColumnType("money")
                    .HasColumnName("Factura_Balance");

                entity.Property(e => e.FacturaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Factura_Fecha");

                entity.Property(e => e.FacturaId).HasColumnName("Factura_ID");

                entity.Property(e => e.FacturaNo)
                    .HasMaxLength(20)
                    .HasColumnName("Factura_No");

                entity.Property(e => e.Pendiente).HasColumnType("money");

                entity.Property(e => e.ReciboFactPagoMonto)
                    .HasColumnType("money")
                    .HasColumnName("Recibo_FactPagoMonto");

                entity.Property(e => e.ReciboFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Recibo_Fecha");

                entity.Property(e => e.ReciboNo).HasColumnName("Recibo_NO");

                entity.Property(e => e.SuplidorCedula)
                    .HasMaxLength(50)
                    .HasColumnName("Suplidor_Cedula");

                entity.Property(e => e.SuplidorId).HasColumnName("Suplidor_ID");
            });

            modelBuilder.Entity<ReciboPago>(entity =>
            {
                entity.HasKey(e => e.ReciboId)
                    .HasName("aaaaaReciboPago_PK")
                    .IsClustered(false);

                entity.ToTable("ReciboPago");

                entity.HasIndex(e => e.CierreCajaId, "CierreCaja_ID");

                entity.HasIndex(e => e.ReciboFecha, "Factura_ID");

                entity.HasIndex(e => e.ReciboId, "Recibo_ID");

                entity.HasIndex(e => e.UsuarioId, "UsuarioReciboPago");

                entity.HasIndex(e => e.UsuarioId, "Usuario_ID");

                entity.HasIndex(e => e.VendedorId, "VendedorReciboPago");

                entity.HasIndex(e => e.VendedorId, "Vendedor_ID");

                entity.Property(e => e.ReciboId).HasColumnName("Recibo_ID");

                entity.Property(e => e.CierreCajaId)
                    .HasColumnName("CierreCaja_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReciboComentario)
                    .HasMaxLength(100)
                    .HasColumnName("Recibo_Comentario");

                entity.Property(e => e.ReciboFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Recibo_Fecha");

                entity.Property(e => e.ReciboMonto)
                    .HasColumnType("money")
                    .HasColumnName("Recibo_Monto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReciboNo)
                    .HasMaxLength(20)
                    .HasColumnName("Recibo_NO");

                entity.Property(e => e.UsuarioId)
                    .HasColumnName("Usuario_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.VendedorId)
                    .HasColumnName("Vendedor_ID")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<ReciboPagoDet>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ReciboPagoDet");

                entity.HasIndex(e => e.FacturaId, "FactTipoPago_ID");

                entity.HasIndex(e => e.FacturaId, "FacturaReciboPagoDet");

                entity.HasIndex(e => e.ReciboId, "Factura_ID");

                entity.HasIndex(e => e.ReciboId, "ReciboPagoReciboPagoDet");

                entity.Property(e => e.FacturaId)
                    .HasColumnName("Factura_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReciboFactPagoMonto)
                    .HasColumnType("money")
                    .HasColumnName("Recibo_FactPagoMonto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReciboId)
                    .HasColumnName("Recibo_ID")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Factura)
                    .WithMany()
                    .HasForeignKey(d => d.FacturaId)
                    .HasConstraintName("ReciboPagoDet_FK00");

                entity.HasOne(d => d.Recibo)
                    .WithMany()
                    .HasForeignKey(d => d.ReciboId)
                    .HasConstraintName("ReciboPagoDet_FK01");
            });

            modelBuilder.Entity<ReciboTipoPago>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ReciboTipoPago");

                entity.HasIndex(e => e.NotaCrId, "NotaCr_ID");

                entity.HasIndex(e => e.ReciboId, "Recibo_ID");

                entity.HasIndex(e => e.TipoPagoId, "TipoPago_ID");

                entity.Property(e => e.NotaCrId)
                    .HasColumnName("NotaCr_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReciboId)
                    .HasColumnName("Recibo_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReciboSec)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Recibo_Sec");

                entity.Property(e => e.ReciboTipoPagoCom)
                    .HasMaxLength(100)
                    .HasColumnName("Recibo_TipoPagoCom");

                entity.Property(e => e.ReciboTipoPagoMonto)
                    .HasColumnType("money")
                    .HasColumnName("Recibo_TipoPagoMonto")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TipoPagoId)
                    .HasColumnName("TipoPago_ID")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Recibo)
                    .WithMany()
                    .HasForeignKey(d => d.ReciboId)
                    .HasConstraintName("FK_ReciboTipoPago_ReciboPago");

                entity.HasOne(d => d.TipoPago)
                    .WithMany()
                    .HasForeignKey(d => d.TipoPagoId)
                    .HasConstraintName("FK_ReciboTipoPago_TipoPago");
            });

            modelBuilder.Entity<Reporte>(entity =>
            {
                entity.HasKey(e => e.ReporteNombre);

                entity.Property(e => e.ReporteNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Reporte_Nombre");

                entity.Property(e => e.GrupoReporteId).HasColumnName("GrupoReporte_ID");

                entity.Property(e => e.ReporteDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Reporte_Desc");

                entity.Property(e => e.ReporteModulo)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Reporte_Modulo");
            });

            modelBuilder.Entity<ReqMovInventario>(entity =>
            {
                entity.HasKey(e => e.MovId)
                    .HasName("aaaaaReqMovInventario_PK")
                    .IsClustered(false);

                entity.ToTable("ReqMovInventario");

                entity.HasIndex(e => e.AlmacenId, "Almacen_ID");

                entity.HasIndex(e => e.ArticuloId, "Articulo_ID");

                entity.HasIndex(e => e.CuentaId, "Cuenta_ID");

                entity.HasIndex(e => e.MovId, "Mov_ID");

                entity.Property(e => e.MovId).HasColumnName("Mov_ID");

                entity.Property(e => e.AlmacenId).HasColumnName("Almacen_ID");

                entity.Property(e => e.ArticuloId)
                    .HasColumnName("Articulo_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentaId).HasColumnName("Cuenta_ID");

                entity.Property(e => e.MovCantidad)
                    .HasColumnName("Mov_Cantidad")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MovComentario)
                    .HasMaxLength(250)
                    .HasColumnName("Mov_Comentario");

                entity.Property(e => e.MovFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Mov_Fecha");

                entity.Property(e => e.MovMontoGp)
                    .HasColumnType("money")
                    .HasColumnName("Mov_MontoGP");

                entity.Property(e => e.MovPrecio)
                    .HasColumnType("money")
                    .HasColumnName("Mov_Precio")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MovSiUtilizada).HasColumnName("Mov_SiUtilizada");

                entity.Property(e => e.MovTipo)
                    .HasColumnName("Mov_Tipo")
                    .HasDefaultValueSql("((0))")
                    .HasComment("1 =Ent,   2=Sal,   3=Ajuste Positivo,  4=Ajuste Negativo");

                entity.Property(e => e.UpsizeTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("upsize_ts");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.ReservaId)
                    .HasName("aaaaaReserva_PK")
                    .IsClustered(false);

                entity.ToTable("Reserva");

                entity.HasIndex(e => e.ClienteId, "Cliente_ID");

                entity.HasIndex(e => e.PlanId, "Plan_ID");

                entity.HasIndex(e => e.ReservaId, "Reserva_ID");

                entity.HasIndex(e => e.ReservaNo, "Reserva_No")
                    .IsUnique();

                entity.HasIndex(e => e.UsuarioId, "Usuario_ID");

                entity.Property(e => e.ReservaId).HasColumnName("Reserva_ID");

                entity.Property(e => e.ClienteId).HasColumnName("Cliente_ID");

                entity.Property(e => e.FacturaId).HasColumnName("Factura_ID");

                entity.Property(e => e.PlanId).HasColumnName("Plan_ID");

                entity.Property(e => e.ReservaFechaEntrada)
                    .HasColumnType("datetime")
                    .HasColumnName("Reserva_FechaEntrada");

                entity.Property(e => e.ReservaFechaExp)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Reserva_FechaExp");

                entity.Property(e => e.ReservaFechaSalida)
                    .HasColumnType("datetime")
                    .HasColumnName("Reserva_FechaSalida");

                entity.Property(e => e.ReservaNo).HasColumnName("Reserva_No");

                entity.Property(e => e.ReservaObservaciones)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("Reserva_Observaciones");

                entity.Property(e => e.ReservaTarjCred)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("Reserva_TarjCred");

                entity.Property(e => e.ReservaTipo)
                    .HasColumnName("Reserva_Tipo")
                    .HasComment("0=Sin Usar, 1=En Uso, 2=Usada");

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");
            });

            modelBuilder.Entity<ReservaAnulada>(entity =>
            {
                entity.HasKey(e => e.ReservaId);

                entity.Property(e => e.ReservaId)
                    .ValueGeneratedNever()
                    .HasColumnName("Reserva_ID");

                entity.Property(e => e.ReservaNulaComentario)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ReservaNula_Comentario");

                entity.Property(e => e.ReservaNulaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("ReservaNula_Fecha");

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");
            });

            modelBuilder.Entity<ReservaDet>(entity =>
            {
                entity.HasKey(e => e.ReservaDetId)
                    .HasName("aaaaaReservaDet_PK")
                    .IsClustered(false);

                entity.ToTable("ReservaDet");

                entity.HasIndex(e => e.HabitacionId, "Habitacion_ID");

                entity.HasIndex(e => e.ReservaDetId, "ReservaDet_ID");

                entity.HasIndex(e => e.ReservaId, "Reserva_ID");

                entity.HasIndex(e => e.TipoHospedajeId, "TipoHospedaje_ID");

                entity.Property(e => e.ReservaDetId).HasColumnName("ReservaDet_ID");

                entity.Property(e => e.HabitacionId).HasColumnName("Habitacion_ID");

                entity.Property(e => e.ReservaDetPrecio)
                    .HasColumnType("money")
                    .HasColumnName("ReservaDet_Precio");

                entity.Property(e => e.ReservaDetSiCortesia).HasColumnName("ReservaDet_SiCortesia");

                entity.Property(e => e.ReservaDetStatus).HasColumnName("ReservaDet_status");

                entity.Property(e => e.ReservaId).HasColumnName("Reserva_ID");

                entity.Property(e => e.TipoHospedajeId).HasColumnName("TipoHospedaje_ID");

                entity.Property(e => e.UsuarioIdCortesia).HasColumnName("Usuario_ID_Cortesia");
            });

            modelBuilder.Entity<ReservaHospedaje>(entity =>
            {
                entity.HasKey(e => new { e.ReservaDetId, e.ReservaHospedajeSec })
                    .HasName("aaaaaReservaHospedaje_PK")
                    .IsClustered(false);

                entity.ToTable("ReservaHospedaje");

                entity.HasIndex(e => e.ReservaHospedajeSec, "Habitacion_ID");

                entity.HasIndex(e => e.ReservaDetId, "Reserva_ID");

                entity.Property(e => e.ReservaDetId).HasColumnName("ReservaDet_ID");

                entity.Property(e => e.ReservaHospedajeSec).HasColumnName("ReservaHospedaje_Sec");

                entity.Property(e => e.NacionalidadId).HasColumnName("Nacionalidad_ID");

                entity.Property(e => e.ReservaHospedajeComentario)
                    .HasMaxLength(255)
                    .HasColumnName("ReservaHospedaje_Comentario");

                entity.Property(e => e.ReservaHospedajeDireccion)
                    .HasMaxLength(255)
                    .HasColumnName("ReservaHospedaje_Direccion");

                entity.Property(e => e.ReservaHospedajeEdad).HasColumnName("ReservaHospedaje_Edad");

                entity.Property(e => e.ReservaHospedajeEmail)
                    .HasMaxLength(255)
                    .HasColumnName("ReservaHospedaje_Email");

                entity.Property(e => e.ReservaHospedajeFechaEntrada)
                    .HasColumnType("datetime")
                    .HasColumnName("ReservaHospedaje_FechaEntrada");

                entity.Property(e => e.ReservaHospedajeFechaSalida)
                    .HasColumnType("datetime")
                    .HasColumnName("ReservaHospedaje_FechaSalida");

                entity.Property(e => e.ReservaHospedajeIdentificacion)
                    .HasMaxLength(255)
                    .HasColumnName("ReservaHospedaje_Identificacion");

                entity.Property(e => e.ReservaHospedajeNombre)
                    .HasMaxLength(255)
                    .HasColumnName("ReservaHospedaje_Nombre");

                entity.Property(e => e.ReservaHospedajeSexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ReservaHospedaje_Sexo");

                entity.Property(e => e.ReservaHospedajeTelefonos)
                    .HasMaxLength(255)
                    .HasColumnName("ReservaHospedaje_Telefonos");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.ToTable("Sala");

                entity.Property(e => e.SalaId).HasColumnName("Sala_ID");

                entity.Property(e => e.SalaDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Sala_Desc");

                entity.Property(e => e.SalaEstatus).HasColumnName("Sala_Estatus");

                entity.Property(e => e.SucursalId).HasColumnName("Sucursal_ID");
            });

            modelBuilder.Entity<SistemaActualizacion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SistemaActualizacion");

                entity.Property(e => e.UltimaActualizacion).ValueGeneratedOnAdd();

                entity.Property(e => e.UltimaActualizacionComentario)
                    .HasColumnType("text")
                    .HasColumnName("UltimaActualizacion_Comentario");

                entity.Property(e => e.UltimaActualizacionFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("UltimaActualizacion_Fecha");

                entity.Property(e => e.UltimaActualizacionFechaScript)
                    .HasColumnType("datetime")
                    .HasColumnName("UltimaActualizacion_FechaScript");

                entity.Property(e => e.UltimaActualizacionUsuario)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("UltimaActualizacion_Usuario");
            });

            modelBuilder.Entity<Suplidor>(entity =>
            {
                entity.HasKey(e => e.SuplidorId)
                    .HasName("aaaaaSuplidor_PK")
                    .IsClustered(false);

                entity.ToTable("Suplidor");

                entity.HasIndex(e => e.CondPagoId, "CondPagoSuplidor");

                entity.HasIndex(e => e.CondPagoId, "CondPago_ID");

                entity.HasIndex(e => e.SuplidorId, "Suplidor_ID");

                entity.Property(e => e.SuplidorId).HasColumnName("Suplidor_ID");

                entity.Property(e => e.CondPagoId)
                    .HasColumnName("CondPago_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SuplidorBalance)
                    .HasColumnType("money")
                    .HasColumnName("Suplidor_Balance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SuplidorCd)
                    .HasMaxLength(20)
                    .HasColumnName("Suplidor_CD");

                entity.Property(e => e.SuplidorCedula)
                    .HasMaxLength(50)
                    .HasColumnName("Suplidor_Cedula");

                entity.Property(e => e.SuplidorCel)
                    .HasMaxLength(13)
                    .HasColumnName("Suplidor_Cel");

                entity.Property(e => e.SuplidorContacto)
                    .HasMaxLength(50)
                    .HasColumnName("Suplidor_Contacto");

                entity.Property(e => e.SuplidorDgii).HasColumnName("Suplidor_DGII");

                entity.Property(e => e.SuplidorDir1)
                    .HasMaxLength(50)
                    .HasColumnName("Suplidor_Dir1");

                entity.Property(e => e.SuplidorDir2)
                    .HasMaxLength(50)
                    .HasColumnName("Suplidor_Dir2");

                entity.Property(e => e.SuplidorEmail)
                    .HasMaxLength(50)
                    .HasColumnName("Suplidor_Email");

                entity.Property(e => e.SuplidorFax)
                    .HasMaxLength(13)
                    .HasColumnName("Suplidor_Fax");

                entity.Property(e => e.SuplidorNombre)
                    .HasMaxLength(50)
                    .HasColumnName("Suplidor_Nombre");

                entity.Property(e => e.SuplidorStatus).HasColumnName("Suplidor_Status");

                entity.Property(e => e.SuplidorTel)
                    .HasMaxLength(13)
                    .HasColumnName("Suplidor_Tel");
            });

            modelBuilder.Entity<SuplidorArticulo>(entity =>
            {
                entity.HasKey(e => new { e.SuplidorId, e.ArticuloId })
                    .HasName("aaaaaSuplidorArticulos_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.ArticuloId, "Articulo_ID");

                entity.HasIndex(e => e.SuplidorId, "SuplidorSuplidorArticulos");

                entity.HasIndex(e => e.SuplidorId, "Suplidor_ID");

                entity.Property(e => e.SuplidorId).HasColumnName("Suplidor_ID");

                entity.Property(e => e.ArticuloId).HasColumnName("Articulo_ID");

                entity.Property(e => e.SuplidorArticulosPartNo)
                    .HasMaxLength(30)
                    .HasColumnName("SuplidorArticulos_PartNo");

                entity.Property(e => e.SuplidorArticulosUltimoCosto)
                    .HasColumnType("money")
                    .HasColumnName("SuplidorArticulos_UltimoCosto")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Suplidor)
                    .WithMany(p => p.SuplidorArticulos)
                    .HasForeignKey(d => d.SuplidorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SuplidorArticulos_FK00");
            });

            modelBuilder.Entity<Tarifa>(entity =>
            {
                entity.HasKey(e => new { e.TipoHabitacionId, e.TipoHospedajeId, e.PlanId })
                    .HasName("aaaaaTarifa_PK")
                    .IsClustered(false);

                entity.ToTable("Tarifa");

                entity.HasIndex(e => e.TipoHabitacionId, "TipoHabitacion_ID");

                entity.HasIndex(e => e.TipoHospedajeId, "TipoHospedaje_ID");

                entity.Property(e => e.TipoHabitacionId).HasColumnName("TipoHabitacion_ID");

                entity.Property(e => e.TipoHospedajeId).HasColumnName("TipoHospedaje_ID");

                entity.Property(e => e.PlanId).HasColumnName("Plan_ID");

                entity.Property(e => e.TarifaPrecio)
                    .HasColumnType("money")
                    .HasColumnName("Tarifa_Precio");
            });

            modelBuilder.Entity<TempCierreCajaBillete>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TempCierreCajaBillete");

                entity.Property(e => e.BilleteId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Billete_ID");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CierreCajaId).HasColumnName("CierreCaja_ID");
            });

            modelBuilder.Entity<TipoActivoFijo>(entity =>
            {
                entity.HasKey(e => e.TipoActivoFijoId)
                    .HasName("aaaaaTipoActivoFijo_PK")
                    .IsClustered(false);

                entity.ToTable("TipoActivoFijo");

                entity.HasIndex(e => e.CuentaId, "CuentaTipoActivoFijo");

                entity.HasIndex(e => e.CuentaIdDepreciacion, "CuentaTipoActivoFijo1");

                entity.HasIndex(e => e.CuentaId, "Cuenta_ID");

                entity.HasIndex(e => e.CuentaIdDepreciacion, "Cuenta_ID1");

                entity.HasIndex(e => e.TipoActivoFijoId, "TipoActivoFijo_ID");

                entity.Property(e => e.TipoActivoFijoId).HasColumnName("TipoActivoFijo_ID");

                entity.Property(e => e.CuentaId)
                    .HasColumnName("Cuenta_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentaIdDepreciacion)
                    .HasColumnName("Cuenta_ID_Depreciacion")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CuentaIdGasto).HasColumnName("Cuenta_ID_Gasto");

                entity.Property(e => e.TipoActivoFijoDesc)
                    .HasMaxLength(100)
                    .HasColumnName("TipoActivoFijo_Desc");
            });

            modelBuilder.Entity<TipoBiene>(entity =>
            {
                entity.HasKey(e => e.TipoBienesId);

                entity.Property(e => e.TipoBienesId).HasColumnName("TipoBienes_ID");

                entity.Property(e => e.SucursalId).HasColumnName("Sucursal_ID");

                entity.Property(e => e.TipoBienesDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TipoBienes_Desc");

                entity.Property(e => e.TipoBienesEstatus).HasColumnName("TipoBienes_Estatus");
            });

            modelBuilder.Entity<TipoHabitacion>(entity =>
            {
                entity.HasKey(e => e.TipoHabitacionId)
                    .HasName("aaaaaTipoHabitacion_PK")
                    .IsClustered(false);

                entity.ToTable("TipoHabitacion");

                entity.HasIndex(e => e.TipoHabitacionId, "TipoHabitacion_ID");

                entity.Property(e => e.TipoHabitacionId).HasColumnName("TipoHabitacion_ID");

                entity.Property(e => e.TipoHabitacionDesc)
                    .HasMaxLength(255)
                    .HasColumnName("TipoHabitacion_Desc");

                entity.Property(e => e.TipoHabitacionEstatus).HasColumnName("TipoHabitacion_Estatus");
            });

            modelBuilder.Entity<TipoHospedaje>(entity =>
            {
                entity.HasKey(e => e.TipoHospedajeId)
                    .HasName("aaaaaTipoHospedaje_PK")
                    .IsClustered(false);

                entity.ToTable("TipoHospedaje");

                entity.HasIndex(e => e.TipoHospedajeId, "TipoHospedaje_ID");

                entity.Property(e => e.TipoHospedajeId).HasColumnName("TipoHospedaje_ID");

                entity.Property(e => e.TipoHospedajeDesc)
                    .HasMaxLength(255)
                    .HasColumnName("TipoHospedaje_Desc");

                entity.Property(e => e.TipoHospedajeEstatus).HasColumnName("TipoHospedaje_Estatus");

                entity.Property(e => e.TipoHospedajeOcupacion).HasColumnName("TipoHospedaje_Ocupacion");
            });

            modelBuilder.Entity<TipoPago>(entity =>
            {
                entity.HasKey(e => e.TipoPagoId)
                    .HasName("aaaaaTipoPago_PK")
                    .IsClustered(false);

                entity.ToTable("TipoPago");

                entity.HasIndex(e => e.CuentaId, "CuentaTipoPago");

                entity.HasIndex(e => e.CuentaId, "Cuenta_ID");

                entity.HasIndex(e => e.TipoPagoId, "TipoPago_ID");

                entity.Property(e => e.TipoPagoId).HasColumnName("TipoPago_ID");

                entity.Property(e => e.CuentaId)
                    .HasColumnName("Cuenta_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TipoPagoDesc)
                    .HasMaxLength(50)
                    .HasColumnName("TipoPago_Desc");

                entity.Property(e => e.TipoPagoEstatus).HasColumnName("TipoPago_Estatus");

                entity.Property(e => e.TipoPagoIfnoPago).HasColumnName("TipoPago_IFNoPago");

                entity.Property(e => e.TipoPagoSiEfectivo).HasColumnName("TipoPago_SiEfectivo");

                entity.Property(e => e.TipoPagoSiNotaCr).HasColumnName("TipoPago_SiNotaCr");

                entity.Property(e => e.TipoPagoSiNotaCredito).HasColumnName("TipoPago_SiNotaCredito");

                entity.Property(e => e.TipoPagoSiPrepago).HasColumnName("TipoPago_SiPrepago");

                entity.Property(e => e.TipoPagoSiPuntos).HasColumnName("TipoPago_SiPuntos");

                entity.Property(e => e.TipoPagoSiRnc).HasColumnName("TipoPago_SiRnc");

                entity.HasOne(d => d.Cuenta)
                    .WithMany(p => p.TipoPagos)
                    .HasForeignKey(d => d.CuentaId)
                    .HasConstraintName("TipoPago_FK00");
            });

            modelBuilder.Entity<Traccion>(entity =>
            {
                entity.HasKey(e => e.TracciónId);

                entity.ToTable("Traccion");

                entity.Property(e => e.TracciónId).HasColumnName("Tracción_ID");

                entity.Property(e => e.TracciónDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Tracción_Desc");
            });

            modelBuilder.Entity<Unidad>(entity =>
            {
                entity.HasKey(e => e.UnidadId)
                    .HasName("aaaaaUnidad_PK")
                    .IsClustered(false);

                entity.ToTable("Unidad");

                entity.HasIndex(e => e.UnidadId, "Unidad_ID");

                entity.Property(e => e.UnidadId).HasColumnName("Unidad_ID");

                entity.Property(e => e.UnidadDesc)
                    .HasMaxLength(50)
                    .HasColumnName("Unidad_Desc");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UsuarioId)
                    .HasName("aaaaaUsuario_PK")
                    .IsClustered(false);

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.AlmacenId, "Almacen_ID");

                entity.HasIndex(e => e.AutoridadId, "Authority_ID");

                entity.HasIndex(e => e.AutoridadId, "AutoridadUsuario");

                entity.HasIndex(e => e.UsuarioDescId, "User_DescID");

                entity.HasIndex(e => e.UsuarioId, "User_ID");

                entity.Property(e => e.UsuarioId)
                    .ValueGeneratedNever()
                    .HasColumnName("Usuario_ID");

                entity.Property(e => e.AlmacenId).HasColumnName("Almacen_ID");

                entity.Property(e => e.AutoridadId)
                    .HasColumnName("Autoridad_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UsuarioDescId)
                    .HasMaxLength(40)
                    .HasColumnName("Usuario_DescID");

                entity.Property(e => e.UsuarioNoCopiaFac).HasColumnName("Usuario_NoCopiaFac");

                entity.Property(e => e.UsuarioNombre)
                    .HasMaxLength(40)
                    .HasColumnName("Usuario_Nombre");

                entity.Property(e => e.UsuarioPass)
                    .HasMaxLength(20)
                    .HasColumnName("Usuario_Pass");

                entity.Property(e => e.UsuarioSiAnularFactura).HasColumnName("Usuario_SiAnularFactura");

                entity.Property(e => e.UsuarioSiBorrarFactura).HasColumnName("Usuario_SiBorrarFactura");

                entity.Property(e => e.UsuarioSiCajero).HasColumnName("Usuario_SiCajero");

                entity.Property(e => e.UsuarioSiFacCliSob).HasColumnName("Usuario_SiFacCliSob");

                entity.Property(e => e.UsuarioSiFacFacVen).HasColumnName("Usuario_SiFacFacVen");

                entity.Property(e => e.UsuarioSiImpuesto).HasColumnName("Usuario_SiImpuesto");

                entity.Property(e => e.UsuarioSiModCredCliente).HasColumnName("Usuario_SiModCredCliente");

                entity.Property(e => e.UsuarioSiPreFactura).HasColumnName("Usuario_SiPreFactura");

                entity.Property(e => e.UsuarioSiReAbrirCompra).HasColumnName("Usuario_SiReAbrirCompra");

                entity.Property(e => e.UsuarioSiReAbrirFactura).HasColumnName("Usuario_SiReAbrirFactura");

                entity.HasOne(d => d.Autoridad)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.AutoridadId)
                    .HasConstraintName("Usuario_FK00");
            });

            modelBuilder.Entity<UsuarioComputadora>(entity =>
            {
                entity.HasKey(e => e.ComputadoraId)
                    .HasName("aaaaaUsuario_Computadora_PK")
                    .IsClustered(false);

                entity.ToTable("Usuario_Computadora");

                entity.HasIndex(e => e.UsuarioId, "UsuarioUsuario_Computadora");

                entity.HasIndex(e => e.UsuarioId, "Usuario_ID");

                entity.Property(e => e.ComputadoraId)
                    .HasMaxLength(30)
                    .HasColumnName("Computadora_ID");

                entity.Property(e => e.UsuarioId)
                    .HasColumnName("Usuario_ID")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.UsuarioComputadoras)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("Usuario_Computadora_FK00");
            });

            modelBuilder.Entity<VArticulo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_Articulo");

                entity.Property(e => e.ArticuloCantMaxima).HasColumnName("Articulo_CantMaxima");

                entity.Property(e => e.ArticuloCantReOrden).HasColumnName("Articulo_CantReOrden");

                entity.Property(e => e.ArticuloCd)
                    .HasMaxLength(30)
                    .HasColumnName("Articulo_CD");

                entity.Property(e => e.ArticuloConvertible).HasColumnName("Articulo_Convertible");

                entity.Property(e => e.ArticuloCosto).HasColumnName("Articulo_Costo");

                entity.Property(e => e.ArticuloCostoCodigo)
                    .HasMaxLength(50)
                    .HasColumnName("Articulo_CostoCodigo");

                entity.Property(e => e.ArticuloCostoProm).HasColumnName("Articulo_CostoProm");

                entity.Property(e => e.ArticuloDesc)
                    .HasMaxLength(80)
                    .HasColumnName("Articulo_Desc");

                entity.Property(e => e.ArticuloExistencia).HasColumnName("Articulo_Existencia");

                entity.Property(e => e.ArticuloFabricado).HasColumnName("Articulo_Fabricado");

                entity.Property(e => e.ArticuloGanancia2).HasColumnName("Articulo_Ganancia2");

                entity.Property(e => e.ArticuloGananciaMinima).HasColumnName("Articulo_GananciaMinima");

                entity.Property(e => e.ArticuloId).HasColumnName("Articulo_ID");

                entity.Property(e => e.ArticuloImgRuta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Articulo_ImgRuta");

                entity.Property(e => e.ArticuloInventario).HasColumnName("Articulo_Inventario");

                entity.Property(e => e.ArticuloPartNo)
                    .HasMaxLength(30)
                    .HasColumnName("Articulo_PartNo");

                entity.Property(e => e.ArticuloSiComanda).HasColumnName("Articulo_SiComanda");

                entity.Property(e => e.ArticuloSiFactNegativo).HasColumnName("Articulo_SiFactNegativo");

                entity.Property(e => e.ArticuloSiGuarnicion).HasColumnName("Articulo_SiGuarnicion");

                entity.Property(e => e.ArticuloSiItbis).HasColumnName("Articulo_SiITBIS");

                entity.Property(e => e.ArticuloSiItbisincluido).HasColumnName("Articulo_SiITBISIncluido");

                entity.Property(e => e.ArticuloSiKit).HasColumnName("Articulo_SiKit");

                entity.Property(e => e.ArticuloSiPeso).HasColumnName("Articulo_SiPeso");

                entity.Property(e => e.ArticuloSiVencimiento).HasColumnName("Articulo_SiVencimiento");

                entity.Property(e => e.ArticuloStatus).HasColumnName("Articulo_Status");

                entity.Property(e => e.ArticuloUbicacion)
                    .HasMaxLength(50)
                    .HasColumnName("Articulo_Ubicacion");

                entity.Property(e => e.DepartamentoId).HasColumnName("Departamento_ID");

                entity.Property(e => e.MarcaId).HasColumnName("Marca_ID");

                entity.Property(e => e.ModeloId).HasColumnName("Modelo_ID");

                entity.Property(e => e.UnidadId).HasColumnName("Unidad_ID");
            });

            modelBuilder.Entity<VArticulo1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_Articulos");

                entity.Property(e => e.AlmacenDesc)
                    .HasMaxLength(100)
                    .HasColumnName("Almacen_Desc");

                entity.Property(e => e.AlmacenId).HasColumnName("Almacen_ID");

                entity.Property(e => e.ArticuloCantMaxima).HasColumnName("Articulo_CantMaxima");

                entity.Property(e => e.ArticuloCantReOrden).HasColumnName("Articulo_CantReOrden");

                entity.Property(e => e.ArticuloCd)
                    .HasMaxLength(30)
                    .HasColumnName("Articulo_CD");

                entity.Property(e => e.ArticuloConvertible).HasColumnName("Articulo_Convertible");

                entity.Property(e => e.ArticuloCosto).HasColumnName("Articulo_Costo");

                entity.Property(e => e.ArticuloCostoCodigo)
                    .HasMaxLength(50)
                    .HasColumnName("Articulo_CostoCodigo");

                entity.Property(e => e.ArticuloCostoProm).HasColumnName("Articulo_CostoProm");

                entity.Property(e => e.ArticuloDesc)
                    .HasMaxLength(80)
                    .HasColumnName("Articulo_Desc");

                entity.Property(e => e.ArticuloExistencia).HasColumnName("Articulo_Existencia");

                entity.Property(e => e.ArticuloFabricado).HasColumnName("Articulo_Fabricado");

                entity.Property(e => e.ArticuloGanancia2).HasColumnName("Articulo_Ganancia2");

                entity.Property(e => e.ArticuloGananciaMinima).HasColumnName("Articulo_GananciaMinima");

                entity.Property(e => e.ArticuloId).HasColumnName("Articulo_ID");

                entity.Property(e => e.ArticuloInventario).HasColumnName("Articulo_Inventario");

                entity.Property(e => e.ArticuloPartNo)
                    .HasMaxLength(30)
                    .HasColumnName("Articulo_PartNo");

                entity.Property(e => e.ArticuloSiItbis).HasColumnName("Articulo_SiITBIS");

                entity.Property(e => e.ArticuloSiItbisincluido).HasColumnName("Articulo_SiITBISIncluido");

                entity.Property(e => e.ArticuloSiKit).HasColumnName("Articulo_SiKit");

                entity.Property(e => e.ArticuloSiVencimiento).HasColumnName("Articulo_SiVencimiento");

                entity.Property(e => e.ArticuloStatus).HasColumnName("Articulo_Status");

                entity.Property(e => e.ArticuloUbicacion)
                    .HasMaxLength(50)
                    .HasColumnName("Articulo_Ubicacion");

                entity.Property(e => e.DepartamentoId).HasColumnName("Departamento_ID");

                entity.Property(e => e.MarcaId).HasColumnName("Marca_ID");

                entity.Property(e => e.ModeloId).HasColumnName("Modelo_ID");

                entity.Property(e => e.UnidadId).HasColumnName("Unidad_ID");
            });

            modelBuilder.Entity<VFactura>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_Facturas");

                entity.Property(e => e.AlmacenId).HasColumnName("Almacen_ID");

                entity.Property(e => e.ClienteId).HasColumnName("Cliente_ID");

                entity.Property(e => e.ComprobanteTipoId).HasColumnName("ComprobanteTipo_ID");

                entity.Property(e => e.CondPagoId).HasColumnName("CondPago_ID");

                entity.Property(e => e.CreditoAutorizadoId).HasColumnName("CreditoAutorizado_ID");

                entity.Property(e => e.FacturaBalance)
                    .HasColumnType("money")
                    .HasColumnName("Factura_Balance");

                entity.Property(e => e.FacturaCliente)
                    .HasMaxLength(50)
                    .HasColumnName("Factura_Cliente");

                entity.Property(e => e.FacturaComentario)
                    .HasMaxLength(250)
                    .HasColumnName("Factura_Comentario");

                entity.Property(e => e.FacturaComprobante)
                    .HasMaxLength(20)
                    .HasColumnName("Factura_Comprobante");

                entity.Property(e => e.FacturaDatos)
                    .HasMaxLength(150)
                    .HasColumnName("Factura_Datos");

                entity.Property(e => e.FacturaDescto)
                    .HasColumnType("money")
                    .HasColumnName("Factura_Descto");

                entity.Property(e => e.FacturaEstatus).HasColumnName("Factura_Estatus");

                entity.Property(e => e.FacturaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Factura_Fecha");

                entity.Property(e => e.FacturaId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Factura_ID");

                entity.Property(e => e.FacturaItbis)
                    .HasColumnType("money")
                    .HasColumnName("Factura_ITBIS");

                entity.Property(e => e.FacturaMontoImpuesto)
                    .HasColumnType("money")
                    .HasColumnName("Factura_MontoImpuesto");

                entity.Property(e => e.FacturaMontoRetIsr)
                    .HasColumnType("money")
                    .HasColumnName("Factura_MontoRetISR");

                entity.Property(e => e.FacturaNo)
                    .HasMaxLength(20)
                    .HasColumnName("Factura_No");

                entity.Property(e => e.FacturaNoImpreso).HasColumnName("Factura_NoImpreso");

                entity.Property(e => e.FacturaSiBeneficio).HasColumnName("Factura_SiBeneficio");

                entity.Property(e => e.FacturaSiCobrable).HasColumnName("Factura_SiCobrable");

                entity.Property(e => e.UsuarioIdAnulador).HasColumnName("Usuario_ID_Anulador");

                entity.Property(e => e.VendedorId).HasColumnName("Vendedor_ID");
            });

            modelBuilder.Entity<VOrigenCuentum>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_OrigenCuenta");

                entity.Property(e => e.CuentaId).HasColumnName("Cuenta_ID");

                entity.Property(e => e.CuentaIdorigen).HasColumnName("Cuenta_IDOrigen");
            });

            modelBuilder.Entity<VRepLo1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_RepLO1");

                entity.Property(e => e.FacturaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Factura_Fecha");

                entity.Property(e => e.SubTipo).HasMaxLength(62);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(7)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VRepLo2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_RepLO2");

                entity.Property(e => e.Monto0Dias)
                    .HasColumnType("money")
                    .HasColumnName("Monto_0_Dias");

                entity.Property(e => e.Monto120Dias)
                    .HasColumnType("money")
                    .HasColumnName("Monto_120_Dias");

                entity.Property(e => e.Monto120masDias)
                    .HasColumnType("money")
                    .HasColumnName("Monto_120Mas_Dias");

                entity.Property(e => e.Monto30Dias)
                    .HasColumnType("money")
                    .HasColumnName("Monto_30_Dias");

                entity.Property(e => e.Monto60Dias)
                    .HasColumnType("money")
                    .HasColumnName("Monto_60_Dias");

                entity.Property(e => e.Monto90Dias)
                    .HasColumnType("money")
                    .HasColumnName("Monto_90_Dias");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VRepLo3>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_RepLO3");

                entity.Property(e => e.ArticuloCostoProm).HasColumnName("Articulo_CostoProm");

                entity.Property(e => e.CompraFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Compra_Fecha");

                entity.Property(e => e.CompraQty).HasColumnName("Compra_Qty");
            });

            modelBuilder.Entity<VRepLo4>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_RepLO4");

                entity.Property(e => e.BancoNombre)
                    .HasMaxLength(62)
                    .HasColumnName("Banco_Nombre");

                entity.Property(e => e.ChequeFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Cheque_Fecha");

                entity.Property(e => e.Monto)
                    .HasColumnType("money")
                    .HasColumnName("monto");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ValorCodigo>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("aaaaaValorCodigo_PK")
                    .IsClustered(false);

                entity.ToTable("ValorCodigo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.V0).HasMaxLength(1);

                entity.Property(e => e.V1).HasMaxLength(1);

                entity.Property(e => e.V2).HasMaxLength(1);

                entity.Property(e => e.V3).HasMaxLength(1);

                entity.Property(e => e.V4).HasMaxLength(1);

                entity.Property(e => e.V5).HasMaxLength(1);

                entity.Property(e => e.V6).HasMaxLength(1);

                entity.Property(e => e.V7).HasMaxLength(1);

                entity.Property(e => e.V8).HasMaxLength(1);

                entity.Property(e => e.V9).HasMaxLength(1);
            });

            modelBuilder.Entity<Vencimiento>(entity =>
            {
                entity.HasKey(e => e.VencimientoId)
                    .HasName("aaaaaVencimiento_PK")
                    .IsClustered(false);

                entity.ToTable("Vencimiento");

                entity.HasIndex(e => e.AlmacenId, "Almacen_ID");

                entity.HasIndex(e => e.ArticuloId, "Articulo_ID");

                entity.HasIndex(e => e.VencimientoId, "Vencimiento_ID");

                entity.Property(e => e.VencimientoId).HasColumnName("Vencimiento_ID");

                entity.Property(e => e.AlmacenId).HasColumnName("Almacen_ID");

                entity.Property(e => e.ArticuloId).HasColumnName("Articulo_ID");

                entity.Property(e => e.VencimientoCantEntrada).HasColumnName("Vencimiento_CantEntrada");

                entity.Property(e => e.VencimientoCantSalida).HasColumnName("Vencimiento_CantSalida");

                entity.Property(e => e.VencimientoFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Vencimiento_Fecha");
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.HasKey(e => e.VendedorId)
                    .HasName("aaaaaVendedor_PK")
                    .IsClustered(false);

                entity.ToTable("Vendedor");

                entity.Property(e => e.VendedorId).HasColumnName("Vendedor_ID");

                entity.Property(e => e.VendedorCodigo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Vendedor_Codigo");

                entity.Property(e => e.VendedorEstatus).HasColumnName("Vendedor_Estatus");

                entity.Property(e => e.VendedorNombre)
                    .HasMaxLength(50)
                    .HasColumnName("Vendedor_Nombre");
            });

            modelBuilder.Entity<VistaEstadoCxC>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vista_Estado_CxC");

                entity.Property(e => e.ClienteId).HasColumnName("Cliente_ID");

                entity.Property(e => e.ClienteNombre)
                    .HasMaxLength(50)
                    .HasColumnName("Cliente_Nombre");

                entity.Property(e => e.ComprobanteTipoId).HasColumnName("ComprobanteTipo_ID");

                entity.Property(e => e.CondPagoId).HasColumnName("CondPago_ID");

                entity.Property(e => e.Condicion)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.FacturaBalance)
                    .HasColumnType("money")
                    .HasColumnName("Factura_Balance");

                entity.Property(e => e.FacturaComprobante)
                    .HasMaxLength(20)
                    .HasColumnName("Factura_Comprobante");

                entity.Property(e => e.FacturaDescto)
                    .HasColumnType("money")
                    .HasColumnName("Factura_Descto");

                entity.Property(e => e.FacturaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Factura_Fecha");

                entity.Property(e => e.FacturaId).HasColumnName("Factura_ID");

                entity.Property(e => e.FacturaItbis)
                    .HasColumnType("money")
                    .HasColumnName("Factura_ITBIS");

                entity.Property(e => e.FacturaMontoImpuesto)
                    .HasColumnType("money")
                    .HasColumnName("Factura_MontoImpuesto");

                entity.Property(e => e.FacturaNo)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Factura_No");

                entity.Property(e => e.HabitacionDesc)
                    .HasMaxLength(255)
                    .HasColumnName("Habitacion_Desc");

                entity.Property(e => e.MesaId).HasColumnName("Mesa_ID");

                entity.Property(e => e.Mesero).HasMaxLength(50);

                entity.Property(e => e.Pagado).HasColumnType("money");

                entity.Property(e => e.Pendiente).HasColumnType("money");

                entity.Property(e => e.UsuarioNombre)
                    .HasMaxLength(40)
                    .HasColumnName("Usuario_Nombre");

                entity.Property(e => e.VendedorId).HasColumnName("Vendedor_ID");
            });

            modelBuilder.Entity<VistaEstadoSuplidor>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vista_Estado_Suplidor");

                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.CompraNo)
                    .HasMaxLength(30)
                    .HasColumnName("Compra_No");

                entity.Property(e => e.FechaApaga)
                    .HasColumnType("datetime")
                    .HasColumnName("FechaAPaga");

                entity.Property(e => e.FechaCompra).HasColumnType("datetime");

                entity.Property(e => e.Pagado).HasColumnType("money");

                entity.Property(e => e.Pendiente).HasColumnType("money");

                entity.Property(e => e.Suplidor).HasMaxLength(102);

                entity.Property(e => e.SuplidorCd)
                    .HasMaxLength(20)
                    .HasColumnName("Suplidor_CD");
            });

            modelBuilder.Entity<VistaFacturaTipoPago>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vista_Factura_TipoPago");

                entity.Property(e => e.CondPagoId).HasColumnName("CondPago_ID");

                entity.Property(e => e.FacturaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Factura_Fecha");

                entity.Property(e => e.FacturaId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Factura_ID");

                entity.Property(e => e.FacturaNo)
                    .HasMaxLength(20)
                    .HasColumnName("Factura_No");
            });

            modelBuilder.Entity<VistaFacturasRecibo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vista_Facturas_Recibo");

                entity.Property(e => e.ClienteId).HasColumnName("Cliente_ID");

                entity.Property(e => e.ComprobantesFacturas)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NumFacturas)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ReciboId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Recibo_ID");
            });

            modelBuilder.Entity<VistaFacturasSinCierre>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vista_Facturas_SinCierre");

                entity.Property(e => e.ClienteNombre).HasMaxLength(50);

                entity.Property(e => e.CondPagoDesc)
                    .HasMaxLength(50)
                    .HasColumnName("CondPago_Desc");

                entity.Property(e => e.FacturaBalance)
                    .HasColumnType("money")
                    .HasColumnName("Factura_Balance");

                entity.Property(e => e.FacturaDescto)
                    .HasColumnType("money")
                    .HasColumnName("Factura_Descto");

                entity.Property(e => e.FacturaEstatus).HasColumnName("Factura_Estatus");

                entity.Property(e => e.FacturaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Factura_Fecha");

                entity.Property(e => e.FacturaId).HasColumnName("Factura_ID");

                entity.Property(e => e.FacturaItbis)
                    .HasColumnType("money")
                    .HasColumnName("Factura_ITBIS");

                entity.Property(e => e.FacturaMontoImpuesto)
                    .HasColumnType("money")
                    .HasColumnName("Factura_MontoImpuesto");

                entity.Property(e => e.FacturaNo)
                    .HasMaxLength(20)
                    .HasColumnName("Factura_No");
            });

            modelBuilder.Entity<VistaGastosComprasNcf>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vista_Gastos_Compras_NCF");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.GastoClasCode)
                    .HasMaxLength(2)
                    .HasColumnName("Gasto_ClasCode");

                entity.Property(e => e.Monto).HasColumnType("money");

                entity.Property(e => e.RecGastoFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("RecGasto_Fecha");

                entity.Property(e => e.RecGastoItbis)
                    .HasColumnType("money")
                    .HasColumnName("RecGasto_ITBIS");

                entity.Property(e => e.RecGastoItbisretenido)
                    .HasColumnType("money")
                    .HasColumnName("RecGasto_ITBISRetenido");

                entity.Property(e => e.RecGastoNcf)
                    .HasMaxLength(255)
                    .HasColumnName("RecGasto_NCF");

                entity.Property(e => e.RecGastoNcfNcnd)
                    .HasMaxLength(20)
                    .HasColumnName("RecGasto_NCF_NCND");

                entity.Property(e => e.SuplidorCedula)
                    .HasMaxLength(255)
                    .HasColumnName("Suplidor_Cedula");

                entity.Property(e => e.TipoPago)
                    .HasMaxLength(31)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VistaTipopagoCierrecaja>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VISTA_TIPOPAGO_CIERRECAJA");

                entity.Property(e => e.CierreCajaId).HasColumnName("CierreCaja_ID");

                entity.Property(e => e.Monto).HasColumnType("money");

                entity.Property(e => e.TipoPagoDesc)
                    .HasMaxLength(50)
                    .HasColumnName("TipoPago_Desc");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
