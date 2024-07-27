function reservaHospedajeDTO(ReservaDetId, ReservaHospedajeSec, 
    ReservaHospedajeNombre,ReservaHospedajeIdentificacion,ReservaHospedajeDireccion,ReservaHospedajeTelefonos,
    ReservaHospedajeEmail,ReservaHospedajeFechaEntrada,ReservaHospedajeFechaSalida,ReservaHospedajeComentario,
    NacionalidadId,NacionalidadDesc,ReservaHospedajeSexo,ReservaHospedajeEdad)
{
    this.ReservaDetId = ReservaDetId;
    this.ReservaHospedajeSec = ReservaHospedajeSec;
    this.ReservaHospedajeNombre = ReservaHospedajeNombre;
    this.ReservaHospedajeIdentificacion = ReservaHospedajeIdentificacion;
    this.ReservaHospedajeDireccion = ReservaHospedajeDireccion;
    this.ReservaHospedajeTelefonos = ReservaHospedajeTelefonos;
    this.ReservaHospedajeEmail = ReservaHospedajeEmail;
    this.ReservaHospedajeFechaEntrada = ReservaHospedajeFechaEntrada;
    this.ReservaHospedajeFechaSalida = ReservaHospedajeFechaSalida;
    this.ReservaHospedajeComentario = ReservaHospedajeComentario;
    this.NacionalidadId = NacionalidadId;
    this.NacionalidadDesc = NacionalidadDesc;
    this.ReservaHospedajeSexo = ReservaHospedajeSexo;
    this.ReservaHospedajeEdad = ReservaHospedajeEdad;
}
function reservaCreacionDTO(ReservaId, ReservaFechaEntrada,ReservaFechaSalida,ClienteId,PlanId,HabitacionId,TipoHospedajeId, 
    ReservaDetPrecio)
{
    this.ReservaId = ReservaId;
    this.ReservaFechaEntrada = ReservaFechaEntrada;
    this.ReservaFechaSalida = ReservaFechaSalida;
    this.ClienteId = ClienteId;
    this.PlanId = PlanId;
    this.HabitacionId = HabitacionId;
    this.TipoHospedajeId = TipoHospedajeId;
    this.ReservaDetPrecio = ReservaDetPrecio;
}
function CheckIn(ventana,planta,habitacionId,cliente,plan,tipoHospedaje,fechaDesde,fechaHasta,precio,reservaId) {
    this.ventana = $(ventana);
    this.planta = $(planta);
    this.habitacionId = $(habitacionId);
    this.cliente = $(cliente);
    this.plan = $(plan);
    this.tipoHospedaje = $(tipoHospedaje);
    this.fechaDesde = $(fechaDesde);
    this.fechaHasta = $(fechaHasta);
    this.precio = $(precio);
    this.reservaId = $(reservaId);

    this.Init = function() {
        self.BuscarPlantas();
        self.BuscarHabitaciones();
        self.BuscarClientes();
        self.BuscarPlan();
        self.BuscarTipoHospedaje();
        self.BuscarNacionalidad();
        interval = setInterval(function(){
            self.BuscarHabitaciones();
        },5000);

        
        self.ventana.on('hidden.bs.modal', function (e) {
            self.InicializarComponentes();
        });

        
        $("#formulario-huesped").on('hidden.bs.modal', function (e) {
            self.InicializarComponentesHuesped();
        });
        $("#formulario-huesped").on('shown.bs.modal', function (e) {
            $("#txtDocumentoIdent").focus();
            $("#txtDocumentoIdent").select();
        });
        
        self.fechaDesde.datepicker({
            language: 'es',
            locale: 'es-es',
            dateFormat: 'dd/mm/yy',// Now can select only dates, which goes after today
        });
        self.fechaHasta.datepicker({
            language: 'es',
            locale: 'es-es',
            dateFormat: 'dd/mm/yy', // Now can select only dates, which goes after today
        });
        $("#txtFechaEntrada").datepicker({
            language: 'es',
            locale: 'es-es',
            dateFormat: 'dd/mm/yy',
            minDate: new Date() // Now can select only dates, which goes after today
        });

        self.cliente.change(function(e) {
            if ($(this).val() != null){
                self.plan.val(($( "#cmbCliente option[value='"+$(this).val()+"']").data('planid')));
            }
            else {
                self.plan.val("0");
            }
        });
        
        $("input,select").keypress(function (e) {
            var keycode = (event.keyCode ? event.keyCode : event.which);
            var sigfocus = $(this).data('sigfocus');
            if (keycode == '13') {
                $("#"+sigfocus).focus();
                return false;
            }
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

        self.reservaId.val("0");
        self.habitacionId.val("0");
        
        self.cliente.val(null).trigger('change');
        
        self.fechaDesde.removeAttr('disabled');
        self.fechaHasta.removeAttr('disabled');
        self.plan.removeAttr('disabled');
        self.tipoHospedaje.removeAttr('disabled');
        self.cliente.removeAttr('disabled');

        $("#add-reserva .modal-footer").removeClass('oculto');
        
        $("#lblHabitacionDesc").parent().removeClass('cardbox-checkin');
        $("#lblHabitacionDesc").parent().removeClass('cardbox-reserva');

        $("#btnCheckIn,#btnAnularCheckIn,#btnImprimirCheckIn,#btnCheckOut,#btnGenerarFactura").addClass('oculto');
        $("#dataTable-huesped tbody").html("");
        $("#content-huesped").addClass('oculto');
    }
    this.InicializarComponentesHuesped = function () {
        $("#formulario-huesped input").each(function (e) {
            if ($(this).hasClass('is-invalid')) {
                $(this).removeClass('is-invalid');
            }
            $(this).val(""); 
        });
        $("#formulario-huesped select").each(function (e) {
            if ($(this).hasClass('is-invalid')) {
                $(this).removeClass('is-invalid');
            }
            $(this).val("0"); 
        });

        $("#txtReservaDetId").val("0");
        
    }
    this.BuscarPlantas = function () {
        GetAjax("Plantas", "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<option value="0">Todas</option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.plantaId + '">' + currentValue.plantaDesc + '</option>'
            });
            self.planta.html(dataHtml);
        });
    }
    this.BuscarTarifa = function() {
        if (self.plan.val() != "0" && self.tipoHospedaje.val() != "0")
        {
            GetAjax("TarifaPrecio/"+$("#txtTipoHabitacionId").val()+"/"+self.tipoHospedaje.val()+"/"+self.plan.val(), "json", "", function (data) {
                if (data != null){
                    self.precio.val(data.tarifaPrecio);
                }
                else{
                    self.precio.val("");
                }
            });
        }
    }
    this.SeleccionarHabitacion = function (ele) {
        let reservaId = $(ele).data('reservaid');
        let reservaTipo = $(ele).data('reservatipo');
        let habitacionEstado = $(ele).data('habitacionestado');
        let habitacionId = $(ele).data('habitacionid');
        self.habitacionId.val(habitacionId);
        $("#txtTipoHabitacionId").val($(ele).data('tipohabitacionid'));
        if (habitacionEstado == "0"){
            $("#lblHabitacionDesc").text($(ele).data('habitaciondesc'));
            if (reservaId != "0") {
                self.fechaDesde.attr('disabled','disabled');
                self.fechaHasta.attr('disabled','disabled');
                self.cliente.attr('disabled','disabled');
                self.plan.attr('disabled','disabled');
                self.tipoHospedaje.attr('disabled','disabled');
                $("#content-huesped").removeClass('oculto');
                GetAjax("Reserva/"+reservaId, "json", "", function (data) {
                    if (data != null){
                        self.reservaId.val(data.reservaId);
                        self.fechaDesde.val(data.reservaFechaEntrada);
                        self.fechaHasta.val(data.reservaFechaSalida);
                        self.cliente.val([data.clienteId]).trigger('change');
                        self.plan.val(data.planId);
                        self.tipoHospedaje.val(data.tipoHospedajeId);
                        self.precio.val(data.reservaDetPrecio);
                        if (data.reservaTipo != "0"){
                            
                        }
                        else{
                            
                        }
                    }
                    self.BuscarReservaHospedaje(data.reservaDetId);
                });
                if (reservaTipo == "0") {
                    $("#btnCheckIn").removeClass('oculto');
                    $("#lblHabitacionDesc").parent().addClass('cardbox-reserva');
                }
                else {
                    $("#btnCheckOut,#btnImprimirCheckIn,#btnAnularCheckIn,#btnGenerarFactura").removeClass('oculto');
                    $("#lblHabitacionDesc").parent().addClass('cardbox-checkin');
                }
            }
            else {
                $("#lblHabitacionDesc").parent().removeClass('cardbox-reserva');
                $("#lblHabitacionDesc").parent().removeClass('cardbox-reserva');

                let FechaActual = new Date();
                let diaselect = FechaActual.getDate();
                let messelect = FechaActual.getMonth() + 1;
                let anoselect = FechaActual.getFullYear();
                self.fechaDesde.val(diaselect+"/"+messelect+"/"+anoselect);

                let FechaFinal = new Date();
                FechaFinal.setDate(FechaFinal.getDate() +1);
                let diaselectFinal = FechaFinal.getDate();
                let messelectFinal = FechaFinal.getMonth() + 1;
                let anoselectFinal = FechaFinal.getFullYear();
                self.fechaHasta.val(diaselectFinal+"/"+messelectFinal+"/"+anoselectFinal);
                
                self.fechaDesde.removeAttr('disabled');
                self.fechaHasta.removeAttr('disabled');
                self.cliente.removeAttr('disabled');
                self.plan.removeAttr('disabled');
                self.tipoHospedaje.removeAttr('disabled');
                
                $("#btnCheckIn").removeClass('oculto');
            }
            if (reservaId != "0")
            {

            }
            self.ventana.modal('show');
        }
        else {
            let swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'mr-2 btn btn-success dialog-botones',
                    cancelButton: 'btn btn-danger   dialog-botones'
                },
                buttonsStyling: false,
            });
    
            swalWithBootstrapButtons.fire({
                title: "Habitación Fuera de Servicio",
                text: `La habitación seleccionada esta fuera de servicio. ¿Desea ponerla disponible?`,
                type: 'info',
                showCancelButton: true,
                cancelButtonText: 'No',
                confirmButtonText: 'Si'
                }).then(function(respuesta) {
                    if (respuesta.value){
                        PostAjax("CambiarEstadoHabitacion/"+habitacionId,"json","Post", "", 
                            function (param) {
                                self.BuscarHabitaciones();
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
    }
    this.EditarHuesped = function (ele) {
        let revervaDetId = $(ele).data('reservadetid');
        let revervaDetSec = $(ele).data('reservahospedajesec');

        $("#txtReservaDetId").val(revervaDetId);
        $("#txtNo").val(revervaDetSec);

        if (revervaDetId != "0") {
            GetAjax("Huesped/"+revervaDetId+"/"+revervaDetSec, "json", "", function (data) {
                if (data != null){
                    $("#txtFechaEntrada").val(data.reservaHospedajeFechaEntrada);
                    $("#txtDocumentoIdent").val(data.reservaHospedajeIdentificacion);
                    $("#txtNombre").val(data.reservaHospedajeNombre);
                    $("#cmbNacionalidad").val(data.nacionalidadId);
                    $("#cmbSexo").val(data.reservaHospedajeSexo);
                    $("#txtEdad").val(data.reservaHospedajeEdad);
                    $("#txtDireccion").val(data.reservaHospedajeDireccion);
                    $("#txtTelefono").val(data.reservaHospedajeTelefonos);
                    $("#txtEmail").val(data.reservaHospedajeEmail);

                    if	(data.reservaHospedajeFechaEntrada == "" || data.reservaHospedajeFechaEntrada == null) {
                        $("#txtFechaEntrada").val(self.fechaDesde.val());
                    }
                }
            });
        }
        $("#formulario-huesped").modal('show');
    }
    this.ConsultarIdenticacionHuesped = function () {
        if ($("#txtDocumentoIdent").val() != ""){
            GetAjax("ConsultaIdenticacion/"+$("#txtDocumentoIdent").val(), "json", "", function (data) {
                if (data != null){
                    $("#txtNombre").val(data.reservaHospedajeNombre);
                    $("#cmbNacionalidad").val(data.nacionalidadId);
                    $("#cmbSexo").val(data.reservaHospedajeSexo);
                    $("#txtEdad").val(data.reservaHospedajeEdad);
                    $("#txtDireccion").val(data.reservaHospedajeDireccion);
                    $("#txtTelefono").val(data.reservaHospedajeTelefonos);
                    $("#txtEmail").val(data.reservaHospedajeEmail);
                }
            });
        }
    }
    this.ImprimirCheckIn = function() {
        DeshabilitarBottonCargar("#btnImprimirCheckIn");
        $.ajax({
            url : "/CheckInReport/"+self.reservaId.val(),
            type: "POST",
            dataType : "",
            contentType: "application/json; charset=utf-8",
            data : "",
            cache: false,
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                'Authorization': 'Bearer '+sessionStorage.getItem('UserTokenProbeta')},
    
            success : function(data) {
                $("#pdf-viewer .modal-body").html('<embed src="/PDFReports/checkinreport.pdf" type="application/pdf" width="100%" height="600px" />'); // result is the HTML text
                $("#pdf-viewer").modal('show');
                HabilitarBottonCargar("#btnImprimirCheckIn");
            //    $("#recetaReport .modal-body").html('<embed src="/PDFReports/histConsult-'+sessionStorage.getItem('UsuarioId')+'.pdf" type="application/pdf" width="100%" height="600px" />'); // result is the HTML text
            //     HabilitarBottonCargar("#btnPrintHistoricoCons");
            },
        });
        
        // PostAjax("CheckInReport","","Post", "", 
        //     function (param) {
        //         notificacion.fire(
        //             'Notificacion',
        //             "Impreso",
        //             'info'
        //         );
        //     }, 
        //     function(error) {
        //         let swalWithBootstrapButtons = Swal.mixin({
        //             customClass: {
        //                 confirmButton: 'mr-2 btn btn-success dialog-botones',
        //                 cancelButton: 'btn btn-danger dialog-botones'
        //             },
        //             buttonsStyling: false,
        //         });
        //         if (error.status == 404) {
        //             swalWithBootstrapButtons.fire(
        //                 'Notificacion',
        //                 error.responseJSON,
        //                 'info'
        //             );
        //         }
        //         else {
        //             swalWithBootstrapButtons.fire(
        //                 'Notificacion',
        //                 error.responseJSON,
        //                 'error'
        //             );
        //         }
        //         HabilitarBottonCargar("#btnGuardarHuesped");
        //     }
        // ); 
    }
    this.CancelarHuesped = function () {
        $("#formulario-huesped").modal('hide');
    }
    this.GenerarFactura = function () {
        $("#pant-factura").modal('show');
    }
    this.GuardarHuesped = function () {
        DeshabilitarBottonCargar("#btnGuardarHuesped");
            let reservaHospedaje = new reservaHospedajeDTO(
                parseInt($("#txtReservaDetId").val()),
                parseInt($("#txtNo").val()),
                $("#txtNombre").val(),
                $("#txtDocumentoIdent").val(),
                $("#txtDireccion").val(),
                $("#txtTelefono").val(),
                $("#txtEmail").val(),
                CambiarFormatoFecha($("#txtFechaEntrada").val())+"T00:00:00","","",
                parseInt($("#cmbNacionalidad").val()),"",
                $("#cmbSexo").val(),
                $("#txtEdad").val()
            );
            PostAjax("ReservaHospedaje","json","PUT", JSON.stringify(reservaHospedaje), 
                function (param) {
                    HabilitarBottonCargar("#btnGuardarHuesped");
                    self.BuscarReservaHospedaje($("#txtReservaDetId").val());
                    $("#formulario-huesped").modal('hide');
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
                    HabilitarBottonCargar("#btnGuardarHuesped");
                }
            ); 
    }
    this.BuscarReservaHospedaje = function(reservaDetId) {
        GetAjax("Hospedajes/"+reservaDetId, "json", "", function (data) {
            $("#dataTable-huesped tbody").html("");
            let dataHtml = '';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + `<tr>
                                            <td>${currentValue.reservaHospedajeSec}</td>
                                            <td>${currentValue.reservaHospedajeNombre}</td>
                                            <td>${currentValue.reservaHospedajeSexo}</td>
                                            <td>${currentValue.reservaHospedajeEdad}</td>
                                            <td>${currentValue.reservaHospedajeTelefonos}</td>
                                            <td>${currentValue.reservaHospedajeEmail}</td>
                                            <td class="text-center">
                                                <div>
                                                    <button type="button" data-reservadetid=${currentValue.reservaDetId} data-reservahospedajesec=${currentValue.reservaHospedajeSec} onclick="checkin.EditarHuesped(this)" class="btn btn-add btn-sm btn-action-mjp btn-action-editar"><i class="fa fa-pencil"></i></button>
                                                </div>
                                            </td>
                                        </tr>`
            });
            $("#dataTable-huesped tbody").html(dataHtml);
        });
    }
    this.CheckIn = function() {
        
        if ($("#txtReservaId").val() != "0") {
            DeshabilitarBottonCargar("#btnCheckIn");
            PostAjax("ReservaCheckIn/"+$("#txtReservaId").val(),"json","Post", "", 
                function (param) {
                    self.CheckInRealizado();
                }, 
                function(error) {
                    
                    if (error.status == 404) {
                        notificacion.fire(
                            'Notificacion',
                            error.responseJSON,
                            'info'
                        );
                    }
                    else {
                        notificacion.fire(
                            'Notificacion',
                            error.responseJSON,
                            'info'
                        );
                    }
                    HabilitarBottonCargar("#btnCheckIn");
                }
            ); 
        }
        else
        {
            if (self.Validar()){
                DeshabilitarBottonCargar("#btnCheckIn");
                let reservaCreacion = new reservaCreacionDTO(
                    parseInt(self.reservaId.val()),CambiarFormatoFecha(self.fechaDesde.val())+"T00:00:00",CambiarFormatoFecha(self.fechaHasta.val())+"T00:00:00",
                    parseInt(self.cliente.val()),parseInt(self.plan.val()),parseInt(self.habitacionId.val()),parseInt(self.tipoHospedaje.val()),parseFloat(self.precio.val())
                );
                
                let url = "ReservaCkeckIn";
                PostAjax(url,"json","POST", JSON.stringify(reservaCreacion), 
                    function (param) {
                        self.CheckInRealizado();
                        $("#txtReservaId").val(param);
                        self.BuscarReservaHospedaje(param);
                        $("#content-huesped").removeClass('oculto');
                        
                        self.fechaDesde.attr('disabled','disabled');
                        self.fechaHasta.attr('disabled','disabled');
                        self.cliente.attr('disabled','disabled');
                        self.plan.attr('disabled','disabled');
                        self.tipoHospedaje.attr('disabled','disabled');
                    }, 
                    function(error) {
                        
                        if (error.status == 404) {
                            notificacion.fire(
                                'Notificacion',
                                error.responseJSON,
                                'info'
                            );
                        }
                        else {
                            notificacion.fire(
                                'Notificacion',
                                error.responseJSON,
                                'info'
                            );
                        }
                        HabilitarBottonCargar("#btnCheckIn");
                    }
                ); 
            }
        }
    }
    this.Anular = function() {
        notificacion.fire({
            title: "Anular CheckIn",
            text: `¿Está seguro que desea Anular CheckIn?`,
            type: 'info',
            showCancelButton: true,
            cancelButtonText: 'No',
            confirmButtonText: 'Si'
            }).then(function(respuesta) {
                if (respuesta.value){
                    DeshabilitarBottonCargar("#btnAnularCheckIn");
                    PostAjax("AnularCheckIn/"+$("#txtReservaId").val(),"json","Post", "", 
                        function (param) {
                            HabilitarBottonCargar("#btnAnularCheckIn");
                            $("#lblHabitacionDesc").parent().addClass('cardbox-reserva');
                            $("#lblHabitacionDesc").parent().removeClass('cardbox-checkin');
                            $("#btnCheckIn").removeClass('oculto');
                            $("#btnCheckOut,#btnImprimirCheckIn,#btnAnularCheckIn,#btnGenerarFactura").addClass('oculto');
                            notificacion.fire(
                                'CheckIn',
                                "CheckIn anulado exitosamente.",
                                'success'
                            );
                        }, 
                        function(error) {
                            
                            if (error.status == 404) {
                                notificacion.fire(
                                    'Notificacion',
                                    error.responseJSON,
                                    'info'
                                );
                            }
                            else {
                                notificacion.fire(
                                    'Notificacion',
                                    error.responseJSON,
                                    'info'
                                );
                            }
                            HabilitarBottonCargar("#btnAnularCheckIn");
                        }
                    ); 
                }
            }
        );
        
    }
    this.CheckInRealizado = function() {
        HabilitarBottonCargar("#btnCheckIn");
        $("#lblHabitacionDesc").parent().removeClass('cardbox-reserva');
        $("#lblHabitacionDesc").parent().addClass('cardbox-checkin');
        $("#btnCheckIn").addClass('oculto');
        $("#btnCheckOut,#btnImprimirCheckIn,#btnAnularCheckIn,#btnGenerarFactura").removeClass('oculto');
        notificacion.fire(
            'CheckIn',
            "CheckIn realizado exitosamente.",
            'success'
        );
    }
    this.BuscarClientes = function () {
        GetAjax("Cliente", "json", "", function (data) {
            let dataHtml = '';
            //dataHtml = dataHtml + '<option value="0"></option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option data-planid="'+currentValue.planId+'" value="' + currentValue.clienteId + '">' + currentValue.clienteNombre + '</option>'
            });
            self.cliente.html(dataHtml);
            self.cliente.select2({
                allowClear: true,
                placeholder: "",
                language: "es"
            });
            self.cliente.val(null).trigger('change');
        });
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
    this.BuscarNacionalidad = function () {
        GetAjax("Nacionalidades", "json", "", function (data) {
            let dataHtml = '';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.nacionalidadId + '">' + currentValue.nacionalidadDesc + '</option>'
            });
            $("#cmbNacionalidad").html(dataHtml);
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
    this.BuscarHabitaciones = function () {
        GetAjax("CheckInHabitaciones/"+self.planta.val(), "json", "", function (data) {
           
            let dataHtml = '';
            data.forEach(function (currentValue, index, arr) {
                let classHab = "";
                if (currentValue.habitacionEstado == "1"){
                    classHab = "cardbox-inactive";
                }
                else if (currentValue.reservaId != "0"){
                    if (currentValue.reservaTipo == "0")
                    {
                        classHab = "cardbox-reserva";
                    }
                    else{
                        if (currentValue.checkout == "0"){
                            classHab = "cardbox-checkin";
                        }
                        else {
                            classHab = "cardbox-checkout";
                        }
                    }
                }
                dataHtml = dataHtml + `<div class=" col-sm-6 col-md-4 col-lg-3 col-xl-3">
                                            <div onclick="checkin.SeleccionarHabitacion(this)" data-tipohabitacionid="${currentValue.tipoHabitacionId}" data-tipohabitacion="${currentValue.tipoHabitacionDesc}" data-habitaciondesc="${currentValue.habitacionDesc}" data-habitacionid="${currentValue.habitacionId}" data-reservatipo="${currentValue.reservaTipo}" data-habitacionEstado="${currentValue.habitacionEstado}" data-reservaid="${currentValue.reservaId}" class="cardbox ${classHab}">
                                                <div class="statistic-box">
                                                    <i class="fa fa-bed fa-3x"></i>
                                                    <div class="counter-number pull-right">
                                                        <span class="">${currentValue.tipoHabitacionDesc}</span>
                                                    </div>
                                                    <h3>${currentValue.habitacionDesc}</h3>
                                                </div>
                                            </div>
                                        </div>`
            });
            $("#content-habitaciones").html(dataHtml);
        });
    }
    this.Validar = function() {
        let result = true;
        if (self.precio.val() == ""){
            self.precio.addClass('is-invalid');
            self.precio.focus();
            result = false;
        }else{
            self.precio.removeClass('is-invalid');
        }
        if (self.fechaDesde.val() == ""){
            self.fechaDesde.addClass('is-invalid');
            self.fechaDesde.focus();
            result = false;
        }else{
            self.fechaDesde.removeClass('is-invalid');
        }
        if (self.fechaHasta.val() == ""){
            self.fechaHasta.addClass('is-invalid');
            self.fechaHasta.focus();
            result = false;
        }else{
            self.fechaHasta.removeClass('is-invalid');
        }
        if (self.cliente.val() == null){
            self.cliente.addClass('is-invalid');
            self.cliente.focus();
            result = false;
        }else{
            self.cliente.removeClass('is-invalid');
        }
        if (self.plan.val() == "0"){
            self.plan.addClass('is-invalid');
            self.plan.focus();
            result = false;
        }else{
            self.plan.removeClass('is-invalid');
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

    let self = this;

    let notificacion = Swal.mixin({
        customClass: {
            confirmButton: 'mr-2 btn btn-success dialog-botones',
            cancelButton: 'btn btn-danger dialog-botones'
        },
        buttonsStyling: false,
    });
}

const checkin = new CheckIn("#checkin-checkout","#cmbPlanta","#txtHabitacionId",
                            "#cmbCliente","#cmbPlan","#cmbTipoHospedaje","#txtFechaDesde",
                            "#txtFechaHasta","#txtPrecio","#txtReservaId");
checkin.Init();

$(document).ready(function(){

    var height = $(window).height();

    $('.content').css('min-height',height);
    
    
});