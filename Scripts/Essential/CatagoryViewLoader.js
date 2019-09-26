$(document).ready(function () {
    getCatagory();

});


//class Catagory {
//    id = 0;
//    name = "";
//    code = "";
//}

//let catragoryList = [];

function getCatagory() {
    $.ajax({

        url: "../../Catagory/GetCatagory",
        type: "GET",
        data: JSON.stringify(),
        contentType: "application/json;charset=utf-8",
        success: function (data) {

            if (data !== false && data !== undefined) {
                sl = 1;
                $.each(data, function (k, v) {

                    //const list = getSelectedData(v);
                    //if (list !== "" && list !== undefined) {
                    //    catragoryList.push(list);
                    //}
                    tableRowEffect(sl, v.Name, v.Code,v.Id);
                    sl++;
                   
                });
            }

        }, error: function (err) {
            alert(err);
        }
    });
}


function tableRowEffect(serial, catagoryName, catagoryCode,id) {

    var serialCell = "<td>" + serial++ + "</td>";
    var catagoryNameCell = "<td  id='catagoryName" + serial + "' name='Catagories[" + serial + "].Name' value='" + catagoryName + "'>" + catagoryName + "</td>";
    var catagoryCodeCell = "<td  id='catagoryCode" + serial + "' name='Catagories[" + serial + "].Code' value='" + catagoryCode + "'>" + catagoryCode + "</td>";

    var options = "<td align='center'><button type='button' class='btn btn-success' id='Edit' onClick='editRow(" + id + ")'> <span class='glyphicon glyphicon-pencil'></span></button><button type='button' class='btn btn-warning' id='Delete' onClick='deleteRow(" + id + ")'><span class='glyphicon glyphicon-trash'></span></button></td>";
    var createNewRow = "<tr> " + serialCell + catagoryNameCell + catagoryCodeCell + options + " </tr>";

    $("#CatsDetailsTable").append(createNewRow);
}


function deleteRow(id) {
    deleteFromServer(id);
    $("#CatsDetailsTable").empty();


   
}




function deleteFromServer(id) {

    var serial = 0;
    if (confirm('Are You Sure to Delete?') === true) {
       
        var params = { id: id };
        var url = "../../Catagory/Delete";
        $.post(url, params, function (data) {
            data.forEach(c => {
                tableRowEffect(++serial, c.Name, c.Code, c.Id);
  
            });



        }).fail(function (err) {
            alert(err);
        });
    }
}


//function getSelectedData(v) {
//    const model = new Catagory();
//    model.id = v.Id;
//    model.name = v.Name;
//    model.code = v.Code;

//    return model;
//}