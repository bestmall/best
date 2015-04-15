<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ViewVoluntaryCompany.aspx.cs" Inherits="BestCompany.ViewCompany" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>檢視廠商資訊</title>
    <link href="css/AddCompany.css" rel="stylesheet" type="text/css" />
</head>

<script src="js/jquery-latest.min.js" type="text/javascript"></script>
<script src="js/aj-address.js" type="text/javascript"></script>
<script src="js/aj-address1.js" type="text/javascript"></script>
<script src="js/jquery.js" type="text/javascript"></script>
<script src="js/jquery.validate.js" type="text/javascript"></script>
<script src="js/aj-birthday.js" type="text/javascript"></script>
<%--<script src="https://code.jquery.com/jquery-2.1.3.js" type="text/javascript" language="javascript"></script>--%>

<script type="text/javascript">
    $(function () {
        //須與form表單ID名稱相同,驗證必填欄位
        $("#UpdateCo").validate();

        //載入地址JQUERY     
        if (("<%# ComRegisterAddressCity%>").toString() != null) {
            $('.address-zone').ajaddress({ city: "<%# ComRegisterAddressCity%>", county: "<%# ComRegisterAddressCounty%>" });
        } else {
            $('.address-zone').ajaddress({ city: "請選擇", county: "請選擇" });
        }
        if (("<%# ComAddressCity%>").toString() != null) {
            $('.address-zone1').ajaddress1({ city1: "<%# ComAddressCity%>", county1: "<%# ComAddressCounty%>" });
        } else {
            $('.address-zone1').ajaddress1({ city1: "請選擇", county1: "請選擇" });
        }
        //日期選單
        if (("<%# ComFoundedY%>").toString() != null) {
            $('.birthday-zone').ajbirthday({ year: "<%# ComFoundedY%>", month: "<%# ComFoundedM%>", day: "<%# ComFoundedD%>" });
        } else {
            $('.birthday-zone').ajbirthday({ year: "請選擇", month: "請選擇", day: "請選擇" });
        }
    });

    function get_Select_Year(obj) {
        var ddl = document.getElementById(obj.id);
        if (ddl) {
            $('#<%=hf_year.ClientID%>').val(ddl.value);
        }
    }
    function get_Select_month(obj) {
        var ddl = document.getElementById(obj.id);
        if (ddl)
            $('#<%=hf_month.ClientID%>').val(ddl.value);
    }
    function get_Select_day(obj) {
        var ddl = document.getElementById(obj.id);
        if (ddl)
            $('#<%=hf_day.ClientID%>').val(ddl.value);
    }

    function get_Select_City(obj) {
        var ddl = document.getElementById(obj.id);
        if (ddl) {
            $('#<%=city.ClientID%>').val(ddl.value);
        }
    }
    function get_Select_county(obj) {
        var ddl = document.getElementById(obj.id);
        if (ddl)
            $('#<%=county.ClientID%>').val(ddl.value);
        $("#<%= zipcode.ClientID %>").val(zip[$("#<%= city.ClientID %>").val()][$("#<%= county.ClientID %>").val()]);
        ("<%# ComRegisterAddressZipcode%>").toString($("#<%= zipcode.ClientID %>").val());
        $("#<%= RegisterAddress.ClientID %>").val($("#<%= zipcode.ClientID %>").val() + " " + $("#<%= city.ClientID %>").val() + " " + $("#<%= county.ClientID %>").val());
    }
    function get_Select_City1(obj) {
        var ddl = document.getElementById(obj.id);
        if (ddl)
            $('#<%=city1.ClientID%>').val(ddl.value);
    }
    function get_Select_county1(obj) {
        var ddl = document.getElementById(obj.id);
        if (ddl)
            $('#<%=county1.ClientID%>').val(ddl.value);
        $("#<%= zipcode1.ClientID %>").val(zip1[$("#<%= city1.ClientID %>").val()][$("#<%= county1.ClientID %>").val()]);
        ("<%# ComAddressZipcode%>").toString($("#<%= zipcode1.ClientID %>").val());
        $("#<%= ContactAddress.ClientID %>").val($("#<%= zipcode1.ClientID %>").val() + " " + $("#<%= city1.ClientID %>").val() + " " + $("#<%= county1.ClientID %>").val());
    }
</script>

<body>
    <form id="UpdateCo" runat="server">
        <asp:HiddenField ID="hf_year" runat="server" Value="<%# ComFoundedY%>" />
        <asp:HiddenField ID="hf_month" runat="server" Value="<%# ComFoundedM%>" />
        <asp:HiddenField ID="hf_day" runat="server" Value="<%# ComFoundedD%>" />
        <asp:HiddenField ID="RegisterAddress" runat="server" Value="" />
        <asp:HiddenField ID="zipcode" runat="server" Value="<%# ComRegisterAddressZipcode%>" />
        <asp:HiddenField ID="city" runat="server" Value="<%# ComRegisterAddressCity%>" />
        <asp:HiddenField ID="county" runat="server" Value="<%# ComRegisterAddressCounty%>" />
        <asp:HiddenField ID="ContactAddress" runat="server" Value="" />
        <asp:HiddenField ID="city1" runat="server" Value="<%# ComAddressCity%>" />
        <asp:HiddenField ID="county1" runat="server" Value="<%# ComAddressCounty%>" />
        <asp:HiddenField ID="zipcode1" runat="server" Value="<%# ComAddressZipcode%>" />
        <div>
            <asp:ListView ID="LV_ViewVoluntaryCompany" runat="server" OnItemEditing="LV_ViewVoluntaryCompany_ItemEditing" OnItemUpdating="LV_ViewVoluntaryCompany_ItemUpdating">
                <ItemTemplate>
                    <table border="0">
                        <tbody>
                            <tr>
                                <td valign="top" align="left" class="auto-style9">
                                    <table border="0">
                                        <tbody>
                                            <tr>
                                                <td style="border-bottom: 5px solid #e3017e;" class="auto-style10">
                                                    <asp:Image ID="Image2" runat="server" Width="156" Height="22" ImageUrl="pic/AddCompanyTitle00.jpg" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table border="0">
                                        <tbody>
                                            <tr>
                                                <td align="left" colspan="2">
                                                    <asp:Image ID="Image1" runat="server" Width="697" Height="24" ImageUrl="pic/AddCompanyTitle01.jpg" />

                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style4">
                                                    <label class="itemText" for="Com_Name"><span class="PS">＊</span>公司名稱</label>
                                                    <asp:Label ID="Com_Name" runat="server" size="40" Text='<%# Eval("Com_Name") %>'></asp:Label>
                                                </td>
                                                <td class="auto-style18">
                                                    <span class="PS itemText">若無設立公司行號或無統編者，則無法進行洽商簽約。</span><br />
                                                    <label class="itemText" for="Com_Number"><span class="PS">＊</span>統一編號</label>
                                                    <asp:Label ID="Com_Number" runat="server" Text='<%# Eval("Com_Number") %>' MaxLength="8" Width="65px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style16">
                                                    <asp:Label runat="server" class="itemText" for="Com_Capital"><span class="PS">＊</span>資本額</asp:Label>
                                                    <asp:Label ID="Com_Capital" runat="server" Text='<%# Eval("Com_Capital") %>' MaxLength="8" size="11"></asp:Label>
                                                    萬
                                                        <asp:Label runat="server" class="itemText" for="Com_Employees"><span class="PS digits">&nbsp;&nbsp;&nbsp;&nbsp; ＊</span>公司人數</asp:Label>
                                                    <asp:Label ID="Com_Employees" runat="server" Text='<%# Eval("Com_Employees") %>' MaxLength="8" Width="50px"></asp:Label>
                                                </td>

                                                <td class="auto-style19">
                                                    <span class="PS">＊</span>
                                                    <asp:Label runat="server">設立日期&nbsp; </asp:Label>

                                                    西元   
                                                    <asp:Label ID="Com_Founded" runat="server" Text='<%# Eval("Com_Founded","{0:yyyy-MM-dd}") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="1" class="auto-style1">
                                                    <label class="itemText required"><span class="PS">＊</span>組織型態</label>
                                                    <asp:Label ID="CGI_OrganizationPatterns" runat="server" Text='<%# Eval("CGI_OrganizationPatterns") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1" colspan="2">
                                                    <label><span class="PS">＊</span>營登地址</label>
                                                    <asp:Label ID="Com_RegisterAddress" runat="server" Text='<%# Eval("Com_RegisterAddress") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1" colspan="2">
                                                    <label for="Com_Address"><span class="PS">＊</span>聯絡地址</label>
                                                    <asp:Label ID="Com_Address" runat="server" Text='<%# Eval("Com_Address") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="itemText" colspan="2">
                                                    <label class="itemTextNoRequire">&nbsp;&nbsp;&nbsp; 公司網址</label>
                                                    <asp:Label ID="Com_Url" CssClass="url" size="40" runat="server" Width="715px" Text='<%# Eval("Com_Url") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    <label class="itemText"><span class="PS">＊</span>公司電話</label>
                                                    <asp:Label ID="Com_Telephone" runat="server" Text='<%# Eval("Com_Telephone") %>'></asp:Label>

                                                </td>
                                                <td class="auto-style17">
                                                    <label class="itemTextNoRequire">公司傳真</label>
                                                    <asp:Label ID="Com_Fax" runat="server" Text='<%# Eval("Com_Fax") %>'></asp:Label>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    <label><span class="PS">＊</span>聯絡人</label>
                                                    <asp:Label ID="CCo_Name" runat="server" Width="85px" Text='<%# Eval("CCo_Name") %>'></asp:Label>
                                                    <label>&nbsp;&nbsp;&nbsp;&nbsp; 職稱</label>
                                                    <asp:Label ID="CCo_Title" size="15" runat="server" Text='<%# Eval("CCo_Title") %>'></asp:Label>

                                                </td>
                                                <td class="auto-style17">
                                                    <label>分機</label>
                                                    <asp:Label ID="CCo_Extn" size="6" runat="server" Text='<%# Eval("CCo_Extn") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    <span class="PS">＊</span><label>電子郵件</label>
                                                    <asp:Label ID="CCo_Email" size="40" runat="server" Text='<%# Eval("CCo_Email") %>'></asp:Label>
                                                </td>
                                                <td class="auto-style17">
                                                    <label>行動電話</label>
                                                    <asp:Label ID="CCo_Mobile" size="12" Text='<%# Eval("CCo_Mobile") %>' runat="server" Width="85px"></asp:Label>
                                                    <label>行動電話2</label>
                                                    <asp:Label ID="CCo_Mobile2" size="12" Text='<%# Eval("CCo_Mobile2") %>' runat="server" Width="85px"></asp:Label>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table border="0">
                                        <tr>
                                            <td align="left" colspan="3">
                                                <img src="pic/AddCompanyTitle02.jpg" width="697" height="28" /></td>
                                        </tr>
                                        <tr>
                                            <td><span class="PS">＊</span><label>主力商品</label>
                                                <asp:Label ID="labCGI_MainGoods" runat="server" Text='<%#CGI_MainGoodsVule %>'></asp:Label>
                                            </td>
                                            <td>
                                                <label>次要商品</label>
                                                <asp:Label ID="labCGI_EscortGoods" runat="server" Text="<%# CGI_EscortGoodsVule %>"></asp:Label>
                                            </td>
                                            <td>
                                                <label>其他商品</label>
                                                <asp:Label ID="labCGI_OthersGoods" runat="server" Text="<%# CGI_OthersGoodsVule %>"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 800px;" border="0">
                                        <tr>
                                            <td align="left" class="auto-style4">
                                                <img src="pic/AddCompanyTitle03.jpg" width="697" height="24" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>&nbsp;&nbsp;&nbsp; 電視購物</label>
                                                <asp:Label ID="CGI_TV" size="80" MaxLength="100" runat="server" Width="710px" Text='<%# Eval("CGI_TV") %>'> </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>&nbsp;&nbsp;&nbsp; 網路購物</label>
                                                <asp:Label ID="CGI_Web" size="80" MaxLength="100" runat="server" Width="710px" Text='<%# Eval("CGI_Web") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>&nbsp;&nbsp;&nbsp; 實體通路</label>
                                                <asp:Label ID="CGI_Store" size="80" MaxLength="100" runat="server" Width="710px" Text='<%# Eval("CGI_Store") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 800px;" border="0">
                                        <tr>
                                            <td align="left">
                                                <img src="pic/AddCompanyTitle04.jpg" width="697" height="24" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="CGI_Ps" runat="server" Columns="120" Height="130px" TextMode="MultiLine" Width="800px" Text='<%# Eval("CGI_Ps") %>'></asp:Label>

                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>

                    <asp:Label ID="ContactMD" runat="server" Text='<%# ContactMD %>'></asp:Label>連絡供應商 
                    <br />
                    <asp:Label ID="MDName" runat="server" Text='<%# MGrMDName %>'></asp:Label>負責的商開
                    <br />
                    備註：
                    <br />
                    <asp:Label ID="ComPs" runat="server" Text='<%# Eval("Com_Ps") %>'></asp:Label>
                    <br />

                    <p />
                    <p />

                    <asp:Button ID="btEditCompany" runat="server" CommandName="Edit" Text="編輯" />
                    <asp:Button ID="DelCheck" runat="server" Text="刪除" OnClick="DelCheck_Click" OnClientClick="return confirm('再次確認，是否刪除資料？')" />
                    <asp:Button runat="server" type="submit" ID="btnBack1" OnClick="btnBack1_Click" Text="回上一頁" />
                </ItemTemplate>

                <EditItemTemplate>
                    <table border="0">
                        <tbody>
                            <tr>
                                <td valign="top" align="left" class="auto-style9">
                                    <table border="0">
                                        <tbody>
                                            <tr>
                                                <td style="border-bottom: 5px solid #e3017e;" class="auto-style10">
                                                    <asp:Image ID="Image2" runat="server" Width="156" Height="22" ImageUrl="pic/AddCompanyTitle00.jpg" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table border="0">
                                        <tbody>
                                            <tr>
                                                <td align="left" colspan="4">
                                                    <asp:Image ID="Image1" runat="server" Width="697" Height="24" ImageUrl="pic/AddCompanyTitle01.jpg" />

                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style4">
                                                    <label class="itemText" for="Com_Name"><span class="PS">＊</span>公司名稱</label>
                                                    <asp:TextBox ID="Com_Name" runat="server" CssClass="required" size="40" Text='<%# Bind("Com_Name")%>' Visible="true"></asp:TextBox>
                                                </td>
                                                <td class="auto-style18">
                                                    <span class="PS itemText">若無設立公司行號或無統編者，則無法進行洽商簽約。</span><br />
                                                    <label class="itemText" for="Com_Number"><span class="PS">＊</span>統一編號</label>
                                                    <asp:TextBox ID="Com_Number" runat="server" CssClass="required digits " MaxLength="8" Width="65px" Text='<%# Bind("Com_Number")%>'> </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style16">
                                                    <label class="itemText" for="Com_Capital"><span class="PS">＊</span>資本額</label>
                                                    <asp:TextBox ID="Com_Capital" runat="server" CssClass="smallMargin required digits" MaxLength="8" size="11" Text='<%# Bind("Com_Capital")%>'> </asp:TextBox>
                                                    萬
                                                        <label class="itemText" for="Com_Employees"><span class="PS digits">&nbsp;&nbsp;&nbsp;&nbsp; ＊</span>公司人數</label>
                                                    <asp:TextBox ID="Com_Employees" runat="server" CssClass="required smallMargin digits" MaxLength="8" Width="50px" Text='<%# Bind("Com_Employees")%>'> </asp:TextBox>
                                                </td>

                                                <td class="auto-style19">
                                                    <span class="PS">＊</span><label class="itemText" for="init_year">設立日期&nbsp; </label>
                                                    西元 
                                                     <div class="birthday-zone" style="margin-left: 109px; margin-top: -19px;">
                                                         <asp:DropDownList ID="init_year" runat="server" CssClass="year required" onchange="get_Select_Year(this)">
                                                             <%--OnDataBinding="init_year_DataBinding"--%>
                                                         </asp:DropDownList>
                                                         <asp:DropDownList ID="init_month" runat="server" CssClass="month required" onchange="get_Select_month(this)">
                                                             <%--OnDataBinding="init_month_DataBinding"--%>
                                                         </asp:DropDownList>
                                                         <asp:DropDownList ID="init_day" runat="server" CssClass="day required" onchange="get_Select_day(this)">
                                                             <%-- OnDataBinding="init_day_DataBinding" --%>
                                                         </asp:DropDownList>
                                                     </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="1" class="auto-style1">
                                                    <label class="itemText required"><span class="PS">＊</span>組織型態</label>
                                                    <asp:CheckBoxList ID="CGI_OrganizationPatterns" runat="server" RepeatColumns="5" Width="360px" OnDataBound="CGI_OrganizationPatterns_DataBound">
                                                        <asp:ListItem Value="原廠">原廠</asp:ListItem>
                                                        <asp:ListItem Value="總代理">總代理</asp:ListItem>
                                                        <asp:ListItem Value="經銷商">經銷商</asp:ListItem>
                                                        <asp:ListItem Value="進出口商">進出口商</asp:ListItem>
                                                        <asp:ListItem Value="其他">其他</asp:ListItem>
                                                    </asp:CheckBoxList>

                                                </td>
                                                <td colspan="2" class="auto-style17">
                                                    <br />
                                                    <asp:TextBox ID="CGI_OrganizationPatternsOther" runat="server" Style="margin-left: -52px;" Text="<%#CGIOrganizationPatternsOther%>"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="auto-style1" colspan="4">
                                                    <label class="itemText1" for="Com_RegisterAddress"><span class="PS">＊</span>營業登記地址</label>
                                                    <div class="address-zone " style="margin-left: 110px; margin-top: -19px;">
                                                        <asp:Label ID="zipcode" runat="server" CssClass="zipcode" Width="32px"></asp:Label>
                                                        <asp:DropDownList ID="city" runat="server" CssClass="city  required" onchange="get_Select_City(this)">
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="county" runat="server" CssClass="county  required" onchange="get_Select_county(this)">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="Com_Add" runat="server" size="20" CssClass="required" Width="510px" Text="<%#ComRegisterAddressAdd%>"></asp:TextBox>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1" colspan="4">
                                                    <label class="itemText" for="Com_Address"><span class="PS">＊</span>聯絡地址</label>
                                                    <div class="address-zone1 " style="margin-left: 107px; margin-top: -19px;">
                                                        <asp:Label ID="zipcode1" runat="server" CssClass="zipcode1" Width="22px"></asp:Label>
                                                        <asp:DropDownList ID="city1" runat="server" CssClass="city1" onchange="get_Select_City1(this)">
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="county1" runat="server" CssClass="county1" onchange="get_Select_county1(this)">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="Com_Add1" runat="server" size="20" CssClass="" Width="510px" Text="<%#ComAddressAdd%>"></asp:TextBox>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="itemText" colspan="4">
                                                    <label for="Com_Url" class="itemTextNoRequire">&nbsp;&nbsp;&nbsp; 公司網址</label>
                                                    <asp:TextBox ID="Com_Url" CssClass="url" size="40" runat="server" Width="715px" Text='<%# Bind("Com_Url")%>'> </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    <label for="Com_TelephoneA" class="itemText"><span class="PS">＊</span>公司電話</label>
                                                    <asp:TextBox ID="Com_TelephoneA" Size="2" MaxLength="2" CssClass="required digits" runat="server" Text="<%#ComTelephoneValueA%>">  </asp:TextBox>

                                                    <asp:TextBox ID="Com_TelephoneB" size="10" CssClass="required digits" MaxLength="8" runat="server" Text="<%#ComTelephoneValueB%>"></asp:TextBox>

                                                </td>
                                                <td class="auto-style17">
                                                    <label for="Com_FaxA" class="itemTextNoRequire">公司傳真</label>
                                                    <asp:TextBox ID="Com_FaxA" Size="2" MaxLength="2" CssClass=" digits" runat="server" Text="<%#ComFaxA%>"></asp:TextBox>
                                                    -
                                                        <asp:TextBox ID="Com_FaxB" size="10" CssClass=" digits" MaxLength="8" runat="server" Text="<%#ComFaxB%>"></asp:TextBox>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    <label class="itemText" for="CCo_Name"><span class="PS">＊</span>聯絡人</label>
                                                    <asp:TextBox ID="CCo_Name" CssClass="required leftMargin" runat="server" Width="85px" Text='<%# Bind("CCo_Name")%>'></asp:TextBox>
                                                    <label for="CCo_Title" class="itemText">&nbsp;&nbsp;&nbsp;&nbsp; 職稱</label>
                                                    <asp:TextBox ID="CCo_Title" size="15" CssClass="leftMargin" runat="server" Text='<%# Bind("CCo_Title")%>'></asp:TextBox>

                                                </td>
                                                <td class="auto-style17">
                                                    <label for="CCo_Extn" class="itemTextNoRequire">分機</label>
                                                    <asp:TextBox ID="CCo_Extn" size="6" CssClass="digits leftMargin" runat="server" Text='<%# Bind("CCo_Extn")%>'> </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1">
                                                    <span class="PS">＊</span><label for="CCo_Email" class="itemText">電子郵件</label>
                                                    <asp:TextBox ID="CCo_Email" Width="315px" CssClass="email" runat="server" Text='<%# Eval("CCo_Email").ToString().Trim()%>'> </asp:TextBox>

                                                </td>
                                                <td class="auto-style17">
                                                    <label for="CCo_Mobile" class="itemTextNoRequire">行動電話</label>
                                                    <asp:TextBox ID="CCo_Mobile" size="12" CssClass="digits" runat="server" Width="85px" Text='<%# Bind("CCo_Mobile")%>'></asp:TextBox>
                                                    <label for="CCo_Mobile2" class="itemTextNoRequire">行動電話2</label>
                                                    <asp:TextBox ID="CCo_Mobile2" size="12" CssClass="digits" runat="server" Width="85px" Text='<%# Bind("CCo_Mobile2")%>'></asp:TextBox>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table border="0">
                                        <tr>
                                            <td align="left" colspan="4">
                                                <img src="pic/AddCompanyTitle02.jpg" width="697" height="28" /></td>
                                        </tr>
                                        <tr>
                                            <td><span class="PS">＊</span><label for="CGI_MainGoods" class="itemText">主力商品</label>
                                                <asp:DropDownList ID="CGI_MainGoods" CssClass="selSize required" runat="server" OnDataBound="CGI_MainGoods_DataBound">
                                                    <asp:ListItem>請選擇</asp:ListItem>
                                                    <asp:ListItem Value="1">食品</asp:ListItem>
                                                    <asp:ListItem Value="2">美妝</asp:ListItem>
                                                    <asp:ListItem Value="3">3C</asp:ListItem>
                                                    <asp:ListItem Value="4">服飾</asp:ListItem>
                                                    <asp:ListItem Value="5">保健</asp:ListItem>
                                                    <asp:ListItem Value="6">家電</asp:ListItem>
                                                    <asp:ListItem Value="7">旅遊</asp:ListItem>
                                                    <asp:ListItem Value="8">宗教</asp:ListItem>
                                                    <asp:ListItem Value="9">五金/收納/用品</asp:ListItem>
                                                    <asp:ListItem Value="10">寢具/傢俱/家飾</asp:ListItem>
                                                    <asp:ListItem Value="11">餐廚/衛浴/清潔</asp:ListItem>
                                                    <asp:ListItem Value="12">圖書/文教/藝術</asp:ListItem>
                                                    <asp:ListItem Value="13">貴重/珠寶/鞋包</asp:ListItem>
                                                    <asp:ListItem Value="14">戶外/運動/健身</asp:ListItem>
                                                    <asp:ListItem Value="15">婦幼/玩具/行李箱</asp:ListItem>
                                                    <asp:ListItem Value="16">汽車/機車/自行車</asp:ListItem>
                                                    <asp:ListItem Value="17">寵物/園藝</asp:ListItem>
                                                    <asp:ListItem Value="18">擺飾/燈飾</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <label for="CGI_EscortGoods" class="itemText">
                                                    次要商品  
                                                </label>
                                                <asp:DropDownList ID="CGI_EscortGoods" CssClass="selSize " runat="server" OnDataBound="CGI_EscortGoods_DataBound">
                                                    <asp:ListItem Value="0">請選擇</asp:ListItem>
                                                    <asp:ListItem Value="1">食品</asp:ListItem>
                                                    <asp:ListItem Value="2">美妝</asp:ListItem>
                                                    <asp:ListItem Value="3">3C</asp:ListItem>
                                                    <asp:ListItem Value="4">服飾</asp:ListItem>
                                                    <asp:ListItem Value="5">保健</asp:ListItem>
                                                    <asp:ListItem Value="6">家電</asp:ListItem>
                                                    <asp:ListItem Value="7">旅遊</asp:ListItem>
                                                    <asp:ListItem Value="8">宗教</asp:ListItem>
                                                    <asp:ListItem Value="9">五金/收納/用品</asp:ListItem>
                                                    <asp:ListItem Value="10">寢具/傢俱/家飾</asp:ListItem>
                                                    <asp:ListItem Value="11">餐廚/衛浴/清潔</asp:ListItem>
                                                    <asp:ListItem Value="12">圖書/文教/藝術</asp:ListItem>
                                                    <asp:ListItem Value="13">貴重/珠寶/鞋包</asp:ListItem>
                                                    <asp:ListItem Value="14">戶外/運動/健身</asp:ListItem>
                                                    <asp:ListItem Value="15">婦幼/玩具/行李箱</asp:ListItem>
                                                    <asp:ListItem Value="16">汽車/機車/自行車</asp:ListItem>
                                                    <asp:ListItem Value="17">寵物/園藝</asp:ListItem>
                                                    <asp:ListItem Value="18">擺飾/燈飾</asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td>
                                                <label for="CGI_OthersGoods" class="itemText">其他商品</label>
                                                <asp:DropDownList ID="CGI_OthersGoods" CssClass="selSize " runat="server" OnDataBound="CGI_OthersGoods_DataBound">
                                                    <asp:ListItem Value="0">請選擇</asp:ListItem>
                                                    <asp:ListItem Value="1">食品</asp:ListItem>
                                                    <asp:ListItem Value="2">美妝</asp:ListItem>
                                                    <asp:ListItem Value="3">3C</asp:ListItem>
                                                    <asp:ListItem Value="4">服飾</asp:ListItem>
                                                    <asp:ListItem Value="5">保健</asp:ListItem>
                                                    <asp:ListItem Value="6">家電</asp:ListItem>
                                                    <asp:ListItem Value="7">旅遊</asp:ListItem>
                                                    <asp:ListItem Value="8">宗教</asp:ListItem>
                                                    <asp:ListItem Value="9">五金/收納/用品</asp:ListItem>
                                                    <asp:ListItem Value="10">寢具/傢俱/家飾</asp:ListItem>
                                                    <asp:ListItem Value="11">餐廚/衛浴/清潔</asp:ListItem>
                                                    <asp:ListItem Value="12">圖書/文教/藝術</asp:ListItem>
                                                    <asp:ListItem Value="13">貴重/珠寶/鞋包</asp:ListItem>
                                                    <asp:ListItem Value="14">戶外/運動/健身</asp:ListItem>
                                                    <asp:ListItem Value="15">婦幼/玩具/行李箱</asp:ListItem>
                                                    <asp:ListItem Value="16">汽車/機車/自行車</asp:ListItem>
                                                    <asp:ListItem Value="17">寵物/園藝</asp:ListItem>
                                                    <asp:ListItem Value="18">擺飾/燈飾</asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                    </table>
                                    <table style="width: 800px;" border="0">
                                        <tr>
                                            <td align="left" class="auto-style4">
                                                <img src="pic/AddCompanyTitle03.jpg" width="697" height="24" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="itemText" for="CGI_Tv">&nbsp;&nbsp;&nbsp; 電視購物</label>
                                                <asp:TextBox ID="CGI_TV" size="80" MaxLength="100" runat="server" Width="710px" Text='<%# Bind("CGI_TV")%>'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="itemText" for="ch_web">&nbsp;&nbsp;&nbsp; 網路購物</label>
                                                <asp:TextBox ID="CGI_Web" size="80" MaxLength="100" runat="server" Width="710px" Text='<%# Bind("CGI_Web")%>'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="itemText" for="ch_store">&nbsp;&nbsp;&nbsp; 實體通路</label>
                                                <asp:TextBox ID="CGI_Store" size="80" MaxLength="100" runat="server" Width="710px" Text='<%# Bind("CGI_Store")%>'></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 800px;" border="0">
                                        <tr>
                                            <td align="left" colspan="2">
                                                <img src="pic/AddCompanyTitle04.jpg" width="697" height="24" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:TextBox ID="CGI_Ps" runat="server" Columns="120" Height="130px" TextMode="MultiLine" Width="800px" Text='<%# Bind("CGI_Ps")%>'></asp:TextBox>

                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>



                    <asp:DropDownList ID="ddlContactMD" runat="server" OnDataBinding="ContactMD_DataBinding"></asp:DropDownList>連絡供應商 
                    <br />
                    <asp:DropDownList ID="ddlMDName" runat="server" OnDataBinding="MDName_DataBinding"></asp:DropDownList>負責的商開
                    <br />
                    備註：
                    <br />
                    <asp:TextBox ID="ComPs" runat="server" Columns="120" Height="130px" TextMode="MultiLine" Width="800px" Text='<%# Eval("Com_Ps") %>'></asp:TextBox>
                    <br />

                    <p />
                    <p />


                    <asp:Button runat="server" type="submit" ID="btnUpdateCo" CommandName="Update" Text="更新" />
                    <asp:Button runat="server" type="submit" ID="btnBack" Text="取消" OnClick="btnBack_Click" />
                </EditItemTemplate>

            </asp:ListView>

            <br />
            <br />

        </div>

    </form>
</body>
</html>
