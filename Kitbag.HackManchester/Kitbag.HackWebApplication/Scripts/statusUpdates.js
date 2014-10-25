$(function () {
    // Declare a proxy to reference the hub. 
    var status = $.connection.statusHub;
    // Create a function that the hub can call to broadcast messages.
    status.client.broadcastMessage = function (message, email, imageUrl, timeStamp) {
        AddStatus(message, email, imageUrl, timeStamp);
    };
    // Start the connection.
    $.connection.hub.start().done(function () {
        $('#statusButton').click(function () {
            // Call the Send method on the hub. 
            status.server.send($('#statusMessage').val());
            $('#statusMessage').val('');
        });
    });
});

function AddStatus(message, email, imageUrl, timeStamp) {
    $("<div class='feed-status'><div class='user-image'><img src='"+imageUrl+"'></div><div class='post'><div class='user-name'><a href='/person/view/1'>"+email+"</a></div><div class='message'>" + message + "</div><div class='when'>"+timeStamp+"</div></div></div><hr style='clear:both'>").prependTo('#feed').hide().slideDown();
}