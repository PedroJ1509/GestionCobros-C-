function ConsInventario(tabla) {
    this.tabla = $(tabla);

    this.Init = function () {
        //self.InicializarTabla();
        self.ActualizarFiltro();
    }

    this.InicializarTabla = function () {
        let siCambio = 1;
        let totalRegistros = 0;
        table = self.tabla.DataTable({
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
            ajax: {
                method: "get",
                url: "/Inventario/"+parseInt($("#cmbExistencia").val())+"/"+$("#numero-pagina-actual").text()+"/"+siCambio+"/"+totalRegistros,
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
            columns: [
                { "data": "articuloCodigo" },
                { "data": "articuloDescripcion" },
                { "data": "articuloParteNo" },
                { "data": "articuloUdm" },
                { "data": "articuloUbicacion" },
                { "data": "articuloExistencia" },
                { "data": "articuloCosto" },
                { "data": "articuloPrecios" }
            ],
            "language": {
                "url": "https://cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json"
            }
        });
    }
    this.InicializarTablaSinFiltro = function () {

        table = self.tabla.DataTable({
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

    
    this.BuscarDatosFiltro = function() {
        $("#dataTable tbody").html("");
        let siCambio = parseInt($("#txtSiCambio").val());
        let totalRegistros = parseInt($("#numero-registro-pag-total").text());

        let cadenaFiltro = $("#txtDescripcion").val() == "" ? "*" : $("#txtDescripcion").val();

        if (siCambio == 1){
            $("#numero-pagina-actual").text('1');
        }
        DeshabilitarBottonCargar("#btnFiltrar");
        GetAjax("/Inventario/"+parseInt($("#cmbExistencia").val())+"/"+$("#numero-pagina-actual").text()+"/"+siCambio+"/"+totalRegistros+"/"+cadenaFiltro, "json", "", function (data) {
            let dataHtml = '';

            data.registros.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + `<tr>
                                        <td>${currentValue.articuloCodigo}</td>
                                        <td>${currentValue.articuloDescripcion}</td>
                                        <td>${currentValue.articuloParteNo}</td>
                                        <td>${currentValue.articuloUdm}</td>
                                        <td>${currentValue.articuloUbicacion}</td>
                                        <td>${currentValue.articuloExistencia}</td>
                                        <td>${currentValue.articuloCosto}</td>
                                        <td>${currentValue.articuloPrecios}</td>
                                    </tr>`
            });
            $("#dataTable tbody").html(dataHtml);

            self.InicializarTablaSinFiltro();

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
            
            self.ActualizarPaginacion();

            HabilitarBottonCargar("#btnFiltrar");
        });
    }
    this.CambioFiltro = function() {
        $("#txtSiCambio").val("1");
    }

    this.ActualizarFiltro = function() {
        self.tabla.dataTable().fnDestroy();
        // self.InicializarTabla();
        self.BuscarDatosFiltro();
    }
    this.ActualizarPaginacion = function() {
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
    this.IrSiguientePagina = function () {
        let paginaActual = parseInt($("#numero-pagina-actual").text()) + 1;
        $("#numero-pagina-actual").text(paginaActual);
        self.ActualizarFiltro();
        return false;
    }
    this.IrPaginaAnterior = function () {
        let paginaActual = parseInt($("#numero-pagina-actual").text()) - 1;
        $("#numero-pagina-actual").text(paginaActual);
        self.ActualizarFiltro();

        return false;
    }

    let self = this;
}


var height = $(window).height();

$('.content').css('min-height', height);

const consinventario = new ConsInventario("#dataTable");
consinventario.Init();


