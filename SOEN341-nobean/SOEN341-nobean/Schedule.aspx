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
    <div id="sliderID" class="semesterSlider" data-slick='{"infinite": false, "slidesToShow": 1, "slidesToScroll": 1}' style="width:70%; margin:0 auto" runat="server">
   
    </div>

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
