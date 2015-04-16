<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/masterPage.master" EnableViewState="true" EnableViewStateMAC="true" ViewStateEncryptionMode="Always" CodeBehind="adminHome.aspx.cs" Inherits="SOEN341_nobean.adminHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head"  runat="server">
        <link rel="stylesheet" href="/css/master.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center;"><h2>Student administration</h2>
            <p style="margin-top:30px">Enter a valid 8-digits Concordia Student ID in the textbox below and click Search. To log in as a new student, you will have to come back to administrator home.</p>
        <p style="font-style:italic">Please note that you do not have the rights to log in as an administrator.</p>
        <p>With great power comes great responsability</p>
        <p>Speak friend and enter</p>
    </div>
    <div style="text-align:center;">
        <asp:TextBox Width="60px" runat="server" ID="studentIDTextBox"></asp:TextBox>
        <div style="display:inline; margin-left:30px">
        <asp:Button Width="120px" runat="server" ID="SubmitIDButton" Text="Search Student"/>
        </div>
        <p><asp:Label runat="server" ID="error_IDStudent"></asp:Label></p>
        <asp:Checkbox style="display:none" runat="server" ID="CheckboxStudentFound"></asp:Checkbox>
        <asp:Button runat="server" ID="connectStudent" Text="Connect" Visible="false" style="margin:0 auto; display:block"></asp:Button>
    </div>

      <script type="text/javascript">
               $(function () {
                   var stickyRibbonTop = $('[id$=navigation]').offset().top;

                   $(window).scroll(function () {
                       if ($(window).scrollTop() > stickyRibbonTop) {
                           $('[id$=navigation]').css({ position: 'fixed', top: '0px' });
                       } else {
                           $('[id$=navigation]').css({ position: 'static', top: '0px' });
                       }
                   });
               });
                       </script>
</asp:Content>