    // Get the array diff
    Array.prototype.diff = function(a) {
        return this.filter(function(i) {return a.indexOf(i) < 0;});
    };


    // Filter Items by Category Id
    // Hide the itens that doest match this id
    function applyFilterByCategory(categoryFilterId) {
        $('.catalog-item[category-id=' + categoryFilterId + ']')
            .css('opacity', 0)
            .slideDown('slow')
            .animate(
                { opacity: 1 },
                { queue: false, duration: 'slow' }
            );
    };

    function showItem (categoryFilterId) {
        if (!$('.catalog-item[category-id=' + categoryFilterId + ']').is(':visible')) {
            $('.catalog-item[category-id=' + categoryFilterId + ']')
                .css('opacity', 0)
                .slideDown('fast')
                .animate(
                    { opacity: 1 },
                    { queue: false, duration: 'fast' }
                );
        }

        if (!categoryFilterId) {
            $('.catalog-item')
                .css('opacity', 0)
                .slideDown('fast')
                .animate(
                    { opacity: 1 },
                    { queue: false, duration: 'fast' }
                );
        }
    }

    function showArray () {

    }

    function hideOthers (categoryFilterId) {
        if ($('.catalog-item[category-id!=' + categoryFilterId + ']').length) {
            if ($('.catalog-item[category-id!=' + categoryFilterId + ']').is(':visible')) {
                $('.catalog-item[category-id!=' + categoryFilterId + ']')
                    .css('opacity', 1)
                    .slideUp('fast')
                    .animate(
                        { opacity: 0 },
                        { queue: false, duration: 'fast' }
                    );
            }
        }
    }

    function hideItem (categoryFilterId) {
        if ($('.catalog-item[category-id=' + categoryFilterId + ']').length) {
            if ($('.catalog-item[category-id=' + categoryFilterId + ']').is(':visible')) {
                $('.catalog-item[category-id=' + categoryFilterId + ']')
                    .css('opacity', 1)
                    .slideUp('fast')
                    .animate(
                        { opacity: 0 },
                        { queue: false, duration: 'fast' }
                    );
            }
        }
    }
    
    // Expand Recurrence
    function expandRecurrence() {
        var recurrenceElementId = "#recurrenceElement";
        $(recurrenceElementId).toggle('');
    };
        
    $(document).ready(function () {
    	    	    	
        $('.category').click(function () {

            var selectedId;

            if ($('.category:checked').length === 0) {
                showItem();
            }
            else if ($('.category:checked').length === 1) {
                selectedId = $('.category:checked').val();

                showItem(selectedId);
                hideOthers(selectedId);
            }
            else {
                var itens = $('.category').not($('.category:checked'));

                console.log(itens);

                $.each($('.category:checked'), function () {
                    showItem($(this).val());
                });

                $.each(itens, function () {
                    hideItem($(this).val());
                });
            }

        });    
    });