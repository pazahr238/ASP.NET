<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowRecs.aspx.cs" Inherits="ShowRecs" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 78%;
            height: 101px;
        }
        .auto-style2 {
            height: 23px;
            width: 321px;
        }
        .auto-style5 {
            height: 23px;
            width: 1269px;
        }
        .auto-style6 {
            width: 1269px;
        }
        .auto-style7 {
            width: 321px;
        }
.RadButton_Default.rbSkinnedButton{background-image:url('mvwres://Telerik.Web.UI, Version=2015.2.623.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2015.2.623.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png');color:#333}.RadButton_Default{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px}.rbSkinnedButton{padding-left:4px}.RadButton{cursor:pointer}.rbSkinnedButton{vertical-align:middle}.rbSkinnedButton{vertical-align:top}.rbSkinnedButton{display:inline-block;position:relative;background-color:transparent;background-repeat:no-repeat;border:0 none;height:22px;text-align:center;text-decoration:none;white-space:nowrap;background-position:left -525px;padding-left:4px;vertical-align:top;box-sizing:border-box}.RadButton{font-size:12px;font-family:"Segoe UI",Arial,Helvetica,sans-serif}.RadButton{box-sizing:content-box;-moz-box-sizing:content-box}.RadButton_Default .rbDecorated{background-image:url('mvwres://Telerik.Web.UI, Version=2015.2.623.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2015.2.623.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png');color:#333}.RadButton_Default .rbDecorated{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px}.RadButton .rbDecorated{padding-left:8px;padding-right:12px;margin:0;border:0}.rbDecorated{padding-left:8px;padding-right:12px}.rbDecorated{display:block;*display:inline;*zoom:1;height:22px;padding-left:6px;*padding-left:8px;padding-right:10px;border:0;text-align:center;background-position:right -88px;overflow:visible;background-color:transparent;outline:0;cursor:pointer;-webkit-border-radius:0;-webkit-appearance:none;*line-height:22px}.rbDecorated{line-height:20px}.rbDecorated{font-size:12px;font-family:"Segoe UI",Arial,Helvetica,sans-serif}
        .auto-style8 {
        }
        .auto-style10 {
            height: 10px;
        }
        .RadMediaPlayer_Default{font-weight:normal;font-size:12px;line-height:16px;font-family:"Segoe UI",Arial,Helvetica,sans-serif;color:#333}.RadMediaPlayer{position:relative;background-color:#000}.RadMediaPlayer .rmpTitleBar{-webkit-box-sizing:content-box;-moz-box-sizing:content-box;box-sizing:content-box}.RadMediaPlayer .rmpTitleBar{background-color:#000;background-color:rgba(0,0,0,0.4);min-height:20px;padding:10px 0;width:100%;position:absolute;top:0;left:0;z-index:2147483647}.RadMediaPlayer .rmpTitleBar h4{float:left;margin:0 60px 0 20px;font-size:14px;font-weight:normal;line-height:16px;color:#fff}.RadMediaPlayer .rmpTitleBar .rmpButtSet{position:absolute;right:5px}.RadMediaPlayer .rmpButtSet .rmpActionButton{margin:0 10px}.RadMediaPlayer .rmpActionButton{height:22px;width:22px;background:0;border:0 none;padding:0;cursor:pointer;margin-right:17px;vertical-align:middle}.RadMediaPlayer_Default .rmpShareIcon{background-position:0 -2139px}.RadMediaPlayer_Default .rmpIcon{background-image:url('mvwres://Telerik.Web.UI, Version=2015.2.623.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radActionsSprite.png')}.RadMediaPlayer .rmpIcon{height:22px;width:22px;margin:0 1px;display:inline-block;background-repeat:no-repeat}.RadMediaPlayer .rmpButtonText{display:none}.RadMediaPlayer .rmpToolbarWrapper{background-image:url(data:image/gif;base64,R0lGODlhAQABAHAAACH5BAUAAAAALAAAAAABAAEAAAICRAEAOw==)}.RadMediaPlayer .rmpToolbarWrapper{height:40px;width:100%!important;position:absolute;bottom:10px;left:0}.RadMediaPlayer_Default .rmpToolbar{color:#333;border-color: #8a8a8a;
            background-image: linear-gradient(to bottom,rgba(252,252,252,0.9) 0,rgba(193,193,193,0.9) 100%);
        }.RadMediaPlayer .rmpToolbar{position:absolute;bottom:0;left:0;right:0}.RadMediaPlayer .rmpToolbar{-webkit-box-sizing:content-box;-moz-box-sizing:content-box;box-sizing:content-box}.RadMediaPlayer .rmpToolbar{background-image:url(data:image/gif;base64,R0lGODlhAQABAHAAACH5BAUAAAAALAAAAAABAAEAAAICRAEAOw==)}.RadMediaPlayer .rmpToolbar{margin:0 10px;height:30px;padding-top:8px;border-radius:3px;border-width:1px;border-style:solid;position:relative}.RadMediaPlayer .rmpLeftControlsSet{position:absolute;left:15px}.RadMediaPlayer_Default .rmpPlayIcon{background-position:0 -1999px}.RadMediaPlayer .rmpRightControlsSet{position:absolute;right:0;top:0;height:30px;padding-top:8px}.RadMediaPlayer .rmpProgressText{font-size:11px;margin-right:7px}.RadMediaPlayer .rmpHDButton{width:27px}.RadMediaPlayer .rmpHDButton .rmpIcon{width:27px}.RadMediaPlayer_Default .rmpHDIcon{background-position:0 -2079px}.RadMediaPlayer_Default .rmpFullScrIcon{background-position:0 -2099px}
        .auto-style13 {
            width: 100%;
        }
        .auto-style18 {
            height: 23px;
            width: 425px;
        }
        .auto-style20 {
        }
        .auto-style28 {
        }
    </style>

    <link rel="stylesheet" type="text/css" href="Skins/Rating.css"></link>
    <link rel="stylesheet" type="text/css" href="Skins/MyCustomSkin/Rating.Sunset.css"></link>

</head>
<body>
    <form id="form1" runat="server">
    
    
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
    
    <asp:Panel ID="Panelusr" runat="server" Direction="RightToLeft">
        <table class="auto-style1" style="width: 100%; text-align: center; vertical-align: middle; height: 312px;">
            <tr>
                <td class="auto-style18">
                    <asp:Label ID="lblstats" runat="server" Font-Bold="True" Font-Names="B Mitra" Font-Size="16pt" ForeColor="Red"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="lblrecs" runat="server" Text="پیشنهادات برای شما:" style="font-weight: 700; text-decoration: underline;" Font-Names="B Mitra" Font-Size="Large"></asp:Label>
                    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                        <Scripts>
                            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
                            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
                            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
                        </Scripts>
                    </telerik:RadScriptManager>
                    <br />
                    <asp:Label ID="lblcmtop" runat="server" Text="لطفا درمورد هریک از پیشنهادات اگر مطابق سلیقه شماست نظر بدهید" Font-Names="B Mitra" Font-Size="Large"></asp:Label>
                    <br />
                </td>
                <td class="auto-style2">

               <telerik:RadButton ID="btngomain" runat="server" Font-Names="B Mitra" Font-Size="Large" style="top: 3px; left: 60px; height: 30px; width: 96px; line-height: 30px; position: relative;" Text="بازگشت" ButtonType="SkinnedButton" EnableBrowserButtonStyle="True" EnableEmbeddedSkins="False" Height="30px" Skin="Default" OnClick="btngomain_Click">
               </telerik:RadButton>

                            </td>
            </tr>
            <tr>
                <td colspan="3" dir="auto">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MusicRecCn %>" SelectCommand="SELECT        TOP (10) name, artist, id, SUM(itrate) AS totrate
FROM            dbo.View_Recs
WHERE        (userid = @userid)
GROUP BY name, artist, id
ORDER BY totrate DESC">
                        <SelectParameters>
                            <asp:SessionParameter Name="userid" SessionField="userid" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:GridView ID="gvRecs" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="gvRecs_SelectedIndexChanged" Width="100%">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="name" HeaderText="Music" SortExpression="name">
                            <HeaderStyle Font-Names="B Mitra" Font-Size="Large" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="artist" HeaderText="Artist" SortExpression="artist">
                            <HeaderStyle Font-Names="B Mitra" Font-Size="Large" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id">
                            <HeaderStyle Font-Names="B Mitra" Font-Size="Large" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:CommandField ButtonType="Image" HeaderText="Preview" SelectImageUrl="~/play.png" SelectText="اجرا" ShowSelectButton="True">
                            <HeaderStyle Font-Names="B Mitra" Font-Size="Large" HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="Favorable">
                                <ItemTemplate>
                                    <telerik:RadRating ID="myrate" Runat="server" EnableEmbeddedSkins="False" ItemCount="1" Skin="Sunset" style="text-align: center">
                                    </telerik:RadRating>
                                </ItemTemplate>
                                <ControlStyle Width="70px" />
                                <HeaderStyle Font-Names="B Mitra" Font-Size="Large" HorizontalAlign="Center" Width="70px" />
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#F7F7DE" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style20" colspan="3">
                    <telerik:RadMediaPlayer ID="SearchPlayer" runat="server" EnableTheming="False" Height="80px" Poster="~/mpback.gif" StartVolume="100" ToolbarDocked="True" Width="100%" AutoPlay="True">
                        <PlaylistSettings ButtonsTrigger="Hover" Mode="Scrollbar" />
                    </telerik:RadMediaPlayer>
                </td>
            </tr>
             <tr>
                <td class="auto-style20">
                    &nbsp;</td>
                <td class="auto-style6">

                    
               
                    <asp:Label ID="lblmsgfound" runat="server" Visible="False" Font-Bold="True" Font-Size="16pt" ForeColor="#FF3300"></asp:Label>

                    
               
                    <asp:Label ID="lblmsgerrorplay" runat="server" Font-Bold="True" Font-Size="16pt" ForeColor="Red" Visible="False"></asp:Label>

                    
               
                </td>
                <td class="auto-style7">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style20" colspan="3">
                    <table class="auto-style13">
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <telerik:RadButton ID="btnclear" runat="server" BackColor="#F7F7DE" ButtonType="SkinnedButton" EnableBrowserButtonStyle="True" EnableEmbeddedSkins="False" Font-Names="B Mitra" Font-Size="Large" Height="30px" OnClick="btnclear_Click" Skin="Default" style="top: 3px; left: -7px; height: 30px; width: 128px; line-height: 30px; position: relative;" Text="نظردهی مجدد">
                                </telerik:RadButton>
                            </td>
                            <td>
                                <telerik:RadButton ID="btnremove" runat="server" BackColor="#F7F7DE" ButtonType="SkinnedButton" EnableBrowserButtonStyle="True" Font-Names="B Mitra" Font-Size="Large" Height="30px" OnClick="btnremove_Click" Skin="Default" style="top: 3px; left: -16px; height: 30px; width: 159px; line-height: 30px; position: relative;" Text="حذف نظرات ثبت شده">
                                </telerik:RadButton>
                            </td>
                            <td>
                                <telerik:RadButton ID="btnsubmit" runat="server" BackColor="#F7F7DE" ButtonType="SkinnedButton" EnableBrowserButtonStyle="True" Font-Names="B Mitra" Font-Size="Large" Height="30px" OnClick="btnrate_Click" Skin="Default" style="top: 3px; left: -21px; width: 110px;" Text="ثبت نظرات">
                                </telerik:RadButton>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            
        </table>
    <br />
        <table style="width: 100%; text-align: center; vertical-align: middle;">
            <tr>
                <td class="auto-style28" style="background-color: #F5F5DC">
                    <asp:Label ID="lblmsg3" runat="server" Font-Names="B Mitra" Font-Size="Large" Text="میزان رضایت شما:" Visible="False"></asp:Label>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style28" style="background-color: #F5F5DC">
                    <telerik:RadButton ID="btnstats" runat="server" Font-Names="B Mitra" Font-Size="Large" OnClick="btnstats_Click" style="top: 0px; left: 0px;" Text="محاسبه" Visible="False">
                    </telerik:RadButton>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">
                    <br />
                    <asp:Label ID="lblInst" runat="server" Font-Bold="True" Font-Names="B Mitra" Font-Size="Large" Text="دستورالعمل استفاده از این صفحه:"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:TextBox ID="txtinst" runat="server" BorderColor="Black" BorderStyle="Outset" BorderWidth="1px" Font-Names="B Mitra" Font-Size="14pt" Height="250px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                    <br />
                </td>
            </tr>
        </table>
    </asp:Panel>
    </form>
</body>
</html>
