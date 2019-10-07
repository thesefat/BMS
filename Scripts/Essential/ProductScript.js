
//$(document).ready(function () {
    
//    //createCatagorySelectedListItem();
//});
$(document).ready(function () {
    getProducts();
});

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

$("#Name").change(function () {

    var nam = $(this).val();
    isCatagoryNameUnique(nam);


});

$("#Code").change(function () {

    var code = $(this).val();
    isCatagoryCodeUnique(code);
   

});

function isCatagoryNameUnique(name) {

    var params = { name: name };
    var url = "../../Product/IsCatagoryNameUnique";
    $.post(url, params, function (data) {

        if (data === true) {
            $("#Name_warning_label").text("Name is already Taken !").css("color", "red").fadeOut(3000);
        }

    }).fail(function (err) {
        alert(err);
    });
}

function isCatagoryCodeUnique(code) {

    var params = { code: code };
    var url = "../../Product/IsCatagoryCodeUnique";
    $.post(url, params, function (data) {

        if (data === true) {
            $("#Code_warning_label").text("Code is already Taken !").css("color", "red").fadeOut(3000);

        }
    }).fail(function (err) {
        alert(err);
    });
}

function createCatagorySelectedListItem() {
    $.ajax(
        {
            url: "../../Product/GetCatagories",
            contentType: "application/json;chasrset=utf-8",
            type: "POST",
            data: JSON.stringify(),
            success: function (data) {

                $("#CatagoryId").empty();
                $("#CatagoryId").append("<option>-----Select-----</option>");
                if (data !== false && data !== undefined) {
                    $.each(data, function (k, v) {
                        $("#CatagoryId").append("<option value='" + v.Id + "'> " + v.Name + "</option>");
                    });
                }
            },
            error: function (err) {
                alert(err);
            }
        }

    );
}


function getProducts() {
    $.ajax({

        url: "../../Product/GetProducts",
        type: "GET",
        data: JSON.data,
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            if (data !== false && data !== undefined) {

                var sl = 1;
                $.each(data, function (k, v) {

                    tableRowEffect(sl, v.Name, v.UnitPrice, v.CostPrice, v.ReorderLevel, v.PhotoStr, v.Description, v.Id);
                    sl++;
                });
            }

        }, error: function (err) {
            alert(err);
        }
    });
}


function tableRowEffect(serial, productName, productUnitPrice, productCostPrice, productReorderLevel, productImage, productDescription, id) {



    var serialCell = "<td>" + serial++ + "</td>";
    var productsNameCell = "<td>" + productName + "</td>";
    var productUnitPriceCell = "<td >" + productUnitPrice + "</td>";
    var productCostPriceCell = "<td >" + productCostPrice + "</td>";
    var productsReorderCell = "<td >" + productReorderLevel + "</td>";




    var productsImageCell = "<td align='center'><img src='" + productImage + "' style='height: 120px; width: 100px;'/></td >";


    var productsDiscriptionCell = "<td>" + productDescription + "</td>";

    var options = "<td align='center'><button type='button' class='btn btn-success' id='Edit' onClick='editRow(" + id + ")'> <span class='glyphicon glyphicon-pencil'></span></button>    <button type='button' class='btn btn-warning' id='Delete' onClick='deleteRow(" + id + ")'><span class='glyphicon glyphicon-trash'></span></button></td>";


    var createNewRow = "<tr> " + serialCell + productsNameCell + productUnitPriceCell + productCostPriceCell + productsReorderCell + productsImageCell + productsDiscriptionCell + options + " </tr>";

    $("#ProductsDetailsTable").append(createNewRow);


}


function deleteRow(id) {
    deleteFromServer(id);
    $("#ProductsDetailsTable").empty();



}

function deleteFromServer(id) {

    var serial = 0;
    if (confirm('Are You Sure to Delete?') === true) {

        var params = { id: id };
        var url = "../../Product/Delete";
        $.post(url, params, function (data) {
            data.forEach(c => {
                tableRowEffect(++serial, c.Name, c.UnitPrice, c.CostPrice, c.ReorderLecel, c.PhotoStr, c.Description, c.Id);

            });



        }).fail(function (err) {
            alert(err);
        });
    }
}



function editRow(id) {
    var params = { id: id };
    var url = "../../Product/GetProducts";
    $.post(url, params, function (data) {
        data.forEach(c => {





            $("#Name").val(c.Name);
            $("#Code").val(c.Code);
            $("#CatagoryId").val(c.CatagoryId);
            $('#ReorderLevel').val(c.ReorderLevel);
            $('#UnitPrice').val(c.UnitPrice);
            $('#CostPrice').val(c.CostPrice);
            $('#Description').val(c.Description);
            $('#ImageData').hide();

            $("#saveButton").val("Edit");
        });


    }).fail(function (err) {
        alert(err);
    });

}

