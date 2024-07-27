function ConsInventario(tabla) {
    this.tabla = $(tabla);

    this.Init = function () {
        //self.InicializarTabla();
        $("#txtFechaDesde").datepicker({
            language: 'es',
            dateFormat: "dd/mm/yy"
        });
        $("#txtFechaHasta").datepicker({
            language: 'es',
            dateFormat: "dd/mm/yy"
        });

        self.ActualizarFiltro();
        self.BuscarArticulos();
    }

    this.BuscarArticulos = function () {
        GetAjax("AllArticulos", "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<option value="0">Todos</option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.articuloId + '">' + currentValue.articuloDesc + '</option>'
            });
            $("#cmbArtículo").html(dataHtml);
            $("#cmbArtículo").select2({
                allowClear: true,
                placeholder: "",
                language: "es"
            });
            $("#cmbArtículo").val(null).trigger('change');
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
            order: [[ 2, "desc" ]],
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

        let articulo = $("#cmbArtículo").val() == null ? "0" : $("#cmbArtículo").val();

        if (siCambio == 1){
            $("#numero-pagina-actual").text('1');
        }
        DeshabilitarBottonCargar("#btnFiltrar");
        GetAjax("/ConsultaVentasPorArticulo/"+parseInt(articulo)+"/"+CambiarFormatoFecha($("#txtFechaDesde").val())+"T00:00:00/"+CambiarFormatoFecha($("#txtFechaHasta").val())+"T23:59:00/"+$("#numero-pagina-actual").text()+"/"+siCambio+"/"+totalRegistros, "json", "", function (data) {
            let dataHtml = '';

            data.registros.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + `<tr>
                                        <td>${currentValue.articuloCd}</td>
                                        <td>${currentValue.articuloDesc}</td>
                                        <td class="text-right">${currentValue.cantidad}</td>
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

const consventasporarticulo = new ConsInventario("#dataTable");
consventasporarticulo.Init();


