<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Preferences.aspx.cs" Inherits="SOEN341_nobean.Preferences" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
    <link rel="stylesheet" href="master.css" type="text/css" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Preferences</h2>
    <asp:Button runat="server" Text="Edit" OnClick="editPreferences" />
<div id="allprefs">
    <h3>General Electives</h3>
    <div>
        <asp:CheckBoxList runat="server" ID="ChkLstGeneral"></asp:CheckBoxList>
        <asp:Table runat="server" ID="TableGeneral"></asp:Table>
    </div>    
    <h3>Technical Electives</h3>
    <div>
        <asp:CheckBoxList runat="server" ID="ChkLstTechnical"></asp:CheckBoxList>
    </div>
    <h3>Basic Science Electives</h3>    
    <div>
        <asp:CheckBoxList runat="server" ID="ChkLstScience"></asp:CheckBoxList>
        <asp:Table runat="server" ID="TableScience"></asp:Table>
    </div>

</div>

    <br /><br />Test Label:<br />
    <asp:Label runat="server" ID="testLabel"></asp:Label>
    
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#allprefs").accordion({
                active: false,
                collapsible: true,
                heightStyle: "content"
            });
        });
    </script>
</asp:Content>
