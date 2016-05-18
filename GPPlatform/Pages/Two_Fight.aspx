<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Two_Fight.aspx.cs" Inherits="GPPlatform.Pages.Two_Fight" %>

<div data-role="page">
    <script type="text/javascript" src="../Scripts/jquery-2.2.3.js"></script>
    <script src="../Scripts/jquery-2.2.3.min.js"></script>
    <link rel="stylesheet" href="../Content/jquery.mobile-1.4.2.css" />
    <link type="text/css" href="../Content/Custom/board.css" rel="stylesheet" />
    <link type="text/css" href="../Content/Custom/fightboard.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/Custom/stage.js"> </script>
    <script type="text/javascript">
        $(function () {

            InitTable();
            BindAction();
            InitLables(localData);
        })
        //$(document).on("pageload", function (event, data) {
        //    InitTable();
        //    BindAction();
        //    InitLables(localData);
        //    var userId = 'd59238a9-c535-41ca-81fe-cfe8ad13ad24';
        //    //$(".btnName").click(function () {
        //    //    SumbitMap(userId);

        //    //})
        //});

        ///时间相关
        var isRunning = true;
        var currentTime = new Date();
        currentTime.setHours(0, 0, 0, 0);
        showCurrentTime();
        var timerTigger = setInterval(showCurrentTime, 1000);

        function showCurrentTime() {
            var dateText = diplayTime(currentTime);
            $("#showTime").html("时间:" + dateText);
            if (isRunning == false) {
                clearInterval(timerTigger);
            } var t = currentTime.getTime();
            t += 1000;//一个小时的毫秒数
            currentTime = new Date(t);
        }
        function diplayTime(d) {
            var displayTimeText = "";
            var hour = d.getHours();
            var min = d.getMinutes();
            var s = d.getSeconds();

            displayTimeText = hour < 10 ? "0" + hour : hour;
            displayTimeText += (":" + (min < 10 ? "0" + min : min));
            displayTimeText += ":" + (s < 10 ? "0" + s : s);
            return displayTimeText;
        }


        function InitTable() {
            var body = "";
            for (var row = 0; row < 10; row++) {
                body += "<tr>";
                for (var col = 0; col < 10; col++) {
                    body += "<td id='Item_" + row + "_" + col + "' x='" + col + "' y='" + row + "' class='clearItem' >";
                    body += "</td>";
                }
                body += "</tr>";
            }
            $("#my_board").html(body);

            body = "";
            for (var row = 0; row < 10; row++) {
                body += "<tr>";
                for (var col = 0; col < 10; col++) {
                    body += "<td id='your_boardItem_" + row + "_" + col + "' x='" + col + "' y='" + row + "' class='clearItem' >";
                    body += "</td>";
                }
                body += "</tr>";
            }
            $("#your_board").html(body);
        }
        function BindAction() {
            $("#my_board td").click(function () {
                //alert($(this).attr("class"));
                if ($(this).attr("class") != "clearItem") {
                    return;
                }
                ClickOne($(this).attr("id"));
            });
        }

        var localData = new Object();
        localData.MH = 0;
        localData.MB = 0;
        localData.YH = 0;
        localData.YB = 0;
        function InitLables() {
            var statusArray = new Array();
            statusArray[0] = "平";
            statusArray[1] = "优";
            statusArray[2] = "劣";
            var statusIndex = 0;
            if (localData.MH > localData.YH) {
                statusIndex = 1;
            }
            else if (localData.MH < localData.YH) {
                statusIndex = 2;
            }
            else {
                if (localData.MB > localData.YB) {
                    statusIndex = 1;
                }
                else if (localData.MB < localData.YB) {
                    statusIndex = 2;
                }
            }
            var headTxt = "Head:";
            var bodyTxt = "Body:";
            $("#my_ShotHeaders").html(headTxt + localData.MH);
            $("#your_ShotHeaders").html(headTxt + localData.YH);
            $("#my_Shotbodys").html(bodyTxt + localData.MB);
            $("#your_Shotbodys").html(bodyTxt + localData.YB);
            $("#my_status").html("形势:" + statusArray[statusIndex]);
            //$("#my_status").html("123");
        }

    </script>
    <%--    <div data-role="header">
        <a  data-role="button" data-icon="home" data-transition='slide' data-rel="back" data-direction="reverse">返回</a>
        <h1>CreateMap</h1>
        <!--<a href="#" data-role="button" data-icon="search">搜索</a>-->
    </div>--%>        

    <div data-role="content">
    <div class="my_header">
            <span id="showTime"></span>
            <span id="my_status"></span>
            <span id="my_ShotHeaders"></span>
            <span id="my_Shotbodys"></span>
        </div>
        <table id="my_board" class="board">
            <tr>
                <td onclick=""></td>
            </tr>
        </table>
        <div style="width:350px;height:0px;border-style:solid none;border-color:ActiveBorder;border-width:1px; margin-top:10px;margin-bottom:10px;"></div>
        <div style="width: 100%" >
            <div class="your_header">
                <h3>your status</h3>
                <div id="your_ShotHeaders"></div>
                <div id="your_Shotbodys"></div>
            </div>
            <table id="your_board" class="board" style="width: 200px">
                <tr>
                    <td onclick=""></td>
                </tr>
            </table>
        </div>
        <a href="#" data-role="button" data-inline="true" data-rel="back">返回</a>
    </div>
</div>
