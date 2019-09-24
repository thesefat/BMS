/// <reference path="../../models/purchasedetail.js" />



// in edit mode
//1- Get Purchase Details JsonData by PurchaseId
// Add to purchaseDetailList
// Call createNewRowForPurchase()






$(document.body).on("click", "#AddButton", function () {
    addPurchaseDetail();

    //var name = $(this).attr("data-name");
    //var name2 = $(this).data("name");

});


function addPurchaseDetail() {

    const model = getSelectedData();
    if (model !== false && model !== undefined) {


        purchaseDetailList.push(model);
        createNewRowForPurchase();
    }
}


let purchaseDetailList = [];


function createNewRowForPurchase() {

    //Create function For Global Validation
    if (purchaseDetailList.length > 0) {
        $("#ProductsDetailsTable").empty();

        let sl = 0;
        purchaseDetailList.forEach(c => {
            const index = $("#ProductsDetailsTable").children("tr").length;

            //let sl2 = index;


            const slCell = "<td><input type='hidden' id='Index_" + index + "' name='PurchaseDetails.Index' value='" + index + "'/> " + (++sl) + " </td>";
            const productName = "<td><input type='hidden' id='ProductName_" + index + "' name='PurchaseDetails[" + index + "].ProductId' value='" + c.productId + "' />" + c.productName + "</td>";
            const unitPrice = "<td><input type='hidden' id='UnitPrice_" + index + "' name='PurchaseDetails[" + index + "].UnitPrice' value='" + c.unitPrice + "' />" + c.unitPrice + "</td>";
            const qty = "<td><input type='hidden' id='Qty_" + index + "' name='PurchaseDetails[" + index + "].Qty' value='" + c.qty + "' />" + c.qty + "</td>";
            const lineTotal = "<td>" + c.getLineTotal() + "</td>";

            // const deleteBtn = "<input type='button' value='Delete' data-id="+10+" data-name="+c.productName+" class='btn btn-sm btn-danger' id='DeleteBtn' onClick='deleteRow(" + index + ")'/>";
            const deleteBtn = "<td><input type='button' value='Delete' class='btn btn-sm btn-danger' id='DeleteBtn' onClick='deleteRow(" + c.productId + ")' />" +
                "<input type='button' value='Edit' class='btn btn-sm btn-warning' id='DeleteBtn' onClick='editRow(" + c.productId + ")' />" +
                " </td>";

            const tr = "<tr id='ProductRow_" + index + "'>" + slCell + productName + unitPrice + qty + lineTotal + deleteBtn + "</tr>";

            $("#ProductsDetailsTable").append(tr);

        });


        clearDetailForm();
    } else {
        $("#ProductsDetailsTable").empty();
    }

}


function editRow(productId) {
    if (productId >= 0) {

        const model = purchaseDetailList.find(c => c.productId == productId);
        if (model != undefined) {
            purchaseDetailList = purchaseDetailList.filter(c => c.productId != productId);

            $("#ProductId").val(model.productId);
            $("#Qty").val(model.qty);
            $("#UnitPrice").val(model.unitPrice);

            createNewRowForPurchase();
        }


    }
}

function deleteRow(productId) {
    if (productId >= 0) {
        purchaseDetailList = purchaseDetailList.filter(c => c.productId != productId);
        createNewRowForPurchase();
    }
}

function getSelectedData() {

    const model = new PurchaseDetail();

    model.productId = $("#ProductId").val();
    model.productName = $("#ProductId option:selected").text();
    model.qty = $("#Qty").val();
    model.unitPrice = $("#UnitPrice").val();

    if (!(model.productId > 0) || model.qty == "" || !(model.unitPrice > 0)) {
        alert("Please Check Details");
        return false;
    }

    return model;
}

function clearDetailForm() {

    $("#ProductId").val("");
    $("#Qty").val(0);
    $("#UnitPrice").val(0);

}