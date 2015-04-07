<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Record.aspx.cs" Inherits="SOEN341_nobean.Record" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="master.css" type="text/css" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="Record">
        <asp:Table runat="server" id="recordTable" GridLines="both" HorizontalAlign="Center">
        </asp:Table>
    </div>
    <div id="CoursesToBeTaken">
        <h3>Remaining Courses</h3>
        <div>
            <asp:Table runat="server" id="rCoursesTable" GridLines="both" HorizontalAlign="Center">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Class</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Credits</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </div>




    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#CoursesToBeTaken").accordion({
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
