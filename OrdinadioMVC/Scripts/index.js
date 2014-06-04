$(document).ready(function () {

    $("#acceder").click(function () {
        if ($("#usuario").val() != "" && $("#contrasena").val() != "") {
            $.ajax({
                type: "POST",
                url: "Home",
                data: { "usuario": $("#usuario").val(), "contrasena": $("#contrasena").val() },
                //data: "usuario=" + $("#usuario").val() + "&contrasena=" + $("#contrasena").val(),
                dataType: "json",
                success: function (data) {
                    if (data.isRedirect) {
                        window.location.href = data.redirectUrl;
                    } else {
                        $("#mensaje-error").html(data);
                    }
                }
            });
        } else {
            $("#mensaje-error").html("Usuario/Contraseña no deben estar vacios");
        }
    });


});