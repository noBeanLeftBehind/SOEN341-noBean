<%@ Page Title="" Language="C#" MasterPageFile="~/NoNav.Master" AutoEventWireup="true" CodeBehind="Regist.aspx.cs" Inherits="SOEN341_nobean.Regist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <link rel="stylesheet" href="/css/master.css" type="text/css" />
        <link rel="stylesheet" href="/css/Regist.css" type="text/css" />
         <script  src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
         <script src="js/registration.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="registDiv">
        <span id="registheader" >Registration</span>
        <br />
        
        <asp:TextBox ID="TextBoxFN" runat="server" OnTextChanged="TextBoxFN_TextChanged" MaxLength="50" placeholder="First Name" CssClass="textboxCss"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBoxFN" ErrorMessage="First Name is required" ForeColor="Red" CssClass="errormsg" ></asp:RequiredFieldValidator>
        <br />

        <!--<asp:Label ID="Label2" runat="server" Text="Last Name :"></asp:Label>-->
        <asp:TextBox ID="TextBoxLN" runat="server" MaxLength="50" placeholder="Last Name" CssClass="textboxCss"></asp:TextBox>    
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBoxLN" ErrorMessage="Last Name is required" ForeColor="Red" CssClass="errormsg" ></asp:RequiredFieldValidator>
        <br />

        <!--<asp:Label ID="Label7" runat="server" Text="School ID :"></asp:Label>-->
        <asp:TextBox ID="TextBoxSchoolID" runat="server" MaxLength="8" placeholder="Student ID" CssClass="textboxCss"></asp:TextBox>              
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TextBoxSchoolID" ErrorMessage="Student ID is required" ForeColor="Red" CssClass="errormsg" ></asp:RequiredFieldValidator>
        <br />

        <!--<asp:Label ID="Label6" runat="server" Text="Email :"></asp:Label>-->
        <asp:TextBox ID="TextBoxEmail" runat="server" MaxLength="50" placeholder="Email" CssClass="textboxCss"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Email is required" ForeColor="Red" ControlToValidate="TextBoxEmail" CssClass="errormsg" ></asp:RequiredFieldValidator>
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Enter a valid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="errormsg" ></asp:RegularExpressionValidator>
        <br />

        <!--<asp:Label ID="Label5" runat="server" Text="Netname :"></asp:Label>-->
        <asp:TextBox ID="TextBoxNetN" runat="server" MaxLength="50" placeholder="Username" CssClass="textboxCss"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBoxNetN" ErrorMessage="Username is required" ForeColor="Red" CssClass="errormsg" ></asp:RequiredFieldValidator>
        <br />

        <!--<asp:Label ID="Label3" runat="server" Text="Password :"></asp:Label>-->
        <asp:TextBox ID="TextBoxPWD" runat="server" MaxLength="50" placeholder="Password" CssClass="textboxCss"></asp:TextBox>      
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBoxPWD" ErrorMessage="Password is required &nbsp&nbsp<img id='passwordTooltip' src='getInfo.png' title=''>" ForeColor="Red" CssClass="errormsg" ></asp:RequiredFieldValidator>
        <br />

        <!--<asp:Label ID="Label4" runat="server" Text="Confirm Password :"></asp:Label>-->
        <asp:TextBox ID="TextBoxCPWD" runat="server" MaxLength="50" placeholder="Confirm Password" CssClass="textboxCss"></asp:TextBox>           
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBoxCPWD" ErrorMessage="Password confirmation is required" ForeColor="Red" CssClass="errormsg" ></asp:RequiredFieldValidator>
        <br />
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxPWD" ControlToValidate="TextBoxCPWD" ErrorMessage="Passwords do not match" ForeColor="Red" CssClass="errormsg" ></asp:CompareValidator>
        <br />

        <div id="radioDiv">
            <asp:Label ID="Label8" runat="server" Text="Admin :" CssClass="radiotitle"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="radiobtn" TextAlign="Right">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0" Selected="true">No</asp:ListItem>
            </asp:RadioButtonList>                 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="RadioButtonList1" ErrorMessage="select one" CssClass="errormsg"></asp:RequiredFieldValidator>
            <br />
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" CssClass="submitbtn"/>
        <br />
        <input id="Reset1" type="reset" value="reset" class="reset"/>
    </div>
    <a id="back" href="login.aspx">◀◀ Back to Login Page</a>
    <script>
        $(function () {
        $(document).tooltip({
            content: '<img style="margin-left:40%;" src="http://meatballcandy.com/wp-content/uploads/2013/02/sorry-your-password-must-contain.jpg" />'
        });
        });
    </script>
</asp:Content>
