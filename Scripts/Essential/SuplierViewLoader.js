
$(document).ready(function () {
    getAllSuplier();
});

function getAllSuplier() {
    $.ajax({

        url: "../../Buyers/GetAllSuplier",
        type: "GET",
        data: JSON.stringify(),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            if (data !== false && data !== undefined) {

                var sl = 1;
                $.each(data, function (k, v) {

                    tableRowEffect(sl, v.Name, v.ContactNo, v.Email, v.Address, v.Code, v.PhotoStr, v.Id);
                    sl++;
                });
            }

        }, error: function (err) {
            alert(err);
        }
    });
}


function tableRowEffect(serial, suplierName, suplierContact, suplierEmail, suplierAddress, suplierCode,suplierPhoto,id) {



    var serialCell = "<td>" + serial + "</td>";
    var suplierNameCell = "<td>" + suplierName + "</td>";
    var suplierContactCell = "<td>" + suplierContact + "</td>";
    var suplierEmailCell = "<td>" + suplierEmail + "</td>";
    var suplierAddressCell = "<td>" + suplierAddress + "</td>";
    var suplierCodeCell = "<td>" + suplierCode + "</td>";
    var suplierImageCell = "<td align='center'><img src='" + suplierPhoto + "' style='height: 120px; width: 100px;'/></td >";

    var options = "<td align='center'><button type='button' class='btn btn-success' id='Edit' onClick='editRow(" + id + ")'> <span class='glyphicon glyphicon-pencil'></span></button>    <button type='button' class='btn btn-warning' id='Delete' onClick='deleteRow(" + id + ")'><span class='glyphicon glyphicon-trash'></span></button></td>";

    var createNewRow = "<tr> " + serialCell + suplierNameCell + suplierContactCell + suplierEmailCell + suplierAddressCell + suplierCodeCell + suplierImageCell + options + " </tr>";

    $("#SuplierDetailsTable").append(createNewRow);


}


function deleteRow(id) {
    deleteFromServer(id);
    $("#SuplierDetailsTable").empty();

}


function deleteFromServer(id) {

    var serial = 0;
    if (confirm('Are You Sure to Delete?') === true) {

        var params = { id: id };
        var url = "../../Buyers/Delete";
        $.post(url, params, function (data) {
            data.forEach(c => {
                tableRowEffect(++serial, c.Name, c.ContactNo, c.Email, c.Address, c.Code, c.PhotoStr, c.Id);
            });

        }).fail(function (err) {
            alert(err);
        });
    }
}






function editRow(id) {
    var params = { id: id };
    var url = "../../Buyers/GetAllSuplier";
    $.post(url, params, function (data) {
        data.forEach(c => {





            $("#Name").val(c.Name);
            $("#Code").val(c.Code);

            $('#ContactNo').val(c.ContactNo);

            $('#Email').val(c.Email);

            $('#Address').val(c.Address);
            $('#ContactPerson').val(c.ContactPerson);
           

            $("#saveButton").val("Edit");
            $("#table").hide();

        });


    }).fail(function (err) {
        alert(err);
    });

}