<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/masterPage.master" CodeBehind="adminHome.aspx.cs" Inherits="SOEN341_nobean.adminHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head"  runat="server">
    <link rel="stylesheet" href="master.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center;"><h2>Search for a student ID</h2>
    <h3 style="color:red">Input only 8-digits ID.</h3>
    </div>
    <div style="text-align:center;">
        <asp:TextBox Width="60px" runat="server" ID="studentIDTextBox"></asp:TextBox>
        <div style="display:inline; margin-left:30px">
        <asp:Button Width="120px" runat="server" ID="SubmitIDButton" Text="Search Student"/>
        </div>
        <p><asp:Label runat="server" ID="error_IDStudent"></asp:Label></p>
        <asp:HiddenField runat="server" ID="hiddenStudentID" />
        <asp:Label runat="server" ID="LabelStudentFound"></asp:Label>
        <asp:Button runat="server" ID="connectStudent" Text="Connect" Visible="false"></asp:Button>
    </div>
</asp:Content>