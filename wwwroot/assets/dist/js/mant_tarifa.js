function tarifaDTO(TipoHabitacionId, TipoHabitacionDesc,TipoHospedajeId,TipoHospedajeDesc,PlanId,PlanDesc,TarifaPrecio)
{
    this.TipoHabitacionId = TipoHabitacionId;
    this.TipoHabitacionDesc = TipoHabitacionDesc;
    this.TipoHospedajeId = TipoHospedajeId;
    this.TipoHospedajeDesc = TipoHospedajeDesc;
    this.PlanId = PlanId;
    this.PlanDesc = PlanDesc;
    this.TarifaPrecio = TarifaPrecio;
}

function Tarifa(ventana,tarifaNueva,plan,tipoHabitacion,tipoHospedaje,tarifaPrecio) {
    this.ventana = $(ventana);
    this.tarifaNueva = $(tarifaNueva);
    this.plan = $(plan);
    this.tipoHabitacion = $(tipoHabitacion);
    this.tipoHospedaje = $(tipoHospedaje);
    this.tarifaPrecio = $(tarifaPrecio);

    this.Init = function () {

        self.ventana.on('shown.bs.modal', function (e) {
            self.plan.focus();
        });
        self.ventana.on('hidden.bs.modal', function (e) {
            self.InicializarComponentes();
        });
        CampoNumero(tarifaPrecio);

        self.BuscarPlan();
        self.BuscarTipoHabitacion();
        self.BuscarTipoHospedaje();
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

        self.tarifaNueva.val("0");

    }
    this.BuscarPlan = function () {
        GetAjax("Planes", "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<option value="0"></option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.planId + '">' + currentValue.planDesc + '</option>'
            });
            self.plan.html(dataHtml);
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
    this.BuscarTipoHospedaje = function () {
        GetAjax("TipoHospedajes", "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<option value="0"></option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.tipoHospedajeId + '">' + currentValue.tipoHospedajeDesc + '</option>'
            });
            self.tipoHospedaje.html(dataHtml);
        });
    }
    this.Validar = function() {
        let result = true;
        if (self.plan.val() == "0"){
            self.plan.addClass('is-invalid');
            self.plan.focus();
            result = false;
        }else{
            self.plan.removeClass('is-invalid');
        }
        if (self.tipoHabitacion.val() == "0"){
            self.tipoHabitacion.addClass('is-invalid');
            self.tipoHabitacion.focus();
            result = false;
        }else{
            self.tipoHabitacion.removeClass('is-invalid');
        }
        if (self.tarifaPrecio.val() == ""){
            self.tarifaPrecio.addClass('is-invalid');
            self.tarifaPrecio.focus();
            result = false;
        }else{
            self.tarifaPrecio.removeClass('is-invalid');
        }
        if (self.tipoHospedaje.val() == "0"){
            self.tipoHospedaje.addClass('is-invalid');
            self.tipoHospedaje.focus();
            result = false;
        }else{
            self.tipoHospedaje.removeClass('is-invalid');
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
            let tarifa = new tarifaDTO(
                parseInt(self.tipoHabitacion.val()),"",
                parseInt(self.tipoHospedaje.val()),"",parseInt(self.plan.val()),"",
                parseFloat(self.tarifaPrecio.val())
            );
            let type = "";
            let url = "Tarifa";
            if (parseInt(self.tarifaNueva.val()) == 0){
                type = "POST";
            }
            else{
                type = "PUT"
            }
            PostAjax(url,"json",type, JSON.stringify(tarifa), 
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
    this.Editar = function(ele) {
        self.tarifaNueva.val("1");
        let tarifa = new tarifaDTO(
            parseInt($(ele).data('tipohabitacionid')),"",
            parseInt($(ele).data('tipohospedajeid')),"",parseInt($(ele).data('planid')),"",
            0
        );
        PostAjax("TarifaEdit", "json","POST", JSON.stringify(tarifa), 
            function (data) {
                if (data != null){
                    self.tipoHabitacion.val(data.tipoHabitacionId);
                    self.plan.val(data.planId);
                    self.tipoHospedaje.val(data.tipoHospedajeId);
                    self.tarifaPrecio.val(data.tarifaPrecio);
                }
                self.ventana.modal('show');
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
        });
    }
    this.Borrar = function(ele) {
        let tarifa = new tarifaDTO(
            parseInt($(ele).data('tipohabitacionid')),"",
            parseInt($(ele).data('tipohospedajeid')),"",parseInt($(ele).data('planid')),"",
            0
        );
        let swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: 'mr-2 btn btn-success dialog-botones',
                cancelButton: 'btn btn-danger   dialog-botones'
            },
            buttonsStyling: false,
        });

        swalWithBootstrapButtons.fire({
            title: "Borrar Registro",
            text: `¿Está seguro que desea borrar la tarifa seleccionada?`,
            type: 'info',
            showCancelButton: true,
            cancelButtonText: 'No',
            confirmButtonText: 'Si'
            }).then(function(respuesta) {
                if (respuesta.value){
                    PostAjax("Tarifa","json","Delete", JSON.stringify(tarifa), 
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

const mantTarifa = new Tarifa("#formulario","#txtTarifaNueva", "#cmbPlan","#cmbTipoHabitacion","#cmbTipoHospedaje","#txtPrecio");
mantTarifa.Init();
