<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateBoard.aspx.cs" Inherits="GPPlatform.Pages.CreateBoard" %>

<div data-role="page">
    <link rel="stylesheet" href="http://code.jquery.com/mobile/1.3.2/jquery.mobile-1.3.2.min.css">
    <link type="text/css" href="../Content/Custom/board.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/Custom/stage.js"> </script>
    <script type="text/javascript">

        $(document).on("pageload", function (event, data) {
            InitTable();
            BindAction();
            var userId ='<%=UserInfo.Id%>';
            $(".btnName").click(function () {
                SumbitMap(userId);
               
            })
        });
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
            $("#board").html(body);
        }
        function BindAction() {
            $("#board td").click(function () {
                //alert($(this).attr("class"));
                if ($(this).attr("class") == "clearItem") {
                    $(this).attr("class", "bodyItem");
                }
                else if ($(this).attr("class") == "bodyItem") {
                    $(this).attr("class", "headerItem");
                }
                else {
                    $(this).attr("class", "clearItem");
                }
            });

        }


    </script>
    <div data-role="header">
        <a  data-role="button" data-icon="home" data-transition='slide' data-rel="back" data-direction="reverse">返回</a>
        <h1>CreateMap</h1>
        <!--<a href="#" data-role="button" data-icon="search">搜索</a>-->
    </div>
    <div data-role="content">
        <table id="board">
            <tr>
                <td onclick=""></td>
            </tr>
        </table>
        <input type="button" class="btnName" value="提交" data-role="button" data-inline="true" onclick="" />
        <a href="#" data-role="button"  data-inline="true"data-rel="back">返回</a>
    </div>
</div>
