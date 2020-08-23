$(document).ready(function () {
    // Initialize table
    var table = $('#table_card').DataTable();
    var spinner = $('#loader');
    
    // btn save onclick event
    $('#btn_save').click(function (e) {
        spinner.show();
    });
});