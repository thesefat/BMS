
$(document).ready(function () {
    getSupliers();
});

function getSupliers() {
    $.ajax({

        url: "../../Buyers/GetSupliers",
        type: "GET",
        data: JSON.stringify(),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            if (data !== false && data !== undefined) {

                var sl = 1;
                $.each(data, function (k, v) {

                    // var index = $("#SuplierDetailsTable").children("tr").length();


                    tableRowEffect(sl, v.Name, v.ContactNo, v.Email, v.Address, v.Code, v.Photo);
                    sl++;



                });
            }

        }, error: function (err) {
            alert(err);
        }
    });
}




function tableRowEffect(serial, suplierName, suplierContact, suplierEmail, suplierAddress, suplierCode,suplierPhoto) {



    var serialCell = "<td>" + serial++ + "</td>";
    var suplierNameCell = "<td>" + suplierName + "</td>";
    var suplierContactCell = "<td>" + suplierContact + "</td>";
    var suplierEmailCell = "<td>" + suplierEmail + "</td>";
    var suplierAddressCell = "<td>" + suplierAddress + "</td>";
    var suplierCodeCell = "<td>" + suplierCode + "</td>";
    var suplierImageCell = "<td <img src='" + suplierPhoto + "'/> </td > ";
   

    var options = `<td align="center"><button type="button" class="btn btn-success" id="Edit">
                        <span class="glyphicon glyphicon-pencil"></span>

                      </button >
                      <button type="button" class="btn btn-info" id="Update">
                        <span class="glyphicon glyphicon-refresh"></span>
                     </button> <button type="button" class="btn btn-warning" id="Delete">
                         <span class="glyphicon glyphicon-trash"></span>
                     </button></td>`;
    var createNewRow = "<tr> " + serialCell + suplierNameCell + suplierContactCell + suplierEmailCell + suplierAddressCell + suplierCodeCell + suplierImageCell + options + " </tr>";

    $("#SuplierDetailsTable").append(createNewRow);


}

