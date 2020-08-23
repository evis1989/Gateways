$(document).ready(function () {
    $('#table_card').DataTable();

    var spinner = $('#loader');

    $('#btn_save').click(function (e) {
        spinner.show();
    });

    $('#btn_select').click(function (e) {
        spinner.show();

        $.ajax({
            type: 'POST',
            url: '/Events/SelectedWinner',
            data: $('#form_edit').serialize(),
            content: "application/json",
            dataType: "json",
            success: function (result) {
                location.href = '/';
            },
            error: function () {
                spinner.hide();
            }
        })
    });
});