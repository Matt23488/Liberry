(function () {

    var tokenKey = "_token";

    // Retrieve token from cookie.
    var token = $.cookie(tokenKey);
    if (!token || !token.length || token.length === 0) {
        // Prompt for password
    }

})();