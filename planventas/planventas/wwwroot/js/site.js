// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


$(document).ready(function () {

    $('.datepicker').datepicker({
        format: "dd/mm/yyyy",
        clearBtn: true,
        language: "es",
        orientation: "bottom left",
        autoclose: true,
        todayHighlight: true,
        multidate: true
    });

    $('#datetimepicker1').datepicker({
        format: "dd-mm-yyyy",
        autoclose: true,
        language: "es"
    });
    
    $('#datetimepicker2').datepicker({
        format: "dd/mm/yyyy",
        clearBtn: true,
        autoclose: false,
        language: "es",
        todayHighlight: true,
        multidate: true
    });

    $('#datetimepicker3').datepicker({
        format: "dd/mm/yyyy",
        clearBtn: true,
        autoclose: false,
        language: "es",
        todayHighlight: true,
        multidate: true
    });

    $('#datetimepicker4').datepicker({
        format: "dd/mm/yyyy",
        clearBtn: true,
        autoclose: false,
        language: "es",
        todayHighlight: true,
        multidate: true
    });

    $('#datetimepicker5').datepicker({
        format: "dd/mm/yyyy",
        clearBtn: true,
        autoclose: false,
        language: "es",
        todayHighlight: true,
        multidate: true
    });
    $('#Param_Table').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
        },
        paging: true,
        columnDefs: [
            {
                width: 70, targets: 4,
                className: 'dt-body-right' },
            {
                targets: 3,
                className: 'dt-body-right',
                render: $.fn.dataTable.render.number(',', '.', 2)
            },
            {
                targets: 0,
                className: 'dt-body-center',
            }
        ],
        fixedColumns: true,
    });

    $('#Param1_Table').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
        },
        paging: true,
        columnDefs: [
            {
                width: 120, targets: [0, 2],
                className: 'dt-center',
            },
            {
                targets: 3,
                className: 'dt-body-right',
            }
        ],
        fixedColumns: true,

    });

    $('#Param2_Table').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
        },
        paging: true,
        columnDefs: [
            {
                width: 120, targets: [0],
                className: 'dt-center',
            },
            {
                targets: 2,
                className: 'dt-body-right',
            }
        ],
    });

    $('#Param3_Table').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
        },
        paging: true,
        columnDefs: [
            {
                width: 120, targets: [0],
                className: 'dt-center',
            },
            {
                targets: 4,
                className: 'dt-body-right',
            }
        ],
    });

    $('#Param4_Table').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
        },
        paging: true,
        columnDefs: [
            {
                targets: 4,
                className: 'dt-body-right',
                width: 100,
            },
            {
                targets: 0,
                className: 'dt-body-center',
                width: 100,
            },
            {
                targets: 1,
                className: 'dt-body-center',
                width: 100,
            },
            {
                targets: 2,
                className: 'dt-body-left',
                width: 200,
            },
            {
                targets: 3,
                className: 'dt-body-left',
                width: 250,
            },

        ],
        fixedColumns: true,
    });

    $('#UnCampo_Table').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
        },
        paging: true,
        columnDefs: [
            {
                width: 60, targets: 1,
                className: 'dt-body-right'
            },
            {
                targets: 0,
                className: 'dt-body-left',
            },
        ],
        fixedColumns: true,
    });

    $('#Param5_Table').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
        },
        paging: true,
        columnDefs: [
            {
                width: 100, targets: [2],
                className: 'dt-center',
            },
            {
                targets: 4,
                className: 'dt-body-right',
            }
        ],
    });

    $('#Param6_Table').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
        },
        paging: true,
        columnDefs: [
            {
                targets: 0,
                className: 'dt-body-center',
                width: 25,
            },
            {
                targets: 1,
                className: 'dt-body-center',
                width: 80,
            },
            {
                targets: 2,
                className: 'dt-body-center',
                width: 30,
            },
            {
                targets: 3,
                className: 'dt-body-left',
                width: 170,
            },
            {
                targets: 4,
                className: 'dt-body-left',
                width: 160,
            },
            {
                targets: 5,
                className: 'dt-body-right',
                width: 100,
            }



        ],
    });

    //$('#ConEmp').DataTable({
    //    "language": {
    //        "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
    //    },
    //    paging: true,
    //    columnDefs: [

    //        {
    //            width: 100, targets: [0],
    //            className: 'dt-body-center',
    //        },
    //        {
    //            width: 200, targets: [1],
    //            className: 'dt-body-left',
    //        }
    //    ],
    //});

/*    var table = $('#ComEmp').DataTable();*/

    //$('#ComEmp tbody').on('click', 'tr', function () {
    //    if ($(this).hasClass('selected')) {
    //        $(this).removeClass('selected');
    //    }
    //    else {
    //        table.$('tr.selected').removeClass('selected');
    //        $(this).addClass('selected');
    //    }
    //});


    $('#TActos').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
        },
        paging: true,
        "bFilter": false,
        "lengthChange": false,
        columnDefs: [
            {
                width: 60, targets: [0],
                className: 'dt-left',
            },
            {
                width: 250, targets: [1],
                className: 'dt-left',
            },
            {
                width: 1295, targets: [2],
                className: 'dt-left',
            },
            {
                width: 9, targets: [3],
                className: 'dt-center',
            },
            {
                targets: 4,
                className: 'dt-body-right',
            }
        ],
    });



});


$(function () {
    // ------------------------------------------------------- //
    // Multi Level dropdowns
    // Nestor Mourelo
    // ------------------------------------------------------ //
    $("ul.dropdown-menu [data-toggle='dropdown']").on("click", function (event) {
        event.preventDefault();
        event.stopPropagation();

        $(this).siblings().toggleClass("show");


        if (!$(this).next().hasClass('show')) {
            $(this).parents('.dropdown-menu').first().find('.show').removeClass("show");
        }
        $(this).parents('li.nav-item.dropdown.show').on('hidden.bs.dropdown', function (e) {
            $('.dropdown-submenu .show').removeClass("show");
        });

    });
});

function displayBusyIndicator() {
    $('.loading').show();
}

function hideBusyIndicator() {
    $('.loading').hide();
}