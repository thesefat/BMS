

$(document).ready(function () {
    getCustomers();
});

function getCustomers() {
    $.ajax({

        url: "../../Customer/GetCustomers",
        type: "GET",
        data: JSON.data,
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            if (data !== false && data !== undefined) {

                var sl = 1;
                $.each(data, function (k, v) {

                    tableRowEffect(sl, v.Name, v.ContactNo, v.Email, v.LoyaltyPoint, v.PhotoStr,v.Id);
                    sl++;
                });
            }

        }, error: function (err) {
            alert(err);
        }
    });
}

function tableRowEffect(serial, customerName, contactNo, email, loyaltyPoint, productImage,id) {



    var serialCell = "<td>" + serial++ + "</td>";
    var customerNameCell = "<td>" + customerName + "</td>";
    var contactNoCell = "<td >" + contactNo + "</td>";
    var emailCell = "<td >" + email + "</td>";
    var loyaltyPointCell = "<td >" + loyaltyPoint + "</td>";




    var productsImageCell = "<td align='center'><img src='" + productImage + "' style='height: 120px; width: 100px;'/></td >";

    var options = "<td align='center'><button type='button' class='btn btn-success' id='Edit' onClick='editRow(" + id + ")'> <span class='glyphicon glyphicon-pencil'></span></button>    <button type='button' class='btn btn-warning' id='Delete' onClick='deleteRow(" + id + ")'><span class='glyphicon glyphicon-trash'></span></button></td>";



    var createNewRow = "<tr> " + serialCell + customerNameCell + contactNoCell + emailCell + loyaltyPointCell + productsImageCell  + options + " </tr>";

    $("#CustomerDetailsTable").append(createNewRow);


}



function deleteRow(id) {
    deleteFromServer(id);
    $("#SuplierDetailsTable").empty();

}


function deleteFromServer(id) {

    var sl = 0;
    if (confirm('Are You Sure to Delete?') === true) {

        var params = { id: id };
        var url = "../../Customer/Delete";
        $.post(url, params, function (data) {
            data.forEach(c => {
                tableRowEffect(++sl, v.Name, v.ContactNo, v.Email, v.LoyaltyPoint, v.PhotoStr, v.Id);
            });

        }).fail(function (err) {
            alert(err);
        });
    }
}




function editRow(id) {
    var params = { id: id };
    var url = "../../Customer/GetCustomers";
    $.post(url, params, function (data) {
        data.forEach(c => {





            $("#Name").val(c.Name);
            $("#Code").val(c.Code);


            $('#ContactNo').val(c.ContactNo);

            $('#Email').val(c.Email);

            $('#Address').val(c.Address);
            
            $('#LoyaltyPoint').val(c.LoyaltyPoint);



            $("#saveButton").val("Edit");
            $("#table").hide();

        });


    }).fail(function (err) {
        alert(err);
    });

}