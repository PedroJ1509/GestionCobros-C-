using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class General
    {
        public string? GeneralInstallerName { get; set; }
        public float? GeneralItbis { get; set; }
        public bool GeneralIfMarca { get; set; }
        public int? GeneralUltimaFactura { get; set; }
        public int? GeneralUltimoRecibo { get; set; }
        public bool GeneralFacturaSecuencial { get; set; }
        public decimal? GeneralCapital { get; set; }
        public string? GeneralRnc { get; set; }
        public string? GeneralDireccion { get; set; }
        public string? GeneralDireccion2 { get; set; }
        public string? GeneralTelefono { get; set; }
        public string? GeneralTelefono2 { get; set; }
        public string? GeneralFax { get; set; }
        public string? GeneralEmail { get; set; }
        public int? GeneralUltimaNotaCr { get; set; }
        public int? GeneralUltimaNotaDeb { get; set; }
        public string? GeneralUltimaConciliacion { get; set; }
        public string? GeneralEmpresaNombre { get; set; }
        public string? GeneralEmpresaDireccion { get; set; }
        public int? GeneralUltimaCotizacion { get; set; }
        public int? GeneralUltimoDeposito { get; set; }
        public int? GeneralUltimoOrdenProduccion { get; set; }
        public int? GeneralFactorPietaje { get; set; }
        public string? GeneralMensajeFactura { get; set; }
        public int? GeneralNoFactura { get; set; }
        public bool GeneralSiCodClienteSec { get; set; }
        public bool GeneralSiCodSuplidorSec { get; set; }
        public short? GeneralCantDiasFactura { get; set; }
        /// <summary>
        /// 1= Pietaje, 2=Metraje
        /// </summary>
        public short? GeneralPantallaQty { get; set; }
        public int? GeneralUltimoRecCompra { get; set; }
        /// <summary>
        /// 1= Se va ver  0 = No se va a ver
        /// </summary>
        public short? GeneralDatosArticulosFactura { get; set; }
        public string? GeneralComprobante { get; set; }
        public short? GeneralComprobanteTipoId { get; set; }
        public int? GeneralColorFormas { get; set; }
        public float? GeneralTasaImpuesto { get; set; }
        public int? GeneralUltimaEntradaDiario { get; set; }
        public int? GeneralUltimoGasto { get; set; }
        public int? GeneralSuplidorGastoMenor { get; set; }
        public float? GeneralTasaRetencion { get; set; }
        public DateTime? GeneralUltimaActualizacion { get; set; }
        public bool GeneralSiPararVentaPorLimite { get; set; }
        public bool GeneralSiFacturaCambiaPrecio { get; set; }
        public int? GeneralUltimaOrdenCompra { get; set; }
        public float? GeneralRedondeoGanacia { get; set; }
        public bool GeneralSiPararVentaPorVencimiento { get; set; }
        public int? GeneralCantPrecios { get; set; }
        public int? GeneralRetIsr { get; set; }
        public string? GeneralEtiquetaMarca { get; set; }
        public string? GeneralEtiquetaModelo { get; set; }
        public DateTime? GeneralFechaCierre { get; set; }
        public int? GeneralUltimoCuota { get; set; }
        public int? GeneralUltimaCompra { get; set; }
        public float? GeneralValorPunto { get; set; }
        public int? ComprobanteTipoIdUsuarioFinal { get; set; }
        public int? GeneralUltimoGastoRecurrente { get; set; }
        public int? ArticuloIdReserva { get; set; }
        public DateTime? GeneralFechaCierreAud { get; set; }
        public bool GeneralSiDescuentoEnFactura { get; set; }
        public string? GeneralNoCp { get; set; }
        public string? GeneralNoSeguimiento { get; set; }
        public bool? GeneralSiComprobanteObligatorio { get; set; }
        public int? GeneralClienteId { get; set; }
        public int? GeneralTipoPagoEfectivoId { get; set; }
        public string? GeneralRutaImg { get; set; }
        public bool? GeneralMuestraDatosVehiculoCli { get; set; }
        public int? GeneralCantMesServicio { get; set; }
        public int? GeneralCantKilomServicio { get; set; }
        public bool? GeneralSiConfirUsuFact { get; set; }
        public bool? GeneralSiAbonoFact { get; set; }
        public int? GeneralTipoPagoTarjetaId { get; set; }
        public int? GeneralTipoPagoChequeId { get; set; }
        public bool? GeneralSiRestaurant { get; set; }
        public bool? GeneralSiBloqueaCcajaFacAbierta { get; set; }
        public string? GeneralRutaReportes { get; set; }
        public int? GeneralUltimoAjusteInventario { get; set; }
        public bool? GeneralImprimeComandaDirecto { get; set; }
        public bool? GeneralUsaAnalisisCosto { get; set; }
        public int? GeneralComprobanteTipoIdProveedorInformar { get; set; }
        public int? GeneralCondPago { get; set; }
        public bool? GeneralUsaCierreCaja { get; set; }
        public int? GeneralPrepagoId { get; set; }
        public int? GeneralCantidadImpresionFactura { get; set; }
        public bool? GeneralSiHotel { get; set; }
        public bool? GeneralPrecioPorAlmacen { get; set; }
        public bool? GeneralControlaPcPorAlmacen { get; set; }
        public int? GeneralUltimoArticulo { get; set; }
        public int GeneralId { get; set; }
        public bool? GeneralSiEnvíoCorreoAuto { get; set; }
        public string? GeneralEmailSalida { get; set; }
        public string? GeneralEmailLlegada { get; set; }
        public string? GeneralEmailCopia { get; set; }
        public string? GeneralEmailUsuario { get; set; }
        public string? GenaralEmailClave { get; set; }
        public string? GeneralEmailHost { get; set; }
        public string? GeneralEmailPort { get; set; }
    }
}
