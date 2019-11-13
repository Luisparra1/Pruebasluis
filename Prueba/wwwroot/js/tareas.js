var usu = "";
function logueo() {
    var usuario = $("#usuario").val();
    var paswword = $("#paswword").val();
    $.ajax({
        data: {
            usuario: usuario, paswword: paswword,
        },
        type: "POST",
        url: "https://localhost:5001/api/login",
        success: function (data) {
            var l = JSON.parse(data);
            
            if (l['Table'] != 0) {
                
                    usu = l['Table'][0]['usuario'];
                
                console.log(usu);
                    var html = "";
                    alert('Bienvenido al Sistema de gestion de tareas!!');
                    location.href = "https://localhost:5001/tareas/principal/" + usu,
                        $("#logueado").html(html);
                } else {
                var html = "";
                html += "<div class='alert alert-danger' role='alert'><strong>Upsss!!!</strong> Intentalo de nuevo..</div >";
                $("#logueado").html(html);
            }
        
           // console.log(data);
        },
        error: function (res) {
        }
    }); 
}
function search(id) {
    var id = $("#sel").val(); 
    usu = $("#consultar").val();
    $.ajax({
        type: "GET",
        url: "https://localhost:5001/api/consultar/" + id + "/" + usu,
        success: function (data) {
            var html = "";
            var l = JSON.parse(data);
            console.log(l['Table']);
            if (l.length != 0) {
                var html = "";
                html += "<div class='container' ><br><br>";
                html += " <h4><b>RESULTADO DE LA CONSULTA</b></h4>";
                html += " <p><u>Podra observar todos los datos de cada opcion elegida</u></p>  ";
                html += " <p><span class='label label-default'>TODOS LOS REGISTROS CON COLOR GRIS SON LAS DEL USUARIO AUTENTICADO</span></p>  ";
                html += "<div class='table table-responsive'>";
                html += "<table class='table table-hover'>";
                html += "<thead>";
                html += "<tr>";
                html += "<th>#</th>";
                html += "<th>AUTOR</th>";
                html += "<th>FECHA CREACIÓN</th>";
                html += "<th>ESTADO</th>";
                html += "<th>FECHA VENCIMIENTO</th>";
                html += "<th>DESCRIPCION</th>";
                html += "<th><span class='glyphicon glyphicon-cog'></span></th>";
                html += "</tr>";
                html += "</thead>";
                for (var i = 0; i < l['Table'].length; i++) {
                    var id = l['Table'][i]['id'];
                    var autor = l['Table'][i]['autor'];
                    var fechac = l['Table'][i]['fechac'];
                    var estado = l['Table'][i]['estado'];
                    var fechav = l['Table'][i]['fechav'];
                    //explode
                    var descripcion = l['Table'][i]['descripcion'];
                    var idusuario = l['Table'][i]['idusuario'];
                    html += "<tbody>"
                    if (idusuario == usu) {
                       var style = 'background-color:#E6E6E6;'
                        //var style = 'background-color:#e0f2f1 teal lighten-5;'
                    } else {
                       var style=''
                    }
                    html += "<tr style=" + style +">"
                    html += "<th ><span class='badge badge-secondary'>" + id; +"</span></th>";
                    html += "<th >" + autor; +"</th>";
                    html += "<th >" + fechac.replace("T00:00:00",""); +"</th>";
                    if (estado == 'si') {
                        html += "<th><span class='label label-danger' > Finalizada.</span ></th>";
                    } else {
                        html += "<th><span class='label label-default' > No ha Finalizado.</span ></th>";
                    }
                    html += "<th >" + fechav.replace("T00:00:00", ""); +"</th>";
                    html += "<th >" + descripcion; +"</th>";
                    if ((estado == 'no') && ( idusuario == usu)) {    //variable de login
                        html += "<th><a href='/tareas/actualizar/" + id + "' style='font-size: 19px; '><img src='/images/ver.png' width='27px' height='27px' /></a><a href='/tareas/borrar/" + id + "' style='font-size: 19px; '><img src='/images/eliminar.png' width='29px' height='29px' /></a></th>";
                    } else {
                        html += "<th><span class='label label-danger' >No tienes permiso o la tarea ya se encuentra Finalizada.</span ></th>";
                    }
                    html += "</tr>";
                }
            } if (l['Table']== 0) {
                html += "<th><span class='label label-danger' > Upss!! No hay Información.</span ></th>";
                $("#resultado").hide();
                $("#resultado1").show();
                $("#resultado1").html(html);
            }
            html += "</div>";
            html += "</div>";
            html += "</tbody>";
            html += "</table>";
            $("#resultado").html(html);
        },
    });
}
        function agregar() {
            var autor = $("#autor").val();
            if (autor == "") {
                $("#autor").focus();
                return false;
            }
            var fechac = $("#fechac").val();
            if (fechac == "") {
                $("#fechac").focus();
                return false;
            }
            var estado = $("#estado").val();
            if (estado == "") {
                $("#estado").focus();
                return false;
            }
            var fechav = $("#fechav").val();
            if (fechav == "") {
                $("#fechav").focus();
                return false;
            }
            var descripcion = $("#descripcion").val();
            if (descripcion == "") {
                $("#descripcion").focus();
                return false;
            }
            var idusuario = $("#crear").val(); //variable de login
            $.ajax({
                data: {
                    descripcion: descripcion, estado: estado, autor: autor, idusuario: idusuario,fechac: fechac, fechav: fechav, 
                },
                type: "POST",
                url: "https://localhost:5001/api/consultar",
                success: function (data) {
                    var html = "";
                    if (data == '1') {
                        html += "<div class='alert alert-success' role='alert'><b>HA SIDO AGREGADO CORRECTAMENTE</b></div>";
                        $("#autor").val(" ");
                        $("#fechac").val(" ");
                        $("#estado").val(" ");
                        $("#fechav").val(" ");
                        $("#descripcion").val(" ");
                    }
                    $("#agregado").html(html);
                    console.log(data);
                },
                error: function (res) {
                }
            }); 
}       
            function editar() {
                var id = $("#id").val();
                var autor = $("#autor").val();
                if (autor == "") {
                    $("#autor").focus();
                    return false;
                }
                var fechac = $("#fechac").val();
                if (fechac == "") {
                    $("#fechac").focus();
                    return false;
                }
                var estado = $("#estado").val();
                if (estado == "") {
                    $("#estado").focus();
                    return false;
                }
                var fechav = $("#fechav").val();
                if (fechav == "") {
                    $("#fechav").focus();
                    return false;
                }
                var descripcion = $("#descripcion").val();
                if (descripcion == "") {
                    $("#descripcion").focus();
                    return false;
                }
                var idusuario = $("#idusuario").val();;            //variable de login
                $.ajax({
                    data: {
                        id: id, descripcion: descripcion, estado: estado, autor: autor, idusuario: idusuario, fechac: fechac, fechav: fechav,
                    },
                    type: "PUT",
                    url: "https://localhost:5001/api/consultar",
                    success: function (data) {
                        var html = "";
                        if (data == '1') {
                            alert('Se ha actualizado exitosamente!!');
                            location.href = "https://localhost:5001/tareas/consultar/" + idusuario;
                        }
                        $("#actualizado").html(html);
                        console.log(data);
                    },
                    error: function (res) {
                    }
                }); 
            }
      
        function eliminar(id) {
            var id = $("#id").val();
            $.ajax({
                type: "DELETE",
                url: "https://localhost:5001/api/consultar/" + id,
                success: function (data) {
                    var html = "";
                    if (data == '1') {
                        html += "<div class='alert alert-danger' role='alert'><b>HA SIDO ELIMINADO CORRECTAMENTE</b></div>";
                    }
                    $("#dele").html(html);
                    console.log(data);
                },
                error: function (res) {
                }
            }); 
        }
