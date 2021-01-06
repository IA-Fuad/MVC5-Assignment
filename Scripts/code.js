console.log("from code js");

let allInfo;
let dataRetrieveSuccess = false;
let searchWord = "";

$(document).ready(function () {

    $(".up").click(function () {
        $.ajax({
            type: 'POST',
            url: 'SortData',
            data: { x: -1, y: 1 },
            dataType: 'json',
            success: function (data) {
                //dataRetrieveSuccess = true;
                console.log(data);
                //allInfo = Object.keys(data).map(key => data[key]);
                // data.sort((a, b) => (a.Name > b.Name) ? 1 : -1);
                //console.log(data);

                window.location.href = "Index";
            },
            error: function (e) {
                console.log("error");
                console.log(e);
            }
        });
    });
   
});