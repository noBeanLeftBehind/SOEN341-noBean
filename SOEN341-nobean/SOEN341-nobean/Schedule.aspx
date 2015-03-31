<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="SOEN341_nobean.Schedule" %>
<%@ Register assembly="DayPilot" namespace="DayPilot.Web.Ui" tagprefix="DayPilot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="master.css" type="text/css" />
    <link rel="stylesheet" type="text/css" href="//cdn.jsdelivr.net/jquery.slick/1.4.1/slick.css"/>
    <link rel="stylesheet" type="text/css" href="//cdn.jsdelivr.net/jquery.slick/1.4.1/slick-theme.css"/>
    <link rel="stylesheet" href="calendar.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <script type="text/javascript" src="//cdn.jsdelivr.net/jquery.slick/1.4.1/slick.min.js"></script>
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
    <div class="semesterSlider" data-slick='{"infinite": false, "slidesToShow": 1, "slidesToScroll": 1}' style="width:70%; margin:0 auto">
    <DayPilot:DayPilotCalendar ID="DayPilotCalendar1" runat="server" ColumnWidthSpec="fixed" ColumnWidth="100" ViewType="WorkWeek" OnBeforeEventRender="DayPilotMonth1_BeforeEventRender" />
    <DayPilot:DayPilotCalendar ID="DayPilotCalendar2" runat="server"  ColumnWidthSpec="fixed" ColumnWidth="100" Width="60%" ViewType="WorkWeek" OnBeforeEventRender="DayPilotMonth1_BeforeEventRender" />
    </div>
    
    <script type="text/javascript">
    $(document).ready(function(){
      $('.semesterSlider').slick({
        setting-name: setting-value
      });
    });
  </script>

</asp:Content>
