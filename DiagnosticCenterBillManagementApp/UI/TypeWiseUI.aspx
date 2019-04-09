<%@ Page Title="" Language="C#" MasterPageFile="~/UI/MasterPage.Master" AutoEventWireup="true" CodeBehind="TypeWiseUI.aspx.cs" Inherits="DiagnosticCenterBillManagementApp.UI.TypeWiseUI" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    
    <div class="jumbotron ">
        <h3 style="text-align: left">Type Wise Report</h3>

        <div class="container">


            <table class="table ">
                <tr>
                    <td align="right">Form Date</td>
                    <td>
                        <asp:TextBox ID="typeWiseFormDateTextBox" runat="server"></asp:TextBox>

                    </td>
                </tr>

                <tr>
                    <td align="right">To Date</td>
                    <td>
                        <asp:TextBox ID="typeWiseToDateTextBox" runat="server"></asp:TextBox>
                        <asp:Button ID="typeWiseShowButton" runat="server" Text="Show" OnClick="typeWiseShowButton_Click" /></td>

                </tr>
            </table>

        </div>

        </div>


        <div align="center" id="Test" >
            <asp:GridView ID="typeWiseReportGridView" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Sl">
                        <ItemTemplate>
                            <%#  Container.DataItemIndex+1 %>
        
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Test Type Name">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Total No of Test">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("TotalTest")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Amount">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("TotalAmount")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>






        <div class="container">
            <table class="table ">
                <tr>
                    <td align="right">
                        <input type="submit" onclick="PrintDiv('Test')" value="Print" />

                    
                <td>Total   
                    <asp:TextBox ID="typeWiseTotalTextBox" runat="server"></asp:TextBox>
                </td>
                </tr>


            </table>

        </div>

          
        <script>
            function PrintDiv(divname) {
                var printContents = document.getElementById(divname).innerHTML;
                var oldPage = document.body.innerHTML;
                document.body.innerHTML = printContents;
                window.print();
                document.body.innerHTML = oldPage;
            }
        </script>



        <div align="right">
            <button type="button" class="btn ">
                <asp:HyperLink ID="HyperLink1" NavigateUrl="~/UI/Default.aspx" runat="server"> Back</asp:HyperLink></button>
        </div>
        
        

</asp:Content>
