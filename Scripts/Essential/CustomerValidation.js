



$("#Name").change(function () {
    var nam = $(this).val();
    isCatagoryNameUnique(nam);
});

$("#Code").change(function () {
    var code = $(this).val();
    isCatagoryCodeUnique(code);
});

$("#ContactNo").change(function () {
    var nam = $(this).val();
    isCustomerContactNoUnique(nam);
});

$("#Email").change(function () {
    var code = $(this).val();
    isCustomerEmailUnique(code);
});

function isCustomerNameUnique(name) {

    var params = { name: name };
    var url = "../../Customer/IsCustomerNameUnique";
    $.post(url, params, function (data) {

        if (data === true) {
            $("#Name_warning_label").text("Name is already Taken !").css("color", "red").fadeOut(4000);
        }

    }).fail(function (err) {
        alert(err);
    });
}

function isCustomerCodeUnique(code) {

    var params = { code: code };
    var url = "../../Customer/isCustomerCodeUnique";
    $.post(url, params, function (data) {

        if (data === true) {
            $("#Code_warning_label").text("Code is already Taken !").css("color", "red").fadeOut(3000);

        }
    }).fail(function (err) {
        alert(err);
    });
}

function isCustomerContactNoUnique(number) {

    var params = { number: number };
    var url = "../../Customer/isCustomerContactNoUnique";
    $.post(url, params, function (data) {

        if (data === true) {
            $("#ContactNo_warning_label").text("Name is already Taken !").css("color", "red").fadeOut(4000);
        }

    }).fail(function (err) {
        alert(err);
    });
}

function isCustomerEmailUnique(emial) {

    var params = { email: email };
    var url = "../../Customer/isCustomerEmailUnique";
    $.post(url, params, function (data) {

        if (data === true) {
            $("#Email_warning_label").text("Code is already Taken !").css("color", "red").fadeOut(3000);

        }
    }).fail(function (err) {
        alert(err);
    });
}