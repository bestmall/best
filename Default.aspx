<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="css/Site_Css.css" type="text/css" />
    <link rel="stylesheet" type="text/css" href="inc/FineMessBox/css/subModal.css" />

    <%--<script type="text/javascript" src="inc/FineMessBox/js/common.js"></script>--%>

    <%--<script type="text/javascript" src="inc/FineMessBox/js/subModal.js"></script>--%>

    <style type="text/css">
        .navPoint {
            font-family: Webdings;
            font-size: 9pt;
            color: white;
            cursor: pointer;
        }

        p {
            font-size: 9pt;
        }

        .font_size {
            font-family: "Verdana", "Arial", "Helvetica", "sans-serif";
            font-size: 12px;
            font-weight: normal;
            font-variant: normal;
            text-transform: none;
        }
    </style>
</head>
<body>
    <table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%">
<%--    <%
        switch (MenuStyle)
        {
            case 0:
                break;
        }
    %>--%>
        <tr>
            <td id="frmTitle" name="frmTitle" nowrap="nowrap" valign="middle" align="center"
                width="198" style="border-right: 1px solid #000000">
                <iframe name="BoardTitle" style="height: 100%; visibility: inherit; width: 198; z-index: 2"
                    scrolling="auto" frameborder="0" src="left.aspx"></iframe>
            </td>
            <td style="width: 100%">
                <iframe id="mainFrame" name="mainFrame" style="height: 100%; visibility: inherit; width: 100%; z-index: 1"
                    scrolling="auto" frameborder="0" src="Manage_Welcome.aspx"></iframe>
            </td>
        </tr>
    </table>
</body>
</html>
<script type="text/javascript">

    var DispClose = true;

    function CloseEvent() {
        if (DispClose) {
            return "是否離開頁面?";
        }
    }
    window.onbeforeunload = CloseEvent;
    rnd.today = new Date();

    rnd.seed = rnd.today.getTime();

    function rnd() {
        rnd.seed = (rnd.seed * 9301 + 49297) % 233280;
        return rnd.seed / (233280.0);

    };

    function rand(number) {
        return Math.ceil(rnd() * number);

    };

    function AlertMessageBox(Messages) {
        DispClose = false;
        window.location.href = location.href + "?" + rand(1000000);
        alert(Messages);
    }

    var var_frmTitle = document.getElementById("frmTitle");
    var var_menuimg = document.getElementById("menuimg");

    function switchSysBar() {

        if (var_frmTitle.style.display == "none") {
            var_frmTitle.style.display = ""
            var_menuimg.src = "images/Menu/close.gif";
            var_menuimg.alt = "隱藏左欄"
        }
        else {
            var_frmTitle.style.display = "none"
            var_menuimg.src = "images/Menu/open.gif";
            var_menuimg.alt = "開啟左欄"
        }



    }

    function menuonmouseover() {
        if (var_frmTitle.style.display == "none") {
            var_menuimg.src = "images/Menu/open_on.gif";
        }
        else {
            var_menuimg.src = "images/Menu/close_on.gif";
        }
    }
    function menuonmouseout() {
        if (var_frmTitle.style.display == "none") {
            var_menuimg.src = "images/Menu/open.gif";
        }
        else {
            var_menuimg.src = "images/Menu/close.gif";
        }
    }
    if (top != self) {
        top.location.href = "default.aspx";
    }

</script>
