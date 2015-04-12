function GetAntiForgeryToken() {
    var tokenField = $("input[type='hidden'][name$='RequestVerificationToken']");
    if (tokenField.length == 0) {
        return null;
    } else {
        return {
            name: tokenField[0].name,
            value: tokenField[0].value
        };
    }
}

$.ajaxPrefilter(
    function(options, localOptions, jqXHR) {
        if (options.type !== "GET") {
            var token = GetAntiForgeryToken();
            if (token !== null) {
                if (options.data.indexOf("X-Requested-With") === -1) {
                    options.data = "X-Requested-With=XMLHttpRequest" + ((options.data === "") ? "" : "&" + options.data);
                }
                options.data = options.data + "&" + token.name + '=' + token.value;
            }
        }
    }
);

$.postify = function(value) {
    var result = {};

    var buildResult = function(object, prefix) {
        for (var key in object) {

            var postKey = isFinite(key)
                ? (prefix != "" ? prefix : "") + "[" + key + "]"
                : (prefix != "" ? prefix + "." : "") + key;

            switch (typeof (object[key])) {
            case "number":
            case "string":
            case "boolean":
                result[postKey] = object[key];
                break;

            case "object":
                if (object[key].toUTCString)
                    result[postKey] = object[key].toUTCString().replace("UTC", "GMT");
                else {
                    buildResult(object[key], postKey != "" ? postKey : key);
                }
            }
        }
    };

    buildResult(value, "");

    return result;
};