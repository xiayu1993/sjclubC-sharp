$(document).ready(function () {
    $(".a_president").click(function () {
        var account = $(this).attr("account");
        $("#txt_recivierAccount").val(account);
    });
});