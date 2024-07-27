function usuarioLoginDTO(Usuario,Contrasena){
    this.Usuario = Usuario;
    this.Contrasena = Contrasena;
}
function Login(usuario,contrasena) {
    this.usuario = $(usuario);
    this.contrasena = $(contrasena);

    this.Init = function() {
        $("input,select").keypress(function (e) {
            var keycode = (event.keyCode ? event.keyCode : event.which);
            var sigfocus = $(this).data('sigfocus');
            if (keycode == '13') {
                $("#"+sigfocus).focus();
                return false;
            }
        });
        $("#txtContrasena").keypress(function (e) {
            var keycode = (event.keyCode ? event.keyCode : event.which);
            var sigfocus = $(this).data('sigfocus');
            if (keycode == '13') {
                self.EntrarSistema();
                return false;
            }
        });
    }

    this.EntrarSistema = function() {
        if (self.Validar())
        {
            DeshabilitarBottonCargar("#btnEntrar");
            let usuarioLogin  = new usuarioLoginDTO(
                self.usuario.val(),
                self.contrasena.val()
            );
            PostAjax("Login","json","Post", JSON.stringify(usuarioLogin), 
                function (param) {
                    HabilitarBottonCargar("#btnEntrar");
                   //console.log(param);
                    sessionStorage.setItem('tk_mjpsoft', param.tk_mjpsoft.result.token);
                    sessionStorage.setItem('usuario_ID', param.usuario_ID);
                    sessionStorage.setItem('usuario_Nombre', param.usuario_Nombre);
                    sessionStorage.setItem('usuario_SiAnularFactura', param.usuario_SiAnularFacturan);
                    sessionStorage.setItem('usuario_SiBorrarFactura', param.usuario_SiBorrarFactura);
                    sessionStorage.setItem('usuario_SiCajero', param.usuario_SiCajero);
                    sessionStorage.setItem('usuario_SiFacCliSob', param.usuario_SiFacCliSob);
                    sessionStorage.setItem('usuario_SiFacFacVen', param.usuario_SiFacFacVen);
                    sessionStorage.setItem('usuario_SiImpuesto', param.usuario_SiImpuesto);
                    sessionStorage.setItem('usuario_SiModCredCliente', param.usuario_SiModCredCliente);
                    sessionStorage.setItem('usuario_SiPreFactura', param.usuario_SiPreFactura);
                    sessionStorage.setItem('usuario_SiReAbrirCompra', param.usuario_SiReAbrirCompra);
                    sessionStorage.setItem('usuario_SiReAbrirFactura', param.usuario_SiReAbrirFactura);
                    sessionStorage.setItem('autoridad_ID', param.autoridad_ID);
                    sessionStorage.setItem('almacen_ID', param.almacen_ID);
                    window.location.href = "/"
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
                    HabilitarBottonCargar("#btnEntrar");
                }
            ); 
        }
        return false;
    }

    this.Validar = function() {
        let result = true;
        if (self.usuario.val() == ""){
            self.usuario.addClass('is-invalid');
            self.usuario.focus();
            result = false;
        }else{
            self.usuario.removeClass('is-invalid');
        }
        if (self.contrasena.val() == ""){
            self.contrasena.addClass('is-invalid');
            self.contrasena.focus();
            result = false;
        }else{
            self.contrasena.removeClass('is-invalid');
        }
        return result;
    }

    let self = this;
}

const login = new Login("#txtUsuario","#txtContrasena");
login.Init();