<%@ Page Title="" Language="C#" MasterPageFile="~/UI/MasterPage.Master" AutoEventWireup="true" CodeBehind="PaymentUI.aspx.cs" Inherits="DiagnosticCenterBillManagementApp.UI.PaymentUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    




    <div class="jumbotron ">
        <h3 style="text-align: left">Payment</h3>

        <div class="container">


            <table class="table ">
                <tr>
                    <td colspan="2">
                        <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">Bill Number</td>
                    <td>
                        <asp:TextBox ID="billNumberTextBox" runat="server"></asp:TextBox>
                        Or
                    </td>
                </tr>

                <tr>
                    <td align="right">Mobile Number</td>
                    <td>
                        <asp:TextBox ID="mobileNumberTextBox" runat="server"></asp:TextBox>
                        <asp:Button ID="billOrMobileNumberSearchButton" runat="server" Text="Search" OnClick="billOrMobileNumberSearchButton_Click" />
                    </td>
                </tr>

                <tr>
                    <td align="right">Amount</td>
                    <td>
                        <asp:TextBox ID="amountTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td align="right">Due Date</td>
                    <td>
                        <asp:TextBox ID="dueDateTextBox" runat="server"></asp:TextBox>
                        <asp:Button ID="payButton" runat="server" Text="Pay" OnClick="payButton_Click" /></td>
                    
                </tr>
                
                <tr>
                    <td>
                        <asp:HiddenField ID="paymentHiddenField" runat="server" />
                    </td>
                </tr>

            </table>

        </div>





        <div align="right">
            <button type="button" class="btn ">
                <asp:HyperLink ID="HyperLink1" NavigateUrl="~/UI/Default.aspx" runat="server"> Back</asp:HyperLink></button>
        </div>
</asp:Content>
