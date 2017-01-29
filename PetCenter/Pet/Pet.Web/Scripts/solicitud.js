var Estados = [];
function CaragaEstado(element) {
    if (Estados.length == 0) {
        $.ajax({
            type: "GET",
            url: '/Solicitud/ListaEstado',
            success: function (data) {
                Estados = data;
                htmlEstado(element);
            }
        })
    }
    else {
        htmlEstado(element);
    }
}
function htmlEstado(element) {
    var $ele = $(element);
    $ele.empty();
    $.each(Estados, function (i, val) {
        $ele.append($('<option/>').val(val.codigo_estado).text(val.descripcion_estado));
    })
}
CaragaEstado($('#cboEstado'));

var Prioridades = [];
function CaragaPrioridad(element) {
    if (Prioridades.length == 0) {
        $.ajax({
            type: "GET",
            url: '/Solicitud/ListaPrioridad',
            success: function (data) {
                Prioridades = data;
                htmlPrioridad(element);
            }
        })
    }
    else {
        htmlPrioridad(element);
    }
}
function htmlPrioridad(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Seleccione'));
    $.each(Prioridades, function (i, val) {
        $ele.append($('<option/>').val(val.codigo_prioridad).text(val.descripcion_prioridad));
    })
}
CaragaPrioridad($('#cboPrioridad'));

var Recursos = [];
function CaragaRecurso(element) {
    if (Recursos.length == 0) {
        $.ajax({
            type: "GET",
            url: '/Solicitud/ListaRecurso',
            success: function (data) {
                Recursos = data;
                htmlRecurso(element);
            }
        })
    }
    else {
        htmlRecurso(element);
    }
}
function htmlRecurso(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Seleccione'));
    $.each(Recursos, function (i, val) {
        $ele.append($('<option/>').val(val.codigo_recurso).text(val.nombre_recurso));
    })
}
CaragaRecurso($('#cboProducto'));

var Solicitudes = [];
function CaragaSolicitud(element) {

    $.ajax({
        type: "GET",
        url: '/Solicitud/ListaSolicitud',
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
    var estadoEstatus = false;
    var $table = $('<table/>');

    $table.append('<thead><tr><th></th><th>Solitud</th><th>Fecha</th><th>Prioridad</th><th>Usuario</th><th>Estado</th><th>Acción</th></tr></thead>');
    var $tbody = $('<tbody/>');
    $.each(Solicitudes, function (i, val) {
        var $row = $('<tr/>');
        $row.append($('<td />').html(val.numero_solicitud));
        $row.append($('<td/>').html(val.codigo_solicitud));
        $row.append($('<td/>').html(val.fecha_hora));
        $row.append($('<td/>').html(val.prioridad));
        $row.append($('<td/>').html(val.usuario));
        $row.append($('<td/>').html(val.estado));

        //data-toggle='modal' data-target='#myModalStatus'
        var editar = "";
        if (val.codigo_estado == 1) {
            editar = "<a class='editar'  href='javascript:popupEditar(\"" + val.codigo_solicitud + '-' + String(val.numero_solicitud) + "\");'><i class='glyphicon glyphicon-pencil' title='Editar'></i></a>";
        }
        else if (val.codigo_estado == 2) {
            editar = "<a class='editar'  href='javascript:popupEditar(\"" + val.codigo_solicitud + '-' + String(val.numero_solicitud) + "\");'><i class='glyphicon glyphicon-pencil' title='Editar' style='display:none' ></i></a>";
        }

        var anular = "";
        if (val.codigo_estado == 3 || val.codigo_estado == 5) {
            anular = "<a class='delete'  href='javascript:eliminaSolcitud(" + val.numero_solicitud + ");'><i class='glyphicon glyphicon-trash' title='Eliminar' style='display:none'></i></a>";
        }
        else {
            anular = "<a class='delete'  href='javascript:eliminaSolcitud(" + val.numero_solicitud + ");'><i class='glyphicon glyphicon-trash' title='Eliminar'></i></a>";
        }

        var status = "";
        if (val.codigo_estado == 1) {
            status = "<a class='enviar' href='javascript:enviaAprobar(" + val.numero_solicitud + ");'><i class='glyphicon glyphicon-user' title='Enviar para aprobar' ></i></a>";
        }
        else {
            status = "<a class='enviar' href='javascript:enviaAprobar(" + val.numero_solicitud + ");'><i class='glyphicon glyphicon-user' title='Enviar para aprobar'  aria-hidden='true' visible='false' style='display:none' ></i></a>";
        }

        $row.append($('<td/>').html(editar + "&nbsp;<a class='editar'  href='javascript:statusSolcitud(" + val.numero_solicitud + ");'><i class='glyphicon glyphicon-tasks' title='Estatus'></i></a> &nbsp;" + anular + " &nbsp;" + status));
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
    .html('<div><h6>Anular Solicitud</h6></div>')
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

function popupEditar(idSolicitud) {
    var str = idSolicitud;
    var res = str.split('-');

    $("#txtCodigo").val(res[0]);
    $("#txtId").val(res[1]);

    $("#btnEditarSolicitud").click();
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
                    $('#cboEstado').val(val.codigo_estado);
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

function validaRecurso(recurso) {

    var errorDuplicados = true;
    $('#detalleSolicitud tbody tr').each(function (index, ele) {
        var recursoAdd = $('select.recurso', this).val();
        if (recurso == recursoAdd) {
            errorDuplicados = false;
            return errorDuplicados;
        }
    })
    return errorDuplicados;
}


$(document).ready(function () {


    $("[data-toggle=tooltip]").tooltip();

    $("#txtCantidad").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
            (e.keyCode >= 35 && e.keyCode <= 40)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    });

    $('#addDetalle').click(function () {


        var validaDatos = true;
        if ($('#cboProducto').val() == "0") {
            validaDatos = false;
            $('#cboProducto').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#cboProducto').siblings('span.error').css('visibility', 'hidden');
        }
        if (!validaRecurso($('#cboProducto').val())) {
            validaDatos = false;
            $('#cboProducto').siblings('span.error').css('visibility', 'visible');
        }
        if (!($('#txtCantidad').val().trim() != '' && (parseInt($('#txtCantidad').val()) || 0))) {
            validaDatos = false;
            $('#txtCantidad').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#txtCantidad').siblings('span.error').css('visibility', 'hidden');
        }

        if (validaDatos) {
            var $nuevaFila = $('#filaInicial').clone().removeAttr('id');
            $('.recurso', $nuevaFila).val($('#cboProducto').val());

            //Reemplaza el boton de agregar por eliminar
            $('#addDetalle', $nuevaFila).addClass('remove').val('Eliminar').removeClass('btn btn-sm').addClass('btn btn-sm');

            //elimina la fila seleccionada
            $('#cboProducto,#txtCantidad,#addDetalle', $nuevaFila).removeAttr('id');
            $('span.error', $nuevaFila).remove();

            //agrega la fila
            $('#detalleSolicitud').append($nuevaFila);

            //limpiar controles orderdetailsItems
            $('#cboProducto').val('0');
            $('#txtCantidad').val('');
            $('#numeroSolicitudError').empty();
        }

    })

    $('#detalleSolicitud').on('click', '.remove', function () {
        $(this).parents('tr').remove();
    });

    $('#btnGuardar').click(function () {

        var validaDatos = true;
        if (detalleSolicitud.length == 0) {
            $('#detalleSolicitud').html('<span style="color:red;">Agregue recurso</span>');
            validaDatos = false;
        }

        $('#numeroSolicitudError').text('');
        var detalle = [];
        var errorCount = 0;
        $('#detalleSolicitud tbody tr').each(function (index, ele) {
            if (
                $('select.recurso', this).val() == "0" || (parseInt($('.cantidad', this).val()) || 0) == 0
                ) {
                errorCount++;
                $(this).addClass('error');
            } else {
                var itemSolicitud = {
                    codigo_recurso: $('select.recurso', this).val(),
                    cantidad_solicitada: parseInt($('.cantidad', this).val())
                }
                detalle.push(itemSolicitud);
            }
        })

        if ($('#txtFecha').val().trim() == '') {
            $('#txtFecha').siblings('span.error').css('visibility', 'visible');
            validaDatos = false;
        }
        else {
            $('#txtFecha').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#cboPrioridad').val().trim() == '0') {
            $('#cboPrioridad').siblings('span.error').css('visibility', 'visible');
            validaDatos = false;
        }
        else {
            $('#cboPrioridad').siblings('span.error').css('visibility', 'hidden');
        }


        if (validaDatos) {
            var data = {
                numero_solicitud: $('#txtId').val().trim(),
                fecha_hora: $('#txtFecha').val().trim(),
                codigo_prioridad: $('#cboPrioridad').val(),
                codigo_estado: $('#cboEstado').val(),
                GPC_DetalleDeSolicitud: detalle
            }

            $(this).val('Guarando...');

            $.ajax({
                url: '/Solicitud/GuardaSolicitud',
                type: "POST",
                data: JSON.stringify(data),
                dataType: "JSON",
                contentType: "application/json",
                success: function (d) {
                    if (d.status == true) {
                        mensajeConfirmacion();
                        CaragaSolicitud($('#tabSolicitud'));
                        detalle = [];
                        $('#txtId').val('0');
                        $('#txtCodigo').val('');
                       // $('#txtFecha').val('');
                        $('#cboPrioridad').val('0');
                        $('#detalleSolicitud tbody').empty();
                        $("#myModal").modal("hide");
                    }
                    else {
                        alert('Error');
                    }
                    $('#btnGuardar').val('Guardar');
                },
                error: function () {
                    alert('Error. Al Guardar.');
                    $('#btnGuardar').val('Guardar');
                }
            });
        }

    });

    $('#btnElinarSolicitud').click(function () {

        var validaDatos = true;
        if ($("#txtId").val() == '0') {
            alert('Seleccione un registro');
            validaDatos = false;
        }

       

        if (validaDatos) {
            $.ajax({
                url: '/Solicitud/EliminaSolicitud',
                type: "POST",
                data: JSON.stringify({
                    'numero_solicitud': $("#txtId").val()
                }),
                dataType: "JSON",
                contentType: "application/json",
                success: function (d) {
                    if (d.status == true) {
                        mensajeConfirmacion();
                        CaragaSolicitud($('#tabSolicitud'));
                        $('#txtId').val('0');
                    }
                    else {
                        alert('Error: Al Eliminar.');
                    }
                },
                error: function () {
                    alert('Error: Al Eliminar.');
                }
            });
        }
    });

    $('#btnEditarSolicitud').click(function () {
        // $('#detalleSolicitud').dataTable().fnDraw(false)
        //$('#detalleSolicitud').dataTable().destroy();
        $('#detalleSolicitud tbody').empty();

        var editarDEtalle = [];
        var nroSolicitud = parseInt($("#txtId").val(), 10);
        //datos de cabecera
        editarSolicitud(nroSolicitud);
        debugger;
        //detalle
        $.ajax({
            type: "GET",
            url: '/Solicitud/EditarDetalleSolicitud',
            data: { 'numero_solicitud': nroSolicitud },
            success: function (resrult) {
                editarDEtalle = resrult;
                if (editarDEtalle.length > 0) {
                    var itemSolicitud = {
                        numero_solicitud: 0,
                        item: 0,
                        cantidad_solicitada: 0,
                        codigo_recurso: 0
                    }
                    editarDEtalle.push(itemSolicitud);

                    $.each(editarDEtalle, function (i, val) {
                        var $nuevaFila = $('#filaInicial').clone().removeAttr('id');
                        $('.recurso', $nuevaFila).val($('#cboProducto').val());
                        $('#addDetalle', $nuevaFila).addClass('remove').val('Eliminar').removeClass('btn btn-sm').addClass('btn btn-sm');

                        $('#cboProducto').val(val.codigo_recurso);
                        $('#txtCantidad').val(val.cantidad_solicitada);

                        $('#cboProducto,#txtCantidad,#addDetalle', $nuevaFila).removeAttr('id');
                        $('span.error', $nuevaFila).remove();
                        if (i > 0) {
                            $('#detalleSolicitud').append($nuevaFila);
                        }

                    });
                    editarDEtalle = [];
                    $('#cboProducto').val('0');
                    $('#txtCantidad').val('');
                    $('#numeroSolicitudError').empty();
                }
            },
            error: function (resrult) {
                alert('Seleccione un registro para editar');
            }
        })


    });

    $('#btnCerar').click(function () {

        $('#detalleSolicitud tbody').empty();

        detalle = [];
        $('#txtCodigo').val('');
        // $('#txtFecha').val('');
        $('#cboPrioridad').val('0');
        $('#detalleSolicitud').empty();

    });

    $('#btnAddSol').click(function () {
 
        $('#detalleSolicitud tbody').empty();
        detalle = [];
        $('#txtCodigo').val('');

        $('#cboPrioridad').val('0');
        $('#detalleSolicitud').empty();

    });

    $('#btnAprobarSolicitud').click(function () {

        var validaDatos = true;
        if ($("#txtId").val() == '0') {
            alert('Seleccione un registro');
            validaDatos = false;
        }

        if (validaDatos) {
            $.ajax({
                url: '/Solicitud/EnviaAprobarSolicitud',
                type: "POST",
                data: JSON.stringify({
                    'numero_solicitud': $("#txtId").val()
                }),
                dataType: "JSON",
                contentType: "application/json",
                success: function (d) {
                    if (d.status == true) {
                        mensajeConfirmacion();
                        CaragaSolicitud($('#tabSolicitud'));
                        $('#txtId').val('0');
                    }
                    else {
                        alert('Error: No se pudo enviar solicitud.');
                    }
                },
                error: function () {
                    alert('Error: Al No se pudo enviar solicitud.');
                }
            });
        }
    });

    $('#btnStatus').click(function () {
        $('#tabStatus').empty();
        //  CaragaStatusSolicitud($('#tabStatus'), $("#txtId").val());
        var $ele = $('#tabStatus');
        $ele.empty();

        var $table = $('<table/>');
        $table.append('<thead><tr><th>Solitud</th><th>Fecha de Operación</th><th>Empleado</th><th>Estado</th></tr></thead>');
        var $tbody = $('<tbody/>');

        $.ajax({
            type: "GET",
            url: '/Solicitud/EstadosDeSolicitud',
            data: { 'numero_solicitud': $("#txtId").val() },
            success: function (resrult) {
                StatusSolicitud = resrult;
                if (StatusSolicitud.length > 0) {
                    $.each(StatusSolicitud, function (i, val) {
                        var $row = $('<tr/>');
                        $row.append($('<td/>').html(val.codigo_solicitud));
                        $row.append($('<td/>').html(val.fecha_operacion));
                        $row.append($('<td/>').html(val.empleado));
                        $row.append($('<td/>').html(val.estado));
                        $tbody.append($row);
                    });
                    $table.append($tbody);
                    $ele.append($table);
                }
            }
        })
    })

});


