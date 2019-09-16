
//$(document).ready(function () {
//    createProductSelectedListItem();
//    actionLoader("#options");
//});




//function actionLoader(selector) {
//    $(selector).append(`<button type="button" class="btn btn-success" id="Edit">
//                        <span class="glyphicon glyphicon-pencil"></span>

//                      </button >
//                      <button type="button" class="btn btn-info" id="Update">
//                        <span class="glyphicon glyphicon-refresh"></span>
//                     </button> <button type="button" class="btn btn-warning" id="Delete">
//                         <span class="glyphicon glyphicon-trash"></span>
//                     </button>`);

//}


//function createProductSelectedListItem() {
//    $.ajax(
//        {
//            url: "../../Sale/GetProducts",
//            contentType: "application/json;chasrset=utf-8",
//            type: "POST",
//            data: JSON.stringify(),
//            success: function (data) {

//                $("#ProductName").empty();
//                $("#ProductName").append("<option>-----Select-----</option>");
//                if (data !== false && data !== undefined) {
//                    $.each(data, function (k, v) {
//                        $("#ProductName").append("<option value='" + v.Id + "'> " + v.Name + "</option>");
//                    });
//                }
//            },
//            error: function (err) {
//                alert(err);
//            }
//        }

//    );
//}