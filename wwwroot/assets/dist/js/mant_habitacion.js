function habitacionDTO(HabitacionId, HabitacionDesc,PlantaId,PlantaDesc,TipoHabitacionId,TipoHabitacionDesc,HabitacionEstado, 
    HabitacionEstatus)
{
    this.HabitacionId = HabitacionId;
    this.HabitacionDesc = HabitacionDesc;
    this.PlantaId = PlantaId;
    this.PlantaDesc = PlantaDesc;
    this.TipoHabitacionId = TipoHabitacionId;
    this.TipoHabitacionDesc = TipoHabitacionDesc;
    this.HabitacionEstado = HabitacionEstado;
    this.HabitacionEstatus = HabitacionEstatus;
}

function Habitacion(ventana,habitacionId,descripcion,planta,tipoHabitacion,activo) {
    this.ventana = $(ventana);
    this.habitacionId = $(habitacionId);
    this.descripcion = $(descripcion);
    this.planta = $(planta);
    this.tipoHabitacion = $(tipoHabitacion);
    this.activo = $(activo);

    this.Init = function () {

        self.ventana.on('shown.bs.modal', function (e) {
            self.descripcion.focus();
            self.descripcion.select();
        });
        self.ventana.on('hidden.bs.modal', function (e) {
            self.InicializarComponentes();
        });
        self.BuscarPlantas();
        self.BuscarTipoHabitacion();
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

        self.habitacionId.val("0");
        self.activo.prop('checked', true);
    }
    this.BuscarPlantas = function () {
        GetAjax("Plantas", "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<option value="0"></option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.plantaId + '">' + currentValue.plantaDesc + '</option>'
            });
            self.planta.html(dataHtml);
        });
    }
    this.BuscarTipoHabitacion = function () {
        GetAjax("TipoHabitaciones", "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<option value="0"></option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.tipoHabitacionId + '">' + currentValue.tipoHabitacionDesc + '</option>'
            });
            self.tipoHabitacion.html(dataHtml);
        });
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
        if (self.planta.val() == "0"){
            self.planta.addClass('is-invalid');
            self.planta.focus();
            result = false;
        }else{
            self.planta.removeClass('is-invalid');
        }
        if (self.tipoHabitacion.val() == "0"){
            self.tipoHabitacion.addClass('is-invalid');
            self.tipoHabitacion.focus();
            result = false;
        }else{
            self.tipoHabitacion.removeClass('is-invalid');
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
            let habitacion = new habitacionDTO(
                parseInt(self.habitacionId.val()),
                self.descripcion.val(),parseInt(self.planta.val()),"",parseInt(self.tipoHabitacion.val()),"",1,
                self.activo.prop('checked')
            );
            let type = "";
            let url = "Habitacion";
            if (parseInt(self.habitacionId.val()) == 0){
                type = "POST";
            }
            else{
                type = "PUT"
            }
            PostAjax(url,"json",type, JSON.stringify(habitacion), 
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
        self.habitacionId.val(id);
        GetAjax("Habitacion/"+id, "json", "", function (data) {
            if (data != null){
                self.descripcion.val(data.habitacionDesc);
                self.activo.prop('checked',data.habitacionEstatus);
                self.planta.val(data.plantaId);
                self.tipoHabitacion.val(data.tipoHabitacionId);
            }
            self.ventana.modal('show');
        });
    }
    this.Borrar = function(ele) {
        let id = $(ele).data('habitacionid');
        let nombre = $(ele).data('habitaciondesc');
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
                    PostAjax("Habitacion/"+id,"json","Delete", "", 
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

const mantHabitacion = new Habitacion("#formulario","#txtHabitacionId", "#txtDescripcion","#cmbPlanta","#cmbTipoHabitacion","#chkActivo");
mantHabitacion.Init();
