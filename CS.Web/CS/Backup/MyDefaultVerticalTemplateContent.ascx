<%@ Control Language="C#" CodeBehind="MyDefaultVerticalTemplateContent.ascx.cs" ClassName="MyDefaultVerticalTemplateContent" Inherits="MyDefaultVerticalTemplateContent"%>
<%@ Register Assembly="DevExpress.Web.v15.2" Namespace="DevExpress.Web"
    TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.ExpressApp.Web.v15.2" Namespace="DevExpress.ExpressApp.Web.Templates.ActionContainers"
    TagPrefix="cc2" %>
<%@ Register Assembly="DevExpress.ExpressApp.Web.v15.2" Namespace="DevExpress.ExpressApp.Web.Templates"
    TagPrefix="cc3" %>
<%@ Register Assembly="DevExpress.ExpressApp.Web.v15.2" Namespace="DevExpress.ExpressApp.Web.Controls"
    TagPrefix="cc4" %>
<%@ Register Assembly="DevExpress.ExpressApp.Web.v15.2" Namespace="DevExpress.ExpressApp.Web.Templates.Controls"
    TagPrefix="tc" %>
<div class="VerticalTemplate BodyBackColor">
    <dx:ASPxGlobalEvents ID="GE" ClientInstanceName="GE" ClientSideEvents-EndCallback="AdjustSize"
        runat="server" />
   <table id="MT" border="0" width="100%" cellpadding="0" cellspacing="0" class="dxsplControl_<%=BaseXafPage.CurrentTheme%>">
            <tbody>
                <tr>
                    <td style="vertical-align: top; height: 10px;" class="dxsplPane_<%=BaseXafPage.CurrentTheme%>">
                        <div id="VerticalTemplateHeader" class="VerticalTemplateHeader">
                            <table cellpadding="0" cellspacing="0" border="0" class="Top" width="100%">
                                <tr>
                                    <td class="Logo">
                                        <asp:HyperLink runat="server" NavigateUrl="#" ID="LogoLink">
                                            <cc4:ThemedImageControl ID="TIC" DefaultThemeImageLocation="~/Images/" ImageName="AdressenManagement.Web.Images.MainLogo.png"
                                                BorderWidth="0px" runat="server" />
                                        </asp:HyperLink>
                                    </td>
                                    <td class="Security">
                                        <cc3:XafUpdatePanel ID="UPSAC" runat="server">
                                        <cc2:ActionContainerHolder runat="server" ID="SAC" CssClass="Security" Categories="Security"
                                            ContainerStyle="Links" ShowSeparators="True" />
                                        </cc3:XafUpdatePanel>
                                    </td>
                                </tr>
                            </table>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" class="ACPanel"  style="float:left">
                                <tr class="Content" style="text-align:left; margin-left:30px; float:left" >
                                    <td class="Content WithPaddings" style="float:left ">
                                        <cc3:XafUpdatePanel ID="UPSHC" runat="server" HorizontalAlign="Left" >
                                            <cc2:ActionContainerHolder ID="SHC" runat="server" Categories="FullTextSearch;RootObjectsCreation;Appearance;Search"
                                            ContainerStyle="Links" CssClass="TabsContainer"  HorizontalAlign="Left"  />
                                        </cc3:XafUpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top">
                        <table id="MRC" style="width: 100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td id="LPcell" style="width: 220px; vertical-align: top">
                                    <div id="LP" class="LeftPane">
                                        <cc3:XafUpdatePanel ID="UPNC" runat="server">
                                        <cc2:NavigationActionContainer ID="NC" runat="server" CssClass="xafNavigationBarActionContainer"
                                            ContainerId="ViewsNavigation" AutoCollapse="True" Width="200px" />
                                        </cc3:XafUpdatePanel>
                                        <cc3:XafUpdatePanel ID="UPTP" runat="server">
                                            <div id="TP" runat="server" class="ToolsActionContainerPanel">
                                            <dx:ASPxRoundPanel ID="TRP" runat="server" HeaderText="Tools" CssClass="TRP">
                                                <PanelCollection>
                                                    <dx:PanelContent ID="PanelContent1" runat="server">
                                                        <cc2:ActionContainerHolder ID="VTC" runat="server" Menu-Width="100%" Categories="Tools"
                                                            Orientation="Vertical" ContainerStyle="Links" ShowSeparators="False" />
                                                    </dx:PanelContent>
                                                </PanelCollection>
                                            </dx:ASPxRoundPanel>
                                            <cc2:ActionContainerHolder ID="DAC" runat="server" Orientation="Vertical" Categories="Diagnostic"
                                                BorderWidth="0px" ContainerStyle="Links" ShowSeparators="False" />
                                            <br />
                                        </div>
                                        </cc3:XafUpdatePanel>
                                    </div>
                                </td>
                                <td id="separatorCell" style="width: 10px; height:100%; border-bottom-style: none; border-top-style: none"
                                    class="dxsplVSeparator_<%=BaseXafPage.CurrentTheme%> dxsplPane_<%=BaseXafPage.CurrentTheme%>">
                                     <div id="separatorButton0" style="width: 10px; height:55px;" class="dxsplVSeparatorButton_<%=BaseXafPage.CurrentTheme%>" onmouseover="OnMouseEnter('separatorButton0')"
                                        onmouseout="OnMouseLeave('separatorButton0')" onclick="OnClick('LPcell','separatorImage',true)">
                                        <div id="separatorImage20" style="width: 10px;">
                                            <img src="Images/openclose.png" style="margin-top:22.5px">
                                        </div>
                                        <div id="separatorImage0" style="visibility:hidden"></div>
                                    </div>
                                    <div id="separatorButton30" style="width: 10px; height:55px;" class="dxsplVSeparatorButton_<%=BaseXafPage.CurrentTheme%>" onmouseover="OnMouseEnter('separatorButton30')"
                                        onmouseout="OnMouseLeave('separatorButton30')" onclick="OnClick('LPcell','separatorImage',true)">
                                        <div id="separatorImage230" style="width: 10px;">
                                            <img src="Images/openclose.png" style="margin-top:22.5px; visibility:hidden">
                                        </div>
                                        <div id="separatorImage30" style="visibility:hidden"></div>
                                    </div>
                                     <div id="separatorButton30a" style="width: 10px; height:55px;" class="dxsplVSeparatorButton_<%=BaseXafPage.CurrentTheme%>" onmouseover="OnMouseEnter('separatorButton30a')"
                                        onmouseout="OnMouseLeave('separatorButton30a')" onclick="OnClick('LPcell','separatorImage',true)">
                                        <div id="separatorImage230a" style="width: 10px;">
                                            <img src="Images/openclose.png" style="margin-top:22.5px; visibility:hidden">
                                        </div>
                                        <div id="separatorImage30a" style="visibility:hidden"></div>
                                    </div>
                                    <div id="separatorButton" style="width: 10px; height:55px;" class="dxsplVSeparatorButton_<%=BaseXafPage.CurrentTheme%>" onmouseover="OnMouseEnter('separatorButton')"
                                        onmouseout="OnMouseLeave('separatorButton')" onclick="OnClick('LPcell','separatorImage',true)">
                                        <div id="separatorImage2" style="width: 10px;">
                                            <img src="Images/openclose.png" style="margin-top:22.5px; visibility:hidden">
                                        </div>
                                        <div id="separatorImage" style="visibility:hidden"></div>
                                    </div>
                                    <div id="separatorButton3" style="width: 10px; height:55px;" class="dxsplVSeparatorButton_<%=BaseXafPage.CurrentTheme%>" onmouseover="OnMouseEnter('separatorButton3')"
                                        onmouseout="OnMouseLeave('separatorButton3')" onclick="OnClick('LPcell','separatorImage',true)">
                                        <div id="separatorImage23" style="width: 10px;">
                                            <img src="Images/openclose.png" style="margin-top:22.5px; visibility:hidden">
                                        </div>
                                        <div id="separatorImage3" style="visibility:hidden"></div>
                                    </div>
                                    <div id="separatorButton34" style="width: 10px; height:55px;" class="dxsplVSeparatorButton_<%=BaseXafPage.CurrentTheme%>" onmouseover="OnMouseEnter('separatorButton34')"
                                        onmouseout="OnMouseLeave('separatorButton34')" onclick="OnClick('LPcell','separatorImage',true)">
                                        <div id="separatorImage234" style="width: 10px;">
                                            <img src="Images/openclose.png" style="margin-top:22.5px">
                                        </div>
                                        <div id="separatorImage34" style="visibility:hidden"></div>
                                    </div>
                                     <div id="separatorButtonx" style="width: 10px; height:55px;" class="dxsplVSeparatorButton_<%=BaseXafPage.CurrentTheme%>" onmouseover="OnMouseEnter('separatorButtonx')"
                                        onmouseout="OnMouseLeave('separatorButtonx')" onclick="OnClick('LPcell','separatorImage',true)">
                                        <div id="separatorImage2x" style="width: 10px;">
                                            <img src="Images/openclose.png" style="margin-top:22.5px; visibility:hidden">
                                        </div>
                                        <div id="separatorImagex" style="visibility:hidden"></div>
                                    </div>
                                     <div id="separatorButtonxy" style="width: 10px; height:55px;" class="dxsplVSeparatorButton_<%=BaseXafPage.CurrentTheme%>" onmouseover="OnMouseEnter('separatorButtonxy')"
                                        onmouseout="OnMouseLeave('separatorButtonxy')" onclick="OnClick('LPcell','separatorImage',true)">
                                        <div id="separatorImage2xy" style="width: 10px;">
                                            <img src="Images/openclose.png" style="margin-top:22.5px; visibility:hidden">
                                        </div>
                                        <div id="separatorImagexy" style="visibility:hidden"></div>
                                    </div>
                                    <div id="separatorButtonx0" style="width: 10px; height:55px;" class="dxsplVSeparatorButton_<%=BaseXafPage.CurrentTheme%>" onmouseover="OnMouseEnter('separatorButtonx0')"
                                        onmouseout="OnMouseLeave('separatorButtonx0')" onclick="OnClick('LPcell','separatorImage',true)">
                                        <div id="separatorImage2x0" style="width: 10px;">
                                            <img src="Images/openclose.png" style="margin-top:22.5px; visibility:hidden">
                                        </div>
                                        <div id="separatorImagex0" style="visibility:hidden"></div>
                                    </div>
                                     <div id="separatorButtonx0a" style="width: 10px; height:55px;" class="dxsplVSeparatorButton_<%=BaseXafPage.CurrentTheme%>" onmouseover="OnMouseEnter('separatorButtonx0a')"
                                        onmouseout="OnMouseLeave('separatorButtonx0a')" onclick="OnClick('LPcell','separatorImage',true)">
                                        <div id="separatorImage2x0a" style="width: 10px;">
                                            <img src="Images/openclose.png" style="margin-top:22.5px; visibility:hidden">
                                        </div>
                                        <div id="separatorImagex0a" style="visibility:hidden"></div>
                                    </div>
                                     <div id="separatorButtonxy0" style="width: 10px; height:55px;" class="dxsplVSeparatorButton_<%=BaseXafPage.CurrentTheme%>" onmouseover="OnMouseEnter('separatorButtonxy0')"
                                        onmouseout="OnMouseLeave('separatorButtonxy0')" onclick="OnClick('LPcell','separatorImage',true)">
                                        <div id="separatorImage2xy0" style="width: 10px;">
                                            <img src="Images/openclose.png" style="margin-top:22.5px">
                                        </div>
                                        <div id="separatorImagexy0" style="visibility:hidden"></div>
                                    </div>
                                </td>

                                <td style="vertical-align: top;">
                                    <table style="width: 100%;" cellpadding="0" cellspacing="0">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <cc3:XafUpdatePanel ID="UPTB" runat="server">
                                                    <cc2:ActionContainerHolder CssClass="ACH MainToolbar" runat="server" ID="TB" ContainerStyle="ToolBar"
                                                        Orientation="Horizontal" Categories="ObjectsCreation;Edit;RecordEdit;View;Export;Reports;Filters">
                                                        <Menu Width="100%" ItemAutoWidth="False" ClientInstanceName="mainMenu">
                                                            <BorderTop BorderStyle="None" />
                                                            <BorderLeft BorderStyle="None" />
                                                            <BorderRight BorderStyle="None" />
                                                        </Menu>
                                                    </cc2:ActionContainerHolder>
                                                    </cc3:XafUpdatePanel>
                                                    <cc3:XafUpdatePanel ID="UPVH" runat="server">
                                                        <table id="VH" border="0" cellpadding="0" cellspacing="0" class="MainContent" width="100%">
                                                        <tr>
                                                            <td class="ViewHeader">
                                                                <table cellpadding="0" cellspacing="0" border="0" width="100%" class="ViewHeader">
                                                                    <tr>
                                                                        <td class="ViewImage">
                                                                            <cc4:ViewImageControl ID="VIC" runat="server" />
                                                                        </td>
                                                                        <td class="ViewCaption">
                                                                            <h1>
                                                                                    <cc4:ViewCaptionControl ID="VCC" runat="server" />
                                                                            </h1>
                                                                            <cc2:NavigationHistoryActionContainer ID="VHC" runat="server" CssClass="NavigationHistoryLinks"
                                                                                ContainerId="ViewsHistoryNavigation" Delimiter=" / "  />
                                                                        </td>
                                                                        <td align="right">
                                                                          <cc2:ActionContainerHolder runat="server" ID="RNC" ContainerStyle="Links" Orientation="Horizontal"
    UseLargeImage="True" CssClass="RecordsNavigationContainer">
    <Menu Width="100%" ItemAutoWidth="False" HorizontalAlign="Right" />
    <ActionContainers>
        <cc2:WebActionContainer ContainerId="RecordsNavigation" IsDropDown="false" />
    </ActionContainers>
</cc2:ActionContainerHolder>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    </cc3:XafUpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <cc3:XafUpdatePanel ID="UPEMA" runat="server">
                                                    <cc2:ActionContainerHolder runat="server" ID="EMA" ContainerStyle="Links" Orientation="Horizontal"
                                                        Categories="Save;UndoRedo" CssClass="EditModeActions">
                                                        <Menu Width="100%" ItemAutoWidth="False" HorizontalAlign="Left" />
                                                    </cc2:ActionContainerHolder>
                                                    </cc3:XafUpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div id="CP" style="overflow: auto; width: 100%;">
                                                        <table border="0" cellpadding="0" cellspacing="0" class="MainContent" width="100%">
                                                         <tr class="Content" style="margin-top:1px">
                                                                <td class="Content" style="margin-top:1px; margin-left:1px;">
                                                                    <cc3:XafUpdatePanel ID="UPEI" runat="server">
                                                                        <tc:ErrorInfoControl ID="ErrorInfo" Style="margin: 10px 0px 10px 0px" runat="server" />
                                                                    </cc3:XafUpdatePanel>
                                                                    <cc3:XafUpdatePanel ID="UPVSC" runat="server">
                                                                    <cc4:ViewSiteControl ID="VSC" runat="server" />
                                                                    <cc2:ActionContainerHolder runat="server" ID="EditModeActions2" ContainerStyle="Links"
                                                                        Orientation="Horizontal" Categories="Save;UndoRedo" CssClass="EditModeActions">
                                                                        <Menu Width="100%" ItemAutoWidth="False" HorizontalAlign="Right" Paddings-PaddingTop="2px" />
                                                                    </cc2:ActionContainerHolder>
                                                                    </cc3:XafUpdatePanel>
                                                                   <%-
-System.Xml.Linq.XElement.Parse("<div id=\"Spacer\" class=\"Spacer\">"+"</div>")--;
%>
                                                                </td>
                                                            </tr>
                                                            <tr class="Content" style="margin-top:1px;">
                                                                <td class="Content Links" align="left" style="text-align: center; margin-top:-15px;">
																	<span style="display: inline-block">
                                                                    <cc3:XafUpdatePanel ID="UPQC" runat="server">
                                                                    <cc2:QuickAccessNavigationActionContainer CssClass="NavigationLinks" ID="QC" runat="server"
                                                                        ContainerId="ViewsNavigation" PaintStyle="Caption" ShowSeparators="True" />
                                                                    </cc3:XafUpdatePanel>
																	</span>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px; vertical-align: bottom" class="BodyBackColor">
                        <cc3:XafUpdatePanel ID="UPIMP" runat="server">
                        <asp:Literal ID="InfoMessagesPanel" runat="server" Text="" Visible="False"></asp:Literal>
                        </cc3:XafUpdatePanel>
                        <div id="Footer" class="Footer">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td align="left">
                                        <div class="FooterCopyright">
                                            <cc4:AboutInfoControl ID="AIC" runat="server">Copyright text</cc4:AboutInfoControl>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>

</div>

