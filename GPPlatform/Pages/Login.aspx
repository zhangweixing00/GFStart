<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GPPlatform.Pages.Login" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <link rel="stylesheet" href="../Content/jquery.mobile-1.4.2.css" />
    <script src="../Scripts/jquery-2.2.3.min.js"></script>
    <script src="../Scripts/jquery.mobile-1.4.2.min.js"></script>
    <script type="text/javascript">
        //$(function () {
        //    var alertString = $("#tip").html();
        //});

        //$(document).on("pagebeforecreate", function (event, data) {
        //    var alertString = $("#tip").html();
        //    if (alertString!="") {
        //        eval(alertString)
        //    }

        //});
    </script>
</head>
<body>
    <form id="form1" runat="server" data-ajax="false">
<%--        <div style="display:none;" id="tip" runat="server"></div>--%>
        <div>
            <div data-role="page">
                <div data-role="header">
                    <%--<a href="EntryPoint.aspx" data-role="button" data-icon="home" data-transition='slide' data-direction="reverse">返回</a>--%>
                    <h1>Login Or zc</h1>
                    <!--<a href="#" data-role="button" data-icon="search">搜索</a>-->
                </div>
                <div data-role="content">
                    <input type="text" name="fname" id="tbName" placeholder="账号" runat="server">
                    <input type="password" name="Pwd" id="tbPwd" placeholder="密码" runat="server">
                    <asp:Button ID="btnCreate" runat="server" Text="注册"  data-inline="true" OnClick="btnCreate_Click" data-ajax="false"/>
                    <asp:Button ID="btnLogin" runat="server" Text="登录" data-inline="true" OnClick="btnLogin_Click" data-ajax="false"/>

                </div>
            </div>
        </div>
    </form>
</body>
</html>
