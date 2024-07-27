// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

setTimeout(function () {
    $(".alert").fadeOut("slow", function () {
        $(this).alert('close');
    });
}, 4000);

function toLocalTime(utcDateString) {
    var date = new Date(utcDateString);
    return date.toLocaleString();
}

document.addEventListener("DOMContentLoaded", function () {
    var dateElements = document.querySelectorAll('.utc-date');
    dateElements.forEach(function (element) {
        var utcDate = element.textContent;
        element.textContent = toLocalTime(utcDate);
    });
});

$(function () {
    //Filtros e paginação
    $('#table').DataTable({
        language: {
            "decimal": "",
            "emptyTable": "Sem dados disponíveis na tabela",
            "info": "Mostrando _START_ a _END_ de _TOTAL_",
            "infoEmpty": "Mostrando 0 a 0 de 0 entradas",
            "infoFiltered": "(filtrado do total de _MAX_ entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar |_MENU_",
            "loadingRecords": "Carregando...",
            "processing": "",
            "search": "Pesquisar:",
            "zeroRecords": "Nenhum registro correspondente encontrado",
            "paginate": {
                "first": "Primeiro",
                "last": "Último",
                "next": "Próximo",
                "previous": "Anterior"
            },
            "aria": {
                "orderable": "Ordenar por esta coluna",
                "orderableReverse": "Ordem inversa desta coluna"
            }
        },
        columnDefs: [{
            "defaultContent": "-",
            "targets": "_all"
        }]
    })
});
