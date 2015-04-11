﻿

// Filter Items by Category Id
function applyFilter(productFilterId) {

    // Hide products that doesn't have this data-attr Product-ID

    $('#produtos[product-id!=' + productFilterId + ']').hide();
    $('#produtos[product-id=' + productFilterId + ']').show();
    

};

// Expand Recurrence
function expandRecurrence() {
    var recurrenceElementId = "#recurrenceElement";

    $(recurrenceElementId).toggle('');
};


$(document).load(function () {

    var elementFilter = '#filter-categoria';

    $(elementFilter).click(index, function () {
        var elementProductId = 'product-id';

        var productId = $(this).val();
        applyFilter(productId);

    });

});

