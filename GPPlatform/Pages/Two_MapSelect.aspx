<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Two_MapSelect.aspx.cs" Inherits="GPPlatform.Pages.Two_MapSelect" %>

<div data-role="page">
    <link rel="stylesheet" href="../Content/jquery.mobile-1.4.2.css" />
    <script type="text/javascript" src="../Scripts/Custom/stage.js"> </script>
    <script type="text/javascript">
        console.log("this is javascript");

        $(function () {
            console.log("function!");
        }
        );

        $(document).ready(function () {
            console.log("ready");
        });

        $(window).load(function () {
            console.log("load");
        });
        $(document).on("pagebeforecreate", function (event, data) {

            var wid ='<%=UserInfo==null?"":UserInfo.Id%>';
            if (wid=="") {
                location.href="Login.aspx";
            }
            loadStageList(wid);
        })

    </script>
    <div data-role="header">
        <a href="EntryPoint.aspx" data-role="button" data-icon="home" data-transition='slide' data-direction="reverse">返回</a>
        <h1>Setting DefaultMap</h1>
        <!--<a href="#" data-role="button" data-icon="search">搜索</a>-->
    </div>
    <div data-role="content">
        <label for="ddlStageList">选择Stage：</label>
        <select id="ddlStageList">
        </select>
        <a href="CreateBoard.aspx" data-role="button" data-inline="true" data-transition='pop'>创建</a>
        <a href="Two_UserList.aspx" data-role="button" data-inline="true" data-transition='flow'>进入</a>
    </div>
</div>
