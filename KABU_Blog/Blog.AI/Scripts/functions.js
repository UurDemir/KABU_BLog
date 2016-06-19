
//error
//success
//info
//block
function AddMessage(title, message, type) {
    var alertBox = $(".box-content.alerts");
    alertBox.html(alertBox.html()+'<div class="alert alert-'+type+'"><button type="button" class="close" data-dismiss="alert">×</button><strong>'+title+'</strong> '+message+'</div>');
}

function Block(input) {
    input.attr('disabled', '');
}


function Unblock(input) {
    input.removeAttr('disabled');
}