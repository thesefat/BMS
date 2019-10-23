
$("#InStock").attr('disabled', 'disabled');
$("#UnitPrice").attr('disabled', 'disabled');  
$("#LoyalityPoint").attr('disabled', 'disabled');  

$("#ProductName").change(function () {
    var id = $(this).val();
    callProductProperty(id);

});

function callProductProperty(id) {

    var params = { id: id };
    var url = "../../Sale/CallProductProperty";
    $.post(url, params, function (data) {
        data.forEach(c => {
            $("#InStock").val(c.ReorderLevel);
            $("#UnitPrice").val(c.CostPrice);
        });
        console.log(data);
    }).fail(function (err) {
        alert(err);
    });
}


$("#CustomerId").change(function () {
    var id = $(this).val();
    callCustomerLoyalityPoint(id);

});

function callCustomerLoyalityPoint(id) {
    var params = { id: id };
    var url = "../../Sale/callCustomerLoyalityPoint";
    $.post(url, params, function (data) {
        data.forEach(c => {

            console.log(c);
            $("#LoyalityPoint").val(c.LoyaltyPoint);
        });
        console.log(data);
    }).fail(function (err) {
        alert(err);
    });
}
