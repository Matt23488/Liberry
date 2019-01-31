(function () {

    var tokenKey = "_token";

    // Retrieve token from cookie.
    var token = $.cookie(tokenKey);
    if (!token || !token.length || token.length === 0) {
        // Prompt for password
        $("#passwordModal").modal();
        $("#submitPasswordButton").on("click", function () {
            var request = new AjaxRequest(buildURL("GetToken", "Token"));
            request.parameters.set("password", $("#password").val());
            request.post(function (token) {
                alert(token);
                $.cookie(tokenKey, token);
            }, function (err) {
                alert("error");
                console.log(err);
            });
        });
    }

})();