<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="Web.ASCX.Menu" %>
<asp:Menu ID="Menu1" DataSourceID="xmlDataSource" runat="server"
    Font-Names="Arial" ForeColor="#990000" StaticDisplayLevels="1" Orientation="Horizontal"
    Height="25px" Width="96%" EnableViewState="False" MaximumDynamicDisplayLevels="4">
    <DynamicMenuItemStyle BorderStyle="Solid" BorderWidth="1px" Height="20px" HorizontalPadding="3px"
        VerticalPadding="2px" />
    <DataBindings>
        <asp:MenuItemBinding DataMember="MenuItem" NavigateUrlField="NavigateUrl" TextField="Text"
            ToolTipField="ToolTip" />
    </DataBindings>
    <StaticSelectedStyle BackColor="#FFFFCC" HorizontalPadding="3px" VerticalPadding="2px" />
    <DynamicMenuStyle HorizontalPadding="1px" VerticalPadding="2px" CssClass="adjustedZIndex" />
    <DynamicSelectedStyle BackColor="#FFCC66" HorizontalPadding="3px" VerticalPadding="2px" />
    <StaticMenuItemStyle HorizontalPadding="3px" VerticalPadding="2px" />
    <DynamicHoverStyle ForeColor="Black" />
    <StaticHoverStyle ForeColor="Black" />
</asp:Menu>
<asp:XmlDataSource ID="xmlDataSource" TransformFile="~/TransformXSLT.xsl" XPath="MenuItems/MenuItem"
    runat="server" EnableCaching="False" />
