function Encriptar(usuario) {
    this.usuario = $(usuario);

    
    this.EnviarClave = function () {
        if (self.usuario.val() != "") {
            self.usuario.removeClass('is-invalid');
            DeshabilitarBottonCargar("#btnGuardar");
            
            PostAjax("EncriptarClave/"+self.usuario.val(),"json","POST", "", 
                function (param) {
                    HabilitarBottonCargar("#btnGuardar");
                    let swalWithBootstrapButtons = Swal.mixin({
                        customClass: {
                            confirmButton: 'mr-2 btn btn-success dialog-botones',
                            cancelButton: 'btn btn-danger dialog-botones'
                        },
                        buttonsStyling: false,
                    });
                    swalWithBootstrapButtons.fire(
                        'Excelente',
                        "Clave Encriptada Exitosamente.",
                        'success'
                    );
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
        }else {
            self.usuario.addClass('is-invalid');
            self.usuario.focus();
        }
        return false;
    }
    let self = this;
}
const encriptar = new Encriptar("#txtUsuario");
$(document).ready(function(){

    var height = $(window).height();

    $('.content').css('min-height',height);

});
