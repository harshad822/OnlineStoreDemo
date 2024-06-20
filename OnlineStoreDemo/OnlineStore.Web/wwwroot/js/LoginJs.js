$(document).ready(function () {
    $('#signInForm').submit(function (event) {
        event.preventDefault();

        var username = $('#signInUsername').val().trim();
        var password = $('#signInPassword').val();

        if (username.length > 255) {
            toastr.error("Invalid Username", "Error");
            return;
        }

        if (password.length < 6) {
            toastr.error("Password must be at least 6 characters long", "Error");
            return;
        }
        SignIn();
    });

    // Sign up form validation
    $('#signupForm').submit(function (event) {
        event.preventDefault();

        var username = $('#signupUsername').val().trim();
        var email = $('#signupEmail').val().trim();
        var password = $('#signupPassword').val();
        var confirmPassword = $('#signupConfirmPassword').val();

        if (username.length > 255) {
            toastr.error("Username length cannot exceed 255 characters.", "Error");
            return;
        }

        if (email.length > 255) {
            toastr.error("Email length cannot exceed 255 characters.", "Error");
            return;
        }

        if (password.length < 6) {
            toastr.error("Password must be at least 6 characters long.", "Error");
            return;
        }

        if (password !== confirmPassword) {
            toastr.error("Password and Confirm Password must match.", "Error");
            return;
        }
        SignUp();
    });

});
function toggleForm() {
    var signInCard = $("#signInCard");
    var signupCard = $("#signupCard");
    if (signInCard.hasClass("d-none")) {
        signInCard.removeClass("d-none");
        signupCard.addClass("d-none");
    } else {
        signupCard.removeClass("d-none");
        signInCard.addClass("d-none");
    }

    clearForm();
}

function SignIn() {
    var data = {
        Username: $("#signInUsername").val().trim(),
        Password: $("#signInPassword").val()
    }
$(".loader").show();
    $.ajax({
        type: "POST",
        url: "/User/SignIn",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
			$(".loader").hide();
            localStorage.removeItem('cart');
            if (result.isSuccess) {
                toastr.success(result.message, "Success");
                window.location.href = "/Product";
            } else {
                toastr.error(result.message, "Error");
            }
        },
        error: function (result) {
			$(".loader").hide();
        }
    });
}
function SignUp() {
    var data = {
        Username: $('#signupUsername').val().trim(),
        Email: $('#signupEmail').val().trim(),
        Password: $('#signupPassword').val()
    }
	$(".loader").show();
    $.ajax({
        type: "POST",
        url: "/User/SignUp",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
			$(".loader").hide();
            if (result.isSuccess) {
                toastr.success(result.message, "Success");
				clearForm();
                toggleForm();
            } else {
                toastr.error(result.message, "Error");
            }

        },
        error: function (result) {
			$(".loader").hide();
        }
    });
}
function clearForm() {
    $("#signInPassword").val("");
    $("#signInUsername").val("");
    $('#signupUsername').val("");
    $('#signupEmail').val("");
    $('#signupPassword').val("");
    $('#signupConfirmPassword').val("");
}

function ShowOrHidePwd() {
    if ($("#signInPassword").attr("type") === "password") {
        $("#signInPassword").attr("type", "text");
    } else {
        $("#signInPassword").attr("type", "password");
    }
}

function ShowOrHidesignUpPwd() {
    if ($("#signupPassword").attr("type") === "password") {
        $("#signupPassword").attr("type", "text");
    } else {
        $("#signupPassword").attr("type", "password");
    }
}

function ShowOrHideConfirmPwd() {
    if ($("#signupConfirmPassword").attr("type") === "password") {
        $("#signupConfirmPassword").attr("type", "text");
    } else {
        $("#signupConfirmPassword").attr("type", "password");
    }
}
function checkEnterKey(event) {
    if (event.key === 'Enter') {
        event.preventDefault();
        $("form[name='signInForm']").submit();
    }
}