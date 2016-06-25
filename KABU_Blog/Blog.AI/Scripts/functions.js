
//error
//success
//info
//block
function AddMessage(title, message, type) {
    var alertBox = $(".box-content.alerts");
    alertBox.html(alertBox.html() + '<div class="alert alert-' + type + '"><button type="button" class="close" data-dismiss="alert">×</button><strong>' + title + '</strong> ' + message + '</div>');
}

function Block(input) {
    input.attr('disabled', '');
}


function Unblock(input) {
    input.removeAttr('disabled');
}

$(document).ready(function () {

    $(".box-content.alerts").bind('DOMNodeInserted DOMNodeRemoved', function (event) {
        debugger;
        var alertContainer = $('#alerts');

        var totalAlerts = document.querySelectorAll(".box-content.alerts > .alert").length;

        if (totalAlerts === 1 && event.type === "DOMNodeRemoved")
            alertContainer.hide();
        else
            alertContainer.show();
    });
});
