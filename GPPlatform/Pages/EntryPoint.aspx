<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntryPoint.aspx.cs" Inherits="GPPlatform.Pages.EntryPoint" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <link rel="stylesheet" href="../Content/jquery.mobile-1.4.2.css" />
    <script src="../Scripts/jquery-2.2.3.min.js"></script>
    <script src="../Scripts/jquery.mobile-1.4.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.signalR-2.2.0.js"></script>
    <script src="/signalr/hubs"></script>
    <script type="text/javascript">
        $(function () {

        });

        $(document).on("pageinit", function (event, data) {

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div data-role="page">
                <div data-role="header">
                    <!--<a href="#" data-role="button" data-icon="home">首页</a>-->
                    <h1>IT支持平台</h1>
                    <!--<a href="#" data-role="button" data-icon="search">搜索</a>-->
                </div>
                <div data-role="content">
                    <ul id='ItemList' data-inset="true" data-role="listview">
                        <li>
                            <a href="Two_UserList.aspx"  data-transition='slide'  data-ajax="false" >
                                <h2>Single</h2>
                                <p>For Single Person</p>
                            </a>
                        </li>
                        <li>
                            <a href="Two_MapSelect.aspx"  data-transition='slide' >
                                <h2>Together</h2>
                                <p>For Two Person</p>
                            </a>
                        </li>
                    </ul>

                </div>


            </div>
        </div>
    </form>
</body>
</html>
