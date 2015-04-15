<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left.aspx.cs" Inherits="left" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .ttl {
            cursor: pointer;
            color: #ffffff;
            padding-top: 4px;
        }

        A:active {
            color: #000000;
            text-decoration: none;
        }

        A:hover {
            color: #000000;
            text-decoration: none;
        }

        A:link {
            color: #000000;
            text-decoration: none;
        }

        A:visited {
            color: #000000;
            text-decoration: none;
        }

        TD {
            font-size: 12px;
            font-family: "Verdana", "Arial", "細明體", "sans-serif";
        }

        .table_body {
            background-color: #EDF1F8;
            height: 18px;
            cursor: pointer;
        }

        .table_none {
            background-color: #FFFFFF;
            height: 18px;
            cursor: pointer;
        }
    </style>
    <script type="text/javascript">
        function showHide(obj) {
            var oStyle = document.getElementById(obj).style;
            oStyle.display == "none" ? oStyle.display = "block" : oStyle.display = "none";
        }
    </script>

</head>
<body style="background-color: #9aadcd; margin-top: 0; margin-left: 0;">
    <img src="Images/4003738logo_name.png" width="198" />
    <br>
    <asp:Repeater ID="LeftMenu" runat="server" OnItemDataBound="LeftMenu_ItemDataBound">
        <ItemTemplate>
            <table cellspacing="0" cellpadding="0" width="159" align="center" border="0">
                <tr>
                    <td width="23">
                        <img height="25" src="images/Menu/box_topleft.gif" width="23">
                    </td>
                    <td class="ttl" onclick="JavaScript:showHide('M_<%# Eval("MMe_ID")%>');" width="129"
                        background="images/Menu/box_topbg.gif">
                        <%# Eval("MMe_Name")%>
                    </td>
                    <td width="7">
                        <img height="25" src="images/Menu/box_topright.gif" width="7">
                    </td>
                </tr>
            </table>
            <table id="M_<%# Eval("MMe_ID")%>" style="display: none" cellspacing="0" cellpadding="0"
                width="159" align="center" border="0">
                <tr>
                    <td background='images/Menu/box_bg.gif' height="0px" width='159' colspan='3'>
                        <table width="157" border="0" cellpadding="2" cellspacing="1">
                            <tbody>
                                <asp:Repeater ID="LeftMenu_Sub" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="table_none" onclick="javascript:NowShow('M_<%# Eval("MMe_ID")%>','<%# Eval("MMe_Url")%>');"
                                                onmousemove="javascript:TDOverORIn('M_<%# Eval("MMe_ID")%>');" onmouseout="javascript:TDOverOROut('M_<%# Eval("MMe_ID")%>');"
                                                id="M_<%# Eval("MMe_ID")%>">
                                                <img height='7' hspace='5' src='images/Menu/arrow.gif' width='5' align="bottom">
                                                <%# Eval("MMe_Name")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="0" width="159" align="center" border="0">
                <tr>
                    <td colspan="3">
                        <img height='10' src='images/Menu/box_bottom.gif' width='159'>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:Repeater>
</body>

</html>
<script type="text/javascript">
    var NowClickName = "";

    function NowShow(TopMenuName, Url) {
        document.getElementById(TopMenuName).className = "table_body";
        if (NowClickName != "" && NowClickName != TopMenuName)
            document.getElementById(NowClickName).className = "table_none";
        NowClickName = TopMenuName;
        //var o=window.open(url); 
        window.parent.frames["mainFrame"].location = Url;
        //parment.mainFrame.src=Url;
    }

    function TDOverOROut(iname) {
        if (NowClickName != iname) {

            document.getElementById(iname).className = "table_none";

        }
    }
    function TDOverORIn(iname) {
        if (NowClickName != iname) {
            document.getElementById(iname).className = "table_body";
        }
    }
</script>
