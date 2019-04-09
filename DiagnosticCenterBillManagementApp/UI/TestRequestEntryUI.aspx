<%@ Page Title="" Language="C#" MasterPageFile="~/UI/MasterPage.Master" AutoEventWireup="true" CodeBehind="TestRequestEntryUI.aspx.cs" Inherits="DiagnosticCenterBillManagementApp.UI.TestRequestEntryUI" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="jumbotron ">
        <h3 style="text-align: left">Test Request Entry</h3>

        <div class="container">


            <table class="table ">
                <tr>
                    <td align="right">Name Of The Patient</td>
                    <td>
                        <asp:TextBox ID="nameOfThePatientTextBox" runat="server"></asp:TextBox>
                       
                    </td>
                </tr>
                <tr>
                    <td align="right">Date Of Birth</td>
                    <td>  
                        <asp:TextBox ID="dateOfBirthTextBox" runat="server"></asp:TextBox>
                        <asp:ImageButton  runat="server" Height="27px" ImageUrl="~/Images/Calendar_Green.png" OnClick="Unnamed1_Click" Width="43px"/>
                    </td>
                    
                    
                </tr>
                <tr>
                    <td>
                         
                   </td>
                    <td>
                        
                        <asp:Calendar ID="dobCalendar" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" OnSelectionChanged="dobCalendar_SelectionChanged" Width="220px">
                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                            <WeekendDayStyle BackColor="#CCCCFF" />
                        </asp:Calendar>
                    
                    </td>
                </tr>

                <tr>
                    <td align="right">Mobile No</td>
                    <td>
                        <asp:TextBox ID="mobileNoTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td align="right">Select Test</td>

                    <td>
                        <asp:DropDownList ID="testDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="testDropDownList_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td align="right"></td>
                    <td>Fee
                        <asp:TextBox ID="feeTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td align="left">
                        <asp:Button ID="testRequestEntryButton" runat="server" Text="Save" OnClick="testRequestEntryButton_Click" /></td>

                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label runat="server" ID="messageLabel" Text=""></asp:Label>
                    </td>
                </tr>


            </table>
        </div>



        <div class="container" align="center">
            <asp:GridView ID="allTestRequestGridView" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Sl#">
                        <ItemTemplate>
                            <%#  Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Test">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    

                    <asp:TemplateField HeaderText="Fee">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("Fee")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                
            </asp:GridView>
            <table>
                <tr>
                    <td align="right">Total    </td>
                    <td>
                        <asp:TextBox runat="server" ID="totalAmountTextBox" ></asp:TextBox><br/><br/>
                    </td>
                </tr> 
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="allTestSubmitButton" runat="server" Text="Save" OnClick="allTestSubmitButton_Click"/>
                        <input type="submit" value="Print" onclick="PrintDiv('Test')"/>
                    </td>
                </tr>
            </table>
            
            
            
        </div>


        <div ID="Test">
            <asp:Label runat="server" ID="billNumberLabel"></asp:Label>
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
        </div></div>
</asp:Content>
