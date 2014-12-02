$(document).ready(function () {
    
    $('#privacyLink').click(function (event) {
        event.preventDefault();
        var url = $(this).attr('href');
        $('#privacy').load(url);
    });

    $('#commentForm').submit(function (event) {
        event.preventDefault();
        
        var comment = $(this).serialize();
        var url = $(this).attr('action');

        alert("In the form " + " URL=" + url + " DATA=" + comment);
        $.post(url, data, function (response) {
            $('#comments').append(response);
        });
    });
});