<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="SOEN341_nobean.Schedule" %>
<%@ Register assembly="DayPilot" namespace="DayPilot.Web.Ui" tagprefix="DayPilot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--MasterPage css-->
    <link rel="stylesheet" href="master.css" type="text/css" />
    <!--Slick slider with buttons css-->
    <link rel="stylesheet" type="text/css" href="//cdn.jsdelivr.net/jquery.slick/1.4.1/slick.css"/>
    <!--Slick slider default css-->
    <link rel="stylesheet" type="text/css" href="//cdn.jsdelivr.net/jquery.slick/1.4.1/slick-theme.css"/>
    <!--Modify default components css-->
    <link rel="stylesheet" href="calendar.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- JQuery -- Could be in the masterpage-->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <!--Script for Caroussel slider-->
    <script type="text/javascript" src="//cdn.jsdelivr.net/jquery.slick/1.4.1/slick.min.js"></script>
    
    <!--Slick slider for semesters-->
    <div class="semesterSlider" data-slick='{"infinite": false, "slidesToShow": 1, "slidesToScroll": 1}' style="width:70%; margin:0 auto">
    <div style="text-align:center;"><p>Fall 2015</p><DayPilot:DayPilotCalendar ID="DayPilotCalendar1" runat="server" TimeHeaderCellDuration="15" ColumnWidthSpec="fixed" ColumnWidth="100" ViewType="WorkWeek" OnBeforeEventRender="DayPilotMonth1_BeforeEventRender" /></div>
    <div style="text-align:center;"><p>Winter 2016</p><DayPilot:DayPilotCalendar ID="DayPilotCalendar2" runat="server"  ColumnWidthSpec="fixed" ColumnWidth="100" ViewType="WorkWeek" OnBeforeEventRender="DayPilotMonth1_BeforeEventRender" /></div>
    </div>

    <p>Not the best calendar finally.. Course don't overlap, they fit exact hours in the table, but the blue line on the left is the duration of the event.. 
        <br />
       I was trying to display school hours like from 8-22, but seems that it comes also with the Pro version too.. At least we have something..
    </p>
    
    <script type="text/javascript">
    $(document).ready(function(){
      $('.semesterSlider').slick({
      });
      $('.semesterSlider table tr').each(function () {

          var hide = true;
          $('td', this).each(function () {

              if ($(this).html() != '')
                  hide = false;

          });

          if (hide)
              $(this).hide();

      });
    });
  </script>

</asp:Content>
