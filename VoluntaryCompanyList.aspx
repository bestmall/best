<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoluntaryCompanyList.aspx.cs" Inherits="BestCompany.Companylist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>廠商資訊</title>
</head>
<style>
    #form1 {
        display :none;
    }
    </style>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="CheckAll" runat="server" Text="全選" OnClick="CheckAll_Click" />
        &nbsp;<asp:Button ID="ClickAll" runat="server" Text="取消" OnClick="ClickAll_Click" />
        &nbsp;<asp:Button ID="DelCheck" runat="server" Text="刪除" OnClick="DelCheck_Click" OnClientClick="return confirm('再次確認，是否刪除資料？')" />
        &nbsp;<asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" />
        <br />
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <ContentTemplate>
                <asp:GridView ID="GV_VoluntaryCompany" runat="server"  AllowPaging="True" PageSize="10" AutoGenerateColumns="False" DataKeyNames="Com_ID" CellPadding="4"  GridLines="None" OnPageIndexChanging="GV_VoluntaryCompany_PageIndexChanging" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Left" HeaderText="選取">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckCompany" runat="server" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Left" HeaderText="檢視">
                            <ItemTemplate>
                                <asp:HyperLink ID="UpdateCompany" runat="server" NavigateUrl='<%# "ViewVoluntaryCompany.aspx?ComID=" +  Eval("Com_ID") %>' Text="檢視"> </asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Left" HeaderText="編號" >
                            <ItemTemplate >
                                <asp:HyperLink ID="Com_ID" runat="server" Text='<%# Eval("Com_ID") %>' ></asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Left" HeaderText="公司名稱">
                            <ItemTemplate>
                                <asp:Label ID="Com_Name" runat="server" Text='<%# Eval("Com_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Left" HeaderText="統一編號">
                            <ItemTemplate>
                                <asp:Label ID="Com_Number" runat="server" Text='<%# Eval("Com_Number") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Left" HeaderText="聯絡地址">
                            <ItemTemplate>
                                <asp:Label ID="Com_Address" runat="server" Text='<%# Eval("Com_Address") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Left" HeaderText="公司電話">
                            <ItemTemplate>
                                <asp:Label ID="Com_Telephone" runat="server" Text='<%# Eval("Com_Telephone") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Left" HeaderText="聯絡人">
                            <ItemTemplate>
                                <asp:Label ID="CCo_Name" runat="server" Text='<%# Eval("CCo_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Left" HeaderText="職稱">
                            <ItemTemplate>
                                <asp:Label ID="CCo_Title" runat="server" Text='<%# Eval("CCo_Title") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Left" HeaderText="分機">
                            <ItemTemplate>
                                <asp:Label ID="CCo_Extn" runat="server" Text='<%# Eval("CCo_Extn") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Left" HeaderText="行動電話">
                            <ItemTemplate>
                                <asp:Label ID="CCo_Mobile" runat="server" Text='<%# Eval("CCo_Mobile") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Left" HeaderText="主力商品">
                            <ItemTemplate>
                                <asp:Label ID="GTy_Type" runat="server" Text='<%# Eval("GTy_Type") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Left" HeaderText="申請日期">
                            <ItemTemplate>
                                <asp:Label ID="VCC_ApplyTime" runat="server" Text='<%# Eval("VCC_ApplyTime") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Left" HeaderText="連絡的商開">
                            <ItemTemplate>
                                <asp:Label ID="ContactMDName" runat="server" Text='<%# Eval("ContactMDName") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Left" HeaderText="負責商開">
                            <ItemTemplate>
                                <asp:Label ID="MDName" runat="server" Text='<%# Eval("MDName") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>

                    </Columns>

                     <PagerSettings Mode="Numeric" />
                     <PagerStyle HorizontalAlign="Center" />

                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />

                </asp:GridView>
                <br />
                <br />
            </ContentTemplate>
                </asp:UpdatePanel>
        <br />
    </form>
</body>
</html>
