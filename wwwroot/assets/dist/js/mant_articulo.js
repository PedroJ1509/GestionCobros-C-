function articuloDTO(ArticuloId, ArticuloCd, 
    ArticuloPartNo, 
    ArticuloDesc, 
    MarcaId, 
    ModeloId, 
    ArticuloCosto, 
    ArticuloCostoProm, 
    ArticuloStatus, 
    UnidadId, 
    UnidadIdAnt,
    ArticuloConvertible, 
    ArticuloSiItbis, 
    DepartamentoId, 
    ArticuloInventario, 
    ArticuloSiItbisincluido, 
    ArticuloFabricado, 
    ArticuloCostoCodigo, 
    ArticuloSiKit, 
    ArticuloGanancia2, 
    ArticuloGananciaMinima, 
    ArticuloSiVencimiento, 
    ArticuloSiComanda, 
    ArticuloIdArt, 
    ArticuloImgRuta, 
    ArticuloSiFactNegativo, 
    ArticuloSiGuarnicion, 
    ArticuloSiPeso, 
    ArticuloExistencia)
{
    this.ArticuloId = ArticuloId;
    this.ArticuloCd = ArticuloCd;
    this.ArticuloPartNo = ArticuloPartNo;
    this.ArticuloDesc = ArticuloDesc;
    this.MarcaId = MarcaId;
    this.ModeloId = ModeloId;
    this.ArticuloCosto = ArticuloCosto;
    this.ArticuloCostoProm = ArticuloCostoProm;
    this.ArticuloStatus = ArticuloStatus;
    this.UnidadId = UnidadId;
    this.UnidadIdAnt = UnidadIdAnt;
    this.ArticuloConvertible = ArticuloConvertible;
    this.ArticuloSiItbis = ArticuloSiItbis;
    this.DepartamentoId = DepartamentoId;
    this.ArticuloInventario = ArticuloInventario;
    this.ArticuloSiItbisincluido = ArticuloSiItbisincluido;
    this.ArticuloFabricado = ArticuloFabricado;
    this.ArticuloCostoCodigo = ArticuloCostoCodigo;
    this.ArticuloSiKit = ArticuloSiKit;
    this.ArticuloGanancia2 = ArticuloGanancia2;
    this.ArticuloGananciaMinima = ArticuloGananciaMinima;
    this.ArticuloSiVencimiento = ArticuloSiVencimiento;
    this.ArticuloSiComanda = ArticuloSiComanda;
    this.ArticuloIdArt = ArticuloIdArt;
    this.ArticuloImgRuta = ArticuloImgRuta;
    this.ArticuloSiFactNegativo = ArticuloSiFactNegativo;
    this.ArticuloSiGuarnicion = ArticuloSiGuarnicion;
    this.ArticuloSiPeso = ArticuloSiPeso;
    this.ArticuloExistencia = ArticuloExistencia;
}
function MantArticulo(ventana, articuloId,codigoArt, noParte, descripcionArt, departamento, modelo, marca, unidad, ganMin,
    existencia, costoUltimo, costoProm,costoItbis, costoCodigo, imgArt, activo, inventario, itbis, itbisIncluido, fabricado, 
    convertible, kitMenu, vencimiento, comanda, factNegativo, guarnicion, ventaPeso
) {
    this.ventana = $(ventana);
    this.articuloId = $(articuloId);
    this.codigoArt = $(codigoArt);
    this.noParte = $(noParte);
    this.descripcionArt = $(descripcionArt);
    this.departamento = $(departamento);
    this.modelo = $(modelo);
    this.marca = $(marca);
    this.unidad = $(unidad);
    this.ganMin = $(ganMin);
    this.existencia = $(existencia);
    this.costoUltimo = $(costoUltimo);
    this.costoProm = $(costoProm);
    this.costoItbis = $(costoItbis);
    this.costoCodigo = $(costoCodigo);
    this.imgArt = $(imgArt);
    this.activo = $(activo);
    this.inventario = $(inventario);
    this.itbis = $(itbis);
    this.itbisIncluido = $(itbisIncluido);
    this.fabricado = $(fabricado);
    this.convertible = $(convertible);
    this.kitMenu = $(kitMenu);
    this.vencimiento = $(vencimiento);
    this.comanda = $(comanda);
    this.factNegativo = $(factNegativo);
    this.guarnicion = $(guarnicion);
    this.ventaPeso = $(ventaPeso);

    this.Init = function () {
        self.ventana.on('shown.bs.modal', function (e) {
            self.descripcionArt.focus();
            self.descripcionArt.select();
        });
        
        self.ventana.on('hidden.bs.modal', function (e) {
            self.InicializarComponentes();
        });

        $("input,select").keypress(function (e) {
            var keycode = (event.keyCode ? event.keyCode : event.which);
            var sigfocus = $(this).data('sigfocus');
            if (keycode == '13') {
                $("#"+sigfocus).focus();
                return false;
            }
        });
        $("#txtDescripcionFiltro").keypress(function (e) {
            var keycode = (event.keyCode ? event.keyCode : event.which);
            var sigfocus = $(this).data('sigfocus');
            if (keycode == '13') {
                ActualizarFiltro();
                return false;
            }
        });

        self.BuscarDepartamentos();
        self.BuscarModelo();
        self.BuscarMarca();
        self.BuscarUnidad();
        // self.BuscarCondicionesPagos();
        // self.BuscarPrecio();

        self.InicializarComponentes();

        
        const drEvent = self.imgArt.dropify({
            messages: {
                'default': 'Arrastre y suelte un archivo aquí o haga clic',
                'replace': 'Arrastra y suelta o haz clic para reemplazar',
                'remove':  'Eliminar',
                'error':   'Ups, algo malo pasó.'
            }
        });

        drEvent.on('dropify.afterClear', function (event, element) {
            self.QuitarImagenUsuario();
        });

        
    }

    this.InicializarComponentes = function () {
        $(ventana+" input").each(function (e) {
            if ($(this).hasClass('is-invalid')) {
                $(this).removeClass('is-invalid');
            }
            $(this).val(""); 
        });
        $(ventana+" select").each(function (e) {
            if ($(this).hasClass('is-invalid')) {
                $(this).removeClass('is-invalid');
            }
            $(this).val("0"); 
        });

        self.articuloId.val("0");
        self.noParte.val("-");
        self.activo.prop('checked', true);
        self.inventario.prop('checked', true);
        self.itbis.prop('checked', true);
        self.itbisIncluido.prop('checked', true);
        self.factNegativo.prop('checked', true);
        
        self.fabricado.prop('checked', false);
        self.convertible.prop('checked', false);
        self.kitMenu.prop('checked', false);
        self.vencimiento.prop('checked', false);
        self.comanda.prop('checked', false);
        self.guarnicion.prop('checked', false);
        self.ventaPeso.prop('checked', true);

        

        self.existencia.removeAttr('disabled');
        self.costoUltimo.removeAttr('disabled');
        self.fabricado.removeAttr('disabled');
        self.convertible.removeAttr('disabled');

        $("#ingredientes-tab").parent().addClass('oculto');

        self.BuscarArticuloKit();

        $("#cmbIngredientes").val(null).trigger('change');
        $("#txtCantidadIngred").val('');
        $("#txtUnidadIngred").val('');
        
        $("#myTab1 .nav-link").removeClass('active');
        $("#precios-tab").addClass('active');

        $(".tab-content .tab-pane").removeClass('active');
        $(".tab-content .tab-pane").removeClass('show');
        $("#precios").addClass('active');
        $("#precios").addClass('show');
    }
    this.BuscarDepartamentos = function () {
        GetAjax("Departamentos", "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<option value="0"></option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.departamentoId + '">' + currentValue.departamentoDesc + '</option>'
            });
            self.departamento.html(dataHtml);
        });
    }
    this.BuscarModelo = function () {
        GetAjax("Modelos", "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<option value="0"></option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option  value="' + currentValue.modeloId + '">' + currentValue.modeloDesc + '</option>'
            });
            self.modelo.html(dataHtml);
        });
    }
    this.BuscarMarca = function () {
        GetAjax("Marcas", "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<option value="0"></option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.marcaId + '">' + currentValue.marcaDesc + '</option>'
            });
            self.marca.html(dataHtml);
        });
    }
    this.BuscarUnidad = function () {
        GetAjax("Unidades", "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<option value="0"></option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.unidadId + '">' + currentValue.unidadDesc + '</option>'
            });
            self.unidad.html(dataHtml);
        });
    }
    this.BuscarUnidadMedidas = function (articuloId) {
        GetAjax("UnidadesMedidas/"+articuloId, "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<option value="0"></option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.unidadId + '">' + currentValue.unidadDesc + '</option>'
            });
            $("#cmbUnidadMedida").html(dataHtml);
        });
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
    this.BuscarPreciosArticulo = function (articuloId) {
        $("#dataTable-precios tbody").html("");
        PostAjax("PreciosArticulo/"+articuloId,"json",'POST', '', function (data) {
        //GetAjax("PreciosArticulo/"+articuloId, "json", "", function (data) {
            let dataHtml = '';

            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + `<tr>
                                        <td>${currentValue.precioNo}</td>
                                        <td>
                                            <input type="number" onchange="mantArticulo.CambiarPrecio(this)" data-precioid="${currentValue.precioId}" data-sigfocus="txtGanancia${currentValue.precioId}" id="txtPrecio${currentValue.precioId}" placeholder="" value="${currentValue.precioMonto}" class="form-control">
                                        </td>
                                        <td>
                                            <input type="number" onchange="mantArticulo.CambiarPrecio(this)" data-precioid="${currentValue.precioId}" data-sigfocus="txtComision${currentValue.precioId}" id="txtGanancia${currentValue.precioId}" placeholder="" value="${currentValue.precioGanancia}" class="form-control">
                                        </td>
                                        <td>
                                            <input type="number" onchange="mantArticulo.CambiarPrecio(this)" data-precioid="${currentValue.precioId}" data-sigfocus="txtCodigo${currentValue.precioId}" id="txtComision${currentValue.precioId}" placeholder="" value="${currentValue.precioComision}" class="form-control">
                                        </td>
                                        <td>
                                            <input type="text" onchange="mantArticulo.CambiarPrecio(this)" data-sigfocus="cmbDepartamento" data-precioid="${currentValue.precioId}"  id="txtCodigo${currentValue.precioId}" placeholder="" value="${currentValue.precioCodigo}" class="form-control">
                                        </td>
                                    </tr>`
            });
            $("#dataTable-precios tbody").html(dataHtml);
        });
    }
    this.BuscarAlmacenesArticulo = function (articuloId) {
        $("#dataTable-almacen tbody").html("");
        GetAjax("AlmacenesArticulo/"+articuloId, "json", "", function (data) {
            let dataHtml = '';

            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + `<tr>
                                        <td>${currentValue.almadenDesc}</td>
                                        <td>
                                            ${currentValue.existencia}
                                        </td>
                                        <td>
                                            <input type="text" onchange="mantArticulo.ActualizaArticuloAlmacen(this)"  data-sigfocus="cmbDepartamento" data-almacenid="${currentValue.almadenId}" id="txtUbicacionArt${currentValue.almadenId}" placeholder="" value="${currentValue.ubicacion}" class="form-control">
                                        </td>
                                        <td>
                                            <input type="number" onchange="mantArticulo.ActualizaArticuloAlmacen(this)"  data-sigfocus="cmbDepartamento" data-almacenid="${currentValue.almadenId}"  id="txtCantMaxArt${currentValue.almadenId}" placeholder="" value="${currentValue.cantMaxima}" class="form-control">
                                      
                                        </td>
                                        <td>
                                            <input type="number" onchange="mantArticulo.ActualizaArticuloAlmacen(this)"  data-sigfocus="cmbDepartamento" data-almacenid="${currentValue.almadenId}"  id="txtCantMinArt${currentValue.almadenId}" placeholder="" value="${currentValue.cantMinima}" class="form-control">

                                        </td>
                                    </tr>`
            });
            $("#dataTable-almacen tbody").html(dataHtml);
        });
    }
    this.BuscarUnidadesArticulo = function (articuloId) {
        $("dataTable-unidades tbody").html("");
        GetAjax("UnidadesMedidaArticulo/"+articuloId, "json", "", function (data) {
            let dataHtml = '';

            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + `<tr>
                                        <td>${currentValue.unidadDesc}</td>
                                        <td>
                                            ${currentValue.cantidad}
                                        </td>
                                        <td>
                                            ${currentValue.ratio}
                                        </td>
                                    </tr>`
            });
            $("#dataTable-unidades tbody").html(dataHtml);
        });
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
            $("#dataTable-compras tbody").html(dataHtml);
        });
    }
    this.BuscarArticuloKit = function() {
        $("#dataTable-ingredientes tbody").html("");
        GetAjax("ArticulosKit/"+self.articuloId.val(), "json", "", function (data) {
            let dataHtml = '';

            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + `<tr>
                                        <td>${currentValue.articuloCd}</td>
                                        <td>
                                            ${currentValue.articuloDesc}
                                        </td>
                                        <td>
                                        ${currentValue.unidadDesc}
                                        </td>
                                        <td>
                                        ${currentValue.cantidad}
                                      
                                        </td>
                                        <td>
                                        <button type="button" data-articulokitid=${currentValue.articuloKitId}  onclick="mantArticulo.BorrarIngrediente(this)" class="btn btn-danger btn-sm btn-action-mjp btn-action-borrar" ><i class="fa fa-trash-o"></i> </button>
                                        </td>
                                    </tr>`
            });
            $("#dataTable-ingredientes tbody").html(dataHtml);
        });
    }
    this.Guardar = function () {
        if (self.Validar() == true) {
            let unidadArtAnt="";
            if (parseInt(self.articuloId.val()) != 0){
                unidadArtAnt = self.unidad.data('unidadidant').toString();
            }
            
            DeshabilitarBottonCargar("#btnGuardar");
            let articulo = new articuloDTO(
                parseInt(self.articuloId.val()),
                self.codigoArt.val(),
                self.noParte.val(),
                self.descripcionArt.val(),
                parseInt(self.marca.val()),
                parseInt(self.modelo.val()),
                parseFloat(self.costoUltimo.val()),
                self.costoProm.val(),
                self.activo.prop('checked'),
                parseInt(self.unidad.val()),
                unidadArtAnt,
                self.convertible.prop('checked'),
                self.itbis.prop('checked'),
                parseInt(self.departamento.val()),
                self.inventario.prop('checked'),
                self.itbisIncluido.prop('checked'),
                self.fabricado.prop('checked'),
                self.costoCodigo.val(),
                self.kitMenu.prop('checked'),0,
                self.ganMin.val(),
                self.vencimiento.prop('checked'),
                self.comanda.prop('checked'),'','',
                self.factNegativo.prop('checked'),
                self.guarnicion.prop('checked'),
                self.ventaPeso.prop('checked'),
                self.existencia.val()
                //self.costoItbis.val(data.articuloPrecioNo);
                //self.costoItbis.val(data.articuloSiItbis);
            
            );
            let type = "";
            let url = "";
            if (parseInt(self.articuloId.val()) == 0){
                type = "POST";
                url = "Articulo"
            }
            else{
                type = "PUT"
                url = "Articulo"
            }
            PostAjax(url,"json",type, JSON.stringify(articulo), 
                function (param) {
                    HabilitarBottonCargar("#btnGuardar");
                    ActualizarFiltro();
                    var notification = new NotificationFx({
                        message: '<span class="icon icon-megaphone"></span><p text-aling="center">Registro guardado exitosamente.</p>',
                        layout: 'bar',
                        effect: 'slidetop',
                        type: 'success', // notice, warning or error
                        ttl : 2000,
                    });
        
                    // show the notification
                    notification.show();
                    if (parseInt(self.articuloId.val()) == 0) {
                        self.articuloId.val(param.articuloId);
                        self.unidad.data('unidadidant',self.unidad.val());
                        
                        self.BuscarPreciosArticulo(self.articuloId.val());
                        self.BuscarAlmacenesArticulo(self.articuloId.val());
                        self.BuscarComprasArticulo(self.articuloId.val());

                        
                        self.BuscarUnidadMedidas(self.articuloId.val());
                        self.BuscarUnidadesArticulo(self.articuloId.val());

                        self.existencia.attr('disabled','disabled');
                        self.costoUltimo.attr('disabled','disabled');
                        self.fabricado.attr('disabled','disabled');
                        self.convertible.attr('disabled','disabled');
                        
                        $("#myTab1 .nav-link").removeClass('active');
                        $("#precios-tab").addClass('active');

                        $(".tab-content .tab-pane").removeClass('active');
                        $(".tab-content .tab-pane").removeClass('show');
                        $("#precios").addClass('active');
                        $("#precios").addClass('show');

                        if (self.kitMenu.prop('checked')) {
                            $("#ingredientes-tab").parent().removeClass('oculto');
                            
                            self.BuscarArticulosIngredientes();
                            self.BuscarArticuloKit();
                        }
                        else {
                            
                            $("#ingredientes-tab").parent().addClass('oculto');
                        }

                        $("#detalle-articulo").removeClass('oculto');
                    }
                    else {
                        self.ventana.modal('hide');
                    }
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
    this.Cancelar = function () {
        self.ventana.modal('hide');
        return false;
    }
    this.NuevoArticulo = function () {
        $("#detalle-articulo").addClass('oculto');
        GetAjax("UltimoArticulo", "json", "", function (data) {
            self.codigoArt.val(data);
        });
        return false;
    }
    this.Editar = function(id) {
        self.articuloId.val(id);
        GetAjax("Articulo/"+id, "json", "", function (data) {
            if (data != null){
                self.codigoArt.val(data.articuloCd);
                self.noParte.val(data.articuloPartNo);
                self.descripcionArt.val(data.articuloDesc);
                self.departamento.val(data.departamentoId);
                self.modelo.val(data.modeloId);
                self.marca.val(data.marcaId);
                self.unidad.val(data.unidadId);
                self.unidad.data('unidadidant',data.unidadId);
                self.ganMin.val(data.articuloGananciaMinima);
                self.existencia.val(data.articuloExistencia);
                self.costoUltimo.val(data.articuloCosto);
                self.costoProm.val(data.articuloCostoProm);
                //self.costoItbis.val(data.articuloPrecioNo);
                self.costoItbis.val(data.articuloSiItbis);
                self.costoCodigo.val(data.articuloCostoCodigo);
                self.activo.prop('checked', data.articuloStatus);
                self.inventario.prop('checked', data.articuloInventario);
                self.itbis.prop('checked', data.articuloSiItbis);
                self.itbisIncluido.prop('checked', data.articuloSiItbisincluido);
                self.fabricado.prop('checked', data.articuloFabricado);
                self.convertible.prop('checked', data.articuloConvertible);
                self.kitMenu.prop('checked', data.articuloSiKit);
                self.vencimiento.prop('checked', data.articuloSiVencimiento);
                self.comanda.prop('checked', data.articuloSiComanda);
                self.factNegativo.prop('checked', data.articuloSiFactNegativo);
                self.guarnicion.prop('checked', data.articuloSiGuarnicion);
                self.ventaPeso.prop('checked', data.articuloSiPeso);

                self.BuscarPreciosArticulo(self.articuloId.val());
                self.BuscarAlmacenesArticulo(self.articuloId.val());
                self.BuscarComprasArticulo(self.articuloId.val());
                self.BuscarUnidadMedidas(self.articuloId.val());
                self.BuscarUnidadesArticulo(self.articuloId.val());

                self.existencia.attr('disabled','disabled');
                self.costoUltimo.attr('disabled','disabled');
                self.fabricado.attr('disabled','disabled');
                self.convertible.attr('disabled','disabled');
                
                $("#myTab1 .nav-link").removeClass('active');
                $("#precios-tab").addClass('active');

                $(".tab-content .tab-pane").removeClass('active');
                $(".tab-content .tab-pane").removeClass('show');
                $("#precios").addClass('active');
                $("#precios").addClass('show');

                if (self.kitMenu.prop('checked')) {
                    $("#ingredientes-tab").parent().removeClass('oculto');
                    self.BuscarArticulosIngredientes();
                    self.BuscarArticuloKit();
                }
                else {
                    
                    $("#ingredientes-tab").parent().addClass('oculto');
                }

                if (self.inventario.prop('checked')){
                }

                $("#detalle-articulo").removeClass('oculto');
            }
            self.ventana.modal('show');
        });
    }
    this.HabilitaIngredientes = function() {
        
        if (self.kitMenu.prop('checked')) {
            $("#ingredientes-tab").parent().removeClass('oculto');
            self.BuscarArticulosIngredientes();
            self.BuscarArticuloKit();
        }
        else {
            
            $("#ingredientes-tab").parent().addClass('oculto');
        }
    }
    this.CambiarPrecio = function(ele) {
        let precioId = $(ele).data('precioid');

        let precioArticulo = {
            "precioId" : precioId,
            "precioMonto" : $("#txtPrecio"+precioId).val(),
            "precioGanancia" : parseFloat($("#txtGanancia"+precioId).val()),
            "precioComision" : parseFloat($("#txtComision"+precioId).val()),
            "precioCodigo" : $("#txtCodigo"+precioId).val()
        }

        PostAjax("CambiarPrecioArticulo", "json", "POST", JSON.stringify(precioArticulo),
            function (param) {
                
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
    
    this.ActualizaArticuloAlmacen = function(ele) {
        let almacenId = $(ele).data('almacenid');

        let precioArticulo = {
            "almadenId" : almacenId,
            "articuloId" : parseInt(self.articuloId.val()),
            "almadenDesc" : "",
            "ubicacion" : $("#txtUbicacionArt"+almacenId).val(),
            "cantMaxima" : parseFloat($("#txtCantMaxArt"+almacenId).val()),
            "cantMinima" : parseFloat($("#txtCantMinArt"+almacenId).val())
        }

        PostAjax("ActualizaArticuloAlmacen", "json", "POST", JSON.stringify(precioArticulo),
            function (param) {
                
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
    this.Borrar = function(ele) {
        let id = $(ele).data('articuloid');
        let nombre = $(ele).data('articulonombre');
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
            }).then(function(respuesta) {
                if (respuesta.value){
                    PostAjax("Articulo/"+id,"json","Delete", "", 
                        function (param) {
                            swalWithBootstrapButtons.fire(
                                'Registro Borrado',
                                'Registro ha sido borrado exitosamente.',
                                'success'
                            );
                            
                            ActualizarFiltro();
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
                            
                            self.BuscarArticuloKit();
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
    this.Validar = function() {
        let result = true;
        if (self.codigoArt.val() == ""){
            self.codigoArt.addClass('is-invalid');
            self.codigoArt.focus();
            result = false;
        }else{
            self.codigoArt.removeClass('is-invalid');
        }
        if (self.noParte.val() == ""){
            self.noParte.addClass('is-invalid');
            self.noParte.focus();
            result = false;
        }else{
            self.noParte.removeClass('is-invalid');
        }
        
        if (self.descripcionArt.val() == ""){
            self.descripcionArt.addClass('is-invalid');
            self.descripcionArt.focus();
            result = false;
        }else{
            self.descripcionArt.removeClass('is-invalid');
        }
        if (self.departamento.val() == "0"){
            self.departamento.addClass('is-invalid');
            self.departamento.focus();
            result = false;
        }else{
            self.departamento.removeClass('is-invalid');
        }
        if (self.modelo.val() == "0"){
            self.modelo.addClass('is-invalid');
            self.modelo.focus();
            result = false;
        }else{
            self.modelo.removeClass('is-invalid');
        }
        if (self.marca.val() == "0"){
            self.marca.addClass('is-invalid');
            self.marca.focus();
            result = false;
        }else{
            self.marca.removeClass('is-invalid');
        }
        if (self.unidad.val() == "0"){
            self.unidad.addClass('is-invalid');
            self.unidad.focus();
            result = false;
        }else{
            self.unidad.removeClass('is-invalid');
        }
        if (self.ganMin.val() == ""){
            self.ganMin.val("0");
        }
        if (self.existencia.val() == ""){
            self.existencia.val("0");
        }
        if (self.costoProm.val() == ""){
            self.costoProm.val("0");
        }
        if (self.costoUltimo.val() == ""){
            self.costoUltimo.val("0");
        }
        return result;
    }
    this.CambiarImagenUsuario = function (ele) {
        let fileUpload = $(ele).get(0);
        let files = fileUpload.files;
        let formData = new FormData();
        formData.append('file', files[0]);

        $.ajax({
            url: 'UploadImagUser',
            type: 'POST',
            headers: {
                'Authorization': 'Bearer ' + sessionStorage.getItem('UserTokenProbeta')
            },
            data: formData,
            processData: false,
            contentType: false,
            success: function (result) {

                sessionStorage.setItem('dp_user_img', result.image);
                $(".user-img").attr('src', 'dist/img/users/' + sessionStorage.getItem('dp_user_img'))
            }
        });
    }

    this.QuitarImagenUsuario = function () {

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
            "articuloIdPadre" : parseInt(self.articuloId.val()),
            "articuloIdHijo" : parseInt($("#cmbIngredientes").val()),
            "unidadId" : parseInt($("#cmbUnidadIngred").val()),
            "cantidad" : parseFloat($("#txtCantidadIngred").val())
        }

        PostAjax("ArticuloKit", "json", "POST", JSON.stringify(articuloKit),
            function (param) {
                $("#cmbIngredientes").val(null).trigger('change');
                $("#txtCantidadIngred").val('');
                $("#txtUnidadIngred").val('');
                self.BuscarArticuloKit();
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
    this.AgregarUnidad = function() {
        if ($("#cmbUnidadMedida").val() == null || $("#cmbUnidadMedida").val() == ""){
            $("#cmbUnidadMedida").addClass('is-invalid');
            $("#cmbUnidadMedida").focus();
            return false;
        }else{
            $("#cmbUnidadMedida").removeClass('is-invalid');
        }
        
        if ($("#txtRatio").val() == "" || $("#txtRatio").val() == "0"){
            $("#txtRatio").addClass('is-invalid');
            $("#txtRatio").focus();
            return false;
        }else{
            $("#txtRatio").removeClass('is-invalid');
        }

        let articuloUnidad = {
            "unidadId" : parseInt($("#cmbUnidadMedida").val()), 
            "articuloId" : parseInt(self.articuloId.val()),
            "ratio" : parseFloat($("#txtRatio").val())
        }

        PostAjax("UnidadArticulo", "json", "POST", JSON.stringify(articuloUnidad),
            function (param) {
                $("#cmbUnidadMedida").val('0')
                $("#txtRatio").val('');
                self.BuscarUnidadesArticulo(self.articuloId.val());
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

    let self = this;
}


const mantArticulo = new MantArticulo("#mant-articulo","#txtArticuloId", "#txtCodigoArt",
    "#txtNoParte",
    "#txtDescripcion",
    "#cmbDepartamento",
    "#cmbModelo",
    "#cmbMarca",
    "#cmbUnidad",
    "#txtGanMin",
    "#txtExistencia",
    "#txtCostoUltimo",
    "#txtCostoPromedio",
    "#txtCostoItbis",
    "#txtCostoCódigo",
    "#input-img-art",
    "#chkActivo",
    "#chkInventario",
    "#chkItbis",
    "#chkItbisIncluido",
    "#chkFabricado",
    "#chkConvertible",
    "#chkKitMenu",
    "#chkVencimiento",
    "#chkComanda",
    "#chkFactNegativo",
    "#chkGuarnicion",
    "#chkVentaPeso"
);
mantArticulo.Init();

