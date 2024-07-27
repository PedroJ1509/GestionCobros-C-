function PostAjax(url, dataType, type, data, callBack, callBackError) {
    $.ajax({
        url: url,
        dataType: dataType,
        type: type,
        cache: false,
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + sessionStorage.getItem('tk_mjpsoft')
        },
        async: true,
        data: data,
        success: function (jqXHR, textStatus, errorThrown) {
            callBack(jqXHR);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            
            if (jqXHR.status == 401) {
                $(location).attr('href', '/login');
            }
            else{
                callBackError(jqXHR);
            }
        }
    });
}
function PostAjaxAsync(url, dataType, type, data, callBack, callBackError) {
    $.ajax({
        url: url,
        dataType: dataType,
        type: type,
        cache: false,
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + sessionStorage.getItem('tk_mjpsoft')
        },
        async: false,
        data: data,
        success: function (jqXHR, textStatus, errorThrown) {
            callBack(jqXHR);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            
            if (jqXHR.status == 401) {
                $(location).attr('href', '/login');
            }
            else{
                callBackError(jqXHR);
            }
        }
    });
}
function GetAjax(url, dataType, data, callBack) {
    $.ajax({
        url: url,
        dataType: dataType,
        type: "GET",
        headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('tk_mjpsoft') },
        async: true,
        data: data,
        cache: false,
        success: function (data) {
            callBack(data);
        },
        error: function (data) {

            if (data.status == 404) {
                let swalWithBootstrapButtons = Swal.mixin({
                    customClass: {
                        confirmButton: 'mr-2 btn btn-success dialog-botones',
                        cancelButton: 'btn btn-danger dialog-botones'
                    },
                    buttonsStyling: false,
                });

                swalWithBootstrapButtons.fire({
                    title: "Notificación",
                    text: data.responseJSON,
                    type: 'info',
                    showCancelButton: false,
                    confirmButtonText: 'Ok',
                    showLoaderOnConfirm: true
                }).then((result) => {
                    if (result.value) {//si la respuesta es que si
                        $(location).attr('href', '/logout');
                    }
                });
                return false;
            }
            if (data.status == 401) {
                $(location).attr('href', '/login');
            }
            else {
                let swalWithBootstrapButtons = Swal.mixin({
                    customClass: {
                        confirmButton: 'mr-2 btn btn-success dialog-botones',
                        cancelButton: 'btn btn-danger dialog-botones'
                    },
                    buttonsStyling: false,
                });
                swalWithBootstrapButtons.fire(
                    'Notificacion',
                    data.responseJSON,
                    'info'
                );
                callBack(data);
                //$(location).attr('href','/dashboard');
            }
        }
    });
}
function IsEmail(email) {
    let regex = /[\w-\.]{2,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/;
    if (regex.test(email.trim()) == false) {
        return false;
    }
    else
    {
        return true;
    }
}
//Deshabilitar el boton guardar
function DeshabilitarBottonCargar(boton) {
    $(boton).attr('disabled', 'disabled');
    $(boton).css('height', '35px');
    $(boton + ' span:eq(0)').css('display', 'inline-block');
    $(boton + ' span:eq(1)').show();
    $(boton + ' span:eq(2)').hide();
}

//Habilita el boton guardar
function HabilitarBottonCargar(boton) {
    $(boton).removeAttr('disabled');
    $(boton).css('height', 'auto');
    $(boton + ' span:eq(0)').css('display', 'none');
    $(boton + ' span:eq(1)').hide();
    $(boton + ' span:eq(2)').show();
}

//Muestra Mensaje error
function MensajeError(mensaje) {
    let swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'mr-2 btn btn-success dialog-botones',
            cancelButton: 'btn btn-danger dialog-botones'
        },
        buttonsStyling: false,
    });
   
    swalWithBootstrapButtons.fire(
        "Notificación",
        mensaje,
        'error'
    );
}
//Muestra Mensaje error
function MensajeInfo(mensaje) {
    let swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'mr-2 btn btn-success dialog-botones',
            cancelButton: 'btn btn-danger dialog-botones'
        },
        buttonsStyling: false,
    });
    swalWithBootstrapButtons.fire(
        JSON.parse(sessionStorage.getItem('IdiomaUsuario_DoctorPad')).generales.mesajes.msg_titulo_notificacion,
        mensaje,
        'info'
    );
}
//Applicar formato al check
function AplicaFormatoCheckBox() {
    $('.check').each(function () {
        var ck = $(this).attr('data-checkbox') ? $(this).attr('data-checkbox') : 'icheckbox_minimal-red';
        var rd = $(this).attr('data-radio') ? $(this).attr('data-radio') : 'iradio_minimal-red';

        if (ck.indexOf('_line') > -1 || rd.indexOf('_line') > -1) {
            $(this).iCheck({
                checkboxClass: ck,
                radioClass: rd,
                insert: '<div class="icheck_line-icon"></div>' + $(this).attr("data-label")
            });
        } else {
            $(this).iCheck({
                checkboxClass: ck,
                radioClass: rd
            });
        }
    });
}
//Muestra Mensaje exitoso
function UsuarioTieneRole(rol) {
    let rolesUsuario = sessionStorage.getItem('dp_user_roles').split(',');
    let result = false;
    rolesUsuario.forEach(function (currentValue) {
        if (currentValue == rol) {
            result = true;
        }
    });
    return result;
}
function CambiarFormatoFecha(fecha) {
    var values = fecha.split("/");
    var dia = values[0];
    var mes = values[1];
    var ano = values[2];

    return ano + '-' + mes + '-' + dia;
}
function TienePermiso(permiso) {
    if (sessionStorage.getItem('dp_user_permisos') != "") {
        let arrPermisos = sessionStorage.getItem('dp_user_permisos').split(",");
        if (arrPermisos.includes(permiso)) {
            return true;
        }
        else {
            return false;
        }
    }
    else {
        return false;
    }
}
function TieneRol(rol) {
    if (sessionStorage.getItem('dp_user_roles') != "") {
        let arrRoles = sessionStorage.getItem('dp_user_roles').split(",");
        if (arrRoles.includes(rol)) {
            return true;
        }
        else {
            return false;
        }
    }
    else {
        return false;
    }
}
function notificacionExitosa(titulo, mensaje) {
    $.toast({
        heading: titulo,
        text: mensaje,
        position: 'top-right',
        loaderBg: '#ff6849',
        icon: 'success',
        hideAfter: 3500,
        allowToastClose: true,
        stack: 6
    });
}
function ObtenerNombreMes(mes) {
    var result = "";

    if (mes == 1) {
        result = "Enero";
    }
    else if (mes == 2) {
        result = "Febrero";
    }
    else if (mes == 3) {
        result = "Marzo";
    }
    else if (mes == 4) {
        result = "Abril";
    }
    else if (mes == 5) {
        result = "Mayo";
    }
    else if (mes == 6) {
        result = "Junio";
    }
    else if (mes == 7) {
        result = "Julio";
    }
    else if (mes == 8) {
        result = "Agosto";
    }
    else if (mes == 9) {
        result = "Septiembre";
    }
    else if (mes == 10) {
        result = "Octubre";
    }
    else if (mes == 11) {
        result = "Noviembre";
    }
    else if (mes == 12) {
        result = "Diciembre";
    }
    return result;
}
function ObtenerNombreMesAbr(mes) {
    var result = "";

    if (mes == 1) {
        result = "Ene";
    }
    else if (mes == 2) {
        result = "Feb";
    }
    else if (mes == 3) {
        result = "Mar";
    }
    else if (mes == 4) {
        result = "Abr";
    }
    else if (mes == 5) {
        result = "May";
    }
    else if (mes == 6) {
        result = "Jun";
    }
    else if (mes == 7) {
        result = "Jul";
    }
    else if (mes == 8) {
        result = "Ago";
    }
    else if (mes == 9) {
        result = "Sept";
    }
    else if (mes == 10) {
        result = "Oct";
    }
    else if (mes == 11) {
        result = "Nov";
    }
    else if (mes == 12) {
        result = "Dic";
    }
    return result;
}
function ObtenerNombreDia(dia) {
    var result = "";

    if (dia == 0) {
        result = "Domingo";
    }
    else if (dia == 1) {
        result = "Lunes";
    }
    else if (dia == 2) {
        result = "Martes";
    }
    else if (dia == 3) {
        result = "Miércoles";
    }
    else if (dia == 4) {
        result = "Jueves";
    }
    else if (dia == 5) {
        result = "Viernes";
    }
    else if (dia == 6) {
        result = "Sábado";
    }
    return result;
}
function generarNumero(numero) {
    return (Math.random() * numero).toFixed(0);
}
function numeroAleatorio(min, max) {
    return Math.round(Math.random() * (max - min) + min);
}
function quitarEspacios(cadena) {
    let nuevaCadena = cadena;
    while (nuevaCadena.indexOf(" ") != -1) {
        nuevaCadena = nuevaCadena.replace(" ", "-");
    }
    return nuevaCadena;
}

function isNegativo(valor) {
    if (parseFloat(valor) >= 0) {
        return false;
    }
    else {
        return true;
    }
}
function isNumerico(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}

function colorRGB() {
    var coolor = "(" + generarNumero(255) + "," + generarNumero(255) + "," + generarNumero(255) + ")";
    return "rgb" + coolor;
}

function NumericoCaracter(string) {//solo letras y numeros y los cácteres especiales que se requieran
    var out = '';
    //Se añaden las letras, números y carácteres válidos
    var filtro = '1234567890-/ ';//Caracteres validos

    for (var i = 0; i < string.length; i++)
        if (filtro.indexOf(string.charAt(i)) != -1)
            out += string.charAt(i);
    return out;
}
function CampoNumeroCaracter(selector) {//solo letras y numeros y los cácteres especiales que se requieran

    var textoInput = document.querySelector(selector);

    textoInput.oninput = function (event) {
        textoInput.value = textoInput.value.replace(/[^0-9-/ ]/g, "");
    };
}
function NumericoDecimal(string) {//solo letras y numeros y los cácteres especiales que se requieran
    var out = '';
    //Se añaden las letras, números y carácteres válidos
    var filtro = '1234567890.';//Caracteres validos

    for (var i = 0; i < string.length; i++)
        if (filtro.indexOf(string.charAt(i)) != -1)
            out += string.charAt(i);
    return out;
}
function CampoSoloLetras(selector) {//solo letras y el putno
    var textoInput = document.querySelector(selector);

    textoInput.oninput = function (event) {
        textoInput.value = textoInput.value.replace(/[^a-z.A-Z '-]/g, "");
    };
}
function CampoNumero(selector) {//solo letras y numeros y los cácteres especiales que se requieran

    var textoInput = document.querySelector(selector);

    textoInput.oninput = function (event) {
        textoInput.value = textoInput.value.replace(/[^0-9.]/g, "");
    };
}
function CampoCedula(selector) {//solo letras y numeros y los cácteres especiales que se requieran

    var textoInput = document.querySelector(selector);

    textoInput.oninput = function (event) {
        textoInput.value = textoInput.value.replace(/[^0-9 -]/g, "");
    };
}
function CampoNumeroEntero(selector) {//solo letras y numeros y los cácteres especiales que se requieran

    var textoInput = document.querySelector(selector);

    textoInput.oninput = function (event) {
        textoInput.value = textoInput.value.replace(/[^0-9]/g, "");
    };
}
function CampoNumeroFraccion(selector) {//solo letras y numeros y los cácteres especiales que se requieran

    var textoInput = document.querySelector(selector);

    textoInput.oninput = function (event) {
        textoInput.value = textoInput.value.replace(/[^0-9./]/g, "");
    };
}
function CalcularEdadMesDia(fecha) {
    var values = fecha.split("/");
    var dia = values[0];
    var mes = values[1];
    var ano = values[2];

    // cogemos los valores actuales
    var fecha_hoy = new Date();
    var ahora_ano = fecha_hoy.getYear();
    var ahora_mes = fecha_hoy.getMonth() + 1;
    var ahora_dia = fecha_hoy.getDate();

    // realizamos el calculo
    var edad = (ahora_ano + 1900) - ano;
    if (ahora_mes < mes) {
        edad--;
    }
    if ((mes == ahora_mes) && (ahora_dia < dia)) {
        edad--;
    }
    if (edad > 1900) {
        edad -= 1900;
    }

    // calculamos los meses
    var meses = 0;

    if (ahora_mes > mes && dia > ahora_dia)
        meses = ahora_mes - mes - 1;
    else if (ahora_mes > mes)
        meses = ahora_mes - mes
    if (ahora_mes < mes && dia < ahora_dia)
        meses = 12 - (mes - ahora_mes);
    else if (ahora_mes < mes)
        meses = 12 - (mes - ahora_mes + 1);
    if (ahora_mes == mes && dia > ahora_dia)
        meses = 11;

    // calculamos los dias
    var dias = 0;
    if (ahora_dia > dia)
        dias = ahora_dia - dia;
    if (ahora_dia < dia) {
        ultimoDiaMes = new Date(ahora_ano, ahora_mes - 1, 0);
        dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
    }

    var result = 0;
    let tipoEdad = "";
    if (edad > 0) {
        if (edad > 1) {
            tipoEdad = "años";
        }
        else {
            tipoEdad = "año";
        }
        result = edad;
    }
    else if (meses > 0) {
        if (meses > 1) {
            tipoEdad = "meses";
        }
        else {
            tipoEdad = "mes";
        }
        result = meses;
    }
    else {

        if (dias > 1) {
            tipoEdad = "días";
        }
        else {
            tipoEdad = "día";
        }
        result = dias;
    }

    return result + " " + tipoEdad;

}
function CalcularEdadMesDiaConsulta(fechaconsulta, fecha) {
    let fechaConsultaCompleta = fechaconsulta.split(" ");
    let fechaConsulta = fechaConsultaCompleta[0];
    let ArrfechaConsulta = fechaConsulta.split("/");

    let fecConsultaCambiada = ArrfechaConsulta[2] + "-" + ArrfechaConsulta[1] + "-" + ArrfechaConsulta[0];
    var values = fecha.split("/");
    var dia = values[0];
    var mes = values[1];
    var ano = values[2];

    // cogemos los valores actuales
    var fecha_hoy = new Date(fecConsultaCambiada + "T00:00:00");
    var ahora_ano = fecha_hoy.getYear();
    var ahora_mes = fecha_hoy.getMonth() + 1;
    var ahora_dia = fecha_hoy.getDate();

    // realizamos el calculo
    var edad = (ahora_ano + 1900) - ano;
    if (ahora_mes < mes) {
        edad--;
    }
    if ((mes == ahora_mes) && (ahora_dia < dia)) {
        edad--;
    }
    if (edad > 1900) {
        edad -= 1900;
    }

    // calculamos los meses
    var meses = 0;

    if (ahora_mes > mes && dia > ahora_dia)
        meses = ahora_mes - mes - 1;
    else if (ahora_mes > mes)
        meses = ahora_mes - mes
    if (ahora_mes < mes && dia < ahora_dia)
        meses = 12 - (mes - ahora_mes);
    else if (ahora_mes < mes)
        meses = 12 - (mes - ahora_mes + 1);
    if (ahora_mes == mes && dia > ahora_dia)
        meses = 11;

    // calculamos los dias
    var dias = 0;
    if (ahora_dia > dia)
        dias = ahora_dia - dia;
    if (ahora_dia < dia) {
        ultimoDiaMes = new Date(ahora_ano, ahora_mes - 1, 0);
        dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
    }

    var result = 0;
    let tipoEdad = "";
    if (edad > 0) {
        if (edad > 1) {
            tipoEdad = "años";
        }
        else {
            tipoEdad = "año";
        }
        result = edad;
    }
    else if (meses > 0) {
        if (meses > 1) {
            tipoEdad = "meses";
        }
        else {
            tipoEdad = "mes";
        }
        result = meses;
    }
    else {

        if (dias > 1) {
            tipoEdad = "días";
        }
        else {
            tipoEdad = "día";
        }
        result = dias;
    }

    return result + " " + tipoEdad;

}