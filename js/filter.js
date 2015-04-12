
    // Filter Items by Category Id
    function applyFilterByCategory(categoryFilterId) {
        $('.catalog-item[category-id=' + categoryFilterId + ']').show();
    };
    
    // Expand Recurrence
    function expandRecurrence() {
        var recurrenceElementId = "#recurrenceElement";
        $(recurrenceElementId).toggle('');
    };
        
    $(document).ready(function () {
    	    	    	
        $('.category').click(function () {
        	$('.catalog-item').hide();
            var selectedCategories = $('.category:checked');
            
            if($(selectedCategories).length > 0){
            	$(selectedCategories).each(function(){
	            applyFilterByCategory($(this).val());
	            });
            }else{
            	// None Selected - Show All
            	$('.catalog-item').show();
            }
        });    
    });