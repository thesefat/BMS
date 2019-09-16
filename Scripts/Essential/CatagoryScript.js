

//$(document).ready(function () {
//    actionLoader("#action");
   
//});


$("#Name").change(function () {

    var nam = $(this).val();
    isCatagoryNameUnique(nam);


});

$("#Code").change(function () {

    var code = $(this).val();
    isCatagoryCodeUnique(code);
    //if (nam !== "") {
    //  
    //}

});

function isCatagoryNameUnique(name) {

    var params = { name: name };
    var url = "../../Catagory/IsCatagoryNameUnique";
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
    var url = "../../Catagory/IsCatagoryCodeUnique";
    $.post(url, params, function (data) {

        if (data === true) {
            $("#Code_warning_label").text("Code is already Taken !").css("color", "red").fadeOut(3000);

        }
    }).fail(function (err) {
        alert(err);
    });
}

