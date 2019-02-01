(function () {

    $("#TestValidate").on("click", function () {
        var request = new AjaxRequest(buildURL("TestValidate", "Home"));
        request.get(function () { alert("success"); }, function (err) { alert(err); });
    });

    $("#TestNoValidate").on("click", function () {
        var request = new AjaxRequest(buildURL("TestNoValidate", "Home"));
        request.get(function () { alert("success"); }, function (err) { alert(err); });
    });

})();