
var Solicitudes = [];
function CaragaSolicitud(element) {

    $.ajax({
        type: "GET",
        url: '/AprobarSolicitud/ListaSolicitud',
        success: function (data) {
            Solicitudes = data;
            if (Solicitudes.length > 0) {
                htmlSolicitud(element);
            }

        }
    })
}

function htmlSolicitud(element) {
    var $ele = $(element);
    $ele.empty();

    var $table = $('<table/>');

    $table.append('<thead><tr><th></th><th>Solitud</th><th>Fecha</th><th>Prioridad</th><th>Estado</th><th> Aprobar</th></tr></thead>');
    var $tbody = $('<tbody/>');
    $.each(Solicitudes, function (i, val) {
        var $row = $('<tr/>');
        $row.append($('<td />').html(val.numero_solicitud));
        $row.append($('<td/>').html(val.codigo_solicitud));
        $row.append($('<td/>').html(val.fecha_hora));
        $row.append($('<td/>').html(val.prioridad));
        $row.append($('<td/>').html(val.estado));
//data-toggle='modal' data-target='#myModalStatus'  
        $row.append($('<td/>').html("&nbsp;&nbsp;&nbsp;<a class='editar'  href='javascript:popupAprobar(\"" + String(val.numero_solicitud) + '#' + String(val.codigo_solicitud) + '#' + String(val.fecha_hora) + '#' + String(val.prioridad) + '#' + String(val.estado) + "\");'><i class='glyphicon glyphicon-user' title='Aprobar'></i></a>"));
        $tbody.append($row);
    });
    $table.append($tbody);
    $ele.append($table);
}
CaragaSolicitud($('#tabSolicitud'));


function mensajeConfirmacion() {

    $('<div></div>').appendTo('body')
    .html('<div><h6>Operación realizada satisfactoriamente.</h6></div>')
    .dialog({
        modal: true,
        title: 'Pet Center',
        zIndex: 10000,
        autoOpen: true,
        width: '250px',
        resizable: false,
        buttons: {
            Ok: function () {


                $(this).dialog("close");
            }
        },
        close: function (event, ui) {
            $(this).remove();
        }
    });
}

function eliminaSolcitud(idSolicitud) {
    $("#txtId").val(idSolicitud);

    $('<div></div>').appendTo('body')
    .html('<div><h6>Eliminar Solicitud</h6></div>')
    .dialog({
        modal: true,
        title: 'Pet Center',
        zIndex: 10000,
        autoOpen: true,
        width: '250px',
        resizable: false,
        buttons: {
            Si: function () {
                $("#btnElinarSolicitud").click();

                $(this).dialog("close");
            },
            No: function () {
                $(this).dialog("close");
            }
        },
        close: function (event, ui) {
            $(this).remove();
        }
    });


}

function enviaAprobar(idSolicitud) {
    $("#txtId").val(idSolicitud);
    $("#btnAprobarSolicitud").click();
}

function popupAprobar(idSolicitud) {
    var str = idSolicitud;
    var res = str.split('#');

    var numeroSolicitud = res[0];
    var codigoSolicitud = res[1];
    var fechaSolicitud = res[2];
    var prioridadSolicitud = res[3];
    var estadoSolicitud = res[4];
   
    $("#txtId").val(numeroSolicitud);
    $("#txtCodigo").val(codigoSolicitud);
    $("#txtFecha").val(fechaSolicitud);

    $("#txtPrioridad").val(prioridadSolicitud);
    $("#txtEstado").val(estadoSolicitud);
   
    $("#btnAprobarSolicitud").click();
    $("#myModal").modal("show");
}

function editarSolicitud(nroSolicitud) {

    if (nroSolicitud != 0) {
        $.ajax({
            type: "GET",
            url: '/Solicitud/EditarSolicitud',
            data: { 'numero_solicitud': nroSolicitud },
            success: function (resrult) {

                $.each(resrult, function (i, val) {
                    $('#txtCodigo').val(val.codigo_solicitud);
                    $('#txtId').val(val.numero_solicitud);
                    $('#txtFecha').val(val.fecha_hora);
                    $('#cboPrioridad').val(val.codigo_prioridad);
                });
            },
            error: function (resrult) {
                alert('Seleccione un registro para editar');
            }
        })
    }

}

function statusSolcitud(nroSolicitud) {

    $("#txtId").val(nroSolicitud);
    $("#btnStatus").click();
    $("#myModalStatus").modal("show");

}

var StatusSolicitud = [];


function htmlStatusSolicitud(element) {
    var $ele = $(element);
    $ele.empty();

    var $table = $('<table/>');

    $table.append('<thead><tr><th>Solitud</th><th>Fecha de Operacion</th><th>Empleado</th><th>Estado</th></tr></thead>');
    var $tbody = $('<tbody/>');
    $.each(StatusSolicitud, function (i, val) {
        var $row = $('<tr/>');
        $row.append($('<td/>').html(val.codigo_solicitud));
        $row.append($('<td/>').html(val.fecha_operacion));
        $row.append($('<td/>').html(val.emlpeado));
        $row.append($('<td/>').html(val.estado));
        $tbody.append($row);
    });
    $table.append($tbody);
    $ele.append($table);
}



$(document).ready(function () {

    $('#btnAprobarSolicitud').click(function () {
      
        $('#tabDetaleSolicitud').empty();

        var aprobarDetalle = [];
        var nroSolicitud = parseInt($("#txtId").val(), 10);



        //detalle
        var $ele = $('#tabDetaleSolicitud');
        var $table = $('<table/>');
        $table.append('<thead><tr><th>Item</th><th>Código</th><th>Recurso</th><th>Cantidad Solicitada</th><th>Cantidad Aprobada</th></tr></thead>');
        var $tbody = $('<tbody/>');

        $.ajax({
            type: "GET",
            url: '/AprobarSolicitud/ListaDetalleSolicitudAprobar',
            data: { 'numero_solicitud': nroSolicitud },
            success: function (resrult) {
                aprobarDetalle = resrult;
                if (aprobarDetalle.length > 0) {

                    //<input type="text" class="cantidad select"  id="txtCantidad"  name="txtCantidad"  placeholder="0"  style="width:60px">
                    //                                     <span class="error">Ingrese cantidad</span>

                    $.each(aprobarDetalle, function (i, val) {
                        var cantidad = "<input type='text' class='cantidad select'  id='txtCantidad'  name='txtCantidad' value='" + val.cantidad + "'    style='width:80px'> <span class='error'>Ingrese cantidad</span>";

                        var $row = $('<tr/>');
                        $row.append($('<td/>').html(val.item));
                        $row.append($('<td/>').html(val.codigo_recurso));
                        $row.append($('<td/>').html(val.recurso));
                        $row.append($('<td/>').html(val.cantidad));
                        $row.append($('<td/>').html(cantidad));
                        $tbody.append($row);
                    });
                    $table.append($tbody);
                    $ele.append($table);
                    aprobarDetalle = [];
                }
            }
        })
    });

    //btnAprobar
    //btnRechazar

    $('#btnAprobar').click(function () {
        debugger;
        var validaDatos = true;
        if ($("#txtId").val() == '0') {
            alert('Seleccione un registro');
            validaDatos = false;
        }

        $('#numeroSolicitudError').text('');
        var detalle = [];
        var errorCount = 0;
        $('#tabDetaleSolicitud tbody tr').each(function (index, ele) {
            if (
                (parseInt($('.cantidad', this).val()) || 0) == 0
                ) {
                errorCount++;
                $(this).addClass('error');
            } else {
                var itemSolicitud = {
                    item: parseInt(this.cells[0].innerHTML),
                    cantidad_aprobada: parseInt($('.cantidad', this).val())
                }
                detalle.push(itemSolicitud);
            }
        })

        var data = {
            numero_solicitud: $('#txtId').val().trim(),
            codigo_estado: '3',
            GPC_DetalleDeSolicitud: detalle
        }

        if (validaDatos) {
            $.ajax({
                url: '/AprobarSolicitud/NotificarAprobacionORechazo',
                type: "POST",
                data: JSON.stringify(data),
                dataType: "JSON",
                contentType: "application/json",
                success: function (d) {
                    if (d.status == true) {
                        mensajeConfirmacion();
                        CaragaSolicitud($('#tabSolicitud'));
                        $('#txtId').val('0');
                       // alert('Se ha compleado la operacion satisfactoriamente.');
                        $("#myModal").modal("hide");
                    }
                    else {
                        alert('Error: Al Aprobar Solicitud.');
                    }
                },
                error: function () {
                    alert('Error: Al Aprobar Solicitud.');
                }
            });
        }
    });

    $('#btnRechazar').click(function () {

        var validaDatos = true;
        if ($("#txtId").val() == '0') {
            alert('Seleccione un registro');
            validaDatos = false;
        }

        var detalle = [];
        var data = {
            numero_solicitud: $('#txtId').val().trim(),
            codigo_estado: '4',
            GPC_DetalleDeSolicitud: detalle
        }

        if (validaDatos) {
            $.ajax({
                url: '/AprobarSolicitud/NotificarAprobacionORechazo',
                type: "POST",
                data: JSON.stringify(data),
                dataType: "JSON",
                contentType: "application/json",
                success: function (d) {
                    if (d.status == true) {
                        mensajeConfirmacion();
                        CaragaSolicitud($('#tabSolicitud'));
                        $('#txtId').val('0');
                       // alert('Se ha compleado la operacion satisfactoriamente.');
                        $("#myModal").modal("hide");

                    }
                    else {
                        alert('Error: Rechazar Solicitud.');
                    }
                },
                error: function () {
                    alert('Error: Rechazar Solicitud.');
                }
            });
        }
    });

    $('#btnCerar').click(function () {
        $('#txtCodigo').val('');
        $("#txtId").val(0);
        $("#txtFecha").val('');
        $("#txtPrioridad").val('');
        $("#txtEstado").val('');
        $('#tabDetaleSolicitud').empty();

    });

    //NotificarAprobacionORechazo
});


