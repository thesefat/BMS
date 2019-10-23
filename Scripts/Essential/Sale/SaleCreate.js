/// <reference path="../../models/saledetail.js" />



//$("#InStock")
//$("#UnitPrice")
//$("#LoyalityPoint")
//$("#ProductName")

$(document.body).on("click", "#AddButton", function () {

    addSaleDetail();
    clearDetailForm();

});

$(document.body).on("click", "#submitButton", function () {

    var value = $("#PurchaseDate").val();

    if (value == "") {
        $("#dateAlert").css('color', 'red').text("Required").fadeOut(3000);
        $("#PurchaseDate").focus();
        return false;
    }
    return true;
});



let saleDetailsList = [];

function addSaleDetail() {

    const model = getSelectedData();

    if (model !== false && model !== undefined) {

        if (duplicateCheck(model.productId)) {
            return alert("Already added into cart you can - Edit - now !");
        } else {
            saleDetailsList.push(model);
            createNewRowForPurchase();
        }


    }


}

function createNewRowForPurchase() {

    //Create function For Global Validation
    if (saleDetailsList.length > 0) {
        $("#ProductsDetailsTable").empty();

        let sl = 0;
        saleDetailsList.forEach(c => {
            const index = $("#ProductsDetailsTable").children("tr").length;

            //let sl2 = index;


            const slCell = "<td><input type='hidden' id='Index_" + index + "' name='SaleDetails.Index' value='" + index + "'/> " + (++sl) + " </td>";
            const productName = "<td><input type='hidden' id='ProductName_" + index + "' name='SaleDetails[" + index + "].ProductId' value='" + c.productId + "' />" + c.productName + "</td>";
            const unitPrice = "<td><input type='hidden' id='UnitPrice_" + index + "' name='SaleDetails[" + index + "].UnitPrice' value='" + c.unitPrice + "' />" + c.unitPrice + "</td>";
            const qty = "<td><input type='hidden' id='Qty_" + index + "' name='SaleDetails[" + index + "].Qty' value='" + c.qty + "' />" + c.qty + "</td>";
            const lineTotal = "<td>" + c.getLineTotal() + "</td>";

            // const deleteBtn = "<input type='button' value='Delete' data-id="+10+" data-name="+c.productName+" class='btn btn-sm btn-danger' id='DeleteBtn' onClick='deleteRow(" + index + ")'/>";
            const options = "<td><input type='button' value='Delete' class='btn btn-sm btn-danger' id='DeleteBtn' onClick='deleteRow(" + c.productId + ")' />" +
                "<input type='button' value='Edit' class='btn btn-sm btn-warning' id='DeleteBtn' onClick='editRow(" + c.productId + ")' />" +
                " </td>";

            const tr = "<tr id='ProductRow_" + index + "'>" + slCell + productName + unitPrice + qty + lineTotal + options + "</tr>";

            $("#ProductsDetailsTable").append(tr);

        });


        clearDetailForm();
    } else {
        $("#ProductsDetailsTable").empty();
    }

}

function duplicateCheck(id) {

    const found = saleDetailsList.find(c => c.productId === id);
    if (found !== undefined) {
        return true;
    }

    return false;


}

function getSelectedData() {

    const model = new SaleDetail();

    model.productId = $("#ProductName").val();
    model.productName = $("#ProductName option:selected").text();
    model.qty = $("#SaleQuantity").val();
    model.unitPrice = $("#UnitPrice").val();

    if (!(model.productId > 0) || model.qty === "" || !(model.unitPrice > 0)) {
        //alert("Please Check Details");
        $("#detailsWarning").text("Please check details entry !").css("color", 'blue');
        return false;
    }

    return model;
}

function editRow(productId) {
    if (productId >= 0) {

        const model = saleDetailsList.find(c => c.productId == productId);
        if (model != undefined) {
            saleDetailsList = saleDetailsList.filter(c => c.productId != productId);

            $("#ProductName").val(model.productId);
            $("#Qty").val(model.qty);
            $("#UnitPrice").val(model.unitPrice);

            //createNewRowForPurchase();
        }


    }
}

function deleteRow(productId) {
    if (productId >= 0) {
        saleDetailsList = saleDetailsList.filter(c => c.productId != productId);
        createNewRowForPurchase();
    }
}

function clearDetailForm() {

    $("#ProductName").val("");
    $("#Qty").val(0);
    $("#UnitPrice").val(0);

}



