var maxLength = 4;

function ClickOne(id) {
    if ($("#" + id).attr("class") == "headerItem"
        || $("#" + id).attr("class") == "selectedItem"
        || $("#" + id).attr("class") == "bodyItem") {
        return;
    }
    a = new Object();
    a.x = $("#" + id).attr("x");
    a.y = $("#" + id).attr("y");
    a.headers = new Array();
    $("#my_board td[class='headerItem']").each(function (i, x) {
        a.headers[i] = new Object();
        a.headers[i].x = $(this).attr("x");
        a.headers[i].y = $(this).attr("y");
    });
    //if (a.headers.length==maxLength) {
    //    alert("已结束")
    //    return;
    //}
    a.Id = $("#ddlStageList").val();
    var postData = window.JSON.stringify(a);

    $.ajax({
        type: "POST",
        url: uri + "/ClickOne",
        dataType: "jsonp",
        jsonp: "callback",
        jsonpCallback: "DoRefresh",
        contentType: "application/json;charset=utf-8",
        data: postData,
        beforeSend: function () {
            //$(".loadMore0").find("b").html("加载中<i></i>");
        },
        complete: function () {

        },
        success: function (data) {
            //todo:
            if (data) {
                // alert('提交成功！');
            } else {
                // alert('获取失败！');
            };

        },
        error: function (a, b, c, d, e) {
            alert('获取失败！' + a + b + c + d + e);
        }
    });
}
function DoRefresh(data) {
    // alert(data.IsFinish);
    if (data.IsFinish == "1") {
        $.each(data.Blocks, function (x, y) {
            $("#Item_" + y.Y + "_" + y.X).attr("class", y.n);
        });
        alert("游戏结束");
    }
    else if (data.IsFinish != "-1") {
        //$("#board td").attr("class", "clearItem");
        $.each(data.Blocks, function (x, y) {
            $("#Item_" + y.Y + "_" + y.X).attr("class", y.n);
        });
        alert(data.IsFinish == "2" ? "打中机头" : "打中机身");
    }
    else {
        $.each(data.Blocks, function (x, y) {
            $("#Item_" + y.Y + "_" + y.X).attr("class", y.n);
        });
    }
}