$(document).ready(function () {

    console.log("document.ready");

    var totalTime = 0;
    var times = $("td.duration").each(function (index) {

        var text = $(this).text();
        if (text.length > 0) {
            totalTime += parseInt($(this).text());
        }

    });

    $("#totalTimeMinutes").text(totalTime);
    var hours = (totalTime / 60).toFixed(0);
    var minutes = (totalTime % 60);
    $("#totalTimeHours").text(hours);
    $("#minutes").text(minutes);

    // get total time from the server
    var date = $("#date").val();
    if (date.length > 0) {
        var serviceUrl = '/DailyTask/GetTotalTimeByDate';
       
        $.ajax({
            type: "POST",
            url: serviceUrl,
            data: JSON.stringify({ "date": date }),
            contentType: 'application/json; charset=utf-8',            
            success: successFunc,
            error: errorFunc
        });
    }
});
var successFunc = function (data) {
    console.log("Success! => " + data);
    $("#totalTimeServer").html(data);
};

var errorFunc = function (xhr, status,error) {    
    console.log("Error! => " + xhr.responseText +" Status:"+ status +" Error:"+ error);
};


//var successFunc = function (data, status) {
//    console.log("Success! => " + data);
//};

//var errorFunc = function (xhr, status, error) {    
//    console.log("Error! => " + xhr.responseText +" Status:"+ status +" Error:"+ error);
//};