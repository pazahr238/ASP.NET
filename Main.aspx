<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css"/>
    <title></title>
   
    <style type="text/css">
    
        .auto-style4 {
            width: 22px;
        }
    </style>
   
    <link rel="stylesheet" type="text/css" href="Skins/Rating.css"></link>
    <link rel="stylesheet" type="text/css" href="Skins/MyCustomSkin/Rating.Sunset.css"></link>

</head>
<body style="background-color: #ECF4EF">
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
<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
              </Scripts>
          </telerik:RadScriptManager>
          <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
          </telerik:RadAjaxManager>

 
                    
    <asp:Panel ID="Panelusr" runat="server" Direction="RightToLeft">  
     
    <table style="width: 100%; height: 250px" >
        <tr style="height: 33%">
            <td style="width: 33%">&nbsp;</td>
            <td style="width: 34%; text-align: center;">
                <asp:Label ID="lbltitle" runat="server" style="font-size: x-large; font-weight: 700" Text="به سیستم پیشنهاد موزیک SARSIS خوش آمدید" Font-Names="B Mitra"></asp:Label>
            </td>
            <td style="width: 33%">&nbsp;</td>
        </tr>

        <tr style="height: 34%">
            <td style="width: 33%">


                &nbsp;</td>

            <td style="width: 34%">


    <table class="box_round" style="background-color: #DFECE4; height: 121px; width: 635px;">
        <tr>
            <td colspan="3" style="text-align: center">

                <asp:Button ID="btnlogout" runat="server" CssClass="btn" Font-Names="B Mitra" OnClick="btnlogout_Click" Text="خروج" />

            </td>
            <td style="text-align: center">

                                    &nbsp;</td>
        </tr>
         <tr>
           <td colspan="3" style="text-align: center">

                    <asp:Label ID="lblpreview" runat="server" Font-Bold="True" Font-Names="B Mitra" Font-Size="Large" ForeColor="#333399" Text="پیش نمایش"></asp:Label>
               
             </td>
            <td>

              <!--   <audio class="powerpress-mejs-audio" preload="none" src="<%=Session["musicsource"] %>" controls="controls" style="margin-top: 12px; float: left; width: 100%;" id="audioplayer"></audio>  -->

                    <telerik:RadMediaPlayer ID="SearchPlayer" runat="server" EnableTheming="False" Height="80px" StartVolume="100" ToolbarDocked="True" Width="350px" AutoPlay="True">
                        <PlaylistSettings ButtonsTrigger="Hover" Mode="Scrollbar" />
                    </telerik:RadMediaPlayer>


            </td>
        </tr>
        <tr>
           <td style="text-align: center" colspan="3">

                    <asp:Label ID="lblsearch" runat="server" Font-Bold="True" Font-Names="B Mitra" Font-Size="Large" ForeColor="#333399" Text="جستجوی موزیک"></asp:Label>
            </td>
            <td>


                    <asp:Label ID="lblmsgfound" runat="server" Visible="False" ForeColor="#FF3300"></asp:Label>
                    <asp:Label ID="lblmsgerrorplay" runat="server" ForeColor="Red" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="3">

                    <asp:Label ID="lblartistname" runat="server" Font-Names="B Mitra" Font-Size="Large" Text="نام خواننده"></asp:Label>
                    <asp:Label ID="lbltemp" runat="server" Visible="False"></asp:Label>
            </td>
            <td>

                    <asp:SqlDataSource ID="SqlDsArtist" runat="server" ConnectionString="<%$ ConnectionStrings:MusicRecCn %>" SelectCommand="SELECT * FROM [Artists] ORDER BY [name]"></asp:SqlDataSource>
                    <telerik:RadSearchBox ID="txtartist" runat="server" DataSourceID="SqlDsArtist" DataTextField="name" DataValueField="name" OnSearch="txtartist_Search" Width="350px" BackColor="#ECF4EF" BorderColor="#D3EEDE">
                    </telerik:RadSearchBox>

            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="3">

                    <asp:Label ID="lblmusicname" runat="server" Font-Names="B Mitra" Font-Size="Large" Text="نام موزیک"></asp:Label>
            </td>
            <td>

                    <asp:SqlDataSource ID="SqlDsTrack" runat="server" ConnectionString="<%$ ConnectionStrings:MusicRecCn %>" SelectCommand="SELECT * FROM [Tracks] WHERE ([artist] = @artist) ORDER BY [name] DESC">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="lbltemp" Name="artist" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <telerik:RadSearchBox ID="txttrack" runat="server" DataSourceID="SqlDsTrack" DataTextField="name" DataValueField="name" OnSearch="txttrack_Search" Skin="Default" Width="350px" BackColor="#ECF4EF" BorderColor="#D3EEDE">
                    </telerik:RadSearchBox>

            </td>
        </tr>
        <tr>
           <td colspan="3">

               &nbsp;</td>
            <td>

        <script type="text/javascript">
          function OnStartTrack(sender, args) {
           var mediaplayer = $find("<%=SearchPlayer.ClientID %>");
              mediaplayer.stop();
          }
        </script>
                <asp:Label ID="lbleng" runat="server" Font-Size="16pt" ForeColor="Red"></asp:Label>
                <asp:Label ID="lblmustentertrack" runat="server" Font-Size="16pt" ForeColor="Red" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
           <td colspan="3" style="text-align: center">

               <asp:Label ID="lblheard" runat="server" Font-Names="B Mitra" Font-Size="Large" Text="آیا این موزیک را شنیده اید؟"></asp:Label>
            </td>
            <td style="text-align: center">

                    <telerik:RadButton ID="btnheard" runat="server" Font-Names="B Mitra" Font-Size="Medium" OnClick="btnheard_Click" Text="بله" Width="41px">
                    </telerik:RadButton>

                   

            </td>
        </tr>
        <tr>
           <td colspan="3">

               &nbsp;</td>
            <td>
               
                &nbsp;</td>
        </tr>
        <tr>
           <td style="text-align: center">


&nbsp;


               <asp:Label ID="lblrate" runat="server" Font-Names="B Mitra" Font-Size="Large" Text="میزان علاقمندی"></asp:Label>


               </td>
           <td style="text-align: center" class="auto-style4">
               
               <telerik:RadRating Skin="Sunset" ID="rate" Runat="server" ItemCount="3" style="text-align: center" EnableEmbeddedSkins="False">
               </telerik:RadRating>

               <telerik:RadButton ID="btnrate" runat="server" Font-Names="B Mitra" Font-Size="Large" style="top: 0px; left: 0px;" Text="ثبت نظر" OnClick="btnrate_Click">
               </telerik:RadButton>

               </td>
           <td style="text-align: center">


               &nbsp;</td>
            <td style="text-align: center">

                    <asp:Button ID="btnRecs" runat="server" Font-Names="B Mitra" Font-Size="Large" OnClick="btnRecs_Click" Text="پیشنهادات" CssClass="btn" />

            </td>
        </tr>
        <tr>
           <td colspan="3">

               &nbsp;</td>
            <td>

                &nbsp;</td>
        </tr>

    </table>


            </td>

            <td style="width: 33%">
                &nbsp;</td>
        
        </tr>
          
           <tr style="height: 33%">
            <td style="width: 33%">
                &nbsp;</td>
            <td style="width: 34%; text-align: center;">

                &nbsp;</td>
            <td style="width: 33%">

                    &nbsp;</td>
           </tr>

    </table>
   
   
 </asp:Panel>
 
    
    </form>
    
</body>
</html>
