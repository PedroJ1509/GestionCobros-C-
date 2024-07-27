function Autoridad(tabla) {
    this.tabla = $(tabla);

    this.Init = function () {
        self.InicializarTabla();

    }
    this.InicializarTabla = function () {
        table = self.tabla.DataTable({
            responsive: true,
            destroy: true,
            searching: true,
            paging: true,
            "drawCallback": function (settings) {
            },
            dom: 'Bfrtip',
            buttons: [
                { extend: 'pdfHtml5', footer: true 
            },
                { extend: 'excelHtml5', footer: true },
                { extend: 'csvHtml5', footer: true }
            ],
            ajax: {
                method: "get",
                url: "/listadoAutoridad",
                dataSrc: "",
                contentType: "application/json; charset=utf-8",
                'Authorization': 'Bearer ' + sessionStorage.getItem('tk_mjpsoft'),
                dataType: "json",
                data: function (data) {
                    return data;
                },
                async: true,
                cache: false,
                error: function (jqXHR, textStatus, errorThrown) {
                    
                    swal({
                        title: "Error",
                        text: jqXHR.error,
                        type: 'error'
                    });
                    return false;
                }
            },
            columnDefs: [{
                "targets": -2,
                "visible": true,
                "orderable": false,
                "className": 'all',
                "data": null,
                "render": function (data) {
                    return `<div class="btn-action">
                                <button type="button" data-autoridadid=${data.autoridadId} onclick="mantAutoridad.Editar(${data.autoridadId})" class="btn btn-add btn-sm btn-action-mjp btn-action-editar" ><i class="fa fa-pencil"></i></button>
                                <button type="button" data-autoridadid=${data.autoridadId} data-autoridaddesc="${data.autoridadDesc}" onclick="mantAutoridad.Borrar(this)" class="btn btn-danger btn-sm btn-action-mjp btn-action-borrar" ><i class="fa fa-trash-o"></i> </button>
                            </div>`;
                }
            },
            {
                "targets": -1,
                "visible": true,
                "orderable": false,
                "className": 'all',
                "data": null,
                "render": function (data) {
                    return `<div class="btn-group m-b-5">
                                <button type="button" data-toggle="dropdown" class="btn dropdown-toggle btn-inverse btn-sm btn-action-mjp">Acciones
                                <span class="caret"></span>
                                </button>
                                <div class="dropdown-menu border-drop" >
                                    <a class="dropdown-item" data-autoridadid=${data.autoridadId} data-autoridaddesc="${data.autoridadDesc}" onclick="mantAutoridad.VerAlmacenes(this)" href="#">Asignar almacen</a>
                                    <a class="dropdown-item" data-autoridadid=${data.autoridadId} data-autoridaddesc="${data.autoridadDesc}" onclick="mantAutoridad.VerPantallas(this)" href="#">Asignar pantallas</a>
                                    <a class="dropdown-item" data-autoridadid=${data.autoridadId} data-autoridaddesc="${data.autoridadDesc}" onclick="mantAutoridad.VerDepartamentos(this)" href="#">Asignar Depto.</a>
                                    <a class="dropdown-item" data-autoridadid=${data.autoridadId} data-autoridaddesc="${data.autoridadDesc}" onclick="mantAutoridad.VerPrivilegios(this)" href="#">Asignar Priv.</a>
                                    
                                </div>
                            </div>
                            `;
                            // <a class="dropdown-item" data-autoridadid=${data.autoridadId} data-autoridaddesc="${data.autoridadDesc}" onclick="mantAutoridad.VerReportes(this)" href="#">Asigar Reportes</a>
                }
            }],
            columns: [
                { "data": "autoridadId" },
                { "data": "autoridadDesc" },
                { "data": "pantallaDesc" },
                { "defaultContent": '' },
                { "defaultContent": '' }
            ],
            "language": {
                "url": "https://cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json"
            }
        });
    }

    let self = this;
}


$(document).ready(function(){

    var height = $(window).height();

    $('.content').css('min-height',height);
    
    
    const autoridad = new Autoridad("#dataTable");
    autoridad.Init();
});


