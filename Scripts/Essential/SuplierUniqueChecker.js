


$("#ContactNo").change(function () {

    var nam = $(this).val();
    isSuplierContactUnique(nam);


});
$("#Email").change(function () {

    var nam = $(this).val();
    isSuplierEmailUnique(nam);


});
$("#Code").change(function () {

    var code = $(this).val();
    isSuplierCodeUnique(code);


});

function isSuplierContactUnique(number) {

    var params = { number: number };
    var url = "../../Buyers/IsSuplierContactUnique";
    $.post(url, params, function (data) {

        if (data === true) {
            $("#Contact_warning_label").text("Contact is already Taken !").css("color", "red").fadeOut(3000);
        }

    }).fail(function (err) {
        alert(err);
    });
}

function isSuplierCodeUnique(code) {

    var params = { code: code };
    var url = "../../Buyers/IsSuplierCodeUnique";
    $.post(url, params, function (data) {

        if (data === true) {
            $("#Code_warning_label").text("Code is already Taken !").css("color", "red").fadeOut(3000);

        }
    }).fail(function (err) {
        alert(err);
    });
}

function isSuplierEmailUnique(email) {

    var params = { email: email };
    var url = "../../Buyers/IsSuplierEmailUnique";
    $.post(url, params, function (data) {

        if (data === true) {
            $("#Email_warning_label").text("Email is already Taken !").css("color", "red").fadeOut(3000);

        }
    }).fail(function (err) {
        alert(err);
    });
}