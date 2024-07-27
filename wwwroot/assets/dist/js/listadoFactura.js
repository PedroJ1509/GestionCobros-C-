function ListaFacturas(tabla) {
    this.tabla = $(tabla);

    this.Init = function () {

        self.ConsultaVentas();
        self.InicializarTablaSinFiltro();

    }
    this.ConsultaVentas = function () {
        DeshabilitarBottonCargar("#btnFiltrar");
        
        $("#dataTable-ventas").dataTable().fnDestroy();
        $("#dataTable-ventas tbody").html('<tr><td colspan="10" class="text-center"><span class="spinner-border spinner-border-sm spinner_cargando" role="status" aria-hidden="true"></span></td></tr>');
        PostAjax("ListaFacturasVentas/", "json", "POST", "",
            function (param) {
      
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
                                        <td class="text-right">
                                            ${currentValue.estado ? `<span class="label-danger label label-default">Abierta</span>` : `<span class="label-custom label label-default">Cerrada</span>`} 
                                        </td>
                                        <td>
                                        <button type="button" data-facturaid=${currentValue.facturaId}  onclick="listaFacturas.VerDetalle(this)" title="Ver detalles" class="btn btn-info btn-sm btn-action-mjp btn-action-borrar" ><i class="fa fa-reorder"></i> </button>
                                        </td>
                                    </tr>`
                });
                if (dataHtml == '') {
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
    this.ConsultaTotalesVentas = function () {
        
        $("#dataTable-ventas tfoot").html('');
        PostAjax("ListaFacturasVentasTotales/", "json", "POST", "",
            function (param) {
                let dataHtml = '';

                dataHtml = dataHtml + `<tr>
                                    <th>Totales</th>
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
            order: true,
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



    let self = this;
}


var height = $(window).height();

$('.content').css('min-height', height);

const listaFacturas = new ListaFacturas("#dataTable");
listaFacturas.Init();


