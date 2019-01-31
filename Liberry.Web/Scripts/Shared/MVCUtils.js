(function () {

    function buildURL(action, controller) {
        return _baseURL + controller + "/" + action;
    }

    window.buildURL = buildURL;

})();