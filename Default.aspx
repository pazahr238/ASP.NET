<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 186px;
        }
        .auto-style2 {
            width: 457px;
            }
        .auto-style4 {
            height: 35px;
            text-align: center;
        }
        </style>
</head>
<body  style="background-color: #ECF4EF">
    <form id="form1" runat="server" dir="ltr">
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
    
        <asp:Panel ID="Panelusr" runat="server" Direction="RightToLeft" Height="291px">
            <table style="width: 100%; height: 295px" id="maintbl" >
                <tr style="height: 33%">
                    <td style="width: 33%">&nbsp;</td>
                    <td style="width: 34%; font-family: 'b mitra'; font-size: 14pt; font-weight: bold; font-style: normal; text-decoration: underline; color: #FF0000; text-align: center;"></td>
                    <td style="width: 33%">
                        &nbsp;</td>
                </tr>
                <tr style="height: 34%">
                    <td style="width: 33%">&nbsp;</td>
                    <td style="width: 34%">
                        <table class="box_round" style="background-color: #DFECE4; height: 201px; width: 556px;">
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <asp:Label ID="lblusername" runat="server" Font-Names="B Mitra" Font-Size="Large" Text="نام کاربری"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtusername" Runat="server" BackColor="#ECF4EF" BorderColor="#D3EEDE" BorderStyle="Ridge" BorderWidth="2px" EmptyMessage="لطفا نام کاربری را وارد نمایید" Font-Names="B Mitra" Font-Size="Large" Height="29px" LabelWidth="64px" Resize="None" Width="401px">
                                        <EmptyMessageStyle Resize="None" ForeColor="#CC0000">
                                        </EmptyMessageStyle>
                                        <ReadOnlyStyle Resize="None">
                                        </ReadOnlyStyle>
                                        <FocusedStyle Resize="None" BackColor="#ECF4EF" BorderColor="#91BFA3" BorderStyle="Solid" BorderWidth="3px">
                                        </FocusedStyle>
                                        <DisabledStyle Resize="None" BackColor="#ECF4EF" BorderColor="#D3EEDE">
                                        </DisabledStyle>
                                        <InvalidStyle Resize="None" BackColor="#ECF4EF" BorderColor="#D3EEDE">
                                        </InvalidStyle>
                                        <HoveredStyle Resize="None" BackColor="#BDDFCB" BorderColor="#69B889" BorderStyle="Solid" BorderWidth="2px">
                                        </HoveredStyle>
                                        <EnabledStyle Resize="None" BackColor="#ECF4EF" BorderColor="#D3EEDE">
                                        </EnabledStyle>
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <asp:Label ID="lblpassword" runat="server" Font-Names="B Mitra" Font-Size="Large" Text="رمز عبور"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtpassword" Runat="server" BackColor="#ECF4EF" BorderColor="#D3EEDE" BorderStyle="Ridge" BorderWidth="2px" Font-Names="B Mitra" Font-Size="Large" Height="29px" LabelWidth="64px" Resize="None" TextMode="Password" Width="401px">
                                        <EmptyMessageStyle Resize="None" ForeColor="#CC0000">
                                        </EmptyMessageStyle>
                                        <ReadOnlyStyle Resize="None">
                                        </ReadOnlyStyle>
                                        <FocusedStyle Resize="None" BackColor="#ECF4EF" BorderColor="#91BFA3" BorderStyle="Solid" BorderWidth="3px">
                                        </FocusedStyle>
                                        <DisabledStyle Resize="None">
                                        </DisabledStyle>
                                        <InvalidStyle Resize="None">
                                        </InvalidStyle>
                                        <HoveredStyle Resize="None" BackColor="#BDDFCB" BorderColor="#69B889" BorderStyle="Solid" BorderWidth="2px">
                                        </HoveredStyle>
                                        <EnabledStyle Resize="None">
                                        </EnabledStyle>
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center; direction: ltr;">
                                    <asp:Label ID="lbllang" runat="server" Font-Names="B Mitra" Font-Size="Large" Text="زبان"></asp:Label>
                                </td>
                                <td style="text-align: center">
                                    <asp:RadioButtonList ID="rblang" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" style="text-align: left" Width="358px">
                                        <asp:ListItem>Engish</asp:ListItem>
                                        <asp:ListItem Selected="True">Persian (فارسی)</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center" class="auto-style4">
                                    <asp:HyperLink ID="lnkhelp" runat="server" Font-Bold="True" Font-Size="14pt" Font-Underline="False">راهنما</asp:HyperLink>
                                </td>
                                <td class="auto-style4" style="vertical-align: top">
                                    <asp:Button ID="btnlogin" runat="server" CssClass="btn" Font-Names="B Koodak" OnClick="btnlogin_Click" Text="ورود" />
                                    <asp:Button ID="btnreg" runat="server" CssClass="btn" Font-Names="B Koodak" PostBackUrl="~/Register.aspx" Text="ثبت نام" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 33%">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtusername" ErrorMessage="لطفا شماره کاربری خود را به طور صحیح وارد نمایید" Font-Bold="True" Font-Names="B Mitra" Font-Size="Large" ForeColor="Red" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtusername" ErrorMessage="RequiredFieldValidator" Font-Names="B Mitra" Font-Size="Large" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr style="height: 33%">
                    <td style="width: 33%">&nbsp;</td>
                    <td style="width: 34%; text-align: center;">
                        <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Names="B Mitra" Font-Size="Large" ForeColor="Red" style="font-weight: 700" Visible="False">کاربری با این مشخصات ثبت نشده است</asp:Label>
                    </td>
                    <td style="width: 33%">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    
    </form>
    
</body>
</html>
