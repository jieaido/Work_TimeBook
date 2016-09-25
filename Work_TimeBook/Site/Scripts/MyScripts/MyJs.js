
var JsHelper= {
     CheckSelect : function (parameters) {
        $("#Parentid").change(function () {

            if ($("#Parentid select").val() === "-1") {

                $("#controllername").hide();

            } else {
                $("#controllername").show();
            }
        });
    }
}
