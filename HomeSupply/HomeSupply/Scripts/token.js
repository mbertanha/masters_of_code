$(document).ready(function () {

    $("#simplify-payment-form").on("submit", function () {
        $("#process-payment-btn").prop("disabled", true);
        SimplifyCommerce.generateToken({
            key: "sbpb_N2ZhMTVlMWQtYmYzNy00ZmE1LTg1ODItMzQ3NjkwMzMyMzlk",
            card: {
                number: $("#cc-number").val(),
                cvc: $("#cc-cvc").val(),
                expMonth: $("#cc-exp-month").val(),
                expYear: $("#cc-exp-year").val()
            }
        }, simplifyResponseHandler);
    });


});

function simplifyResponseHandler(data)
{
    var paymentForm = $("#simplify-payment-form");

    $(".error").remove();

    if (data.error)
    {
        if (data.error.code == 'validation')
        {
            var fieldErrors = data.error.fieldErrors,
                fieldErrorsLength = fieldErrors.length,
                errorList = "";
            for (var i = 0; i < fieldErrorsLength; i++) {
                errorList += "<div class='error'>Field: '" + fieldErrors[i].field +
                             "' is invalid - " + fieldErrors[i].message + "</div>";
            }
            // Display the errors
            paymentForm.after(errorList);
        }
        $('#process-payment-btn').removeAttr('disabled');
    }
    else
    {
        var token = data["id"];
        paymentForm.append("<input type='hidden' name='simplifyToken' value='" + token + "' />");
        paymentForm.get(0).submit();
    }
}