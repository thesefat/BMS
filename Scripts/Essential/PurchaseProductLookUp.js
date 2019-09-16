
$(document).ready(function () {
    getProductSelectedListItem();
    actionLoader("#options");
});



function actionLoader(selector) {
    $(selector).append(`<button type="button" class="btn btn-success" id="Edit">
                         Edit
                      </button >
                      <button type="button" class="btn btn-info" id="Update">
                         Update
                     </button> <button type="button" class="btn btn-warning" id="Delete">
                         Delete
                     </button>`);

}

function getProductSelectedListItem() {
    $.ajax(
        {
            url: "../../Purchase/GetProducts",
            contentType: "application/json;chasrset=utf-8",
            type: "POST",
            data: JSON.stringify(),
            success: function (data) {

                $("#ProductName").empty();
                $("#ProductName").append("<option>-----Select-----</option>");
                if (data !== false && data !== undefined) {
                    $.each(data, function (k, v) {
                        $("#ProductName").append("<option value='" + v.Id + "'> " + v.Name + "</option>");
                    });
                }
            },
            error: function (err) {
                alert(err);
            }
        }

    );
}