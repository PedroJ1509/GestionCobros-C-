function usuarioDTO(UsuarioId, UsuarioDescId, 
    UsuarioPass,AutoridadId,UsuarioNombre,UsuarioSiCajero,AlmacenId,UsuarioSiReAbrirCompra,UsuarioSiAnularFactura,UsuarioSiReAbrirFactura,UsuarioSiModCredCliente
    ,UsuarioSiPreFactura,UsuarioSiFacCliSob,UsuarioSiFacFacVen,UsuarioSiImpuesto,UsuarioSiBorrarFactura,UsuarioNoCopiaFac,Activo)
{
    this.UsuarioId = UsuarioId;
    this.UsuarioDescId = UsuarioDescId;
    this.UsuarioPass = UsuarioPass;
    this.AutoridadId = AutoridadId;
    this.UsuarioNombre = UsuarioNombre;
    this.UsuarioSiCajero = UsuarioSiCajero;
    this.AlmacenId = AlmacenId;
    this.UsuarioSiReAbrirCompra = UsuarioSiReAbrirCompra;
    this.UsuarioSiAnularFactura = UsuarioSiAnularFactura;
    this.UsuarioSiReAbrirFactura = UsuarioSiReAbrirFactura;
    this.UsuarioSiModCredCliente = UsuarioSiModCredCliente;
    this.UsuarioSiPreFactura = UsuarioSiPreFactura;
    this.UsuarioSiFacCliSob = UsuarioSiFacCliSob;
    this.UsuarioSiFacFacVen = UsuarioSiFacFacVen;
    this.UsuarioSiImpuesto = UsuarioSiImpuesto;
    this.UsuarioSiBorrarFactura = UsuarioSiBorrarFactura;
    this.UsuarioNoCopiaFac = UsuarioNoCopiaFac;
    this.Activo = Activo;
}

function Usuario(ventana,usuarioId,usuarioDescId,usuarioClave,usuarioNombre,usuarioAutoridad,usuarioAlmacen,usuarioAnulaFactura,usuarioModCliCredito,usuarioFacCliSobre,
                usuarioBorraFactura,usuarioReabreCompra,usuarioReabreFActura,usuarioFactFacVen,usuarioCajero,usuarioPrefactura,usuarioImpuesto,activo) {
    this.ventana = $(ventana);
    this.usuarioId = $(usuarioId);
    this.usuarioDescId = $(usuarioDescId);
    this.usuarioClave = $(usuarioClave);
    this.usuarioNombre = $(usuarioNombre);
    this.usuarioAutoridad = $(usuarioAutoridad);
    this.usuarioAlmacen = $(usuarioAlmacen);
    this.usuarioAnulaFactura = $(usuarioAnulaFactura);
    this.usuarioModCliCredito = $(usuarioModCliCredito);
    this.usuarioFacCliSobre = $(usuarioFacCliSobre);
    this.usuarioBorraFactura = $(usuarioBorraFactura);
    this.usuarioReabreCompra = $(usuarioReabreCompra);
    this.usuarioReabreFActura = $(usuarioReabreFActura);
    this.usuarioFactFacVen = $(usuarioFactFacVen);
    this.usuarioCajero = $(usuarioCajero);
    this.usuarioPrefactura = $(usuarioPrefactura);
    this.usuarioImpuesto = $(usuarioImpuesto);
    this.activo = $(activo);

    this.Init = function () {

        self.ventana.on('shown.bs.modal', function (e) {
            self.usuarioNombre.focus();
            self.usuarioNombre.select();
        });
        self.ventana.on('hidden.bs.modal', function (e) {
            self.InicializarComponentes();
        });
        
        self.BuscarAutoridades();
        self.BuscarAmacenes();

        self.activo.prop('checked', true);
        self.usuarioAnulaFactura.prop('checked', false);
        self.usuarioModCliCredito.prop('checked', false);
        self.usuarioFacCliSobre.prop('checked', false);
        self.usuarioBorraFactura.prop('checked', false);
        self.usuarioReabreCompra.prop('checked', false);
        self.usuarioReabreFActura.prop('checked', false);
        self.usuarioFactFacVen.prop('checked', false);
        self.usuarioCajero.prop('checked', false);
        self.usuarioPrefactura.prop('checked', false);
        self.usuarioImpuesto.prop('checked', false);
    }
    this.BuscarAutoridades = function () {
        GetAjax("Autoridad", "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<option value="0"></option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.autoridadId + '">' + currentValue.autoridadDesc + '</option>'
            });
            self.usuarioAutoridad.html(dataHtml);
        });
    }
    this.BuscarAmacenes = function () {
        GetAjax("Almacen", "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<option value="0"></option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.almacenId + '">' + currentValue.almacenDesc + '</option>'
            });
            self.usuarioAlmacen.html(dataHtml);
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

        self.usuarioId.val("0");
        self.activo.prop('checked', true);
        self.usuarioAnulaFactura.prop('checked', false);
        self.usuarioModCliCredito.prop('checked', false);
        self.usuarioFacCliSobre.prop('checked', false);
        self.usuarioBorraFactura.prop('checked', false);
        self.usuarioReabreCompra.prop('checked', false);
        self.usuarioReabreFActura.prop('checked', false);
        self.usuarioFactFacVen.prop('checked', false);
        self.usuarioCajero.prop('checked', false);
        self.usuarioPrefactura.prop('checked', false);
        self.usuarioImpuesto.prop('checked', false);
    }
    this.Validar = function() {
        let result = true;
        if (self.usuarioDescId.val() == ""){
            self.usuarioDescId.addClass('is-invalid');
            self.usuarioDescId.focus();
            result = false;
        }else{
            self.usuarioDescId.removeClass('is-invalid');
        }
        if (self.usuarioClave.val() == ""){
            self.usuarioClave.addClass('is-invalid');
            self.usuarioClave.focus();
            result = false;
        }else{
            self.usuarioClave.removeClass('is-invalid');
        }
        if (self.usuarioNombre.val() == ""){
            self.usuarioNombre.addClass('is-invalid');
            self.usuarioNombre.focus();
            result = false;
        }else{
            self.usuarioNombre.removeClass('is-invalid');
        }
        if (self.usuarioAutoridad.val() == "0"){
            self.usuarioAutoridad.addClass('is-invalid');
            self.usuarioAutoridad.focus();
            result = false;
        }else{
            self.usuarioAutoridad.removeClass('is-invalid');
        }
        if (self.usuarioAlmacen.val() == "0"){
            self.usuarioAlmacen.addClass('is-invalid');
            self.usuarioAlmacen.focus();
            result = false;
        }else{
            self.usuarioAlmacen.removeClass('is-invalid');
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
            let usuario = new usuarioDTO(
                parseInt(self.usuarioId.val()),
                self.usuarioDescId.val(),
                self.usuarioClave.val(),
                parseInt(self.usuarioAutoridad.val()),
                self.usuarioNombre.val(),
                self.usuarioCajero.prop('checked'),
                parseInt(self.usuarioAlmacen.val()),
                self.usuarioReabreCompra.prop('checked'),
                self.usuarioAnulaFactura.prop('checked'),
                self.usuarioReabreFActura.prop('checked'),
                self.usuarioModCliCredito.prop('checked'),
                self.usuarioPrefactura.prop('checked'),
                self.usuarioFacCliSobre.prop('checked'),
                self.usuarioFactFacVen.prop('checked'),
                self.usuarioImpuesto.prop('checked'),
                self.usuarioBorraFactura.prop('checked'),
                0,
                self.activo.prop('checked')
            );
            let type = "";
            let url = "Usuario";
            if (parseInt(self.usuarioId.val()) == 0){
                type = "POST";
            }
            else{
                type = "PUT";
            }
            PostAjax(url,"json",type, JSON.stringify(usuario), 
                function (param) {
                    HabilitarBottonCargar("#btnGuardar");
                    table.ajax.reload();
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
    this.Editar = function(id) {
        self.usuarioId.val(id);
        GetAjax("Usuario/"+id, "json", "", function (data) {
            if (data != null){
                self.usuarioDescId.val(data.usuarioDescId);
                self.usuarioClave.val(data.usuarioPass);
                self.usuarioAutoridad.val(data.autoridadId);
                self.usuarioNombre.val(data.usuarioNombre);
                self.usuarioCajero.prop('checked',data.usuarioSiCajero);
                self.usuarioAlmacen.val(data.almacenId);
                self.usuarioReabreCompra.prop('checked',data.usuarioSiReAbrirCompra);
                self.usuarioAnulaFactura.prop('checked',data.usuarioSiAnularFactura);
                self.usuarioReabreFActura.prop('checked',data.usuarioSiReAbrirFactura);
                self.usuarioModCliCredito.prop('checked',data.usuarioSiModCredCliente);
                self.usuarioPrefactura.prop('checked',data.usuarioSiPreFactura);
                self.usuarioFacCliSobre.prop('checked',data.usuarioSiFacCliSob);
                self.usuarioFactFacVen.prop('checked',data.usuarioSiFacFacVen);
                self.usuarioImpuesto.prop('checked',data.usuarioSiImpuesto);
                self.usuarioBorraFactura.prop('checked',data.usuarioSiBorrarFactura);
                self.activo.prop('checked',data.activo);
            }
            self.ventana.modal('show');
        });
    }
    this.Borrar = function(ele) {
        let id = $(ele).data('usuarioid');
        let nombre = $(ele).data('usuarionombre');
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
                    PostAjax("Usuario/"+id,"json","Delete", "", 
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

    let self = this;
}

const mantUsuario = new Usuario("#formulario","#txtUsuarioId", "#txtCodigoUsuarioId","#txtClave","#txtNombre","#cmbAutoridad","#cmbAlmacen","#chkAnulaFactura","#chkModCredCliente","#chkFacCliSobre"
,"#chkBorrArtfactura","#chkReaCompra","#chkReabreFactura","#chkFacVencidas","#chkCajero","#chkPrefactura","#chkImpuesto","#chkActivo");
mantUsuario.Init();
