<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="SOEN341_nobean.Schedule" %>
<%@ Register assembly="DayPilot" namespace="DayPilot.Web.Ui" tagprefix="DayPilot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="master.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>Current schedule</p>
    <!--<asp:Table runat="server" ID="winter2016Schedule">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>
            Monday
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>
            Tuesday
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>
            Wednesday
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>
            Thursday
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>
            Friday
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>-->
    <DayPilot:DayPilotCalendar ID="DayPilotCalendar1" runat="server" />
    <br />

</asp:Content>
