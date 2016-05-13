<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInteface.aspx.cs" Inherits="GPPlatform.Services.UserInteface" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../Scripts/jquery-2.2.3.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.signalR-2.2.0.js"></script>
    <script src="/signalr/hubs"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="UserDiv" >
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    $(function () {
        var  wid='<%= GetWid() %>';
        var noticeHub = $.connection.noticeHub;
        noticeHub.client.loadUserList = function (userList) {
            // alert("")
            DoLoadUserList(userList);
        }
        $.connection.hub.start().done(function () {
            noticeHub.server.PushUserList(wid);
        });


    });
    function DoLoadUserList(userList) {
        //alert(userList);
        var colors = new Array();
        colors[0] = "gary";
        colors[1] = "Blue";
        colors[2] = "Green";
        var tab = "<table class='List'>";
        $.each(userList, function (i, n) {//n.Status
            tab += "<tr><td style='color:" + colors[n.Status] + ";'>" + n.Name + "</td></tr>";
        });
        tab += "</table>";
        $("#UserDiv").html(tab);
    }
</script>
