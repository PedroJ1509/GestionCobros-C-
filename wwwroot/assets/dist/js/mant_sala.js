function salaDTO(SalaId, SalaDesc, 
    SalaEstatus)
{
    this.SalaId = SalaId;
    this.SalaDesc = SalaDesc;
    this.SalaEstatus = SalaEstatus;
}

function Sala(ventana,salaId,descripcion,activo) {
    this.ventana = $(ventana);
    this.salaId = $(salaId);
    this.descripcion = $(descripcion);
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

        self.salaId.val("0");
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
        return result;
    }
    this.Cancelar = function () {
       
        self.ventana.modal('hide');
        return false;
    }
    this.Guardar = function () {
        if (self.Validar() == true) {
            DeshabilitarBottonCargar("#btnGuardar");
            let sala = new salaDTO(
                parseInt(self.salaId.val()),
                self.descripcion.val(),
                self.activo.prop('checked')
            );
            let type = "";
            let url = "Sala";
            if (parseInt(self.salaId.val()) == 0){
                type = "POST";
            }
            else{
                type = "PUT";
            }
            PostAjax(url,"json",type, JSON.stringify(sala), 
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
        self.salaId.val(id);
        GetAjax("Sala/"+id, "json", "", function (data) {
            if (data != null){
                self.descripcion.val(data.salaDesc);
                self.activo.prop('checked',data.salaEstatus);
            }
            self.ventana.modal('show');
        });
    }
    this.Borrar = function(ele) {
        let id = $(ele).data('salaid');
        let nombre = $(ele).data('saladesc');
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
                    PostAjax("Sala/"+id,"json","Delete", "", 
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

const mantSala = new Sala("#formulario","#txtSalaId", "#txtDescripcion","#chkActivo");
mantSala.Init();
