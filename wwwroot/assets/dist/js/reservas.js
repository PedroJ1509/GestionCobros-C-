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
function Reservas(ventana,calendar, habitacionId, habitacion, fechaDesde, fechaHasta, cliente, plan, tipoHospedaje, precio,reservaId) {
    this.calendar = $(calendar);
    this.habitacionId = $(habitacionId);
    this.habitacion = $(habitacion);
    this.fechaDesde = $(fechaDesde);
    this.fechaHasta = $(fechaHasta);
    this.cliente = $(cliente);
    this.plan = $(plan);
    this.tipoHospedaje = $(tipoHospedaje);
    this.precio = $(precio);
    this.ventana = $(ventana);
    this.reservaId = $(reservaId);

    this.Init = function() {
        self.BuscarHabitaciones();
        self.BuscarReservas();
        self.BuscarClientes();
        self.BuscarPlan();
        self.BuscarTipoHospedaje();
        self.BuscarHabitacionesSelect();
        self.fechaDesde.datepicker({
            language: 'es',
            minDate: new Date() // Now can select only dates, which goes after today
        });
        self.fechaHasta.datepicker({
            language: 'es',
            minDate: new Date() // Now can select only dates, which goes after today
        });
        
        self.ventana.on('hidden.bs.modal', function (e) {
            self.InicializarComponentes();
        });

        
        $("#mant-cliente").on('hidden.bs.modal', function (e) {
            self.BuscarClientes();
        });

        //self.InicializarCalendario();

        $("#content-habitaciones").on('click','.op-habitaciones-res',function(e){
            if ($(this).hasClass('hab-inactiva')){
                let swalWithBootstrapButtons = Swal.mixin({
                    customClass: {
                        confirmButton: 'mr-2 btn btn-success dialog-botones',
                        cancelButton: 'btn btn-danger   dialog-botones'
                    },
                    buttonsStyling: false,
                });
                swalWithBootstrapButtons.fire(
                    'Habitación No disponible',
                    'Esta habitación enta en estado de mantenimiento, debe desbloquearla para poder hacer reserva.',
                    'info'
                );
                return false;
            }
            self.habitacionId.val(($(this).data('habitacionid')));
            self.calendar.fullCalendar('destroy');
            self.BuscarReservas();
        });

        
        $("#content-habitaciones").on('click','.btn-estado-hab',function(e){
            if ($(this).parent().parent().hasClass('active'))
            {
                alert(1);
            }
        });

        self.cliente.change(function(e) {
            if ($(this).val() != null){
                self.plan.val(($( "#cmbCliente option[value='"+$(this).val()+"']").data('planid')));
            }
            else {
                self.plan.val("0");
            }
        });
    }
    this.InicializarCalendario = function(ArrReservas) {
        /* initialize the external events
        -----------------------------------------------------------------*/
        var calndr = $('#external-events .fc-event');

        $(calndr).each(function () {
            // store data so the calendar knows to render an event upon drop
            $(this).data('event', {
                title: $.trim($(this).text()), // use the element's text as the event title
                stick: true // maintain when user navigates (see docs on the renderEvent method)
            });

            // make the event draggable using jQuery UI
            $(this).draggable({
                zIndex: 999,
                revert: true, // will cause the event to go back to its
                revertDuration: 0  //  original position after the drag
            });

        });

        /* initialize the calendar
        -----------------------------------------------------------------*/
   
        self.calendar.fullCalendar({
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay,'
            },
            defaultDate: new Date,
            defaultView:'month',
            navLinks: true, // can click day/week names to navigate views
            businessHours: true, // display business hours
            editable: true,
            selectable: true,
            monthNames: ['Enero','Febrero','Marzo','Abril','Mayo','Junio','Julio','Agosto','Septiembre','Octubre','Noviembre','Diciembre'],
            monthNamesShort: ['Ene','Feb','Mar','Abr','May','Jun','Jul','Ago','Sep','Oct','Nov','Dic'],
            dayNames: ['Domingo','Lunes','Martes','Miércoles','Jueves','Viernes','Sábado'],
            dayNamesShort: ['Dom','Lun','Mar','Mié','Jue','Vie','Sáb'],
            buttonText: {
                today:    'Hoy',
                month:    'Mes',
                week:     'Semana',
                day:      'Día',
                list:     'Lista'
            },
            eventLimit: false,
            locale: 'es',
            timezone: "-04:00",
            droppable: true, // this allows things to be dropped onto the calendar
            drop: function () {
                // is the "remove after drop" checkbox checked?
                if ($('#drop-remove').is(':checked')) {
                    // if so, remove the element from the "Draggable Events" list
                    $(this).remove();
                }
            },
            events: ArrReservas,
            eventDrop: function(event, delta, revertFunc) {
               debugger;
                let reservaId = event.className.toString();
                let fechaInicio = event.start.format();
                let fechaFinal = event.end.format();
                
                PostAjax("ReservaActualizarFechas/"+reservaId+"/"+fechaInicio+"/"+fechaFinal,"json","POST", "", 
                    function (param) {
                        $('#calendar-reservas').fullCalendar( 'destroy' );
                        self.BuscarReservas();
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
                        
                        $('#calendar-reservas').fullCalendar( 'destroy' );
                        self.BuscarReservas();
                    }
                ); 

            },
            select: function(start, end) {
                let fechaActual = new Date();
                let diaActual = fechaActual.getDate();
                let mesActual = fechaActual.getMonth() + 1;
                let anoActual = fechaActual.getFullYear();
                let horaActual = fechaActual.getHours();
                let minActual = fechaActual.getMinutes();
                let fechaActual2 = new Date(anoActual+"-"+mesActual+"-"+diaActual);

                start = moment(start.format());
                let FechaActual = new Date(start);
                let diaselect = FechaActual.getDate();
                let messelect = FechaActual.getMonth() + 1;
                let anoselect = FechaActual.getFullYear();
                let horaselect = FechaActual.getHours();
                let minselect = FechaActual.getMinutes();

                
                end = moment(end.format());
                let FechaFinal = new Date(end);
                FechaFinal.setDate(FechaFinal.getDate() -1);
                let diaselectFinal = FechaFinal.getDate();
                let messelectFinal = FechaFinal.getMonth() + 1;
                let anoselectFinal = FechaFinal.getFullYear();
                let horaselectFinal = FechaFinal.getHours();
                let minselectFinal = FechaFinal.getMinutes();
                let segselectFinal = FechaFinal.getMinutes();

                if (fechaActual2 <= FechaActual)
                {
                    self.fechaDesde.val(diaselect+"/"+messelect+"/"+anoselect);
                    self.fechaHasta.val(diaselectFinal+"/"+messelectFinal+"/"+anoselectFinal);
    
                    self.habitacion.val(self.habitacionId.val());
                    
                    $("#add-reserva").modal('show');
                }

            },
            eventClick: function(event, element) {
        
                var reservaId = event.className;
                GetAjax("Reserva/"+reservaId, "json", "", function (data) {
                    if (data != null){
                        self.reservaId.val(data.reservaId);
                        self.fechaDesde.val(data.reservaFechaEntrada);
                        self.fechaHasta.val(data.reservaFechaSalida);
                        self.cliente.val([data.clienteId]).trigger('change');
                        self.habitacion.val(data.habitacionId);
                        self.plan.val(data.planId);
                        self.tipoHospedaje.val(data.tipoHospedajeId);
                        self.precio.val(data.reservaDetPrecio);
                        if (data.reservaTipo != "0"){
                            self.fechaDesde.attr('disabled','disabled');
                            self.fechaHasta.attr('disabled','disabled');
                            self.plan.attr('disabled','disabled');
                            self.tipoHospedaje.attr('disabled','disabled');
                            self.cliente.attr('disabled','disabled');
                            self.habitacion.attr('disabled','disabled');

                            $("#add-reserva .modal-footer").addClass('oculto');
                            $("#btnAnularReservas").addClass('oculto');
                        }
                        else{
                            
                            self.fechaDesde.removeAttr('disabled');
                            self.fechaHasta.removeAttr('disabled');
                            self.plan.removeAttr('disabled');
                            self.tipoHospedaje.removeAttr('disabled');
                            self.cliente.removeAttr('disabled');
                            self.habitacion.removeAttr('disabled');
                            $("#add-reserva .modal-footer").removeClass('oculto');
                            $("#btnAnularReservas").removeClass('oculto');
                        }

                        $("#add-reserva").modal('show');
                    }
                });
            }
        });
    }
    this.AbrirCliente = function() {
        $("#mant-cliente").modal('show');
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
        
        self.cliente.val(null).trigger('change');
        
        self.fechaDesde.removeAttr('disabled');
        self.fechaHasta.removeAttr('disabled');
        self.plan.removeAttr('disabled');
        self.tipoHospedaje.removeAttr('disabled');
        self.cliente.removeAttr('disabled');
        $("#btnAnularReservas").addClass('oculto');
        self.habitacion.removeAttr('disabled');

        $("#add-reserva .modal-footer").removeClass('oculto');
    }
    this.BuscarHabitacionesSelect = function () {
        GetAjax("HabitacionDisponibles", "json", "", function (data) {
            let dataSelectHtml = '';
            dataSelectHtml = dataSelectHtml + '<option data-tipohabitacionid="0" value="0"></option>';
            data.forEach(function (currentValue, index, arr) {
                dataSelectHtml = dataSelectHtml + '<option data-tipohabitacionid="' + currentValue.tipoHabitacionId + '" value="' + currentValue.habitacionId + '">' + currentValue.habitacionDesc + '</option>'
            });
             self.habitacion.html(dataSelectHtml);
        });
    }
    this.BuscarHabitaciones = function () {
        GetAjax("Habitacion", "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + `<a class="nav-link active op-habitaciones-res" id="v-pills-home-tab" data-toggle="pill" data-habitacionid="0" href="#" role="tab" aria-selected="true"><i class="fa fa-bed"></i>  Todas</a>`
            data.forEach(function (currentValue, index, arr) {
                let classInactivo = "";
                let boton = `<button type="button" data-estado="0" class="btn btn-inverse btn-circle m-b-5 btn-estado-hab"><i class="fa fa-lock"></i></button>`;
                if (currentValue.habitacionEstado == 1){
                    classInactivo = "hab-inactiva";
                    boton = `<button type="button" data-estado="1" class="btn btn-inverse btn-circle m-b-5 btn-estado-hab"><i class="fa fa-unlock"></i></button>`;
                }
                dataHtml = dataHtml + `<a class="nav-link op-habitaciones-res ${classInactivo}" data-toggle="pill" data-habitacionid="${currentValue.habitacionId}" href="#" role="tab" aria-selected="true"><i class="fa fa-bed"></i>  ${currentValue.habitacionDesc}</a>`
            });
            $("#content-habitaciones .habitaciones").html(dataHtml);
        });
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
    this.BuscarTarifa = function() {
        if (self.habitacion.val() != "0" && self.plan.val() != "0" && self.tipoHospedaje.val() != "0")
        {
            let tipoHabitacion = $("#cmbHabitacion option[value='"+$("#cmbHabitacion").val()+"']").data('tipohabitacionid');
            GetAjax("TarifaPrecio/"+tipoHabitacion+"/"+self.tipoHospedaje.val()+"/"+self.plan.val(), "json", "", function (data) {
                if (data != null){
                    self.precio.val(data.tarifaPrecio);
                }
                else{
                    self.precio.val("");
                }
            });
        }
    }
    this.Cancelar = function () {
        $("#add-reserva").modal('hide')
        return false;
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
    this.BuscarReservas= function () {
        let date = new Date();
        let d = date.getDate(),
            m = date.getMonth() +1,
            y = date.getFullYear();
        let fecha = y+"-"+m+"-"+d+"T00:00:00";
        GetAjax("Reservas/"+self.habitacionId.val()+"/"+fecha, "json", "", function (data) {
            let ArrReservas = [];
            data.forEach(function (currentValue, index, arr) {
                let BackGroundColor = "#f39c12!important";
                let BorderColor = "#f39c12!important";
                if (currentValue.reservaTipo == '1')
                {
                    BackGroundColor = "lightcoral!important";
                    BorderColor = "lightcoral!important";
                }
                else if (currentValue.reservaTipo == '2')
                {
                    BackGroundColor = "dodgerblue!important";
                    BorderColor = "dodgerblue!important";
                }
                let ArrRes = {
                    "title": `${currentValue.planDesc} - Reserva No: ${currentValue.reservaNo}  ${currentValue.clienteNombre}`,
                    "start": currentValue.reservaFechaEntrada,
                    "end": currentValue.reservaFechaSalida,
                    "allDay": true,
                    "backgroundColor": BackGroundColor, 
                    "borderColor": BorderColor, 
                    "className": currentValue.reservaId
                };
				ArrReservas.push(ArrRes);
            });
            self.InicializarCalendario(ArrReservas);
        });
    }
    this.Guardar = function() {
        if (self.Validar()){
            DeshabilitarBottonCargar("#btnGuardarReservas");
            let reservaCreacion = new reservaCreacionDTO(
                parseInt(self.reservaId.val()),CambiarFormatoFecha(self.fechaDesde.val())+"T00:00:00",CambiarFormatoFecha(self.fechaHasta.val())+"T00:00:00",
                parseInt(self.cliente.val()),parseInt(self.plan.val()),parseInt(self.habitacion.val()),parseInt(self.tipoHospedaje.val()),parseFloat(self.precio.val())
            );
            
            let type = "";
            let url = "Reserva";
            if (parseInt(self.reservaId.val()) == 0){
                type = "POST";
            }
            else{
                type = "PUT";
            }
            PostAjax(url,"json",type, JSON.stringify(reservaCreacion), 
                function (param) {
                    HabilitarBottonCargar("#btnGuardarReservas");
                    $('#calendar-reservas').fullCalendar( 'destroy' );
                    self.BuscarReservas();
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
                    HabilitarBottonCargar("#btnGuardarReservas");
                }
            ); 
        }
    }
    this.Anular = function() {
        let id = self.reservaId.val();
        let swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: 'mr-2 btn btn-success dialog-botones',
                cancelButton: 'btn btn-danger   dialog-botones'
            },
            buttonsStyling: false,
        });

        swalWithBootstrapButtons.fire({
            title: "Anular Reserva",
            text: `¿Está seguro que desea Anular Reserva?`,
            type: 'info',
            showCancelButton: true,
            cancelButtonText: 'No',
            confirmButtonText: 'Si'
            }).then(function(respuesta) {
                if (respuesta.value){
                    
                    DeshabilitarBottonCargar("#btnAnularReservas");
                    PostAjax("Reserva/"+id,"json","Delete", "", 
                        function (param) {
                            swalWithBootstrapButtons.fire(
                                'Registro Borrado',
                                'Registro ha sido borrado exitosamente.',
                                'success'
                            );
                            
                            HabilitarBottonCargar("#btnAnularReservas");
                            $('#calendar-reservas').fullCalendar( 'destroy' );
                            self.BuscarReservas();
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
                            HabilitarBottonCargar("#btnAnularReservas");
                        }
                    ); 
                }
            }
        );
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
        if (self.habitacion.val() == "0"){
            self.habitacion.addClass('is-invalid');
            self.habitacion.focus();
            result = false;
        }else{
            self.habitacion.removeClass('is-invalid');
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
}

const reservas = new Reservas("#add-reserva","#calendar-reservas","#txtHabitacionId","#cmbHabitacion","#txtFechaDesde","#txtFechaHasta","#cmbCliente","#cmbPlan","#cmbTipoHospedaje","#txtPrecio","#txtReservaId");
reservas.Init();

$(document).ready(function(){

    var height = $(window).height();

    $('.content').css('min-height',height);
    
    
});