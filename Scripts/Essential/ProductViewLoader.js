
$(document).ready(function () {
    getProducts();
});

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

                    tableRowEffect(sl, v.Name, v.UnitPrice, v.CostPrice, v.ReorderLevel, v.PhotoStr, v.Description);
                    sl++;
                });
            }

        }, error: function (err) {
            alert(err);
        }
    });
}



function tableRowEffect(serial, productName,productUnitPrice,productCostPrice,productReorderLevel,productImage,productDescription) {

   

    var serialCell = "<td>" + serial++ + "</td>";
    var productsNameCell = "<td>" + productName + "</td>";
    var productUnitPriceCell = "<td >" + productUnitPrice + "</td>";
    var productCostPriceCell = "<td >" + productCostPrice + "</td>";
    var productsReorderCell = "<td >" + productReorderLevel + "</td>";

   
   

    var productsImageCell = "<td align='center'><img src='" + productImage + "' style='height: 120px; width: 100px;'/></td >";
   

    var productsDiscriptionCell = "<td>" + productDescription + "</td>";

    var options = `<td align="center"><button type="button" class="btn btn-success" id="Edit">
                        <span class="glyphicon glyphicon-pencil"></span>

                      </button >
                      <button type="button" class="btn btn-info" id="Update">
                        <span class="glyphicon glyphicon-refresh"></span>
                     </button> <button type="button" class="btn btn-warning" id="Delete">
                         <span class="glyphicon glyphicon-trash"></span>
                     </button></td>`;


    var createNewRow = "<tr> " + serialCell + productsNameCell + productUnitPriceCell + productCostPriceCell + productsReorderCell + productsImageCell + productsDiscriptionCell + options + " </tr>";

    $("#ProductsDetailsTable").append(createNewRow);


}
