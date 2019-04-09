<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DiagnosticCenterBillManagementApp.UI.Default" %>

    <form id="form1" runat="server">
        <div>

            <nav class="navbar navbar-default">
                <div class="container-fluid">
                    <div class="navbar-header">
                         <asp:HyperLink ID="HyperLink6" NavigateUrl="~/UI/Default.aspx" runat="server"> <h3>Home</h3></asp:HyperLink></li>
                    </div>

                </div>
            </nav>

            <div class="jumbotron">
                <h1 style="text-align: center">Diagnostic Center Bill Management System</h1>
            </div>
        </div>



        <nav class="navbar navbar-default">
            <div class="container-fluid">
                <div class="navbar-header">

                    <ul class="nav navbar-nav">

                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Setup <span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li>
                                    <asp:HyperLink ID="lnk1" NavigateUrl="~/UI/TestTypeUI.aspx" runat="server">Test Type</asp:HyperLink></li>
                                <li>
                                    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/UI/TestUI.aspx" runat="server">Test </asp:HyperLink></li>
                            </ul>
                        </li>


                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Test Request<span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li>
                                    <asp:HyperLink ID="HyperLink4" NavigateUrl="~/UI/TestRequestEntryUI.aspx" runat="server">Entry</asp:HyperLink></li>
                                <li>
                                    <asp:HyperLink ID="HyperLink5" NavigateUrl="~/UI/PaymentUI.aspx" runat="server">Payment </asp:HyperLink></li>
                            </ul>
                        </li>


                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Report <span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li>
                                    <asp:HyperLink ID="HyperLink2" NavigateUrl="~/UI/TestWiseReportUI.aspx" runat="server">Test Wise</asp:HyperLink></li>
                                <li>
                                    <asp:HyperLink ID="HyperLink3" NavigateUrl="~/UI/TypeWiseUI.aspx" runat="server">Type Wise </asp:HyperLink></li>
                                <li>
                                    <asp:HyperLink ID="HyperLink41" NavigateUrl="~/UI/UnpaidBillReportUI.aspx" runat="server">Unpaid Bill </asp:HyperLink></li>
                            </ul>
                        </li>

                    </ul>
                </div>


            </div>
        </nav>


            <div align="right">
                <button type="button" class="btn " >
                    <asp:HyperLink ID="HyperLink7" NavigateUrl="~/UI/Default.aspx" runat="server"> Back</asp:HyperLink></button>
            </div>




    </form>
</body>
</html>
