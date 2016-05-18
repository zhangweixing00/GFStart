<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Two_UserList.aspx.cs" Inherits="GPPlatform.Pages.Two_UserList" %>

<div data-role="page" id="Two_UserList">
    <%--     <meta name="viewport" content="width=device-width" />
   <link rel="stylesheet" href="../Content/jquery.mobile-1.4.2.css" />
    <script type="text/javascript" src="../Scripts/jquery-2.2.3.js"></script>
    <script src="../Scripts/jquery.mobile-1.4.2.min.js"></script>--%>
    <%--    <script type="text/javascript" src="../Scripts/jquery.signalR-2.2.0.js"></script>
    <script src="/signalr/hubs"></script>--%>
    <script type="text/javascript">

        $(document).on("pagebeforecreate", function (event, data) {
            try {
                var userId = 'd59238a9-c535-41ca-81fe-cfe8ad13ad24';
                var noticeHub = $.connection.noticeHub;
                noticeHub.client.loadUserList = function (userList) {
                    // alert("")
                    DoLoadUserList(userList);
                }
                $.connection.hub.start().done(function () {
                    noticeHub.server.PushUserList(userId);
                });

                function refresh() {
                    noticeHub.server.PushUserList(userId);
                }
            } catch (e) { alert(e.name + ": " + e.message); }
            //setInterval(function () { noticeHub.server.PushUserList(userId); }, 1000);
            //var t1 = setInterval(function () { noticeHub.server.PushUserList(userId); }, 5000);
        })
        function DoLoadUserList(userList) {
            //alert(userList);
            var colors = new Array();
            colors[0] = "gary";
            colors[1] = "Blue";
            colors[2] = "Green";

            var statusList = new Array();
            statusList[0] = "不在线";
            statusList[1] = "准备中，需等待";
            statusList[2] = "可以开始，点我加入";

            var tab = "";
            $.each(userList, function (i, n) {//n.Status
                tab += "<li><a "
                if (n.Status == 2) {
                    tab += "href='Two_Fight.aspx' ";
                }
                tab += "data-transition='slide'><h2 style='color:" + colors[n.Status] + ";'>" + n.Name + "</h2><p>" + statusList[n.Status] + "</p></a></li>";
            });
            tab += "";
            $("#ItemList").html(tab);
            $('ul').listview('refresh');
        }
    </script>
    <div data-role="header">
        <a data-role="button" data-icon="home" data-transition='slide' data-rel="back" data-direction="reverse">返回</a>
        <h1>用户列表</h1>
        <!--<a href="#" data-role="button" data-icon="search">搜索</a>-->
    </div>
    <div data-role="content">
        <ul id='ItemList' data-inset="true" data-role="listview">
        </ul>
    </div>
</div>
