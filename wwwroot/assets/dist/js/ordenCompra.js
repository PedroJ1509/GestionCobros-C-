function OrdenCompra(tabla) {
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

        self.BuscarSuplidores();
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
                                        <button type="button" data-facturaid=${currentValue.facturaId}  onclick="ordencompra.VerDetalle(this)" title="Ver detalles" class="btn btn-info btn-sm btn-action-mjp btn-action-borrar" ><i class="fa fa-reorder"></i> </button>
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

    this.InicializarTablaSinFiltro = function () {

        table = $("#dataTable-ordencompra").DataTable({
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

    
    this.BuscarSuplidores = function () {
        GetAjax("Suplidor", "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<option value="0">Todos</option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.suplidorId + '">' + currentValue.suplidorNombre + '</option>'
            });
            $("#cmbSuplidor").html(dataHtml);
            $("#cmbSuplidor").select2({
                allowClear: true,
                placeholder: "",
                language: "es"
            });
            $("#cmbSuplidor").val(null).trigger('change');
        });
    }

    this.ActualizarFiltro = function() {
    }

    let self = this;
}


var height = $(window).height();

$('.content').css('min-height', height);

const ordencompra = new OrdenCompra("#dataTable");
ordencompra.Init();
