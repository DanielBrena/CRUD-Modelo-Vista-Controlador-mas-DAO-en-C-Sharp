$(document).ready(function () {
    var mostrar = false;

    findAll();
    $("#lista li").live('click', function () {
        $("#cabecera-mensaje").css("display", "none");
        if (!mostrar) { $("#contenido-visible").css("display", "block"); mostrar = !mostrar; }
        findById($(this).data('id').toString());
    });

    $("#actualizar").live('click', function () {
        $("#contenido-visible").css("display", "none");
        $("#contenido-editable").css("display", "block");
    });

    $("#cancelar").live('click', function () {
        $("#contenido-visible").css("display", "block");
        $("#contenido-editable").css("display", "none");
    });

    $("#eliminar").live('click', function () {
        var eliminar = confirm("Desea eliminar el usuario?");
        if (eliminar) {
            $("#cabecera-mensaje").css("display", "block");
            deleteById($("#id-editable").val());
            findAll();
            clear();
        }
    });

});

function findAll() {
    $("#lista li").remove();
    $.ajax({
        url: "Principal/FindAll",
        type: "GET",
        dataType: "ajax",
        success: function (data) {
            $.each(JSON.parse(data), function (id, val) {
                $("#lista").append('<li data-id="'+val.id+'" class="lista-item">' + val.usuario + '<li>');
            });
        }
    });

}

function findById(id) {
    $.ajax({
        url: "Principal/FindById",
        data: {id:id},
        type: "GET",
        dataType: "ajax",
        success: function (data) {
            showDetails(data);
        }

    });

}

function deleteById(id) {
    $.ajax({
        url: "Principal/DeleteById",
        data: { id: id },
        type: "POST",
        dataType: "ajax",
        success: function (data) {
            data = JSON.parse(data);
            if (data.eli = 1) {
                $("#cabecera-mensaje").html("Se ha eliminado el Usuario.");
                
            } else {
                $("#cabecera-mensaje").html("No se elimino el Usuario.");
            }
        }
    });
}
function showDetails(data) {

    data = JSON.parse(data);
    $("#id-visible").html(data.id);
    $("#nombre-visible").html(data.nombre);
    $("#usuario-visible").html(data.usuario);
    $("#contrasena-visible").html(data.contrasena);
    $("#estatus-visible").html(data.estatus);
    $("#perfil-visible").html(data.perfil_id.nombre);

    $("#id-editable").val(data.id);
    $("#nombre-editable").val(data.nombre);
    $("#usuario-editable").val(data.usuario);
    $("#contrasena-editable").val(data.contrasena);
    $("#estatus-editable").val(data.estatus);
    $("#estatus-editable").html(data.estatus);
    $("#perfil-editable").val(data.perfil_id.nombre);
    $("#perfil-editable").html(data.perfil_id.nombre);
}

function clear() {

   
    $("#id-visible").html("");
    $("#nombre-visible").html("");
    $("#usuario-visible").html("");
    $("#contrasena-visible").html("");
    $("#estatus-visible").html("");
    $("#perfil-visible").html("");

    $("#id-editable").val("");
    $("#nombre-editable").val("");
    $("#usuario-editable").val("");
    $("#contrasena-editable").val("");
    $("#estatus-editable").val("");
    $("#estatus-editable").html("");
    $("#perfil-editable").val("");
    $("#perfil-editable").html("");
}