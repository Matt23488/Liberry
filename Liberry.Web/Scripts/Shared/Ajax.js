(function () {

    function AjaxRequest(url) {
        this.url = url;
        this.parameters = new Map();
    }

    AjaxRequest.prototype.get = function (successCallback, failCallback) {
        $.ajax(_getRequestObject.bind(this)("GET", successCallback, failCallback));
    };

    AjaxRequest.prototype.post = function (successCallback, failCallback) {
        $.ajax(_getRequestObject.bind(this)("POST", successCallback, failCallback));
    };

    function _getRequestObject(type, successCallback, failCallback) {
        var data = {};
        this.parameters.forEach(function (value, key) {
            data[key] = value;
        });

        return {
            type: type,
            url: this.url,
            cache: false,
            data: data,
            success: function (responseRaw) {
                var response;
                try {
                    response = JSON.parse(responseRaw);
                }
                catch (error) { response = responseRaw; }

                if (response.Success === true) {
                    if (successCallback) {
                        successCallback(response.Data);
                    }
                }
                else if (failCallback) {
                    failCallback(response.Message);
                }
                else {
                    console.log(response.Message);
                }
            },
            error: function (err) {
                if (failCallback) {
                    failCallback(err);
                }
                else {
                    console.log(err);
                }
            }
        };
    }

    window.AjaxRequest = AjaxRequest;

})();