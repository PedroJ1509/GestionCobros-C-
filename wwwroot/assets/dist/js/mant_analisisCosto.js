function analisisCostoDTO(ArticuloAnalisisCostoId, ArticuloId, TotalCosto, CostoUnd, Ganancia,Estado,Cantidad,TotalCostoExist,
    TotalCostoFalt,LabelInfo1,LabelInfo2
) {
    this.ArticuloAnalisisCostoId = ArticuloAnalisisCostoId;
    this.ArticuloId = ArticuloId;
    this.TotalCosto = TotalCosto;
    this.CostoUnd = CostoUnd;
    this.Ganancia = Ganancia;
    this.Estado = Estado;
    this.Cantidad = Cantidad;
    this.TotalCostoExist = TotalCostoExist;
    this.TotalCostoFalt = TotalCostoFalt;
    this.LabelInfo1 = LabelInfo1;
    this.LabelInfo2 = LabelInfo2;
}

function AnalisisCosto(ventana, analisisCostoId, descripcion, sala, activo) {
    this.ventana = $(ventana);
    this.analisisCostoId = $(analisisCostoId);
    this.descripcion = $(descripcion);
    this.sala = $(sala);
    this.activo = $(activo);

    this.Init = function () {

        
        $("input,select").keypress(function (e) {
            var keycode = (event.keyCode ? event.keyCode : event.which);
            var sigfocus = $(this).data('sigfocus');
            if (keycode == '13') {
                $("#"+sigfocus).focus();
                return false;
            }
        });

        self.ventana.on('shown.bs.modal', function (e) {
            self.descripcion.focus();
            self.descripcion.select();
        });
        self.ventana.on('hidden.bs.modal', function (e) {
            self.InicializarComponentes();
        });
        self.BuscarArticulos();
        self.BuscarArticulosIngredientes();
        self.activo.prop('checked', true);
    }
    this.InicializarComponentes = function () {
        $(ventana + " input").each(function (e) {
            if ($(this).hasClass('is-invalid')) {
                $(this).removeClass('is-invalid');
            }
            $(this).val("");
        });
        $(ventana + " select").each(function (e) {
            if ($(this).hasClass('is-invalid')) {
                $(this).removeClass('is-invalid');
            }
            $(this).val("0");
        });

        self.analisisCostoId.val("0");
        $("#cmbArticulo").val(null).trigger('change');
        $("#txtCantidad").val("1");
    }
    
    this.BuscarArticulosIngredientes = function () {
        GetAjax("ArticulosInventario", "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<option value="0"></option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option data-unidadid="' + currentValue.unindadId + '" data-unidaddesc="' + currentValue.unidadDesc + '" value="' + currentValue.articuloID + '">' + currentValue.articuloDescripcion + '</option>'
            });
            $("#cmbIngredientes").html(dataHtml);
            $("#cmbIngredientes").select2({
                allowClear: true,
                placeholder: "",
                language: "es"
            });
            $("#cmbIngredientes").val(null).trigger('change');
        });
    }
    
    this.SeleccionarUnidad = function(ele) {
        if ($(ele).val() == null || $(ele).val() == '' ){
            $("#txtUnidadIngred").val('0');
        }else {
            GetAjax("UnidadesIngrediente/"+$(ele).val(), "json", "", function (data) {
                let dataHtml = '';
                dataHtml = dataHtml + '<option value="0"></option>';
                data.forEach(function (currentValue, index, arr) {
                    dataHtml = dataHtml + '<option value="' + currentValue.unidadId + '">' + currentValue.unidadDesc + '</option>'
                });
                $("#cmbUnidadIngred").html(dataHtml);
                $("#txtCantidadIngred").focus();
            });
        }
    }
    
    this.AgregarIngrediente = function() {
        if ($("#cmbArticulo").val() != null && $("#cmbArticulo").val() != "0") {
            if ($("#cmbIngredientes").val() == null || $("#cmbIngredientes").val() == ""){
                $("#cmbIngredientes").addClass('is-invalid');
                $("#cmbIngredientes").focus();
                return false;
            }else{
                $("#cmbIngredientes").removeClass('is-invalid');
            }
    
            if ($("#cmbUnidadIngred").val() == "0"){
                $("#cmbUnidadIngred").addClass('is-invalid');
                $("#cmbUnidadIngred").focus();
                return false;
            }else{
                $("#cmbUnidadIngred").removeClass('is-invalid');
            }
            
            if ($("#txtCantidadIngred").val() == "" || $("#txtCantidadIngred").val() == "0"){
                $("#txtCantidadIngred").addClass('is-invalid');
                $("#txtCantidadIngred").focus();
                return false;
            }else{
                $("#txtCantidadIngred").removeClass('is-invalid');
            }
    
            let articuloKit = {
                "articuloIdPadre" : parseInt($("#cmbArticulo").val()),
                "articuloIdHijo" : parseInt($("#cmbIngredientes").val()),
                "unidadId" : parseInt($("#cmbUnidadIngred").val()),
                "cantidad" : parseFloat($("#txtCantidadIngred").val())
            }
    
            PostAjax("ArticuloKit", "json", "POST", JSON.stringify(articuloKit),
                function (param) {
                    $("#cmbIngredientes").val(null).trigger('change');
                    $("#txtCantidadIngred").val('');
                    $("#txtUnidadIngred").val('');
                    self.BuscarDatos($("#txtCantidad").val());
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
                }
            );
        }
        else {
            let swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'mr-2 btn btn-success dialog-botones',
                    cancelButton: 'btn btn-danger dialog-botones'
                },
                buttonsStyling: false,
            });

            swalWithBootstrapButtons.fire(
                'Llenar datos',
                'Debe seleccionar el artículo principal para poder agregar ingredientes.',
                'error'
            );
        }
        

    }
    this.BuscarArticulos = function () {
        GetAjax("ArticulosIngredientes", "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<option value="0"></option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option data-unidadid="' + currentValue.unindadId + '" data-unidaddesc="' + currentValue.unidadDesc + '" value="' + currentValue.articuloID + '">' + currentValue.articuloDescripcion + '</option>'
            });
            $("#cmbArticulo").html(dataHtml);
            $("#cmbArticulo").select2({
                allowClear: true,
                placeholder: "",
                language: "es"
            });
            $("#cmbArticulo").val(null).trigger('change');
        });
    }
    this.MostrarDatosIngredientes = function() {
        if ($("#ingredientes").hasClass('oculto')) {
            $("#ingredientes").removeClass('oculto');
            $("#link-agregar-ingredientes").text("Ocultar");
        }
        else {
            $("#link-agregar-ingredientes").text("Agregar Ingredientes");
            $("#ingredientes").addClass('oculto');
        }
    }
    this.CambioCantidad = function(el) {
        if (parseFloat($(el).val()) < 0) {
            let swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'mr-2 btn btn-success dialog-botones',
                    cancelButton: 'btn btn-danger dialog-botones'
                },
                buttonsStyling: false,
            });

            swalWithBootstrapButtons.fire(
                'Valor incorrecto',
                'Valor digitado es incorrecto, favor verificar...',
                'error'
            );
            $(el).val("1");
        }
        self.BuscarDatos($(el).val());
    }
    this.CambioArticulo = function(cantidad) {
        $("#txtCantidad").val(cantidad);
        self.BuscarDatos(cantidad);
    }
    this.BuscarDatos = function (cantidad) {
   
        if ($("#cmbArticulo").val() != null) {
            $("#dataTable-compras tbody").html("<tr><td colspan='10'>No registro seleccionado</td></tr>");
            $("#dataTable-detalle-analisiscosto tbody").html("");
            let articuloId = $("#cmbArticulo").val();

            GetAjax("MenuArticulo/"+articuloId+"/"+cantidad, "json", "", function (data) {
                let dataHtml = '';
                let cantIng = 0;
                data.registros.forEach(function (currentValue, index, arr) {
                    cantIng++;
                    dataHtml = dataHtml + `<tr class="fila-analisis" onclick="mantAnalisisCosto.VerCompras(this,${currentValue.articuloId})">
                                            <td>${currentValue.articuloDesc}</td>
                                            <td>${currentValue.unidadDesc}</td>
                                            <td>
                                                ${currentValue.costoUnidad}
                                            </td>
                                            <td>${currentValue.cantidad}</td>
                                            <td>${currentValue.totalCosto}</td>
                                            <td>${currentValue.existencia}</td>
                                            <td>${currentValue.totalCostoExistencia}</td>
                                            <td style="background: salmon;font-weight: 700;">${currentValue.existenciaFaltante}</td>
                                            <td style="background: bisque;font-weight: 700; ">${currentValue.totalCostoExistenciaFaltante}</td>
                                            <td><button type="button" data-articulokitid=${currentValue.articuloPorKitId}  onclick="mantAnalisisCosto.BorrarIngrediente(this)" class="btn btn-danger btn-sm btn-action-mjp btn-action-borrar" ><i class="fa fa-trash-o"></i> </button></td>
                                        </tr>`
                });

                $("#total-costos-ingred").text(data.totalCostoTotales);
                $("#total-costos-falt").text(data.totalCostoExistenciaFaltanteTotales);
                $("#total-casto-unidad").text(data.costoUnidadTotales);
                $("#cantidad-item").text(cantIng);
                $("#dataTable-detalle-analisiscosto tbody").html(dataHtml);
            });
        }
        else {
            $("#total-costos-ingred").text("0.00");
                $("#total-costos-falt").text("0.00");
                $("#total-casto-unidad").text("0.00");
                $("#cantidad-item").text("0");
            $("#dataTable-detalle-analisiscosto tbody").html("");
        }
    }
    this.VerCompras = function (el,articuloId) {
        $(".fila-analisis").removeClass('filta-select');
        $(el).addClass('filta-select');
        self.BuscarComprasArticulo(articuloId);
    }
    this.BuscarComprasArticulo = function (articuloId) {
        $("#dataTable-compras tbody").html("");
        GetAjax("ComprasArticulo/"+articuloId, "json", "", function (data) {
            let dataHtml = '';

            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + `<tr>
                                        <td>${currentValue.fecha}</td>
                                        <td>
                                            ${currentValue.suplidor}
                                        </td>
                                        <td>
                                        ${currentValue.unidad}
                                        </td>
                                        <td>
                                        ${currentValue.cantidad}
                                      
                                        </td>
                                        <td>
                                        ${currentValue.costo}

                                        </td>
                                    </tr>`
            });
            if (dataHtml == ''){
                dataHtml = "<tr><td colspan='10'>No se encontrron registros</td></tr>";
            }
            $("#dataTable-compras tbody").html(dataHtml);
        });
    }
    this.ActualizaPrecio = function(el) {
       
        $("#precio-sugerido").text(Math.round(parseFloat($("#total-casto-unidad").text()) * ((parseFloat($(el).val())/100)+1))+'.00');
    }
    this.BorrarIngrediente = function(ele) {
        let articuloKitId = $(ele).data('articulokitid');

        let swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: 'mr-2 btn btn-success dialog-botones',
                cancelButton: 'btn btn-danger   dialog-botones'
            },
            buttonsStyling: false,
        });

        swalWithBootstrapButtons.fire({
            title: "Borrar Registro",
            text: `¿Está seguro que desea borrar el registro seleccionado`,
            type: 'info',
            showCancelButton: true,
            cancelButtonText: 'No',
            confirmButtonText: 'Si'
            }).then(function(respuesta) {
                if (respuesta.value){
                    PostAjax("ArticuloKit/"+articuloKitId,"json","Delete", "", 
                        function (param) {
                            swalWithBootstrapButtons.fire(
                                'Registro Borrado',
                                'Registro ha sido borrado exitosamente.',
                                'success'
                            );
                            
                            self.BuscarDatos($("#txtCantidad").val());
                        }, 
                        function(error) {
                            let swalWithBootstrapButtons = Swal.mixin({
                                customClass: {
                                    confirmButton: 'mr-2 btn btn-success dialog-botones',
                                    cancelButton: 'btn btn-danger dialog-botones'
                                },
                                buttonsStyling: false,
                            });
                            if (error.status == 404) {
                                swalWithBootstrapButtons.fire(
                                    'No Borrado',
                                    error.responseJSON,
                                    'error'
                                );
                            }
                            else {
                                swalWithBootstrapButtons.fire(
                                    'No Borrado',
                                    error.responseJSON,
                                    'error'
                                );
                            }
                        }
                    ); 
                }
            }
        );
    }
    this.Validar = function () {
        let result = true;
        if (self.descripcion.val() == "") {
            self.descripcion.addClass('is-invalid');
            self.descripcion.focus();
            result = false;
        } else {
            self.descripcion.removeClass('is-invalid');
        }
        if (self.sala.val() == "0") {
            self.sala.addClass('is-invalid');
            self.sala.focus();
            result = false;
        } else {
            self.sala.removeClass('is-invalid');
        }
        return result;
    }
    this.Cancelar = function () {

        self.ventana.modal('hide');
        return false;
    }
    this.Guardar = function () {
        if (self.Validar() == true) {
            DeshabilitarBottonCargar("#btnGuardar");
            debugger;
            let analisisCosto = new analisisCostoDTO(
                parseInt(self.analisisCostoId.val()), 
                parseInt($("#cmbArticulo").val()),
                parseFloat($("#total-costos-ingred").text().replace(',','')),
                parseFloat($("#total-casto-unidad").text().replace(',','')),
                parseFloat($("#txtGanancia").val()),
                true,
                parseInt($("#txtCantidad").val()),
                0,
                parseFloat($("#total-costos-falt").text().replace(',','')),'',''
            );
            let type = "";
            let url = "AnalisisCosto";
            if (parseInt(self.analisisCostoId.val()) == 0) {
                type = "POST";
            }
            else {
                type = "PUT"
            }
            PostAjax(url, "json", type, JSON.stringify(analisisCosto),
                function (param) {
                    HabilitarBottonCargar("#btnGuardar");
                    ActualizarFiltro();
                    self.ventana.modal('hide');
                },
                function (error) {
                    let swalWithBootstrapButtons = Swal.mixin({
                        customClass: {
                            confirmButton: 'mr-2 btn btn-success dialog-botones',
                            cancelButton: 'btn btn-danger dialog-botones'
                        },
                        buttonsStyling: false,
                    });
                    if (error.status == 404) {
                        swalWithBootstrapButtons.fire(
                            'Notificacion',
                            error.responseJSON,
                            'info'
                        );
                    }
                    else {
                        swalWithBootstrapButtons.fire(
                            'Notificacion',
                            error.responseJSON,
                            'info'
                        );
                    }
                    HabilitarBottonCargar("#btnGuardar");
                }
            );
        }
        return false;
    }
    this.Editar = function (id) {
        self.analisisCostoId.val(id);
        GetAjax("AnalisisCosto/" + id, "json", "", function (data) {
            if (data != null) {
                self.descripcion.val(data.analisisCostoDesc);
                self.activo.prop('checked', data.analisisCostoEstatus);
                self.sala.val(data.salaId);
            }
            self.ventana.modal('show');
        });
    }
    this.Borrar = function (ele) {
        let id = $(ele).data('analisisCostoid');
        let nombre = $(ele).data('analisisCostodesc');
        let swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: 'mr-2 btn btn-success dialog-botones',
                cancelButton: 'btn btn-danger   dialog-botones'
            },
            buttonsStyling: false,
        });

        swalWithBootstrapButtons.fire({
            title: "Borrar Registro",
            text: `¿Está seguro que desea borrar el registro "${nombre}"`,
            type: 'info',
            showCancelButton: true,
            cancelButtonText: 'No',
            confirmButtonText: 'Si'
        }).then(function (respuesta) {
            if (respuesta.value) {
                PostAjax("AnalisisCosto/" + id, "json", "Delete", "",
                    function (param) {
                        swalWithBootstrapButtons.fire(
                            'Registro Borrado',
                            'Registro ha sido borrado exitosamente.',
                            'success'
                        );

                        table.ajax.reload();
                    },
                    function (error) {
                        let swalWithBootstrapButtons = Swal.mixin({
                            customClass: {
                                confirmButton: 'mr-2 btn btn-success dialog-botones',
                                cancelButton: 'btn btn-danger dialog-botones'
                            },
                            buttonsStyling: false,
                        });
                        if (error.status == 404) {
                            swalWithBootstrapButtons.fire(
                                'No Borrado',
                                error.responseJSON,
                                'error'
                            );
                        }
                        else {
                            swalWithBootstrapButtons.fire(
                                'No Borrado',
                                error.responseJSON,
                                'error'
                            );
                        }
                    }
                );
            }
        }
        );
    }

    let self = this;
}

const mantAnalisisCosto = new AnalisisCosto("#mant-articulo", "#txtAnalisisCostoId", "#txtDescripcion", "#cmbSala", "#chkActivo");
mantAnalisisCosto.Init();
