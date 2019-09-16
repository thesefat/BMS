
$(document).ready(function () {
    getSuplierSelectedListItem();
    actionLoader("#options");
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

function getSuplierSelectedListItem() {
    $.ajax(
        {
            url: "../../Buyers/GetSupliers",
            contentType: "application/json;chasrset=utf-8",
            type: "POST",
            data: JSON.stringify(),
            success: function (data) {

                $("#SuplierId").empty();
                $("#SuplierId").append("<option>-----Select-----</option>");
                if (data !== false && data !== undefined) {
                    $.each(data, function (k, v) {
                        $("#SuplierId").append("<option value='" + v.Id + "'> " + v.Name + "</option>");
                    });
                }
            },
            error: function (err) {
                alert(err);
            }
        }

    );
}