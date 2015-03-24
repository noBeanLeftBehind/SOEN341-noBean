<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SOEN341_nobean.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <p style="margin-left: 300px">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="netName:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        </p>
        <div style="margin-left: 300px">
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Password:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <p>
            &nbsp;</p>
        <div style="margin-left: 450px">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="LogIn" />
        </div>
        <br />
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server" BorderStyle="Groove" Font-Size="Large" ForeColor="Red" Height="173px" OnTextChanged="TextBox3_TextChanged" ReadOnly="True" style="margin-left: 0px; margin-right: 2px" TextMode="MultiLine" Width="374px"></asp:TextBox>
    </form>
</body>
</html>
