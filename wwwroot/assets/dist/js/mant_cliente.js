function clienteDTO(ClienteId, ClienteCodigo, 
    ClienteNombre, 
    ClienteDir1, 
    ClienteDir2, 
    ClienteCedula, 
    ClienteTel, 
    ClienteFax, 
    ClienteEmail, 
    ClienteDescto, 
    ClienteBalance, 
    CondPagoId, 
    ClienteStatus, 
    ClienteContacto, 
    ClienteAutCredito, 
    ClienteLimiteCredito, 
    ClienteTipoId, 
    VendedorId, 
    ComprobanteTipoId, 
    ClienteSiRetieneIsr, 
    ClientePrecioNo, 
    ClienteTotalPuntos, 
    ClienteComentario, 
    PlanId)
{
    this.ClienteId = ClienteId;
    this.ClienteCodigo = ClienteCodigo;
    this.ClienteNombre = ClienteNombre;
    this.ClienteDir1 = ClienteDir1;
    this.ClienteDir2 = ClienteDir2;
    this.ClienteCedula = ClienteCedula;
    this.ClienteTel = ClienteTel;
    this.ClienteFax = ClienteFax;
    this.ClienteEmail = ClienteEmail;
    this.ClienteDescto = ClienteDescto;
    this.ClienteBalance = ClienteBalance;
    this.CondPagoId = CondPagoId;
    this.ClienteStatus = ClienteStatus;
    this.ClienteContacto = ClienteContacto;
    this.ClienteAutCredito = ClienteAutCredito;
    this.ClienteLimiteCredito = ClienteLimiteCredito;
    this.ClienteTipoId = ClienteTipoId;
    this.VendedorId = VendedorId;
    this.ComprobanteTipoId = ComprobanteTipoId;
    this.ClienteSiRetieneIsr = ClienteSiRetieneIsr;
    this.ClientePrecioNo = ClientePrecioNo;
    this.ClienteTotalPuntos = ClienteTotalPuntos;
    this.ClienteComentario = ClienteComentario;
    this.PlanId = PlanId;
}
function MantCliente(ventana, clienteId,nombre, direccion, cedula, telefono, email, contacto, tipoCliente, vendedor,
    tipoComprobante, plan, precio,condicion, limiteCredito, comentario, activo
) {
    this.ventana = $(ventana);
    this.clienteId = $(clienteId);
    this.nombre = $(nombre);
    this.direccion = $(direccion);
    this.cedula = $(cedula);
    this.telefono = $(telefono);
    this.email = $(email);
    this.contacto = $(contacto);
    this.tipoCliente = $(tipoCliente);
    this.vendedor = $(vendedor);
    this.tipoComprobante = $(tipoComprobante);
    this.plan = $(plan);
    this.precio = $(precio);
    this.condicion = $(condicion);
    this.limiteCredito = $(limiteCredito);
    this.comentario = $(comentario);
    this.activo = $(activo);

    this.Init = function () {
        self.ventana.on('shown.bs.modal', function (e) {
            self.nombre.focus();
            self.nombre.select();
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

        CampoNumero(limiteCredito);
        CampoCedula(cedula);
        CampoCedula(telefono);

        self.BuscarClienteTipos();
        self.BuscarVendedor();
        self.BuscarComprobante();
        self.BuscarPlan();
        self.BuscarCondicionesPagos();
        self.BuscarPrecio();

        self.InicializarComponentes();
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

        self.precio.val($(precio+" option:eq(0)").attr('value'));
        self.condicion.val($(condicion+" option:eq(0)").attr('value'));
        self.clienteId.val("0");
        self.activo.prop('checked', true);
    }
    this.BuscarClienteTipos = function () {
        GetAjax("ClienteTipo", "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<option value="0"></option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.clienteTipoId + '">' + currentValue.clienteTipoDesc + '</option>'
            });
            self.tipoCliente.html(dataHtml);
        });
    }
    this.BuscarCondicionesPagos = function () {
        GetAjax("CondicionesPago", "json", "", function (data) {
            let dataHtml = '';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option data-cantdias="' + currentValue.condPagoDias + '" value="' + currentValue.condPagoId + '">' + currentValue.condPagoDesc + '</option>'
            });
            self.condicion.html(dataHtml);
        });
    }
    this.BuscarPlan = function () {
        GetAjax("Planes", "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<option value="0"></option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.planId + '">' + currentValue.planDesc + '</option>'
            });
            $("#mant-cliente " + plan).html(dataHtml);
        });
    }
    this.BuscarPrecio = function () {
        GetAjax("Precios", "json", "", function (data) {
            let dataHtml = '';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.precioId + '">' + currentValue.precioDesc + '</option>'
            });
            self.precio.html(dataHtml);
        });
    }
    this.BuscarVendedor = function () {
        GetAjax("Vendedor", "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<option value="0"></option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.vendedorId + '">' + currentValue.vendedorNombre + '</option>'
            });
            self.vendedor.html(dataHtml);
            //self.vendedor.val(null).trigger('change');
            /*self.vendedor.select2({
                allowClear: true,
                placeholder: "",
                language: "es"
            });
            self.vendedor.val([0]).trigger('change');*/
        });
    }
    this.BuscarComprobante = function () {
        GetAjax("ComprobanteTipo", "json", "", function (data) {
            let dataHtml = '';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.comprobanteTipoId + '">' + currentValue.comprobanteDesc + '</option>'
            });
            self.tipoComprobante.html(dataHtml);
        });
    }
    this.CambioCondicionPago = function (el) {
        let cantDias = parseInt($(condicion + " option[value='" + $(el).val() + "']").data('cantdias'));
        if (cantDias > 0) {
            self.limiteCredito.parent().removeClass('oculto');
        } else {
            self.limiteCredito.parent().addClass('oculto');
        }
    }
    this.ConsultarRncDgi = function () {
        if (self.cedula.val() != "") {
            DeshabilitarBottonCargar("#btnConsultarDGI");
            GetAjax("ConsultarRNC/"+self.cedula.val(), "json", "", function (data) {
                if (data != null){
                    self.nombre.val(data.clienteNombre);
                    self.direccion.val(data.clienteDireccion1);
                    self.telefono.val(data.clienteTelefono);
                }
                HabilitarBottonCargar("#btnConsultarDGI");
            });
        }
        return false;
    }
    this.Guardar = function () {
        if (self.Validar() == true) {
            DeshabilitarBottonCargar("#btnGuardar");
            let cliente = new clienteDTO(
                parseInt(self.clienteId.val()),
                "",self.nombre.val(),
                self.direccion.val(),
                "",
                self.cedula.val(),
                self.telefono.val(),"",
                self.email.val(),0,0,
                parseInt(self.condicion.val()),
                self.activo.prop('checked'),
                self.contacto.val(),false,
                self.limiteCredito.val() != "" ? parseFloat(self.limiteCredito.val()) : 0,
                parseInt(self.tipoCliente.val()),
                parseInt(self.vendedor.val()),
                parseInt(self.tipoComprobante.val()),
                false,
                parseInt(self.precio.val()),0,
                self.comentario.val(),
                parseInt($("#mant-cliente " + plan).val())
            );
            let type = "";
            let url = "";
            if (parseInt(self.clienteId.val()) == 0){
                type = "POST";
                url = "Cliente"
            }
            else{
                type = "PUT"
                url = "Cliente"
            }
            PostAjax(url,"json",type, JSON.stringify(cliente), 
                function (param) {
                    HabilitarBottonCargar("#btnGuardar");
                    if ($("#add-reserva").length == 1){
                        $("#cmbCliente").val([param.clienteId]).trigger('change');
                    }
                    else{
                        table.ajax.reload();
                    }
                    self.ventana.modal('hide');
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
    this.Editar = function(id) {
        self.clienteId.val(id);
        GetAjax("Cliente/"+id, "json", "", function (data) {
            if (data != null){
                self.nombre.val(data.clienteNombre);
                self.direccion.val(data.clienteDir1);
                self.telefono.val(data.clienteTel);
                self.cedula.val(data.clienteCedula);
                self.email.val(data.clienteEmail);
                self.contacto.val(data.clienteContacto);
                self.tipoCliente.val(data.clienteTipoId);
                self.vendedor.val(data.vendedorId);
                self.tipoComprobante.val(data.comprobanteTipoId);
                $("#mant-cliente " + plan).val(data.planId);
                self.precio.val(data.clientePrecioNo);
                self.condicion.val(data.condPagoId);
                self.condicion.change();
                self.limiteCredito.val(data.clienteLimiteCredito);
                self.comentario.val(data.clienteComentario);
                self.activo.prop('checked',data.clienteStatus);
            }
            self.ventana.modal('show');
        });
    }
    this.Borrar = function(ele) {
        let id = $(ele).data('clienteid');
        let nombre = $(ele).data('clientenombre');
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
                    PostAjax("Cliente/"+id,"json","Delete", "", 
                        function (param) {
                            swalWithBootstrapButtons.fire(
                                'Registro Borrado',
                                'Registro ha sido borrado exitosamente.',
                                'success'
                            );
                            
                            table.ajax.reload();
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
        if (self.nombre.val() == ""){
            self.nombre.addClass('is-invalid');
            self.nombre.focus();
            result = false;
        }else{
            self.nombre.removeClass('is-invalid');
        }
        if (self.email.val() != "") {
            if (!IsEmail(self.email.val())){
                self.email.addClass('is-invalid');
                self.email.focus();
                result = false;
            }else{
                self.email.removeClass('is-invalid');
            }
        }
        if (self.cedula.val() == ""){
            self.cedula.addClass('is-invalid');
            self.cedula.focus();
            result = false;
        }else{
            self.cedula.removeClass('is-invalid');
        }
        if (self.tipoCliente.val() == "0"){
            self.tipoCliente.addClass('is-invalid');
            self.tipoCliente.focus();
            result = false;
        }else{
            self.tipoCliente.removeClass('is-invalid');
        }
        if (self.vendedor.val() == "0"){
            self.vendedor.addClass('is-invalid');
            self.vendedor.focus();
            result = false;
        }else{
            self.vendedor.removeClass('is-invalid');
        }
        if (self.condicion.val() == "0"){
            self.condicion.addClass('is-invalid');
            self.condicion.focus();
            result = false;
        }else{
            self.condicion.removeClass('is-invalid');
        }
        return result;
    }

    let self = this;
}

const mantCliente = new MantCliente("#mant-cliente","#txtClienteId", "#txtClienteNombre",
    "#txtClienteDireccion",
    "#txtClienteCedula",
    "#txtClienteTelefono",
    "#txtClienteEmail",
    "#txtContacto",
    "#cmbTipoCliente",
    "#cmbVendedor",
    "#cmbTipoComprobante",
    "#cmbPlan",
    "#cmbPrecio",
    "#cmbCondicionPago",
    "#txtLimiteCredito",
    "#txtComentario",
    "#chkActivo"
);
mantCliente.Init();

