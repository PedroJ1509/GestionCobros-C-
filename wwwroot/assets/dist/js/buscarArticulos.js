function BusquedaArticulo(tabla) {
    this.tabla = $(tabla);

    this.Init = function () {
        //self.InicializarTabla();
        //self.ActualizarFiltro();
        $("#buscar-articulos").on('shown.bs.modal', function (e) {
            //$("#dataTable-Articulo tbody").html('<tr><td colspan="8" class="text-center"><span class="spinner-border spinner-border-sm spinner_cargando" role="status" aria-hidden="true"></span></td></tr>');
           
            self.ActualizarFiltro();
            $("#txtDescripcion").focus();
        });
        $("#buscar-articulos").on('hidden.bs.modal', function (e) {
            $("#txtDescripcion").val('');
            $("#txtDescripcion").change();
            self.ActualizarFiltro();
            $("#txtCodigoArt").select();
            $("#txtCodigoArt").focus();
        });
        $("#txtDescripcion").keypress(function (e) {
            var keycode = (event.keyCode ? event.keyCode : event.which);
            var sigfocus = $(this).data('sigfocus');
            if (keycode == '13') {
                $("#txtDescripcion").blur();
                self.tabla.dataTable().fnDestroy();
                self.BuscarDatosFiltro();
                return false;
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
                $("#dataTable-Articulo_info").text('');
            },
            "language": {
                "url": "https://cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json"
            }
        });
    }

    this.SeleccionarArticulo = function(codigo) {
        $("#txtCodigoArt").val(codigo);
        $("#buscar-articulos").modal('hide');
    }
    
    this.BuscarDatosFiltro = function() {
        $("#dataTable-Articulo tbody").html("");
        let siCambio = parseInt($("#txtSiCambio").val());
        let totalRegistros = parseInt($("#numero-registro-pag-total").text());

        let cadenaFiltro = $("#txtDescripcion").val() == "" ? "*" : $("#txtDescripcion").val();

        if (siCambio == 1){
            $("#numero-pagina-actual").text('1');
        }
        DeshabilitarBottonCargar("#btnFiltrar");
        GetAjax("/Inventario/0/"+$("#numero-pagina-actual").text()+"/"+siCambio+"/"+totalRegistros+"/"+cadenaFiltro, "json", "", function (data) {
            let dataHtml = '';
            data.registros.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + `<tr onclick="busquedaArticulo.SeleccionarArticulo('${currentValue.articuloCodigo}')">
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
            
            $("#dataTable-Articulo tbody").html(dataHtml);

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
            $("#txtDescripcion").focus();
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

const busquedaArticulo = new BusquedaArticulo("#dataTable-Articulo");
busquedaArticulo.Init();


