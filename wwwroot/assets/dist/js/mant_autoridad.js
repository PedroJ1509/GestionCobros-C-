function autoridadDTO(AutoridadId, AutoridadDesc, PantallaId,
    PantallaDesc) {
    this.AutoridadId = AutoridadId;
    this.AutoridadDesc = AutoridadDesc;
    this.PantallaId = PantallaId;
    this.PantallaDesc = PantallaDesc;
}

function autorAlmacenDTO(AutoridadId, AlmacenId) {
    this.autorId = AutoridadId;
    this.almacenId = AlmacenId;
}

function autorPantallaDTO(AutoridadId, PantallaId) {
    this.autorId = AutoridadId;
    this.pantallaId = PantallaId;
}
function autorDepartamentoDTO(AutoridadId, DepartamentoId) {
    this.autorId = AutoridadId;
    this.departamentoId = DepartamentoId;
}
function autorPrivilegioDTO(AutoridadId, PrivilegioId) {
    this.autorId = AutoridadId;
    this.privilegioId = PrivilegioId;
}
function autorReporteDTO(AutoridadId, ReporteId) {
    this.autorId = AutoridadId;
    this.reporteId = ReporteId;
}
function Autoridad(ventana, autoridadId, descripcion, pantalla) {
    this.ventana = $(ventana);
    this.autoridadId = $(autoridadId);
    this.descripcion = $(descripcion);
    this.pantalla = $(pantalla);

    this.Init = function () {

        self.ventana.on('shown.bs.modal', function (e) {
            self.descripcion.focus();
            self.descripcion.select();
        });
        self.ventana.on('hidden.bs.modal', function (e) {
            self.InicializarComponentes();
        });
        self.BuscarPantallas();
    }
    this.BuscarPantallas = function () {
        GetAjax("Pantallas", "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<option value="0"></option>';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + '<option value="' + currentValue.pantallaId + '">' + currentValue.pantallaDesc + '</option>'
            });
            self.pantalla.html(dataHtml);
        });
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

        self.autoridadId.val("0");
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
        if (self.pantalla.val() == "0") {
            self.pantalla.addClass('is-invalid');
            self.pantalla.focus();
            result = false;
        } else {
            self.pantalla.removeClass('is-invalid');
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
            let autoridad = new autoridadDTO(
                parseInt(self.autoridadId.val()),
                self.descripcion.val(),
                self.pantalla.val(), ""
            );
            
            let type = "";
            let url = "";
            if (parseInt(self.autoridadId.val()) == 0) {
                type = "POST";
                url = "Autoridad"
            }
            else {
                type = "PUT"
                url = "Autoridad"
            }
            PostAjax(url, "json", type, JSON.stringify(autoridad),
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
                    HabilitarBottonCargar("#btnGuardar");
                }
            );
        }
        return false;
    }
    this.BuscarAlmacenesNoAsignados = function(autoridadId) {
        GetAjax("AlmacenesNoAsignados/"+autoridadId, "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<ol class="dd-list">';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + `<li class="dd-item" data-id="1">
                                            <div onclick="mantAutoridad.AsignarAlmacen(${currentValue.almacenId})" data-almacenid="${currentValue.almacenId}" class="dd-handle">
                                                <span class="label bg-custom"></span> ${currentValue.almacenDesc}
                                            </div>
                                        </li>`;
            });
            dataHtml = dataHtml + '</ol>';
            $("#almacenesNoAsiganados").html(dataHtml);
        });
    }
    this.BuscarAlmacenesAsignados = function(autoridadId) {
        GetAjax("AlmacenesAsignados/"+autoridadId, "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<ol class="dd-list">';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + `<li class="dd-item" data-id="1">
                                            <div onclick="mantAutoridad.QuitarAlmacen(${currentValue.almacenId})" data-almacenid="${currentValue.almacenId}" class="dd-handle">
                                                <span class="label bg-custom"></span> ${currentValue.almacenDesc}
                                            </div>
                                        </li>`;
            });
            dataHtml = dataHtml + '</ol>';
            $("#almacenesAsiganados").html(dataHtml);
        });
    }
    this.AsignarAlmacen = function (almacenId) {
        let autoridadAlmacen = new autorAlmacenDTO(
            parseInt(self.autoridadId.val()),
            parseInt(almacenId)
        );
        PostAjax("AsignarAlamcen", "json", "POST", JSON.stringify(autoridadAlmacen),
            function (param) {
                self.BuscarAlmacenesNoAsignados(self.autoridadId.val());
                self.BuscarAlmacenesAsignados(self.autoridadId.val());
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
                HabilitarBottonCargar("#btnGuardar");
            }
        );
    }
    this.QuitarAlmacen = function (almacenId) {
        
        let autoridadAlmacen = new autorAlmacenDTO(
            parseInt(self.autoridadId.val()),
            parseInt(almacenId)
        );
        PostAjax("QuitarAlmacen", "json", "POST", JSON.stringify(autoridadAlmacen),
            function (param) {
                self.BuscarAlmacenesNoAsignados(self.autoridadId.val());
                self.BuscarAlmacenesAsignados(self.autoridadId.val());
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
                HabilitarBottonCargar("#btnGuardar");
            }
        );
    }
    
    this.BuscarPantallasNoAsignados = function(autoridadId) {
        GetAjax("PantallasNoAsignados/"+autoridadId, "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<ol class="dd-list">';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + `<li class="dd-item" data-id="1">
                                            <div onclick="mantAutoridad.AsignarPantalla(${currentValue.pantallaId})" data-pantallaid="${currentValue.pantallaId}" class="dd-handle">
                                                <span class="label bg-custom"></span> ${currentValue.pantallaDesc}
                                            </div>
                                        </li>`;
            });
            dataHtml = dataHtml + '</ol>';
            $("#pantallasNoAsiganados").html(dataHtml);
        });
    }
    this.BuscarPantallasAsignados = function(autoridadId) {
      
        GetAjax("PantallasAsignados/"+autoridadId, "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<ol class="dd-list">';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + `<li class="dd-item" data-id="1">
                                            <div onclick="mantAutoridad.QuitarPantalla(${currentValue.pantallaId})" data-pantallaid="${currentValue.pantallaId}" class="dd-handle">
                                                <span class="label bg-custom"></span> ${currentValue.pantallaDesc}
                                            </div>
                                        </li>`;
            });
            dataHtml = dataHtml + '</ol>';
            $("#pantallasAsiganados").html(dataHtml);
        });
    }
    
    this.BuscarDepartamentosNoAsignados = function(autoridadId) {
        GetAjax("DepartamentosNoAsignados/"+autoridadId, "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<ol class="dd-list">';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + `<li class="dd-item" data-id="1">
                                            <div onclick="mantAutoridad.AsignarDepartamento(${currentValue.departamentoId})" data-departamentoid="${currentValue.departamentoId}" class="dd-handle">
                                                <span class="label bg-custom"></span> ${currentValue.departamentoDesc}
                                            </div>
                                        </li>`;
            });
            dataHtml = dataHtml + '</ol>';
            $("#departamentosNoAsiganados").html(dataHtml);
        });
    }
    this.BuscarDepartamentosAsignados = function(autoridadId) {
      
        GetAjax("DepartamentosAsignados/"+autoridadId, "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<ol class="dd-list">';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + `<li class="dd-item" data-id="1">
                                            <div onclick="mantAutoridad.QuitarDepartamento(${currentValue.departamentoId})" data-departamentoid="${currentValue.departamentoId}" class="dd-handle">
                                                <span class="label bg-custom"></span> ${currentValue.departamentoDesc}
                                            </div>
                                        </li>`;
            });
            dataHtml = dataHtml + '</ol>';
            $("#departamentosAsiganados").html(dataHtml);
        });
    }
    this.BuscarPrivilegiosNoAsignados = function(autoridadId) {
        GetAjax("PrivilegiosNoAsignados/"+autoridadId, "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<ol class="dd-list">';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + `<li class="dd-item" data-id="1">
                                            <div onclick="mantAutoridad.AsignarPrivilegio(${currentValue.privilegioId})" data-privilegioid="${currentValue.privilegioId}" class="dd-handle">
                                                <span class="label bg-custom"></span> ${currentValue.privilegioDesc}
                                            </div>
                                        </li>`;
            });
            dataHtml = dataHtml + '</ol>';
            $("#privilegiosNoAsiganados").html(dataHtml);
        });
    }
    this.BuscarPrivilegiosAsignados = function(autoridadId) {
      
        GetAjax("PrivilegiosAsignados/"+autoridadId, "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<ol class="dd-list">';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + `<li class="dd-item" data-id="1">
                                            <div onclick="mantAutoridad.QuitarPrivilegio(${currentValue.privilegioId})" data-privilegioid="${currentValue.privilegioId}" class="dd-handle">
                                                <span class="label bg-custom"></span> ${currentValue.privilegioDesc}
                                            </div>
                                        </li>`;
            });
            dataHtml = dataHtml + '</ol>';
            $("#privilegiosAsiganados").html(dataHtml);
        });
    }
    this.BuscarReportesNoAsignados = function(autoridadId) {
        GetAjax("ReportesNoAsignados/"+autoridadId, "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<ol class="dd-list">';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + `<li class="dd-item" data-id="1">
                                            <div onclick="mantAutoridad.AsignarReporte(${currentValue.reporteId})" data-reporteid="${currentValue.reporteId}" class="dd-handle">
                                                <span class="label bg-custom"></span> ${currentValue.reporteDesc}
                                            </div>
                                        </li>`;
            });
            dataHtml = dataHtml + '</ol>';
            $("#reportesNoAsiganados").html(dataHtml);
        });
    }
    this.BuscarReportesAsignados = function(autoridadId) {
      
        GetAjax("ReportesAsignados/"+autoridadId, "json", "", function (data) {
            let dataHtml = '';
            dataHtml = dataHtml + '<ol class="dd-list">';
            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + `<li class="dd-item" data-id="1">
                                            <div onclick="mantAutoridad.QuitarReporte(${currentValue.reporteId})" data-reporteid="${currentValue.reporteId}" class="dd-handle">
                                                <span class="label bg-custom"></span> ${currentValue.reporteDesc}
                                            </div>
                                        </li>`;
            });
            dataHtml = dataHtml + '</ol>';
            $("#reportesAsiganados").html(dataHtml);
        });
    }
    this.AsignarPantalla = function (pantallaId) {
        let autoridadPantalla = new autorPantallaDTO(
            parseInt(self.autoridadId.val()),
            parseInt(pantallaId)
        );
        PostAjax("AsignarPantalla", "json", "POST", JSON.stringify(autoridadPantalla),
            function (param) {
                self.BuscarPantallasNoAsignados(self.autoridadId.val());
                self.BuscarPantallasAsignados(self.autoridadId.val());
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
    this.QuitarPantalla = function (pantallaId) {
        debugger;
        let autoridadPantalla = new autorPantallaDTO(
            parseInt(self.autoridadId.val()),
            parseInt(pantallaId)
        );
        PostAjax("QuitarPantalla", "json", "POST", JSON.stringify(autoridadPantalla),
            function (param) {
                self.BuscarPantallasNoAsignados(self.autoridadId.val());
                self.BuscarPantallasAsignados(self.autoridadId.val());
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
    this.AsignarDepartamento = function (departamentoId) {
        let autoridadDepartamento = new autorDepartamentoDTO(
            parseInt(self.autoridadId.val()),
            parseInt(departamentoId)
        );
        PostAjax("AsignarDepartamento", "json", "POST", JSON.stringify(autoridadDepartamento),
            function (param) {
                self.BuscarDepartamentosNoAsignados(self.autoridadId.val());
                self.BuscarDepartamentosAsignados(self.autoridadId.val());
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
    this.QuitarDepartamento = function (departamentoId) {

        let autoridadDepartamento = new autorDepartamentoDTO(
            parseInt(self.autoridadId.val()),
            parseInt(departamentoId)
        );
        PostAjax("QuitarDepartamento", "json", "POST", JSON.stringify(autoridadDepartamento),
            function (param) {
                self.BuscarDepartamentosNoAsignados(self.autoridadId.val());
                self.BuscarDepartamentosAsignados(self.autoridadId.val());
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
    this.AsignarPrivilegio = function (privilegioId) {
        let autoridadPrivilegio = new autorPrivilegioDTO(
            parseInt(self.autoridadId.val()),
            parseInt(privilegioId)
        );
        PostAjax("AsignarPrivilegio", "json", "POST", JSON.stringify(autoridadPrivilegio),
            function (param) {
                self.BuscarPrivilegiosNoAsignados(self.autoridadId.val());
                self.BuscarPrivilegiosAsignados(self.autoridadId.val());
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
    this.QuitarPrivilegio = function (privilegioId) {

        let autoridadPrivilegio = new autorPrivilegioDTO(
            parseInt(self.autoridadId.val()),
            parseInt(privilegioId)
        );
        PostAjax("QuitarPrivilegio", "json", "POST", JSON.stringify(autoridadPrivilegio),
            function (param) {
                self.BuscarPrivilegiosNoAsignados(self.autoridadId.val());
                self.BuscarPrivilegiosAsignados(self.autoridadId.val());
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
    this.AsignarReporte = function (reporteId) {
        let autoridadReporte = new autorReporteDTO(
            parseInt(self.autoridadId.val()),
            parseInt(reporteId)
        );
        PostAjax("AsignarReporte", "json", "POST", JSON.stringify(autoridadReporte),
            function (param) {
                self.BuscarReportesNoAsignados(self.autoridadId.val());
                self.BuscarReportesAsignados(self.autoridadId.val());
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
    this.QuitarReporte = function (reporteId) {

        let autoridadReporte = new autorReporteDTO(
            parseInt(self.autoridadId.val()),
            parseInt(reporteId)
        );
        PostAjax("QuitarReporte", "json", "POST", JSON.stringify(autoridadReporte),
            function (param) {
                self.BuscarReportesNoAsignados(self.autoridadId.val());
                self.BuscarReportesAsignados(self.autoridadId.val());
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
    this.VerAlmacenes = function (ele) {
        let autoridadId = $(ele).data("autoridadid");
        let autoridadDesc = $(ele).data("autoridaddesc");
        $("#lblAlmacenDesc").text(autoridadDesc);
        $("#txtAutoridadId").val(autoridadId);
        self.BuscarAlmacenesNoAsignados(autoridadId);
        self.BuscarAlmacenesAsignados(autoridadId);
        $("#modal-asignar-almacen").modal("show");
    }
    this.VerPantallas = function (ele) {
        let autoridadId = $(ele).data("autoridadid");
        let autoridadDesc = $(ele).data("autoridaddesc");
        $("#lblPantallaDesc").text(autoridadDesc);
        $("#txtAutoridadId").val(autoridadId);
        self.BuscarPantallasNoAsignados(autoridadId);
        self.BuscarPantallasAsignados(autoridadId);
        $("#modal-asignar-pantalla").modal("show");
    }
    this.VerDepartamentos = function (ele) {
        let autoridadId = $(ele).data("autoridadid");
        let autoridadDesc = $(ele).data("autoridaddesc");
        $("#lblDepartamentoDesc").text(autoridadDesc);
        $("#txtAutoridadId").val(autoridadId);
        self.BuscarDepartamentosNoAsignados(autoridadId);
        self.BuscarDepartamentosAsignados(autoridadId);
        $("#modal-asignar-departamento").modal("show");
    }
    this.VerPrivilegios = function (ele) {
        let autoridadId = $(ele).data("autoridadid");
        let autoridadDesc = $(ele).data("autoridaddesc");
        $("#lblPrivilegioDesc").text(autoridadDesc);
        $("#txtAutoridadId").val(autoridadId);
        self.BuscarPrivilegiosNoAsignados(autoridadId);
        self.BuscarPrivilegiosAsignados(autoridadId);
        $("#modal-asignar-privilegio").modal("show");
    }
    this.VerReportes = function (ele) {
        let autoridadId = $(ele).data("autoridadid");
        let autoridadDesc = $(ele).data("autoridaddesc");
        $("#lblReporteDesc").text(autoridadDesc);
        $("#txtAutoridadId").val(autoridadId);
        self.BuscarReportesNoAsignados(autoridadId);
        self.BuscarReportesAsignados(autoridadId);
        $("#modal-asignar-reporte").modal("show");
    }
    this.Editar = function (id) {
        self.autoridadId.val(id);
        GetAjax("Autoridad/" + id, "json", "", function (data) {
            if (data != null) {
                self.descripcion.val(data.autoridadDesc);
                self.pantalla.val(data.pantallaId);
            }
            self.ventana.modal('show');
        });
    }
    this.Borrar = function (ele) {
        let id = $(ele).data('autoridadid');
        let nombre = $(ele).data('autoridaddesc');
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
                PostAjax("Autoridad/" + id, "json", "Delete", "",
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

const mantAutoridad = new Autoridad("#formulario", "#txtAutoridadId", "#txtDescripcion", "#cmbPantalla");
mantAutoridad.Init();
