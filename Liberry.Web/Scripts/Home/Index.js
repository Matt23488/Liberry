(function () {

    $("#tits").on("click", function () {

        var request = new AjaxRequest(buildURL("GetToken", "Token"));
        request.parameters.set("password", "lololtits");
        request.post(function () { });

    });

})();