var Principal = {};

var id;
var usuario = {};
var perfil = {};
Principal.init = function () {

    Principal.modulo.searchUsuario.init();
    Principal.modulo.findAllUsuarios.init();
    Principal.modulo.eventoLista.init();
    Principal.modulo.eventoGuardar.init();
    Principal.modulo.eventoEliminar.init();
    Principal.modulo.eventoAgregar.init();
    Principal.modulo.cancelarBusqueda.init();
    Principal.modulo.addPerfil.init();
    


}

Principal.modulo = {
    findAllUsuarios: {},
    eventoLista: {},
    cargaAgregar: {},
    findByIdUsuario: {},
    llenarCamposUsuario: {},
    eventoEliminar: {},
    eventoAgregar: {},
    eventoGuardar: {},
    borrarCampoEditable: {},
    findAllPerfiles: {},
    deleteByIdUsuario: {},
    addUsuario: {},
    updateUsuario: {},
    cargaUsuario: {},
    cargaPerfil:{},
    llenarActivo: {},
    removerRestriccion: {},
    searchUsuario: {},
    cancelarBusqueda: {},
    addPerfil: {}
};

/*----FindAllUsuarios---*/
Principal.modulo.findAllUsuarios.init = function () {
    
    $("#lista li").remove();
    $.ajax({
        url: "Principal/FindAllUsuarios",
        type: "GET",
        dataType: "ajax",
        success: function (data) {
            $.each(JSON.parse(data), function (id, val) {
                $("#lista").append('<li data-id="' + val.id + '" class="lista-item">' + val.usuario + '<li>');
            });
        }
    });
}

/*----cancelarBusqueda----*/
Principal.modulo.cancelarBusqueda.init = function () {
    $("#btn-cancelar").live('click', function () {
        $("#buscar-usuario").val("");
        Principal.modulo.findAllUsuarios.init();
    });
}

/*-----searchUsuario----*/
Principal.modulo.searchUsuario.init = function () {
    $(document).ready(function () {
        $("#buscar-usuario").keyup(function () {
            var busqueda = $(this).val();
            $("#lista li").remove();
            $.ajax({
                url: "Principal/Search",
                data:{s:busqueda},
                type: "GET",
                dataType: "ajax",
                success: function (data) {
                    $.each(JSON.parse(data), function (id, val) {
                        $("#lista").append('<li data-id="' + val.id + '" class="lista-item">' + val.usuario + '<li>');
                    });
                }
            });
        });
    });
    
}
/*----removerRestriccioon---*/
Principal.modulo.removerRestriccion.init = function () {

    $("#nombre-editable").removeAttr("disabled");
    $("#usuario-editable").removeAttr("disabled");
    $("#estatus-editable").removeAttr("disabled");
    $("#perfil-editable").removeAttr("disabled");

    $("#nombre-editable-2").removeAttr("disabled");
    $("#descripcion-editable").removeAttr("disabled");
    $("#estatus-editable-2").removeAttr("disabled");
}

/*------EventoLista------*/
Principal.modulo.eventoLista.init = function () {
    $("#lista li").live('click', function () {

        Principal.modulo.removerRestriccion.init();
        $("#eliminar").css("display", "block");
        $("#contrasena-editable").attr("disabled","disabled");
        $("#cabecera-mensaje").css("display", "none");
        id = $(this).data('id').toString();
        Principal.modulo.findByIdUsuario.init($(this).data('id').toString());
    });

}
/*----eventoGuardar----*/
Principal.modulo.eventoGuardar.init = function () {
    $("#guardar").live('click', function () {

        if ($("#id-editable").val() == '') {
            //Crear
            if ($("#usuario-editable").val() != '' && $("#nombre-editable").val() != '' && $("#contrasena-editable").val() != '' ) {
                Principal.modulo.cargaUsuario.init();
                Principal.modulo.addUsuario.init();
                Principal.modulo.borrarCampoEditable.init();
                console.log("guardar");
            } else {
                alert("Hay unos campos vacios");
            }
        } else {
            //Actualizar
            if ($("#usuario-editable").val() != '' && $("#nombre-editable").val() != '') {
                Principal.modulo.cargaUsuario.init();
                Principal.modulo.updateUsuario.init();
                Principal.modulo.findAllUsuarios.init();


                $("#cabecera-mensaje").css("display", "block");

                //Principal.modulo.findAllPerfiles.init();
                console.log("actualizar");
            } else {
                alert("Hay campos vacios");
            }

        }

    });


}

/*----FindByIdUsuario-----*/
Principal.modulo.findByIdUsuario.init = function (id) {
    $.ajax({
        url: "Principal/FindByIdUsuario",
        data: { id: id },
        type: "GET",
        dataType: "json",
        success: function (data) {
            Principal.modulo.llenarCamposUsuario.init(data);
        }
    });
}

/*----findAllPerfiles----*/
Principal.modulo.findAllPerfiles.init = function (idn) {
    if (idn == null) { $("#perfil-editable").empty(); }
    $.ajax({
        url: "Principal/FindAllPerfiles",
        type: "GET",
        dataType: "ajax",
        success: function (data) {
            $.each(JSON.parse(data), function (id, val) {
                if (id != null) {
                    if (idn != val.id) {
                        $("#perfil-editable").append($('<option></option>').attr('value', val.id).text(val.nombre));
                    }
                } else {
                    $("#perfil-editable").append($('<option></option>').attr('value', val.id).text(val.nombre))
                }

            });
        }
    });
}

/*----deleteByIdUsuario----*/
Principal.modulo.deleteByIdUsuario.init = function (id) {
    $.ajax({
        url: "Principal/DeleteByIdUsuario",
        data: { id: id },
        type: "POST",
        dataType: "ajax",
        success: function (data) {
            if (data.eli = 1) {
                $("#cabecera-mensaje").html("Se ha eliminado el Usuario.");

            } else {
                $("#cabecera-mensaje").html("No se elimino el Usuario.");
            }
        }
    });
}

/*----addUsuario----*/
Principal.modulo.addUsuario.init = function () {

    $.ajax({
        url: "Principal/AddUsuario",
        data: usuario,
        type: "POST",
        dataType: "json",
        success: function (data) {
            if (data.upd = 1) {
                $("#cabecera-mensaje").html("Se agrego un nuevo Usuario.");
                Principal.modulo.findAllUsuarios.init();
            } else {
                $("#cabecera-mensaje").html("No se guardo el Usuario.");
            }
        }
    });
}

/*----addPerfil----**/
Principal.modulo.addPerfil.init = function () {
    $("#guardar-2").live('click', function () {
        Principal.modulo.cargaPerfil.init();

        if ($("#nombre-editable-2").val() != '') {
            $.ajax({
                url: "Principal/Addperfil",
                data: perfil,
                type: "POST",
                dataType: "json",
                success: function (data) {
                    if (data.upd = 1) {
                        $("#cabecera-mensaje").html("Se agrego un nuevo Perfil.");

                        Principal.modulo.findAllPerfiles.init();
                        Principal.modulo.borrarCampoEditable.init();
                    } else {
                        $("#cabecera-mensaje").html("No se guardo el Perfil.");
                    }
                }
            });
        } else {
            alert("Hay campos vacios");
        }
    });
}
/*----updateUsuario----*/
Principal.modulo.updateUsuario.init = function () {
    $.ajax({
        url: "Principal/UpdateUsuario",
        data: usuario,
        type: "POST",
        dataType: "json",
        success: function (data) {
            if (data.upd = 1) {
                $("#cabecera-mensaje").html("Se actualizo el Usuario.");

            } else {
                $("#cabecera-mensaje").html("No se actualizo el Usuario.");
            }
        }
    });

}

/*-----llenarCamposUsuario-----*/
Principal.modulo.llenarCamposUsuario.init = function (data) {
    Principal.modulo.borrarCampoEditable.init();


    //  data = JSON.parse(data);
    $("#id-editable").val(data.id);
    $("#nombre-editable").val(data.nombre);
    $("#usuario-editable").val(data.usuario);
    $("#contrasena-aux").val(data.contrasena);
    $("#contrasena-editable").val(data.contrasena);

    // $("#estatus-editable").empty();
    if (data.estatus == 0) {
        $("#estatus-editable").append($('<option></option>').attr('value', '0').text("0"));
        $("#estatus-editable").append($('<option></option>').attr('value', '1').text("1"));
    } else {
        $("#estatus-editable").append($('<option></option>').attr('value', '1').text("1"));
        $("#estatus-editable").append($('<option></option>').attr('value', '0').text("0"));
    }
    //$("#perfil-editable").empty();
    $("#perfil-editable").append($('<option></option>').attr('value', data.perfil_id.id).text(data.perfil_id.nombre));
    Principal.modulo.findAllPerfiles.init(data.perfil_id.id);
}


/*----eventoAgregar----*/
Principal.modulo.eventoAgregar.init = function () {
    $("#btn-agregar").live('click', function () {
        Principal.modulo.removerRestriccion.init();
        Principal.modulo.cargaAgregar.init();

    });
}
/*-----cargaAgregar----*/
Principal.modulo.cargaAgregar.init = function(){
        Principal.modulo.borrarCampoEditable.init();
        $("#contrasena-editable").removeAttr("disabled");
        Principal.modulo.eventoAgregar.init();

        $("#eliminar").css("display", "none");
        Principal.modulo.llenarActivo.init();
        Principal.modulo.findAllPerfiles.init();
}

/*----eventoEliminar----*/
Principal.modulo.eventoEliminar.init = function () {

    $("#eliminar").live('click', function () {
        var eliminar = confirm("Desea eliminar el usuario?");
        if (eliminar) {
            $("#cabecera-mensaje").css("display", "block");
            Principal.modulo.deleteByIdUsuario.init(id);
            Principal.modulo.findAllUsuarios.init();
   
        }
    });
}



/*----cargaUsuario----*/
Principal.modulo.cargaUsuario.init = function () {
    usuario.id = $("#id-editable").val();
    usuario.nombre = $("#nombre-editable").val();
    usuario.usuario = $("#usuario-editable").val();
    usuario.contrasena = $("#contrasena-editable").val();
    usuario.estatus = $("#estatus-editable").val();
    usuario.perfil_id = $("#perfil-editable").val();
}

/*----cargaPerfil----*/
Principal.modulo.cargaPerfil.init = function () {
    perfil.id = $("#id-editable-2").val();
    perfil.nombre = $("#nombre-editable-2").val();
    perfil.descripcion = $("#descripcion-editable").val();
    perfil.estatus = $("#estatus-editable-2").val();
 
}

/*---llenarActivo---*/
Principal.modulo.llenarActivo.init = function () {
    $("#estatus-editable").empty();
    $("#estatus-editable").trigger("chosen:update");
    $("#estatus-editable").append($('<option></option>').attr('value', '0').text("0"));
    $("#estatus-editable").append($('<option></option>').attr('value', '0').text("1"));
}

/*---borrarCampoEditable----*/

Principal.modulo.borrarCampoEditable.init = function () {
    $("#id-editable").val("");
    $("#nombre-editable").val("");
    $("#usuario-editable").val("");
    $("#contrasena-editable").val("");

    $("#estatus-editable").empty();
    $("#estatus-editable").trigger("chosen:update");
   
    $("#perfil-editable").empty();
    $("#perfil-editable").trigger("chosen:update");

    $("#nombre-editable-2").val("");
    $("#descripcion-editable").val("");
}

Principal.init();
    