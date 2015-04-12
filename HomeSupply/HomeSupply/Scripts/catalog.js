$(document).ready(function () {
	$('.recorrente').click(function () {
		$('#frequencyGroup' + $(this).val()).toggle();                         
	});    
	
	$('.datepicker').pickadate({
    selectMonths: true, // Creates a dropdown to control month
    selectYears: 15 // Creates a dropdown of 15 years to control year
	});

	if ($("#itemComprado").val()) {
	    $("#" + $("#itemComprado").val()).fadeOut(2000, function()
	    {
	        $("#cat-" + $("#itemComprado").val()).show();
	    });
	    
	    $("#sc_btn_" + $("#itemComprado").val()).hide();
	    $("#check-" + $("#itemComprado").val()).show();
	}
});