<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginUser.aspx.cs" Inherits="BestCompany.LoginUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>管理者登入頁面</title>
     <style>
        * {
            padding: 0 auto;
            margin: 0 auto;
        }

        #indxcs, #bodya, #heada {
            border: 0 none;
            margin: 0 auto;
            text-align: center;
            position: relative;
        }
        .auto-style3 {
            width: 235px;
        }
        .auto-style4 {
            width: 60px;
        }
        .auto-style5 {
            height: 24px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="indxcs">
            <div id="heada">
                <img style="margin-top: 30px;" src="https://fs1.shop123.com.tw/400373/upload/website_basic/4003738logo_name.png" />
            </div>
            <div id="bodya" style="padding: 10px 0;">
                <div>
                    <table cellpadding="5" cellspacing="0" style="border-collapse: collapse; width: 270px; height: 170px; background-color: #FFFFFF; color: #ffffff;">
                        <tr>
                            <td style="border:#cccccc; border-style:double" height="150px" valign="top" width="300px">
                                <table cellpadding="2" bgcolor="#CCCCCC" width="290px">
                                    <tr>
                                        <td align="center" colspan="2" class="auto-style5">登  入</td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="auto-style4">
                                            <asp:Label ID="UserNameLabel" runat="server">帳號</asp:Label>
                                        </td>
                                        <td class="auto-style3">
                                            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="必須提供使用者名稱。" ToolTip="必須提供使用者名稱。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="auto-style4">
                                            <asp:Label ID="PasswordLabel" runat="server">密碼</asp:Label>
                                        </td>
                                        <td class="auto-style3">
                                            <asp:TextBox ID="Pwd" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Pwd" ErrorMessage="必須提供密碼。" ToolTip="必須提供密碼。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:CheckBox ID="RememberMe" runat="server" Text="記憶密碼供下次使用。" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color: Red;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="UserName" ErrorMessage="必須提供使用者名稱。" ToolTip="必須提供使用者名稱。" ValidationGroup="Login1"></asp:RequiredFieldValidator>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Pwd" ErrorMessage="必須提供密碼。" ToolTip="必須提供密碼。" ValidationGroup="Login1"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Button ID="btnLogin" runat="server" CommandName="Login" Text="登  入" ValidationGroup="Login1" Style="height: 25px" OnClick="btnLogin_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Button ID="Button1" runat="server" Text="忘記密碼" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
