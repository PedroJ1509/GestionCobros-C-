function tipoHospedajeDTO(TipoHospedajeId, TipoHospedajeDesc,TipoHospedajeOcupacion, 
    TipoHospedajeEstatus)
{
    this.TipoHospedajeId = TipoHospedajeId;
    this.TipoHospedajeDesc = TipoHospedajeDesc;
    this.TipoHospedajeOcupacion = TipoHospedajeOcupacion;
    this.TipoHospedajeEstatus = TipoHospedajeEstatus;
}

function TipoHospedaje(ventana,tipoHospedajeId,descripcion,ocupacion,activo) {
    this.ventana = $(ventana);
    this.tipoHospedajeId = $(tipoHospedajeId);
    this.descripcion = $(descripcion);
    this.ocupacion = $(ocupacion);
    this.activo = $(activo);

    this.Init = function () {

        self.ventana.on('shown.bs.modal', function (e) {
            self.descripcion.focus();
            self.descripcion.select();
        });
        self.ventana.on('hidden.bs.modal', function (e) {
            self.InicializarComponentes();
        });
        self.activo.prop('checked', true);
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

        self.tipoHospedajeId.val("0");
        self.activo.prop('checked', true);
    }
    this.Validar = function() {
        let result = true;
        if (self.descripcion.val() == ""){
            self.descripcion.addClass('is-invalid');
            self.descripcion.focus();
            result = false;
        }else{
            self.descripcion.removeClass('is-invalid');
        }
        if (self.ocupacion.val() == ""){
            self.ocupacion.addClass('is-invalid');
            self.ocupacion.focus();
            result = false;
        }else{
            self.ocupacion.removeClass('is-invalid');
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
            let TipoHospedaje = new tipoHospedajeDTO(
                parseInt(self.tipoHospedajeId.val()),
                self.descripcion.val(),
                self.ocupacion.val(),
                self.activo.prop('checked')
            );
            let type = "";
            let url = "";
            if (parseInt(self.tipoHospedajeId.val()) == 0){
                type = "POST";
                url = "TipoHospedaje"
            }
            else{
                type = "PUT"
                url = "TipoHospedaje"
            }
            PostAjax(url,"json",type, JSON.stringify(TipoHospedaje), 
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
        self.tipoHospedajeId.val(id);
        GetAjax("TipoHospedaje/"+id, "json", "", function (data) {
            if (data != null){
                self.descripcion.val(data.tipoHospedajeDesc);
                self.ocupacion.val(data.tipoHospedajeOcupacion);
                self.activo.prop('checked',data.tipoHospedajeEstatus);
            }
            self.ventana.modal('show');
        });
    }
    this.Borrar = function(ele) {
        let id = $(ele).data('tipohospedajeid');
        let nombre = $(ele).data('tipohospedajedesc');
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
                    PostAjax("TipoHospedaje/"+id,"json","Delete", "", 
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

const mantTipoHospedaje = new TipoHospedaje("#formulario","#txtTipoHospedajeId", "#txtDescripcion","#txtOcupacion","#chkActivo");
mantTipoHospedaje.Init();
