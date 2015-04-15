<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CategoryIndexList.aspx.cs" Inherits="CategoryIndexList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>館別管理</title>
    <link href="https://admin.shop123.com.tw/manage/backoffice/images/reset-min-330.css" rel="stylesheet" type="text/css">
    <link href="https://admin.shop123.com.tw/manage/backoffice/images/novel_emall.css" rel="stylesheet" type="text/css">
    <link href="https://admin.shop123.com.tw/manage/module/ckeditor/_samples/sample.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <legend>館別管理</legend>
                <div class="function_bar">
                    <div class="button_bar">
                        <td id="c21td" align="center" valign='bottom' width='10'>
                            <input type='button' value='新增' name='' onclick="to_detail(0)" class='tool_button_new' onmouseover="this.className='tool_button_over';" onmouseout="this.className='tool_button_new';"></td>
                        <td id="c22td" align="center" valign='bottom' width='10'>
                            <input type='button' value='儲存排序' name='' onclick="    to_save_sort()" class='tool_button' onmouseover="this.className='tool_button_over';" onmouseout="this.className='tool_button';"></td>
                        <td id="c23td" align="center" valign='bottom' width='10'>
                            <input type='button' value='上線' name='' onclick="    set_useful('useful_on')" class='tool_button_useful_on' onmouseover="this.className='tool_button_over';" onmouseout="this.className='tool_button_useful_on';"></td>
                        <td id="c24td" align="center" valign='bottom' width='10'>
                            <input type='button' value='下線' name='' onclick="    set_useful('useful_off')" class='tool_button_useful_off' onmouseover="this.className='tool_button_over';" onmouseout="this.className='tool_button_useful_off';"></td>
                        <td id="c25td" align="center" valign='bottom' width='10'>
                            <input type='button' value='優先搜尋' name='' onclick="    set_search_first('search_first')" class='tool_button' onmouseover="this.className='tool_button_over';" onmouseout="this.className='tool_button';"></td>
                        <td id="c26td" align="center" valign='bottom' width='10'>
                            <input type='button' value='刪除' name='' onclick="    to_delete()" class='tool_button_delete' onmouseover="this.className='tool_button_over';" onmouseout="this.className='tool_button_delete';"></td>
                        <td id="c27td" align="center" valign='bottom' width='10'>
                            <input type='button' value='全選' name='' onclick="    CheckAll1(true)" class='tool_button' onmouseover="this.className='tool_button_over';" onmouseout="this.className='tool_button';"></td>
                        <td id="c28td" align="center" valign='bottom' width='10'>
                            <input type='button' value='清空' name='' onclick="    CheckAll1(false)" class='tool_button' onmouseover="this.className='tool_button_over';" onmouseout="this.className='tool_button';"></td>
                        <!--<td width="*">&nbsp;</td>-->
                    </div>
                    <div class="select_bar">
                        <div class="select_conditions">
                            <asp:DropDownList ID="ddlOnline" CssClass="select" runat="server">
                                <asp:ListItem>上線狀態</asp:ListItem>
                                <asp:ListItem Value="1">上線</asp:ListItem>
                                <asp:ListItem Value="0">下線</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlDisplayType" CssClass="select" runat="server">
                                <asp:ListItem>顯示條件</asp:ListItem>
                                <asp:ListItem Value="0">不限制</asp:ListItem>
                                <asp:ListItem Value="1">限特定會員等級</asp:ListItem>
                                <asp:ListItem Value="2">限特定會員等級或非會員</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="txtKeyword" runat="server" class="keyword_text"></asp:TextBox>
                            <asp:Button ID="btnSubmit" runat="server" Text="查詢" CssClass="function_button gradient" />
                        </div>
                    </div>
                </div>
                <asp:GridView ID="gvCategoryIndexList" runat="server" AutoGenerateColumns="False" Height="130px"
                    Width="100%" DataKeyNames="Cat_ID" CssClass="datatable">
                    <RowStyle CssClass="altrow1" />
                    <EmptyDataRowStyle CssClass="altrow1" />
                    <Columns>
                        <asp:TemplateField HeaderText="選取" ShowHeader="False">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="排序" ShowHeader="False">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="input_text_right"></asp:TextBox>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Cat_Name" HeaderText="館別名稱" ItemStyle-CssClass="text">
                            <ItemStyle CssClass="text"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Cat_ID" HeaderText="館別代碼" />
                        <asp:TemplateField HeaderText="上線狀態" ShowHeader="False">
                            <ItemTemplate>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="" HeaderText="線上商品" />--%>
                        <asp:TemplateField HeaderText="編輯" ShowHeader="False">
                            <ItemTemplate>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        查無資料....
                    </EmptyDataTemplate>
                    <AlternatingRowStyle CssClass="altrow" />
                </asp:GridView>
            </fieldset>
        </div>
    </form>
</body>
</html>
