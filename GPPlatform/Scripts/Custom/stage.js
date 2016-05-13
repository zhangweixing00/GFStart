
/*
**使用jsonp跨域获取关卡列表
*/
var uri = '/api/gp';
function loadStageList(id) {
    $.ajax({
        url: uri + "/GetStageListByUser",
        dataType: "jsonp",
        jsonp: "callback",
        jsonpCallback: "InitStageList",
        contentType: "application/json;charset=utf-8",
        data: { "userId": id },
        beforeSend: function () {
            //$(".loadMore0").find("b").html("加载中<i></i>");
        },
        complete: function () {

        },
        success: function (data) {
            //todo:
            if (data) {
                //  alert('提交成功！');
            } else {
                //  alert('获取失败！');
            };
        },
        error: function (a, b, c, d, e) {
            //alert('获取失败！');
        }
    });
}

function InitStageList(data) {
    var list = "";
    $.each(data, function (x, y) {
        list += "<option value='" + y.Id + "'>" + y.Name + "</option>";
    });
    $("#ddlStageList").html(list);
}

//******
function SumbitMap(userId) {
    var name = prompt('输入一个名称:', '');
    if (name == '' || name == null) {
        alert('名称为空');
        return;
    }
    a = new Object();
    a.callback = "SaveStage";
    a.map = new Object();
    a.map.Name = name;
    a.map.row = 10;
    a.map.col = 10;
    a.UserId = userId;
    var mapdata = new Array();
    $("#board td").each(function (index, element) {
        var info = new Object();
        info.x = $(this).attr("x");
        info.y = $(this).attr("y");
        info.n = $(this).attr("class");
        //mapdata.concat(info);
        mapdata[index] = info;
    })
    a.map.data = mapdata;
    var postData = window.JSON.stringify(a);
    $.ajax({
        type: "POST",
        url: uri + "/SaveStage",
        dataType: "jsonp",
        jsonp: "callback",
        jsonpCallback: "handler",
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
                alert('提交成功！');
                history.go(-1);
            } else {
                alert('提交失败！');
            };

        },
        error: function (a, b, c, d, e) {
            alert('获取失败！');
        }
    });
}
//**************