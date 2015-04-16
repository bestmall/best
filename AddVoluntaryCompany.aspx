<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AddVoluntaryCompany.aspx.cs" Inherits="BestCompany.AddCompany" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增廠商資訊</title>
    <link href="css/AddCompany.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="js/aj-address.js" type="text/javascript"></script>
    <script src="js/aj-address1.js" type="text/javascript"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/jquery.validate.js" type="text/javascript"></script>
    <script src="js/aj-birthday.js" type="text/javascript"></script>

    <script type="text/javascript">

        $(function () {
            //須與form表單ID名稱相同,驗證必填欄位
            $("#AddCo").validate();

            //載入地址JQUERY        
            $('.address-zone').ajaddress({ city: "請選擇", county: "請選擇", zipcdoe: zip });
            $('.address-zone1').ajaddress1({ city1: "請選擇", county1: "請選擇" });
            if ($("#<%= CheckAddress.ClientID %>").click(function (e) {
                var selectcity = $('.city').find(':selected').val();
                var selectcounty = $('.county').find(':selected').val();
                var selectCom_Add = $('#Com_Add').val();
                $('.address-zone1').ajaddress1({ city1: selectcity, county1: selectcounty });
                $("#<%= Com_Add1.ClientID %>").val(selectCom_Add);
                }));

            //日期選單
            $('.birthday-zone').ajbirthday({ year: "請選擇", month: "請選擇", day: "請選擇" });


        });

            function getSelect(obj) {
                var ddl = document.getElementById(obj.id);
                if ($("#<%= county.ClientID %>").val() !== "請選擇") {
                    // alert($("#<%= zipcode.ClientID %>").text() + $("#<%= city.ClientID %>").val() + $("#<%= county.ClientID %>").val() + $('#Com_Add').val());
                    $("#<%= txtComAdd.ClientID %>").val($("#<%= zipcode.ClientID %>").text().toString() + " " + $("#<%= city.ClientID %>").val().toString() + " " + $("#<%= county.ClientID %>").val().toString() + " " + $('#Com_Add').val().toString());
                }
            }
            function getSelect2(obj) {
                var ddl = document.getElementById(obj.id);
                if ($("#<%= CheckAddress.ClientID %>").click(function (e) {
                    $("#<%= txtComAdd1.ClientID %>").val($("#<%= txtComAdd.ClientID %>").val());
                }));
                if ($("#<%= county1.ClientID %>").val() !== "請選擇") {
                    $("#<%= txtComAdd1.ClientID %>").val($("#<%= zipcode1.ClientID %>").text().toString() + " " + $("#<%= city1.ClientID %>").val().toString() + " " + $("#<%= county1.ClientID %>").val().toString() + " " + $('#Com_Add1').val().toString());
                }
            }

    </script>

</head>
<body runat="server">
    <div id="body">
        <div id="bodybase">
            <div id="conent">
                <div class="TableBase">
                    <form id="AddCo" runat="server">
                        <asp:TextBox ID="txtComAdd" runat="server" style="display:none;"></asp:TextBox>
                        <asp:TextBox ID="txtComAdd1" runat="server"  style="display:none;"></asp:TextBox>
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
                                                <!-- <tr><td><img width="850" height="6" src=""></td></tr> -->
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
                                                        <asp:TextBox ID="Com_Name" runat="server" CssClass="required" Width="315px"></asp:TextBox>
                                                    </td>
                                                    <td class="auto-style18">
                                                        <span class="PS itemText">若無設立公司行號或無統編者，則無法進行洽商簽約。</span><br />
                                                        <label class="itemText" for="Com_Number"><span class="PS">＊</span>統一編號</label>
                                                        <asp:TextBox ID="Com_Number" runat="server" CssClass="required digits " MaxLength="8" Width="65px" AutoPostBack="true"></asp:TextBox>
                                                        <asp:Label ID="labCom_Number" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style16">
                                                        <label class="itemText" for="Com_Capital"><span class="PS">＊</span>資本額</label>
                                                        <asp:TextBox ID="Com_Capital" runat="server" CssClass="smallMargin required digits" MaxLength="8" size="11"></asp:TextBox>
                                                        萬
                                                        <label class="itemText" for="Com_Employees"><span class="PS digits">&nbsp;&nbsp;&nbsp;&nbsp; ＊</span>公司人數</label>
                                                        <asp:TextBox ID="Com_Employees" runat="server" CssClass="required smallMargin digits" MaxLength="8" Width="50px"></asp:TextBox>
                                                    </td>

                                                    <td class="auto-style19">
                                                        <span class="PS">＊</span><label class="itemText" for="init_year">設立日期&nbsp; </label>
                                                        西元
                                                            <div class="birthday-zone" style="margin-left: 109px; margin-top: -19px;">
                                                                <asp:DropDownList ID="init_year" runat="server" CssClass="year required">
                                                                    <asp:ListItem>請選擇</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:DropDownList ID="init_month" runat="server" CssClass="month required">
                                                                    <asp:ListItem>請選擇</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:DropDownList ID="init_day" runat="server" CssClass="day required">
                                                                    <asp:ListItem>請選擇</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="1" class="auto-style1">
                                                        <label class="itemText required"><span class="PS">＊</span>組織型態</label>
                                                        <asp:CheckBoxList ID="CGI_OrganizationPatterns" runat="server" RepeatColumns="5" Width="360px">
                                                            <asp:ListItem Value="原廠">原廠</asp:ListItem>
                                                            <asp:ListItem Value="總代理">總代理</asp:ListItem>
                                                            <asp:ListItem Value="經銷商">經銷商</asp:ListItem>
                                                            <asp:ListItem Value="進出口商">進出口商</asp:ListItem>
                                                            <asp:ListItem Value="其他">其他</asp:ListItem>
                                                        </asp:CheckBoxList>

                                                    </td>
                                                    <td colspan="2" class="auto-style17">
                                                        <br />
                                                        <asp:TextBox ID="CGI_OrganizationPatternsOther" runat="server" Style="margin-left: -40px;"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style1" colspan="4">
                                                        <label class="itemText1" for="Com_RegisterAddress"><span class="PS">＊</span>營業登記地址</label>
                                                        <div class="address-zone " style="margin-left: 114px; margin-top: -19px;">
                                                            <asp:Label ID="zipcode" runat="server" CssClass="zipcode" Width="22px"></asp:Label>
                                                            <asp:DropDownList ID="city" runat="server" CssClass="city  required">
                                                                <asp:ListItem>請選擇</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:DropDownList ID="county" runat="server" CssClass="county  required" onchange="getSelect(this)">
                                                                <asp:ListItem>請選擇</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:TextBox ID="Com_Add" runat="server" size="20" CssClass="required" Width="510px" onchange="getSelect(this)"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style1" colspan="4">
                                                        <label class="itemText" for="Com_Address"><span class="PS">＊</span>聯絡地址</label>
                                                        <asp:CheckBox ID="CheckAddress" runat="server" Text="同上" />
                                                        <div class="address-zone1 " style="margin-left: 115px; margin-top: -19px;">
                                                            <asp:Label ID="zipcode1" runat="server" CssClass="zipcode1" Width="22px"></asp:Label>
                                                            <asp:DropDownList ID="city1" runat="server" CssClass="city1">
                                                                <asp:ListItem>請選擇</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:DropDownList ID="county1" runat="server" CssClass="county1" onchange="getSelect2(this)">
                                                                <asp:ListItem>請選擇</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:TextBox ID="Com_Add1" runat="server" size="20" CssClass="" Width="510px" onchange="getSelect2(this)"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="itemText" colspan="4">
                                                        <label for="Com_Url" class="itemTextNoRequire">&nbsp;&nbsp;&nbsp; 公司網址</label>
                                                        <asp:TextBox ID="Com_Url" CssClass="url" size="40" runat="server" Width="715px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style1">
                                                        <label for="Com_TelephoneA" class="itemText"><span class="PS">＊</span>公司電話</label>
                                                        <asp:TextBox ID="Com_TelephoneA" Size="2" MaxLength="2" CssClass="required digits" runat="server"></asp:TextBox>
                                                        -
                                                        <asp:TextBox ID="Com_TelephoneB" size="10" CssClass="required digits" MaxLength="8" runat="server"></asp:TextBox>

                                                    </td>
                                                    <td class="auto-style17">
                                                        <label for="Com_FaxA" class="itemTextNoRequire">公司傳真</label>
                                                        <asp:TextBox ID="Com_FaxA" Size="2" MaxLength="2" CssClass=" digits" runat="server"></asp:TextBox>
                                                        -
                                                        <asp:TextBox ID="Com_FaxB" size="10" CssClass=" digits" MaxLength="8" runat="server"></asp:TextBox>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style1">
                                                        <label class="itemText" for="CCo_Name"><span class="PS">＊</span>聯絡人</label>
                                                        <asp:TextBox ID="CCo_Name" CssClass="required leftMargin" runat="server" Width="85px"></asp:TextBox>
                                                        <label for="CCo_Title" class="itemText">&nbsp;&nbsp;&nbsp;&nbsp; 職稱</label>
                                                        <asp:TextBox ID="CCo_Title" size="15" CssClass="leftMargin" runat="server"></asp:TextBox>

                                                    </td>
                                                    <td class="auto-style17">
                                                        <label for="CCo_Extn" class="itemTextNoRequire">分機</label>
                                                        <asp:TextBox ID="CCo_Extn" size="6" CssClass="digits leftMargin" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style1">
                                                        <span class="PS">＊</span><label for="CCo_Email" class="itemText">電子郵件</label>
                                                        <asp:TextBox ID="CCo_Email" Width="315px" CssClass="email" runat="server"></asp:TextBox>

                                                    </td>
                                                    <td class="auto-style17">
                                                        <label for="CCo_Mobile" class="itemTextNoRequire">行動電話</label>
                                                        <asp:TextBox ID="CCo_Mobile" size="12" CssClass="digits" runat="server" Width="85px"></asp:TextBox>
                                                        <label for="CCo_Mobile2" class="itemTextNoRequire">行動電話2</label>
                                                        <asp:TextBox ID="CCo_Mobile2" size="12" CssClass="digits" runat="server" Width="85px"></asp:TextBox>
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
                                                    <asp:DropDownList ID="CGI_MainGoods" CssClass="selSize required" runat="server">
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
                                                    <asp:DropDownList ID="CGI_EscortGoods" CssClass="selSize " runat="server">
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
                                                    <asp:DropDownList ID="CGI_OthersGoods" CssClass="selSize " runat="server">
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
                                                    <asp:TextBox ID="CGI_TV" size="80" MaxLength="100" runat="server" Width="710px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label class="itemText" for="ch_web">&nbsp;&nbsp;&nbsp; 網路購物</label>
                                                    <asp:TextBox ID="CGI_Web" size="80" MaxLength="100" runat="server" Width="710px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label class="itemText" for="ch_store">&nbsp;&nbsp;&nbsp; 實體通路</label>
                                                    <asp:TextBox ID="CGI_Store" size="80" MaxLength="100" runat="server" Width="710px"></asp:TextBox>
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
                                                    <asp:TextBox ID="CGI_Ps" runat="server" Columns="120" Height="130px" TextMode="MultiLine" Width="800px"></asp:TextBox>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center;" class="auto-style4">
                                                    <label class="itemText" for="captcha"><span class="PS">＊</span>驗證碼</label>
                                                    <asp:TextBox ID="txtAuthCode" runat="server" Width="50px"></asp:TextBox>
                                                    <asp:Image ID="imgAuthCode" runat="server" ImageUrl="ValidateCode.ashx" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                        ControlToValidate="txtAuthCode" Display="Dynamic" ErrorMessage="(請輸入驗證碼)"
                                                        ValidationGroup="joinMember"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;">
                                                    <asp:Button runat="server" type="submit" ID="btnAddCo" OnClick="AddCo_Click" Text="送出資料" />
                                                    <input name="submit" type="reset" value="重設資料" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </form>
                </div>
            </div>
        </div>
    </div>

</body>
</html>


