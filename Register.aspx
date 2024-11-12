<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css"/>
    <title></title>
    <style type="text/css">
        .auto-style4 {
            height: 23px;
        }
        .auto-style5 {
            width: 205px;
        }
        .auto-style6 {
            text-align: center;
            width: 205px;
        }
        .auto-style7 {
            height: 23px;
            width: 205px;
        }
    </style>
</head>
<body  style="background-color: #ECF4EF">
    <form id="form1" runat="server">
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
    
<asp:Panel ID="Panelusr" runat="server" Direction="RightToLeft">
      <table style="width: 100%; height: 250px" >
        <tr style="height: 33%">
            <td style="width: 25%">&nbsp;</td>
            <td style="width: 50%">&nbsp;</td>
            <td style="width: 25%">&nbsp;</td>
        </tr>

        <tr style="height: 34%">
            <td style="width: 25%">


                &nbsp;</td>

            <td style="width: 50%">


                <table class="box_round" style="background-color: #DFECE4; height: 121px; width: 600px;">
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: center" class="auto-style5">
                            <asp:Label ID="lblname" runat="server" Font-Names="B Mitra" Font-Size="Large" Text="نام و نام خانوادگی"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtname" Runat="server" BackColor="#ECF4EF" BorderColor="#D3EEDE" BorderStyle="Ridge" EmptyMessage="لطفا نام و نام خانوادگی را وارد نمایید" Font-Names="B Mitra" Font-Size="Large" Height="29px" LabelWidth="64px" Resize="None" Width="350px" BorderWidth="2px">
                                <EmptyMessageStyle ForeColor="#CC0000" Resize="None" />
                                <ReadOnlyStyle Resize="None" />
                                <FocusedStyle BackColor="#ECF4EF" BorderColor="#91BFA3" BorderStyle="Solid" Resize="None" BorderWidth="3px" />
                                <DisabledStyle Resize="None" BackColor="#ECF4EF" BorderColor="#D3EEDE" />
                                <InvalidStyle Resize="None" BackColor="#ECF4EF" BorderColor="#D3EEDE" />
                                <HoveredStyle BackColor="#BDDFCB" BorderColor="#69B889" BorderStyle="Solid" Resize="None" BorderWidth="2px" />
                                <EnabledStyle Resize="None"  BackColor="#ECF4EF" BorderColor="#D3EEDE" />
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" class="auto-style5">
                            <asp:Label ID="lblid" runat="server" Font-Names="B Mitra" Font-Size="Large" Text="شماره کاربری"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtusername" Runat="server" BackColor="#ECF4EF" BorderColor="#D3EEDE" BorderStyle="Ridge" EmptyMessage="لطفا شماره کاربری را وارد نمایید" Font-Names="B Mitra" Font-Size="Large" Height="29px" LabelWidth="64px" Resize="None" Width="350px" BorderWidth="2px">
                                <EmptyMessageStyle ForeColor="#CC0000" Resize="None" />
                                <ReadOnlyStyle Resize="None" />
                                <FocusedStyle BackColor="#ECF4EF" BorderColor="#91BFA3" BorderStyle="Solid" Resize="None" BorderWidth="3px" />
                                <DisabledStyle Resize="None" BackColor="#ECF4EF" BorderColor="#D3EEDE" />
                                <InvalidStyle Resize="None" BackColor="#ECF4EF" BorderColor="#D3EEDE" />
                                <HoveredStyle BackColor="#BDDFCB" BorderColor="#69B889" BorderStyle="Solid" Resize="None" BorderWidth="2px" />
                                <EnabledStyle Resize="None"  BackColor="#ECF4EF" BorderColor="#D3EEDE" />
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" class="auto-style5">
                            <asp:Label ID="lblpassword" runat="server" Font-Names="B Mitra" Font-Size="Large" Text="رمز عبور"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtpassword" Runat="server" BackColor="#ECF4EF" BorderColor="#D3EEDE" BorderStyle="Ridge" Font-Names="B Mitra" Font-Size="Large" Height="29px" LabelWidth="64px" Resize="None" TextMode="Password" Width="350px" BorderWidth="2px">
                                <EmptyMessageStyle ForeColor="#CC0000" Resize="None" />
                                <ReadOnlyStyle Resize="None" />
                                <FocusedStyle BackColor="#ECF4EF" BorderColor="#91BFA3" BorderStyle="Solid" Resize="None" BorderWidth="3px" />
                                <DisabledStyle Resize="None" BackColor="#ECF4EF" BorderColor="#D3EEDE" />
                                <InvalidStyle Resize="None" BackColor="#ECF4EF" BorderColor="#D3EEDE" />
                                <HoveredStyle BackColor="#BDDFCB" BorderColor="#69B889" BorderStyle="Solid" Resize="None" BorderWidth="2px" />
                                <EnabledStyle Resize="None"  BackColor="#ECF4EF" BorderColor="#D3EEDE" />
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">&nbsp;</td>
                        <td>
                            <asp:SqlDataSource ID="SqlDsCity" runat="server" ConnectionString="<%$ ConnectionStrings:MusicRecCn %>" SelectCommand="SELECT * FROM [City]"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">&nbsp;&nbsp;
                            <asp:Label ID="lblage" runat="server" Font-Names="B Mitra" Font-Size="Large" Text="سن"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="txtage" Runat="server" BackColor="#ECF4EF" BorderColor="#D3EEDE" BorderStyle="Ridge" BorderWidth="2px" Culture="en-US" DataType="System.UInt16" DbValueFactor="1" EmptyMessage="لطفا سن را وارد نمایید" Font-Names="B Mitra" Font-Size="Large" Height="29px" LabelWidth="64px" MaxValue="60" MinValue="18" Value="18" Width="160px">
                                <NegativeStyle Resize="None" />
                                <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                <EmptyMessageStyle Resize="None" />
                                <ReadOnlyStyle Resize="None" />
                                <FocusedStyle Resize="None" BackColor="#ECF4EF" BorderColor="#91BFA3" BorderStyle="Solid" BorderWidth="3px" />
                                <DisabledStyle Resize="None" />
                                <InvalidStyle Resize="None" BackColor="#ECF4EF" BorderColor="#D3EEDE" />
                                <HoveredStyle BackColor="#BDDFCB" BorderColor="#69B889" BorderStyle="Solid" BorderWidth="2px" Resize="None" />
                                <EnabledStyle Resize="None" BackColor="#ECF4EF" BorderColor="#D3EEDE" />
                            </telerik:RadNumericTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">
                            <asp:Label ID="lblcity" runat="server" Font-Names="B Mitra" Font-Size="Large" Text="شهر محل سکونت"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadSearchBox ID="txtcity" runat="server" BackColor="#ECF4EF" BorderColor="#D3EEDE" BorderStyle="Ridge" DataSourceID="SqlDsCity" DataTextField="CityName" DataValueField="CityName" EmptyMessage="لطفا شهر محل سکونت خود را وارد کنید" EnableTheming="True" Font-Names="B Mitra" Font-Size="Medium" HighlightFirstMatch="True" Width="350px">
                            </telerik:RadSearchBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">
                            <asp:Label ID="lbllooking" runat="server" Font-Names="B Mitra" Font-Size="Large" Text="علاقه به فعالیت"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cbolooking" Runat="server" BackColor="#ECF4EF" BorderColor="#D3EEDE" BorderStyle="Ridge" BorderWidth="2px" Font-Names="B Mitra" Font-Size="Large" Width="350px">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="ارتباط با دوستان" Value="ارتباط با دوستان" />
                                    <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="دوست یابی" Value="دوست یابی" />
                                    <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="ارتباطات شبکه ای" Value="ارتباطات شبکه ای" />
                                    <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="تفریح" Value="تفریح" />
                                    <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="یافتن موسیقی های مورد علاقه" Value="یافتن موسیقی های مورد علاقه" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" class="auto-style5">
                            <asp:Label ID="lblrelig" runat="server" Font-Names="B Mitra" Font-Size="Large" Text="دین"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cborelig" Runat="server" BackColor="#ECF4EF" BorderColor="#D3EEDE" BorderStyle="Ridge" BorderWidth="2px" Font-Names="B Mitra" Font-Size="Large" Width="350px">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="اسلام" Value="اسلام" />
                                    <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="غیر اسلام" Value="غیر اسلام" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" class="auto-style5">
                            <asp:Label ID="lbledu" runat="server" Font-Names="B Mitra" Font-Size="Large" Text="سطح تحصیلات"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cboedu" Runat="server" BackColor="#ECF4EF" BorderColor="#D3EEDE" BorderStyle="Ridge" BorderWidth="2px" Font-Names="B Mitra" Font-Size="Large" Width="350px">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="دیپلم" Value="دیپلم" />
                                    <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="کاردانی" Value="کاردانی" />
                                    <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="کارشناسی" Value="کارشناسی" />
                                    <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="کارشناسی ارشد" Value="کارشناسی ارشد" />
                                    <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="دکترا" Value="دکترا" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" class="auto-style5">&nbsp;</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="text-align: center" class="auto-style5">
                            <asp:Label ID="lblheartime" runat="server" Font-Names="B Mitra" Font-Size="Large" Text="زمان معمول شنیدن موسیقی"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cboheartime" Runat="server" BackColor="#ECF4EF" BorderColor="#D3EEDE" BorderStyle="Ridge" BorderWidth="2px" Font-Names="B Mitra" Font-Size="Large" Width="350px">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="روز" Value="روز" />
                                    <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="شب" Value="شب" />
                                    <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="فرقی ندارد" Value="فرقی ندارد" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" class="auto-style5">
                            <asp:Label ID="lblhearmth" runat="server" Font-Names="B Mitra" Font-Size="Large" Text="روشهای شنیدن موسیقی"></asp:Label>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:RadioButtonList ID="rdolisthearmth" runat="server" AutoPostBack="True" Font-Names="B Mitra" Font-Size="Large" OnSelectedIndexChanged="rdolisthearmth_SelectedIndexChanged" RepeatDirection="Horizontal" style="direction: rtl" Width="302px">
                                        <asp:ListItem>آنلاین</asp:ListItem>
                                        <asp:ListItem>آفلاین</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <telerik:RadComboBox ID="cboonsite" Runat="server" BackColor="#ECF4EF" BorderColor="#D3EEDE" BorderStyle="Ridge" BorderWidth="2px" Font-Names="B Mitra" Font-Size="Large" Visible="False" Width="91px">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="معمولا از یک سایت خاص" Value="معمولا از یک سایت خاص" />
                                            <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="با جستجو در وب و فرقی ندارد" Value="با جستجو در وب و فرقی ندارد" />
                                        </Items>
                                    </telerik:RadComboBox>
                                    <telerik:RadComboBox ID="cbooffdev" Runat="server" BackColor="#ECF4EF" BorderColor="#D3EEDE" BorderStyle="Ridge" BorderWidth="2px" Font-Names="B Mitra" Font-Size="Large" Visible="False" Width="91px">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="Laptop / PC" Value="Laptop / PC" />
                                            <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="iPod / iPad" Value="iPod / iPad" />
                                            <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="MP3 / MP4 Player" Value="MP3 / MP4 Player" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="rdolisthearmth" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" class="auto-style5">&nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: center" class="auto-style5">
                            <asp:Label ID="lbllonewith" runat="server" Font-Names="B Mitra" Font-Size="Large" Text="همراهی"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cbolonewith" Runat="server" BackColor="#ECF4EF" BorderColor="#D3EEDE" BorderStyle="Ridge" BorderWidth="2px" Font-Names="B Mitra" Font-Size="Large" Width="350px">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="تنها" Value="تنها" />
                                    <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="همراه دیگران" Value="همراه دیگران" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" class="auto-style5">
                            <asp:Label ID="lblmentcond" runat="server" Font-Names="B Mitra" Font-Size="Large" Text="حالت روحی برای شنیدن"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cbomentcond" Runat="server" BackColor="#ECF4EF" BorderColor="#D3EEDE" BorderStyle="Ridge" BorderWidth="2px" Font-Names="B Mitra" Font-Size="Large" Width="350px">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="شرایط خاص مثل شادی / ناراحتی / دلتنگی" Value="شرایط خاص مثل شادی / ناراحتی / دلتنگی" />
                                    <telerik:RadComboBoxItem runat="server" Font-Names="B Mitra" Font-Size="Large" Text="بستگی ندارد و هروقت دلم بخواهد" Value="بستگی ندارد و هروقت دلم بخواهد" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="text-align: center"></td>
                        <td class="auto-style4"></td>
                    </tr>
                    <tr>
                        <td style="text-align: center" class="auto-style5">&nbsp;</td>
                        <td>
                            <asp:Button ID="btnreg" runat="server" CssClass="btn" Font-Names="B Koodak" OnClick="btnreg_Click" Text="ثبت نام" />
                            <asp:Button ID="btnret" runat="server" CssClass="btn" Font-Names="B Koodak" PostBackUrl="~/Default.aspx" Text="بازگشت" />
                        </td>
                    </tr>
                </table>
            </td>

            <td style="width: 25%">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtusername" ErrorMessage="لطفا شماره کاربری خود را به طور صحیح وارد نمایید" Font-Bold="True" Font-Names="B Mitra" Font-Size="Large" ForeColor="Red" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
            </td>
        
        </tr>
          
           <tr style="height: 33%">
            <td style="width: 25%">&nbsp;</td>
            <td style="width: 50%; text-align: center;">
                <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Names="B Mitra" Font-Size="Large" ForeColor="Red" style="font-weight: 700" Visible="False"></asp:Label>
                <asp:Label ID="lblrepeateduser" runat="server" Font-Bold="True" Font-Names="B Mitra" Font-Size="Large" ForeColor="Red" style="font-weight: 700" Visible="False"></asp:Label>
               </td>
            <td style="width: 25%">&nbsp;</td>
           </tr>

    </table>
  

    </asp:Panel>   
    
    </form>
   
</body>
</html>
