<%@ Page Language="C#" MasterPageFile="~/NoNav.Master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="SOEN341_nobean.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <link rel="stylesheet" href="master.css" type="text/css" />
         <script  src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
         <script src="js/registration.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="First Name :"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBoxFN" runat="server" OnTextChanged="TextBoxFN_TextChanged" Width="180px" MaxLength="50"></asp:TextBox>
                
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBoxFN" ErrorMessage="First Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
    <asp:Label ID="Label2" runat="server" Text="Last Name :"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="TextBoxLN" runat="server" Width="180px" MaxLength="50"></asp:TextBox>
                
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBoxLN" ErrorMessage="Last Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
                   <br />
    <asp:Label ID="Label3" runat="server" Text="Password :"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="TextBoxPWD" runat="server" Width="180px" MaxLength="50"></asp:TextBox>
               
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBoxPWD" ErrorMessage="password is required" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
    <asp:Label ID="Label4" runat="server" Text="Confirm Password :"></asp:Label>

                    <asp:TextBox ID="TextBoxCPWD" runat="server" Width="180px" MaxLength="50"></asp:TextBox>
             
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBoxCPWD" ErrorMessage="Confirm Password" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxPWD" ControlToValidate="TextBoxCPWD" ErrorMessage="Both password must be same" ForeColor="Red"></asp:CompareValidator>
                   <br />
     <asp:Label ID="Label5" runat="server" Text="Netname :"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="TextBoxNetN" runat="server" Width="180px" MaxLength="50"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBoxNetN" ErrorMessage="Net Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
                   <br />
    <asp:Label ID="Label6" runat="server" Text="Email :"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="TextBoxEmail" runat="server" Width="180px" MaxLength="50"></asp:TextBox>
               
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Email Id is required" ForeColor="Red" ControlToValidate="TextBoxEmail"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Enter valid email ID" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <br />
    <asp:Label ID="Label7" runat="server" Text="School ID :"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:TextBox ID="TextBoxSchoolID" runat="server" Width="180px" MaxLength="8"></asp:TextBox>
               
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TextBoxSchoolID" ErrorMessage="Schoold Id is required" ForeColor="Red"></asp:RequiredFieldValidator>
                  <br />
     <asp:Label ID="Label8" runat="server" Text="Admin :"></asp:Label>

                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:RadioButtonList>
                 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="RadioButtonList1" ErrorMessage="select one"></asp:RequiredFieldValidator>
                <br />
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" Width="60px" />
                    <input id="Reset1" type="reset" value="reset" />
</asp:Content>

