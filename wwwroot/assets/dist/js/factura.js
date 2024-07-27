function GenerarFactura(ventana,facturaNo, facturaId, fechaFactura, cliente, condicion, vendedor, tipoComprobante, comprobante, codigoArt, almacen) {
    this.ventana = $(ventana);
    this.facturaNo = $(facturaNo);
    this.facturaId = $(facturaId);
    this.fechaFactura = $(fechaFactura);
    this.cliente = $(cliente);
    this.condicion = $(condicion);
    this.vendedor = $(vendedor);
    this.tipoComprobante = $(tipoComprobante);
    this.comprobante = $(comprobante);
    this.codigoArt = $(codigoArt);
    this.almacen = $(almacen);
    this.InvoiceNo = "0";

    this.Init = function() {
        self.BuscarClientes();
        self.BuscarVendedores();
        self.BuscarComprobantes();
        self.BuscarAlmacen();
        self.fechaFactura.datepicker({
            language: 'es',
            locale: 'es-es',
            dateFormat: 'dd/mm/yy'
        });

        $("#cmbClienteFactura").change(function(e) {
   
            if ($("#cmbClienteFactura").val() != null) {
                let  condPago = $("#cmbClienteFactura option[value='"+$("#cmbClienteFactura").val()+"']").data('condpagoid');
                self.BuscarCondiciones(condPago);
                self.vendedor.val($("#cmbClienteFactura option[value='"+$("#cmbClienteFactura").val()+"']").data('vendedorid'));
                self.tipoComprobante.val($("#cmbClienteFactura option[value='"+$("#cmbClienteFactura").val()+"']").data('comprobanteid'));
            }
        });
        self.tipoComprobante.change(function(e) {
            if (self.tipoComprobante.val() == "0"){
                $("#lblComprobante").parent().parent().addClass('oculto');
                self.comprobante.text('');
            }else {
                $("#lblComprobante").parent().parent().removeClass('oculto');
            }
        });
        
        self.ventana.on('shown.bs.modal', function (e) {
            self.codigoArt.focus();
        });

        self.codigoArt.keypress(function (e) {
            var keycode = (event.keyCode ? event.keyCode : event.which);
            var sigfocus = $(this).data('sigfocus');
            if (keycode == '13') {
                if ($(this).val() == ""){
                    $("#buscar-articulos").modal('show');
                }
                return false;
            }
        });
    }
    this.DeshabilitaHeader = function(){
        
        $("#cmbClienteFactura").attr('disabled','disabled');
        $("#cmbAlmacen").attr('disabled','disabled');
        $("#txtFechaFactura").attr('disabled','disabled');
        $("#cmbCondicion").attr('disabled','disabled');
        $("#cmbComprobanteFiscal").attr('disabled','disabled');
        $("#cmbVendedor").attr('disabled','disabled');
    }
    this.HabilitaHeader = function(){
        
        $("#cmbClienteFactura").removeAttr('disabled');
        $("#cmbAlmacen").removeAttr('disabled');
        $("#txtFechaFactura").removeAttr('disabled');
        $("#cmbCondicion").removeAttr('disabled');
        $("#cmbComprobanteFiscal").removeAttr('disabled');
        $("#cmbVendedor").removeAttr('disabled');
    }
    this.LimpiarCampos = function () {
        //IMPUT, SELECT
        self.facturaNo.val('');
        self.facturaId.val('0');
        self.fechaFactura.val(moment(Date.now()).format('DD/MM/YYYY'));
        self.cliente.val(null).trigger('change');
        self.cliente.data('tag','0');
        self.condicion.val('');
        self.vendedor.val('');
        self.tipoComprobante.val('');
        self.comprobante.text('');
        self.codigoArt.val('');
        $("#btnOk").data('tag','0');
        $("#factura-total").data('tag','false');
        $("#CmdCambiarCliente").data('tag','0');
        self.facturaNo.data('tag','0');
        $("#CmdCambiar").data('tag','0');
        self.InvoiceNo = "0";

        self.HabilitaHeader();

        //TOTALES
        $("#factura-subtotal").text("0.00");
        $("#cantidad-item").text("0.00");
        $("#factura-itbis").text("0.00");
        $("#factura-ley").text("0.00");
        $("#factura-descuento").text("0.00");
        $("#factura-total").text("0.00");

        //TABLA DETALLES
        $("#dataTable-det-factura tbody").html('');

        //BOTONES
        self.ConfiguracionBotones("Nuevo");
    }
    this.ConfiguracionBotones = function(opcion){
        if (opcion == "Nuevo"){
            $("#btnAnularFactura").attr('disabled','disabled');
            $("#CmdCambiarCliente").attr('disabled','disabled');
            $("#CmdPreFactura").attr('disabled','disabled');
            $("#cmdComanda").attr('disabled','disabled');
            $("#CmdCambiar").attr('disabled','disabled');
        }
    }
    this.BuscaDatosIniciales = function () {
        GetAjax("BuscarDatosFacturaNueva", "json", "", function (data) {
            self.facturaNo.val(data.ultNumFactura);
            self.cliente.val(data.genClienteId).trigger('change');
            self.almacen.val(sessionStorage.getItem('almacen_ID'));
            self.tipoComprobante.val(data.genTipoComprobante);
            self.tipoComprobante.trigger('change');
            if (data.genTasaImpuesto > 0) {
                $("#chkImpuesto").prop('checked',sessionStorage.getItem('usuario_SiImpuesto'))
            }
            else {
                $("#chkImpuesto").prop('checked',false)
            }
        });
    }

    this.NuevaFactura = function () {
        self.LimpiarCampos();
        self.BuscaDatosIniciales();
        self.codigoArt.focus();
    }
    this.BuscarClientes = function () {
        GetAjax("ClienteFactura", "json", "", function (data) {
            let dataHtml = '';
            //dataHtml = dataHtml + '<option value="0"></option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option data-condpagoid="'+currentValue.condPagoId+'" data-comprobanteid="'+currentValue.comprobanteTipoId+'" data-vendedorid="'+currentValue.vendedorId+'" value="' + currentValue.clienteId + '">' + currentValue.clienteNombre + '</option>'
            });
            self.cliente.html(dataHtml);
            self.cliente.select2({
                allowClear: true,
                placeholder: "",
                language: "es"
            });
            self.cliente.val([parseInt($("#txtClienteContadoId").val())]).trigger('change');
            $("#CmdCambiar").data('tag',self.cliente.val());
        });
    }
    this.BuscarCondiciones = function (condPago) {

        GetAjax("CondicionFactura/"+condPago, "json", "", function (data) {
 
            let dataHtml = '';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option data-condcantdias="'+currentValue.condPagoDias+'" value="' + currentValue.condPagoId + '">' + currentValue.condPagoDesc + '</option>'
            });
            self.condicion.html(dataHtml);
            self.condicion.val(condPago);
        });
    }
    this.BuscarAlmacen = function () {

        GetAjax("Almacen/", "json", "", function (data) {
 
            let dataHtml = '';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option  value="' + currentValue.almacenId + '">' + currentValue.almacenDesc + '</option>'
            });
            self.almacen.html(dataHtml);
            self.almacen.val(almacen);
        });
    }
    this.BuscarVendedores = function () {
        GetAjax("Vendedor", "json", "", function (data) {
            let dataHtml = '';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.vendedorId + '">' + currentValue.vendedorNombre + '</option>'
            });
            self.vendedor.html(dataHtml);
            self.vendedor.val($("#txtVendedorGeneralId").val());
        });
    }
    this.BuscarComprobantes = function () {
        GetAjax("ComprobanteFactura", "json", "", function (data) {
            let dataHtml = '';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option data-sifechavenc="'+currentValue.comprobanteSiFechaVen+'" data-fechavenc="'+currentValue.comprobanteFechaVen+'" data-noitbis="'+currentValue.comprobanteNoitbis+'" value="' + currentValue.comprobanteTipoId + '">' + currentValue.comprobanteDesc + '</option>'
            });
            self.tipoComprobante.html(dataHtml);
            self.tipoComprobante.val($("#txtComprobanteGeneralId").val());
            if (self.tipoComprobante.val() == "0"){
                self.comprobante.parent().parent().addClass('oculto');
                self.comprobante.text('');
            }
        });
    }
    this.BuscarSigteComprobante = function () {
        if (parseInt(self.tipoComprobante.val()) != 0){
            GetAjax("SiguienteComprobante/"+self.tipoComprobante.val(), "json", "", function (data) {
                if (data.mensaje != "") {
                    let swalWithBootstrapButtons = Swal.mixin({
                        customClass: {
                            confirmButton: 'mr-2 btn btn-success dialog-botones',
                            cancelButton: 'btn btn-danger dialog-botones'
                        },
                        buttonsStyling: false,
                    });
                    swalWithBootstrapButtons.fire(
                        'Notificacion',
                        data.mensaje,
                        'info'
                    );
                }
                self.comprobante.text(data.numNCF);
                self.tipoComprobante.val(data.comprobanteId);
                self.comprobante.data('comprobantecoment',data.comprobanteComent);
                self.comprobante.data('estadocomprobante',data.estadoComprobante);
            });
        }
        else {
            $("#lblComprobante").text('');
            $("#lblComprobante").data('comprobantecoment','');
        }
    }
    this.AgregarArticulo = function() {
        if (self.facturaId.val() == "0") {//nueva factura

        }
    }

    let self = this;    
}
const generarFactura = new GenerarFactura("#pant-factura","#txtFacturaNo","#txtFacturaId","#txtFechaFactura","#cmbClienteFactura","#cmbCondicion","#cmbVendedor","#cmbComprobanteFiscal","#lblComprobante","#txtCodigoArt","#cmbAlmacen");
generarFactura.Init();

$(document).ready(function(){
    
});