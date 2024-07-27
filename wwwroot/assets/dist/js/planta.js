function Planta(tabla) {
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
                url: "/listadoPlantas",
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
                "targets": -1,
                "visible": true,
                "orderable": false,
                "className": 'all',
                "data": null,
                "render": function (data) {
                    return `<div class="btn-action">
                                <button type="button" data-plantaid=${data.plantaId} onclick="mantPlanta.Editar(${data.plantaId})" class="btn btn-add btn-sm btn-action-mjp btn-action-editar" ><i class="fa fa-pencil"></i></button>
                                <button type="button" data-plantaid=${data.plantaId} data-plantadesc="${data.plantaDesc}" onclick="mantPlanta.Borrar(this)" class="btn btn-danger btn-sm btn-action-mjp btn-action-borrar" ><i class="fa fa-trash-o"></i> </button>
                            </div>`;
                }
            },
            {
                "targets": -2,
                "visible": true,
                "orderable": true,
                "className": 'all',
                "data": null,
                "render": function (data) {
                    if (data.plantaEstatus == true)
                    {
                        return `<span class="label-custom label label-default">Activo
                        </span>`;
                    }
                    else{
                        return `<span class="label-danger label label-default">Inactivo
                            </span>`;
                    }
                }
            }],
            columns: [
                { "data": "plantaId" },
                { "data": "plantaDesc" },
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
    
    
    const planta = new Planta("#dataTable");
    planta.Init();
});


