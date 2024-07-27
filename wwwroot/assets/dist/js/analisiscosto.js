InicializarTablaSinFiltro = function () {

    table = $("#dataTable").DataTable({
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
BuscarDatosFiltro = function() {
    $("#dataTable tbody").html("");
    let siCambio = parseInt($("#txtSiCambio").val());
    let totalRegistros = parseInt($("#numero-registro-pag-total").text());

    let cadenaFiltro = $("#txtDescripcionFiltro").val() == "" ? "*" : $("#txtDescripcionFiltro").val();

    if (siCambio == 1){
        $("#numero-pagina-actual").text('1');
    }
    DeshabilitarBottonCargar("#btnFiltrar");
    GetAjax("/ListadoArticuloAnalisisCosto/"+$("#numero-pagina-actual").text()+"/"+siCambio+"/"+totalRegistros+"/"+cadenaFiltro, "json", "", function (data) {
        let dataHtml = '';

        data.registros.forEach(function (currentValue, index, arr) {
            let elementoEstado;
            if (currentValue.estadoCerrada == true) 
            {
                elementoEstado = `<span class="label-custom label label-default">Cerrada</span>`;
            }
            else{
                elementoEstado = `<span class="label-danger label label-default">Abierta</span>`;
            }
            
            dataHtml = dataHtml + `<tr>
                                    <td>${currentValue.articuloAnalisisCostoId}</td>
                                    <td>${currentValue.fecha}</td>
                                    <td>${currentValue.codigoDesc}</td>
                                    <td>${currentValue.cantidadTotal}</td>
                                    <td>${currentValue.totalCosto}</td>
                                    <td>${currentValue.costoUnidad}</td>
                                    <td>${currentValue.precio}</td>
                                    <td>${elementoEstado}</td>
                                    <td>
                                        <div class="btn-action">
                                            <button type="button" data-analisisCostoid=${currentValue.articuloAnalisisCostoId} onclick="mantAnalisisCosto.Editar(${currentValue.articuloAnalisisCostoId})" class="btn btn-add btn-sm btn-action-mjp btn-action-editar" ><i class="fa fa-pencil"></i></button>
                                            <button type="button" data-analisisCostoid=${currentValue.articuloAnalisisCostoId} data-analisisCostonombre="${currentValue.codigoDesc}" onclick="mantAnalisisCosto.Borrar(this)" class="btn btn-danger btn-sm btn-action-mjp btn-action-borrar" ><i class="fa fa-trash-o"></i> </button>
                                        </div>
                                    </td>
                                </tr>`
        });
        
        InicializarTablaSinFiltro();

        $("#txtSiCambio").val("0");

        let numeroRegistroPagInicio = 1;
        let numeroRegistroPagFinal = data.paginaActual * 10;
        if (data.paginaActual != 1){
            numeroRegistroPagInicio = data.paginaActual * 10 - 9
        }
        $("#numero-registro-pag-inicio").text(numeroRegistroPagInicio)
        $("#numero-registro-pag-final").text(numeroRegistroPagFinal)

        $("#numero-registro-pag-total").text(data.totalRegistros)
        $("#numero-pagina-actual").text(data.paginaActual)
        $("#total-numero-pagina").text(data.totalPaginas)
        
        ActualizarPaginacion();

        HabilitarBottonCargar("#btnFiltrar");
    });
}
CambioFiltro = function() {
    $("#txtSiCambio").val("1");
}

ActualizarFiltro = function() {
    $("#dataTable").dataTable().fnDestroy();
    // self.InicializarTabla();
    BuscarDatosFiltro();
}
ActualizarPaginacion = function() {
    if (parseInt($("#numero-pagina-actual").text()) == 1){
        $("#btnPagAnterior").addClass('disabled');
    }
    else {
        $("#btnPagAnterior").removeClass('disabled');
    }

    if (parseInt($("#numero-pagina-actual").text()) == parseInt($("#total-numero-pagina").text())){
        $("#btnPagSiguiente").addClass('disabled');
    }
    else {
        $("#btnPagSiguiente").removeClass('disabled');
    }
}
IrSiguientePagina = function () {
    let paginaActual = parseInt($("#numero-pagina-actual").text()) + 1;
    $("#numero-pagina-actual").text(paginaActual);
    self.ActualizarFiltro();
    return false;
}
IrPaginaAnterior = function () {
    let paginaActual = parseInt($("#numero-pagina-actual").text()) - 1;
    $("#numero-pagina-actual").text(paginaActual);
    self.ActualizarFiltro();

    return false;
}
function AnalisisCosto(tabla) {
    this.tabla = $(tabla);

    this.Init = function () {
        BuscarDatosFiltro();
    }

    this.InicializarTabla = function () {
        table = self.tabla.DataTable({
            responsive: true,
            destroy: true,
            searching: true,
            paging: true,
            "drawCallback": function (settings) {
            },
            dom: 'Bfrtip',
            buttons: [
                { extend: 'pdfHtml5', footer: true 
            },
                { extend: 'excelHtml5', footer: true },
                { extend: 'csvHtml5', footer: true }
            ],
            ajax: {
                method: "get",
                url: "/ListadoArticuloAnalisisCosto",
                dataSrc: "",
                contentType: "application/json; charset=utf-8",
                'Authorization': 'Bearer ' + sessionStorage.getItem('tk_mjpsoft'),
                dataType: "json",
                data: function (data) {
                    return data;
                },
                async: true,
                cache: false,
                error: function (jqXHR, textStatus, errorThrown) {
                    
                    swal({
                        title: "Error",
                        text: jqXHR.error,
                        type: 'error'
                    });
                    return false;
                }
            },
            columnDefs: [{
                "targets": -1,
                "visible": true,
                "orderable": false,
                "className": 'all',
                "data": null,
                "render": function (data) {
                    return `<div class="btn-action">
                                <button type="button" data-analisisCostoid=${data.analisisCostoID} onclick="mantAnalisisCosto.Editar(${data.analisisCostoID})" class="btn btn-add btn-sm btn-action-mjp btn-action-editar" ><i class="fa fa-pencil"></i></button>
                                <button type="button" data-analisisCostoid=${data.analisisCostoID} data-analisisCostonombre="${data.analisisCostoDescripcion}" onclick="mantAnalisisCosto.Borrar(this)" class="btn btn-danger btn-sm btn-action-mjp btn-action-borrar" ><i class="fa fa-trash-o"></i> </button>
                            </div>`;
                }
            },
            {
                "targets": -2,
                "visible": true,
                "orderable": true,
                "className": 'all',
                "data": null,
                "render": function (data) {
                    if (data.EstadoCerrada == true)
                    {
                        return `<span class="label-custom label label-default">Cerrada
                        </span>`;
                    }
                    else{
                        return `<span class="label-danger label label-default">Abierta
                            </span>`;
                    }
                }
            }],
            columns: [
                { "data": "articuloAnalisisCostoId" },
                { "data": "fecha" },
                { "data": "codigoDesc" },
                { "data": "cantidadTotal" },
                { "data": "totalCosto" },
                { "data": "costoUnidad" },
                { "data": "precio" },
                { "defaultContent": '' },
                { "defaultContent": '' }
            ],
            "language": {
                "url": "https://cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json"
            }
        });
    }
    

    
    

    let self = this;
}

const analisisCosto = new AnalisisCosto("#dataTable");
analisisCosto.Init();

$(document).ready(function(){
    var height = $(window).height();
    $('.content').css('min-height',height);
});


