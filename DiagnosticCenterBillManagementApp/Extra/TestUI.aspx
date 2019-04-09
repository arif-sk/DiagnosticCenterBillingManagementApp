<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestUI.aspx.cs" Inherits="DiagnosticCenterBillManagementApp.UI.TestUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>




            <div class="jumbotron ">
                <h3 style="text-align: left">Test Type Setup</h3>

                <div class="container">


                    <table class="table ">
                        <tr>
                            <td align="right">Test Name</td>
                            <td>
                                <asp:TextBox ID="testNameTextBox" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Fee</td>
                            <td>
                                <asp:TextBox ID="feeTextBox" runat="server"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td align="right">Test Type</td>

                            <td>
                                <asp:DropDownList ID="testTypeDropDownList" runat="server">
                                    
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td></td>
                            <td align="left">
                                <asp:Button ID="testSaveButton" runat="server" Text="Save" OnClick="testSaveButton_Click" /></td>

                        </tr>


                    </table>
                </div>



                <div class="container">
                    <asp:GridView ID="testTypeSetupGridView" runat="server"></asp:GridView>
                </div>




            </div>







            <div align="right">
                <button type="button" class="btn ">
                    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/UI/Default.aspx" runat="server"> Back</asp:HyperLink></button>
            </div>

            <marquee style="color: blueviolet; font-weight: bold;"> Developed By MD Mahfuzur Rahman</marquee>

        </div>
    </form>
</body>
</html>
