<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="True"
    CodeBehind="Event.aspx.cs" Inherits="Web.Admin.Event" ValidateRequest="false" %>

<%@ Register Src="../ASCX/Takvim.ascx" TagName="Takvim" TagPrefix="uc1" %>
<%@ Register Src="../ASCX/Aciklama.ascx" TagName="Aciklama" TagPrefix="uc2" %>
<%@ Register Src="../ASCX/File.ascx" TagName="File" TagPrefix="uc10" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ctphTable" runat="server">
    <asp:MultiView ID="mvAktiviteler" runat="server" ActiveViewIndex="0">
        <asp:View ID="vListe" runat="server">
            <table class="belgeHeader">
                <tr>
                    <td class="inputs">
                        <asp:GridView ID="gvListe" runat="server" AutoGenerateColumns="False" DataKeyNames="RECID"
                            OnRowCommand="gvListe_RowCommand" OnRowDataBound="gvListe_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="NAME" HeaderText="Title" />
                                <asp:BoundField DataField="NAMEENG" HeaderText="Title English" />
                                <asp:BoundField DataField="DATE" HeaderText="Date" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table class="belgeHeader" width="100%">
                                            <tr>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibSec" runat="server" CausesValidation="false" CommandName="Sec"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/update.gif" />
                                                </td>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibSil" runat="server" CommandName="Sil" CausesValidation="false"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/delete.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:GridView ID="gvListe2" runat="server" AutoGenerateColumns="False" DataKeyNames="RECID,APPROVED"
                                            OnRowCommand="gvListe2_RowCommand" OnRowDataBound="gvListe2_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="NAME" HeaderText="NAME" />
                                                <asp:BoundField DataField="SURNAME" HeaderText="SURNAME" />
                                                <asp:BoundField DataField="MEMBERSHIPTYPE" HeaderText="MEMBERSHIPTYPE" />
                                                <asp:CheckBoxField DataField="APPROVED" HeaderText="APPROVED" />
                                                <asp:BoundField DataField="APPROVEDDATE" HeaderText="APPROVEDDATE" />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <table class="belgeHeader" width="100%">
                                                            <tr>
                                                                <td class="inputs">
                                                                    <asp:ImageButton ID="ibAttendSec" runat="server" CausesValidation="false" CommandName="Onayla"
                                                                        ToolTip="Accept" CssClass="tip" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>'
                                                                        ImageUrl="~/images/accept.png" />
                                                                </td>
                                                                <td class="inputs">
                                                                    <asp:ImageButton ID="ibRemoveAttend" runat="server" CausesValidation="false" CommandName="OnayKaldir"
                                                                        ToolTip="Remove Accept" CssClass="tip" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>'
                                                                        ImageUrl="~/images/exclamation.png" />
                                                                </td>
                                                                <td class="inputs">
                                                                    <asp:ImageButton ID="ibAttendSil" runat="server" CommandName="AttendSil" CausesValidation="false"
                                                                        ToolTip="Delete" CssClass="tip" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>'
                                                                        ImageUrl="~/images/delete.png" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="inputs">
                        <asp:Button ID="btnYeniKayit" runat="server" CssClass="btnKaydet" OnClick="btnYeniKayit_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vKayitGir" runat="server">
            <table class="belgeHeader" width="100%">
                <tr>
                    <td class="labels">
                        &nbsp;
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="ltValidate" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblName" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="reftxtName" runat="server" ControlToValidate="txtName"
                            ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblNameEng" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtNameEng" runat="server"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="reftxtNameEng" runat="server" ControlToValidate="txtNameEng"
                            ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblLocation" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <uc2:Aciklama ID="txtLocation" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblBody" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <tinymce:TextArea ID="txtBody" Height="500px" theme="advanced" plugins="spellchecker,safari,pagebreak,style,layer,table,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template"
                            theme_advanced_buttons1="spellchecker,save,newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,styleselect,formatselect,fontselect,fontsizeselect"
                            theme_advanced_buttons2="cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor"
                            theme_advanced_buttons3="tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen"
                            theme_advanced_buttons4="insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,pagebreak"
                            theme_advanced_toolbar_location="top" theme_advanced_toolbar_align="left" theme_advanced_path_location="bottom"
                            theme_advanced_resizing="true" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="ltBodyEng" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <tinymce:TextArea ID="txtBodyEng" Height="500px" theme="advanced" plugins="spellchecker,safari,pagebreak,style,layer,table,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template"
                            theme_advanced_buttons1="spellchecker,save,newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,styleselect,formatselect,fontselect,fontsizeselect"
                            theme_advanced_buttons2="cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor"
                            theme_advanced_buttons3="tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen"
                            theme_advanced_buttons4="insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,pagebreak"
                            theme_advanced_toolbar_location="top" theme_advanced_toolbar_align="left" theme_advanced_path_location="bottom"
                            theme_advanced_resizing="true" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblDate" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                        <AjaxControlToolkit:MaskedEditExtender ID="txtDate_MaskedEditExtender" runat="server"
                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                            CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                            CultureTimePlaceholder="" DisplayMoney="Right" Enabled="True" Mask="99/99/9999 99:99:99"
                            MaskType="DateTime" TargetControlID="txtDate">
                        </AjaxControlToolkit:MaskedEditExtender>
                        <AjaxControlToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server"
                            ControlExtender="txtDate_MaskedEditExtender" ControlToValidate="txtDate" EmptyValueMessage="*"
                            InvalidValueMessage="*" IsValidEmpty="False" MinimumValue="01.01.2008 00:00:00"
                            MinimumValueMessage="*"></AjaxControlToolkit:MaskedEditValidator>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblEventType" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:DropDownList ID="drpEventType" runat="server">
                        </asp:DropDownList>
                        &nbsp;<asp:CompareValidator ID="cvdrpEventType" runat="server" ControlToValidate="drpEventType"
                            ErrorMessage="*" Operator="GreaterThan" SetFocusOnError="True" Type="Integer"
                            ValueToCompare="0"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="inputs">
                        <uc10:File runat="server" ID="File1" FileType="USED_ON_EVENT" TableName="EVENT" Visible="false" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;
                    </td>
                    <td class="inputs">
                        <asp:Button ID="btnKaydet" runat="server" CssClass="btnKritik" OnClick="btnKaydet_Click" />
                        &nbsp;<asp:Button ID="btnVazgec" runat="server" CssClass="btn" CausesValidation="False"
                            OnClick="btnVazgec_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
