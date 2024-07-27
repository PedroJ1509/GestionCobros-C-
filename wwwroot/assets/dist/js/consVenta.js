function ConsVentas(tabla) {
    this.tabla = $(tabla);

    this.Init = function () {
        
        $("#txtFechaDesde").datepicker({
            language: 'es',
            dateFormat: "dd/mm/yy"
        });
        $("#txtFechaHasta").datepicker({
            language: 'es',
            dateFormat: "dd/mm/yy"
        });

        self.BuscarClientes();
        self.BuscarComprobante();
        self.InicializarTablaSinFiltro();

    }
    this.ConsultaVentas = function() {
        DeshabilitarBottonCargar("#btnFiltrar");
        let consultaVentas = {
            "fechaDesde" : CambiarFormatoFecha($("#txtFechaDesde").val())+"T00:00:00",
            "fechaHasta" : CambiarFormatoFecha($("#txtFechaHasta").val())+"T23:59:00",
            "estado" : $("#cmbEstado").val(),
            "tipoComprobante" :  $("#cmbTipoComprobante").val() == null ? "0" : $("#cmbTipoComprobante").val(),
            "clienteId" : $("#cmbCliente").val() == null ? "0" : $("#cmbCliente").val(),
            "condicionId" : $("#cmbCondicion").val()
        }
        
        $("#dataTable-ventas").dataTable().fnDestroy();
        $("#dataTable-ventas tbody").html('<tr><td colspan="10" class="text-center">No hay registros</td></tr>');
        PostAjax("Ventas/", "json", "POST", JSON.stringify(consultaVentas), 
        function (param) {
            console.log(param);
            let dataHtml = '';

            param.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + `<tr>
                                        <td>${currentValue.facturaNo}</td>
                                        <td>
                                            ${currentValue.fecha}
                                        </td>
                                        <td>
                                            ${currentValue.cliente}
                                        </td>
                                        <td>
                                            ${currentValue.condicionDesc}
                                        </td>
                                        <td>
                                            ${currentValue.comprobante}
                                        </td>
                                        <td class="text-right">
                                            ${currentValue.descuento}
                                        </td>
                                        <td class="text-right">
                                            ${currentValue.itbis}
                                        </td>
                                        <td class="text-right">
                                            ${currentValue.ley}
                                        </td>
                                        <td class="text-right">
                                            ${currentValue.total}
                                        </td>
                                        <td>
                                        <button type="button" data-facturaid=${currentValue.facturaId}  onclick="consventas.VerDetalle(this)" title="Ver detalles" class="btn btn-info btn-sm btn-action-mjp btn-action-borrar" ><i class="fa fa-reorder"></i> </button>
                                        </td>
                                    </tr>`
            });
            if (dataHtml == ''){
                dataHtml = '<tr><td colspan="10" class="text-center">No hay registros</td></tr>';
            }
            $("#dataTable-ventas tbody").html(dataHtml);

            self.ConsultaTotalesVentas();
        },
        function (error) {
            let swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'mr-2 btn btn-success dialog-botones',
                    cancelButton: 'btn btn-danger dialog-botones'
                },
                buttonsStyling: false,
            });
            if (error.responseText == 404) {
                swalWithBootstrapButtons.fire(
                    'Notificacion',
                    error.statusText,
                    'info'
                );
            }
            else {
                swalWithBootstrapButtons.fire(
                    'Notificacion',
                    error.responseText,
                    'info'
                );
            }
        });
    }
    this.VerDetalle = function(ele){
        $("#txtFacturaId").val($(ele).data('facturaid'));
        $("#vista-previa-factura").modal('show');
        $("#dataTable-det-factura tbody").html('');
        GetAjax("/ConsultaDetFactulla/"+parseInt($("#txtFacturaId").val()), "json", "", function (data) {
            
            if (data.comprobanteTipoId == 0){
                $("#tabla-comprobante").addClass('oculto');
            }
            else {
                $("#tabla-comprobante").removeClass('oculto');
                $("#descripcion-comprobante").text(data.comprobanteTipo);
                
                $("#descripcion-comprobante").text(data.comprobanteTipo);
                $("#comprobante-factura").text(data.comprobante);
                if (data.comprobanteSiFechaVen){
                    $("#comprobante-fechavalida").text(data.comprobanteFechaValida);
                    $(".comprobante-fechavalida").removeClass('oculto');
                }else {
                    $(".comprobante-fechavalida").addClass('oculto');
                }
            }

            
            $("#factura-no").text(data.facturaNo);
            $("#factura-cliente").text(data.cliente);
            $("#cliente-cedula").text(data.clienteCedula);
            $("#cliente-telefono").text(data.clienteTelefono);
            $("#factura-fecha").text(data.fecha);
            $("#factura-hora").text(data.hora);
            $("#factura-condicion").text(data.condicionDesc);
            $("#factura-vendedor").text(data.vendedor);
            $("#cantidad-item").text(data.facturaDet.length);
            $("#factura-subtotal").text(data.subTotal);
            $("#factura-descuento").text(data.descuento);
            $("#factura-itbis").text(data.itbis);
            $("#factura-ley").text(data.ley);
            $("#factura-total").text(data.total);
            
            let dataHtml = '';
            
            data.facturaDet.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + `<tr>
                                        <td>${currentValue.codigo}</td>
                                        <td>${currentValue.descripcion}</td>
                                        <td class="text-right">${currentValue.cantidad}</td>
                                        <td>${currentValue.unidad}</td>
                                        <td class="text-right">${currentValue.precio}</td>
                                        <td class="text-right">${currentValue.itbis}</td>
                                        <td class="text-right">${currentValue.importe}</td>
                                    </tr>`
            });
            $("#dataTable-det-factura tbody").html(dataHtml);

        });
    }
    this.ConsultaTotalesVentas = function() {
        let consultaVentas = {
            "fechaDesde" : CambiarFormatoFecha($("#txtFechaDesde").val())+"T00:00:00",
            "fechaHasta" : CambiarFormatoFecha($("#txtFechaHasta").val())+"T23:59:00",
            "estado" : $("#cmbEstado").val(),
            "tipoComprobante" :  $("#cmbTipoComprobante").val() == null ? "0" : $("#cmbTipoComprobante").val(),
            "clienteId" : $("#cmbCliente").val() == null ? "0" : $("#cmbCliente").val(),
            "condicionId" : $("#cmbCondicion").val()
        }
        $("#dataTable-ventas tfoot").html('');
        PostAjax("VentasTotales/", "json", "POST", JSON.stringify(consultaVentas), 
        function (param) {
            let dataHtml = '';

            dataHtml = dataHtml + `<tr>
                                    <th>Totales</th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th class="text-right">
                                        ${param.totalDescuento}
                                    </td>
                                    <th class="text-right">
                                        ${param.totalItbis}
                                    </th>
                                    <th class="text-right">
                                        ${param.totalLey}
                                    </th>
                                    <th class="text-right">
                                        ${param.totalGeneral}
                                    </th>
                                    <th></th>
                                </tr>`
            
            $("#dataTable-ventas tfoot").html(dataHtml);

            HabilitarBottonCargar("#btnFiltrar");

            self.InicializarTablaSinFiltro();
        },
        function (error) {
            let swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'mr-2 btn btn-success dialog-botones',
                    cancelButton: 'btn btn-danger dialog-botones'
                },
                buttonsStyling: false,
            });
            if (error.responseText == 404) {
                swalWithBootstrapButtons.fire(
                    'Notificacion',
                    error.statusText,
                    'info'
                );
            }
            else {
                swalWithBootstrapButtons.fire(
                    'Notificacion',
                    error.responseText,
                    'info'
                );
            }
        });
    }
    
    this.InicializarTablaSinFiltro = function () {

        table = $("#dataTable-ventas").DataTable({
            responsive: true,
            destroy: true,
            searching: false,
            paging: false,
            "drawCallback": function (settings) {
                $("#dataTable_info").text('');
            },
            dom: 'Bfrtip',
            buttons: [
                {
                    extend: 'pdfHtml5', footer: true
                },
                { extend: 'excelHtml5', footer: true },
                { extend: 'csvHtml5', footer: true }
            ],
            "language": {
                "url": "https://cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json"
            }
        });
    }

    
    this.BuscarClientes = function () {
        GetAjax("Cliente", "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<option value="0">Todos</option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.clienteId + '">' + currentValue.clienteNombre + '</option>'
            });
            $("#cmbCliente").html(dataHtml);
            $("#cmbCliente").select2({
                allowClear: true,
                placeholder: "",
                language: "es"
            });
            $("#cmbCliente").val(null).trigger('change');
        });
    }
    this.BuscarComprobante = function () {
        GetAjax("ComprobanteFactura", "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<option value="0">Todos</option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.comprobanteTipoId + '">' + currentValue.comprobanteDesc + '</option>'
            });
            $("#cmbTipoComprobante").html(dataHtml);
            $("#cmbTipoComprobante").select2({
                allowClear: true,
                placeholder: "",
                language: "es"
            });
            $("#cmbTipoComprobante").val(null).trigger('change');
        });
    }

    this.ActualizarFiltro = function() {
    }

    let self = this;
}


var height = $(window).height();

$('.content').css('min-height', height);

const consventas = new ConsVentas("#dataTable");
consventas.Init();


