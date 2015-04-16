<%@ Page Title="" Language="C#" MasterPageFile="~/NoNav.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SOEN341_nobean.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="/css/master.css" type="text/css" />
    <link rel="stylesheet" href="/css/login.css" type="text/css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <script src="js/login.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="loginDiv">
        <span id="loginheader" >Login</span>
        <br />
        <!--<asp:Label ID="Label1" runat="server" Text="Net Name"></asp:Label>-->
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" MaxLength="50" placeholder="Username" CssClass="username" ></asp:TextBox>
        <br />
        <!--<asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>-->
        <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged" TextMode="Password" MaxLength="50" placeholder="Password" CssClass="password"></asp:TextBox>
        <br />
        <a id="forgotpass" href="http://deedtheinky.com/wp-content/uploads/2010/01/2004-06-28-toobadsosad1.jpg">Forgot password?</a>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" CssClass="loginbtn"/>
        <br />
        <asp:HyperLink runat="server" Text="Register" NavigateUrl="~/Regist.aspx" CssClass="register"></asp:HyperLink>
    </div>
    <asp:TextBox ID="TextBox3" runat="server" Height="133px" TextMode="MultiLine"></asp:TextBox>
    <script>
        function forgotpass() {
            alert("Too Bad! :(");
        }
    </script>
</asp:Content>
