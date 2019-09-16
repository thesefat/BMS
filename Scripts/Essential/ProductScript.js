
$(document).ready(function () {
    actionLoader("#options");
    createCatagorySelectedListItem();
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