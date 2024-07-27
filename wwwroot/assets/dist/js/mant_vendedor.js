function vendedorDTO(VendedorId, VendedorNombre, 
    VendedorEstatus,VendedorCodigo)
{
    this.VendedorId = VendedorId;
    this.VendedorNombre = VendedorNombre;
    this.VendedorEstatus = VendedorEstatus;
    this.VendedorCodigo = VendedorCodigo;
}

function Vendedor(ventana,vendedorId,nombre,activo,codigo) {
    this.ventana = $(ventana);
    this.vendedorId = $(vendedorId);
    this.nombre = $(nombre);
    this.activo = $(activo);
    this.codigo = $(codigo);

    this.Init = function () {

        self.ventana.on('shown.bs.modal', function (e) {
            self.nombre.focus();
            self.nombre.select();
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

        self.vendedorId.val("0");
        self.activo.prop('checked', true);
    }
    this.Validar = function() {
        let result = true;
        if (self.nombre.val() == ""){
            self.nombre.addClass('is-invalid');
            self.nombre.focus();
            result = false;
        }else{
            self.nombre.removeClass('is-invalid');
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
            let vendedor = new vendedorDTO(
                parseInt(self.vendedorId.val()),
                self.nombre.val(),
                self.activo.prop('checked'),
                self.codigo.val()
            );
            let type = "";
            let url = "Vendedor";
            if (parseInt(self.vendedorId.val()) == 0){
                type = "POST";
            }
            else{
                type = "PUT";
            }
            PostAjax(url,"json",type, JSON.stringify(vendedor), 
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
        self.vendedorId.val(id);
        GetAjax("Vendedor/"+id, "json", "", function (data) {
            if (data != null){
                self.nombre.val(data.vendedorNombre);
                self.activo.prop('checked',data.vendedorEstatus);
                self.codigo.val(data.vendedorCodigo);
            }
            self.ventana.modal('show');
        });
    }
    this.Borrar = function(ele) {
        let id = $(ele).data('vendedorid');
        let nombre = $(ele).data('vendedornombre');
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
                    PostAjax("Vendedor/"+id,"json","Delete", "", 
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

const mantVendedor = new Vendedor("#formulario","#txtVendedorId", "#txtDescripcion","#chkActivo","#txtCodigo");
mantVendedor.Init();
