<%@ Page Title="" Language="C#" MasterPageFile="~/UI/MasterPage.Master" AutoEventWireup="true" CodeBehind="TestTypeUI.aspx.cs" Inherits="DiagnosticCenterBillManagementApp.UI.TestTypeUI" %>

<%@ Import Namespace="System.ComponentModel" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div class="jumbotron ">
        <h3 style="text-align: left;">Test Type Setup</h3>

        <div align="center" class="container">

            <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
            <table>
                <tr>
                    <td align="right">Type Name</td>
                    <td>
                        <asp:TextBox ID="typeNameTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr><br/>


                <tr>
                    <td></td>
                    <td align="left">
                        <asp:Button ID="typeNameSaveButton" runat="server" Text="Save" OnClick="typeNameSaveButton_Click" /></td>

                </tr>


            </table>
        </div><br/><br/>



        <div align="center" class="container">
            <asp:GridView  Width="50%" cellpadding="10"
        cellspacing="5" ID="testTypeSetupGridView" runat="server" AutoGenerateColumns="False">

                <Columns>
                    <asp:TemplateField HeaderText="Sl#">
                        <ItemTemplate>
                            <%#  Container.DataItemIndex+1 %>
                            <%--                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("Id")%>'></asp:Label>--%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>


    </div>





    <div align="right">
        <button type="button" class="btn ">
            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/UI/Default.aspx" runat="server"> Back</asp:HyperLink></button>
    </div>

</asp:Content>
