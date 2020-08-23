$(document).ready(function () {
    $('.datepicker').datepicker({
        dateFormat: 'yy/mm/dd',
        changeMonth: true,
        changeYear: true,
        showAnim: 'slideDown'
    });

    $('.timepicker').timepicker({
        timeFormat: 'h:mm tt',
        showAnim: 'slideDown',
        addSliderAccess: true,
        sliderAccessArgs: { touchonly: false }
    });
});


