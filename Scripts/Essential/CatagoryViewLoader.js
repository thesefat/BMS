$(document).ready(function () {
    getCatagory();
});

function getCatagory() {
    $.ajax({

        url: "../../Catagory/GetCatagory",
        type: "GET",
        data: JSON.stringify(),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            if (data !== false && data !== undefined) {

                var sl = 1;
                $.each(data, function (k, v) {
                
                   
                    tableRowEffect(sl, v.Name, v.Code);
                    sl++;
                   

                   
                });
            }

        }, error: function (err) {
            alert(err);
        }
    });
}

//function createRowForCatagory() {

//    var sl = index;
//    var serialCell = "<td>" + ++sl + "</td>";
//    var catagoryNameCell = "<td>" ++"</td>";
//    var catagoryCodeCell = "<td><input type='hidden' id='catagoryCode" + index + "' name='Catagories[" + index + "].Name' value='" + selectedIteam.CatagoryCode + "'/> </td>";


//    var createNewRow = "<tr> " + serialCell + catagoryNameCell + catagoryCodeCell + actionLoader("#action") + " </tr>";

//    $("#CatsDetailsTable").append(createNewRow);
//}


function tableRowEffect(serial, catagoryName, catagoryCode) {

    var serialCell = "<td>" + serial++ + "</td>";
    var catagoryNameCell = "<td  id='catagoryName" + serial + "' name='Catagories[" + serial + "].Name' value='" + catagoryName + "'>" + catagoryName + "</td>";
    var catagoryCodeCell = "<td  id='catagoryCode" + serial + "' name='Catagories[" + serial + "].Code' value='" + catagoryCode + "'>" + catagoryCode + "</td>";

    var options = `<td align="center"><button type="button" class="btn btn-success" id="Edit">
                        <span class="glyphicon glyphicon-pencil"></span>

                      </button >
                      <button type="button" class="btn btn-info" id="Update">
                        <span class="glyphicon glyphicon-refresh"></span>
                     </button> <button type="button" class="btn btn-warning" id="Delete">
                         <span class="glyphicon glyphicon-trash"></span>
                     </button></td>`;
    var createNewRow = "<tr> " + serialCell + catagoryNameCell + catagoryCodeCell + options + " </tr>";

    $("#CatsDetailsTable").append(createNewRow);
   

}

function actionLoader(selector) {
    $(selector).append(`<button type="button" class="btn btn-success" id="Edit">
                        <span class="glyphicon glyphicon-pencil"></span>

                      </button >
                      <button type="button" class="btn btn-info" id="Update">
                        <span class="glyphicon glyphicon-refresh"></span>
                     </button> <button type="button" class="btn btn-warning" id="Delete">
                         <span class="glyphicon glyphicon-trash"></span>
                     </button>`);

}

