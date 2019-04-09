<%@ Page Title="" Language="C#" MasterPageFile="~/UI/MasterPage.Master" AutoEventWireup="true" CodeBehind="TestUI.aspx.cs" Inherits="DiagnosticCenterBillManagementApp.UI.TestUI" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">





    <div class="jumbotron">
        <h3 style="text-align: left">Test Setup</h3>

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
                <tr>
                    <td colspan="2">
                        <asp:Label runat="server" ID="messageLabel" Text=""></asp:Label>
                    </td>
                </tr>


            </table>
        </div>



        <div align="center" class="container">
            <asp:GridView ID="testGridView" runat="server" AutoGenerateColumns="False">

                <Columns>
                    <asp:TemplateField HeaderText="Sl#">
                        <ItemTemplate>
                            <%#  Container.DataItemIndex+1 %>
                            <%--                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("Id")%>'></asp:Label>--%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Test Name">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fee">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("Fee")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Type">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("TestTypeName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>


            </asp:GridView>
        </div>







        <div align="right">
            <button type="button" class="btn ">
                <asp:HyperLink ID="HyperLink1" NavigateUrl="~/UI/Default.aspx" runat="server"> Back</asp:HyperLink></button>
        </div>
    </div>
</asp:Content>
