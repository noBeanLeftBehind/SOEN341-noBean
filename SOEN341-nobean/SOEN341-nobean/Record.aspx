<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Record.aspx.cs" Inherits="SOEN341_nobean.Record" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="/css/master.css" type="text/css" />
        <link rel="stylesheet" href="/css/record.css" type="text/css" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Student Record</h2>
    <div id="Record">
        <asp:Table runat="server" id="recordTable" GridLines="both" HorizontalAlign="Center">
        </asp:Table><br/>
    </div>
    <div id="adminRecord" Visible="false" runat="server">
        <br/><br/>
        <h2>Input Course ID to be added/removed.</h2>
        <asp:RadioButtonList ID="adminInstruction" Visible="false" runat="server">
            <asp:ListItem Text="Add course to student passed courses&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" Value="add" Selected="true"/>
            <asp:ListItem Text="Remove course from student passed courses" Value="remove" />
        </asp:RadioButtonList><br/>
        <asp:TextBox Width="60px" runat="server" ID="studentCourse" placeholder="Course ID" Visible="false"></asp:TextBox><br/>
        <asp:Button Width="120px" runat="server" ID="submitCourseButton" Text="Submit" Visible="false" OnClick="editCoursesTaken" />
        <br/>
        <asp:Label runat="server" ID="error_record" Text="Submit" Visible="false"/>
    </div>
    <div id="CoursesPassed">
        <h3>Passed Courses</h3>
        <div>
            <asp:Table runat="server" id="pCoursesTable" GridLines="both" HorizontalAlign="Center">
            </asp:Table>
        </div>
    </div>
    <div id="CoursesToBeTaken">
        <h3>Remaining Core Courses</h3>
        <div>
            <asp:Table runat="server" id="rCoursesTable" GridLines="both" HorizontalAlign="Center">
            </asp:Table>
        </div>
    </div>





    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
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

        $(function () {
            $("#CoursesToBeTaken, #CoursesPassed").accordion({
                active: false,
                collapsible: true,
                heightStyle: "content",
                activate: function (event, ui) {
                    if (!$.isEmptyObject(ui.newHeader.offset())) {
                        $('html:not(:animated), body:not(:animated)').animate({ scrollTop: ui.newHeader.offset().top }, 'medium');
                    }
                }
            });
        });

    </script>
</asp:Content>
