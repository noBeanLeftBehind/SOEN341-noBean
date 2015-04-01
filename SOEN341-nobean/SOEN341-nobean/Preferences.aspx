<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Preferences.aspx.cs" Inherits="SOEN341_nobean.Preferences" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="master.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>Preferences</header>

    <asp:Table runat="server" ID="TableCoursesBasicSci"></asp:Table>
    <asp:Label runat="server" ID="testGetPrefDB"></asp:Label>

</asp:Content>
