$(function () {
    // Declare a proxy to reference the hub. 
    var status = $.connection.statusHub;
    // Create a function that the hub can call to broadcast messages.
    status.client.broadcastMessage = function (message, email, imageUrl, timeStamp, type) {
        AddStatus(message, email, imageUrl, timeStamp, type);
    };

    var currentlyWorkingOn = $.connection.currentlyWorkingOnHub;

    currentlyWorkingOn.client.broadcastMessage = function (message, email, imageUrl, timeStamp, type) {
        AddStatus(message, email, imageUrl, timeStamp, type);
    };

    // Start the connection.
    $.connection.hub.start().done(function () {
        $('#statusButton').click(function () {
            // Call the Send method on the hub. 
            status.server.send($('#statusMessage').val());
            $('#statusMessage').val('');
        });

        $('#currentlyWorkingOnButton').click(function () {
            // Call the Send method on the hub. 
            currentlyWorkingOn.server.send($('#currently-working-on-status-new').val());
            $('#currently-working-on-status-new').val('');
        });
    });

    

});

function AddStatus(message, email, imageUrl, timeStamp, type) {
    $("<div class='feed-status " + type + "'><div class='user-image'><img src='"+imageUrl+"'></div><div class='post'><div class='user-name'><a href='/person/view/1'>"+email+"</a></div><div class='message'>" + message + "</div><div class='when'>"+timeStamp+"</div></div><div style='clear:both'></div></div>").prependTo('#feed').hide().slideDown();
}