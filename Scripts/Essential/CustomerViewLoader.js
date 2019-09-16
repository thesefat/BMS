

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

                    tableRowEffect(sl, v.Name, v.ContactNo, v.Email, v.LoyaltyPoint, v.PhotoStr);
                    sl++;
                });
            }

        }, error: function (err) {
            alert(err);
        }
    });
}



function tableRowEffect(serial, customerName, contactNo, email, loyaltyPoint, productImage) {



    var serialCell = "<td>" + serial++ + "</td>";
    var customerNameCell = "<td>" + customerName + "</td>";
    var contactNoCell = "<td >" + contactNo + "</td>";
    var emailCell = "<td >" + email + "</td>";
    var loyaltyPointCell = "<td >" + loyaltyPoint + "</td>";




    var productsImageCell = "<td align='center'><img src='" + productImage + "' style='height: 120px; width: 100px;'/></td >";



    var options = `<td align="center"><button type="button" class="btn btn-success" id="Edit">
                        <span class="glyphicon glyphicon-pencil"></span>

                      </button >
                      <button type="button" class="btn btn-info" id="Update">
                        <span class="glyphicon glyphicon-refresh"></span>
                     </button> <button type="button" class="btn btn-warning" id="Delete">
                         <span class="glyphicon glyphicon-trash"></span>
                     </button></td>`;


    var createNewRow = "<tr> " + serialCell + customerNameCell + contactNoCell + emailCell + loyaltyPointCell + productsImageCell  + options + " </tr>";

    $("#CustomerDetailsTable").append(createNewRow);


}
