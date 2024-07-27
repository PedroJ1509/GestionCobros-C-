function mesaDTO(MesaId, MesaNo, MesaDesc, MesaEstatus, SalaId, SalaDesc) {
    this.MesaId = MesaId;
    this.MesaNo = MesaNo;
    this.MesaDesc = MesaDesc;
    this.MesaEstatus = MesaEstatus;
    this.SalaId = SalaId;
    this.SalaDesc = SalaDesc;
}

function Mesa(ventana, mesaId, descripcion, sala, activo) {
    this.ventana = $(ventana);
    this.mesaId = $(mesaId);
    this.descripcion = $(descripcion);
    this.sala = $(sala);
    this.activo = $(activo);

    this.Init = function () {

        self.ventana.on('shown.bs.modal', function (e) {
            self.descripcion.focus();
            self.descripcion.select();
        });
        self.ventana.on('hidden.bs.modal', function (e) {
            self.InicializarComponentes();
        });
        self.BuscarSalas();
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

        self.mesaId.val("0");
        self.activo.prop('checked', true);
    }
    this.BuscarSalas = function () {
        GetAjax("Salas", "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<option value="0"></option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.salaId + '">' + currentValue.salaDesc + '</option>'
            });
            self.sala.html(dataHtml);
        });
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
            let mesa = new mesaDTO(
                parseInt(self.mesaId.val()), 0,
                self.descripcion.val(), self.activo.prop('checked'), parseInt(self.sala.val()),
                ""
            );
            let type = "";
            let url = "Mesa";
            if (parseInt(self.mesaId.val()) == 0) {
                type = "POST";
            }
            else {
                type = "PUT"
            }
            PostAjax(url, "json", type, JSON.stringify(mesa),
                function (param) {
                    HabilitarBottonCargar("#btnGuardar");
                    table.ajax.reload();
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
        self.mesaId.val(id);
        GetAjax("Mesa/" + id, "json", "", function (data) {
            if (data != null) {
                self.descripcion.val(data.mesaDesc);
                self.activo.prop('checked', data.mesaEstatus);
                self.sala.val(data.salaId);
            }
            self.ventana.modal('show');
        });
    }
    this.Borrar = function (ele) {
        let id = $(ele).data('mesaid');
        let nombre = $(ele).data('mesadesc');
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
                PostAjax("Mesa/" + id, "json", "Delete", "",
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

const mantMesa = new Mesa("#formulario", "#txtMesaId", "#txtDescripcion", "#cmbSala", "#chkActivo");
mantMesa.Init();
