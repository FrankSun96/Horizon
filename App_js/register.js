var hide = true;
$("#chbAgree").click(function () {
    if (hide) {
        $("#btnCreate").show();
        hide = false;
    }else if(!hide)
    {
        hide = true;
        $("#btnCreate").hide();
    }
});