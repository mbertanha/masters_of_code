$(document).ready(function () {
	$('.recorrente').click(function () {
		$('#frequencyGroup' + $(this).val()).toggle();                         
	});    
	
	$('.datepicker').pickadate({
    selectMonths: true, // Creates a dropdown to control month
    selectYears: 15 // Creates a dropdown of 15 years to control year
  });


	$('.diaRecorrente').hide();
	$('#recorrente1').change(function () {
	    if ($(this).val() != 1) {
	        $('#diaRecorrente1').show();
	    } else {
	        $('#diaRecorrente1').hide();
	    }
	});
	$('#recorrente2').change(function () {
	    if ($(this).val() != 1) {
	        $('#diaRecorrente2').show();
	    } else {
	        $('#diaRecorrente2').hide();
	    }
	});
	$('#recorrente3').change(function () {
	    if ($(this).val() != 1) {
	        $('#diaRecorrente3').show();
	    } else {
	        $('#diaRecorrente3').hide();
	    }
	});
	$('#recorrente4').change(function () {
	    if ($(this).val() != 1) {
	        $('#diaRecorrente4').show();
	    } else {
	        $('#diaRecorrente4').hide();
	    }
	});
});