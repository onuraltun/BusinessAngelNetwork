<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="True"
    CodeBehind="Page.aspx.cs" Inherits="Web.Admin.Page" ValidateRequest="false" %>

<%@ Register Src="../ASCX/Takvim.ascx" TagName="Takvim" TagPrefix="uc1" %>
<%@ Register Src="../ASCX/Aciklama.ascx" TagName="Aciklama" TagPrefix="uc2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ctphTable" runat="server">
    <asp:MultiView ID="mvSayfalar" runat="server" ActiveViewIndex="0">
        <asp:View ID="vListe" runat="server">
            <table class="belgeHeader">
                <tr>
                    <td class="inputs">
                        <asp:GridView ID="gvListe" runat="server" AutoGenerateColumns="False" DataKeyNames="RECID"
                            OnRowCommand="gvListe_RowCommand" OnRowDataBound="gvListe_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="TITLE" HtmlEncode="false" HeaderText="Title" />
                                <asp:BoundField DataField="TITLEENG" HtmlEncode="false" HeaderText="Title English" />
                                <asp:BoundField DataField="CREATIONDATE" HeaderText="Creation Date" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table class="belgeHeader" width="100%">
                                            <tr>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibSec" runat="server" CausesValidation="false" CommandName="Sec"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/update.gif" />
                                                </td>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibSil" runat="server" Visible="false" CommandName="Sil" CausesValidation="false"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/delete.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="inputs">
                        <asp:Button ID="btnYeniKayit" runat="server" CssClass="btnKaydet"
                            OnClick="btnYeniKayit_Click" />
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
                        <asp:Literal ID="lblTitle" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <tinymce:TextArea Height="500px" ID="txtTitle" theme="advanced" plugins="spellchecker,safari,pagebreak,style,layer,table,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template"
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
                        <asp:Literal ID="lblTitleEng" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <tinymce:TextArea Height="500px" ID="txtTitleEng" theme="advanced" plugins="spellchecker,safari,pagebreak,style,layer,table,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template"
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
                        <asp:Literal ID="lblBody" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <tinymce:TextArea Height="500px" ID="txtBody" theme="advanced" plugins="spellchecker,safari,pagebreak,style,layer,table,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template"
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
                        <asp:Literal ID="lblBodyEng" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <tinymce:TextArea Height="500px" ID="txtBodyEng" theme="advanced" plugins="spellchecker,safari,pagebreak,style,layer,table,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template"
                            theme_advanced_buttons1="spellchecker,save,newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,styleselect,formatselect,fontselect,fontsizeselect"
                            theme_advanced_buttons2="cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor"
                            theme_advanced_buttons3="tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen"
                            theme_advanced_buttons4="insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,pagebreak"
                            theme_advanced_toolbar_location="top" theme_advanced_toolbar_align="left" theme_advanced_path_location="bottom"
                            theme_advanced_resizing="true" runat="server" />
                    </td>
                </tr>
                <tr visible="false">
                    <td class="labels">
                        <asp:Literal ID="lblPageType" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:DropDownList ID="drpPageType" runat="server">
                        </asp:DropDownList>
                        &nbsp;<asp:CompareValidator ID="cvdrpPageType" runat="server" ControlToValidate="drpPageType"
                            ErrorMessage="*" Operator="GreaterThan" SetFocusOnError="True" Type="Integer"
                            ValueToCompare="0"></asp:CompareValidator>
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
