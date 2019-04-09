<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestRequestEntryUI.aspx.cs" Inherits="DiagnosticCenterBillManagementApp.UI.TestRequestEntryUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>



            <div class="jumbotron ">
                <h3 style="text-align: left">Test Type Setup</h3>

                <div class="container">


                    <table class="table ">
                        <tr>
                            <td align="right">Type Name</td>
                            <td>
                                <asp:TextBox ID="tpeNameTextBox" runat="server"></asp:TextBox>
                            </td>
                        </tr>


                        <tr>
                            <td></td>
                            <td align="left">
                                <asp:Button ID="typeNameSaveButton" runat="server" Text="Save" /></td>

                        </tr>


                    </table>
                </div>
                
                
                
                
                <div class="container">
                    <asp:GridView ID="testTypeSetupGridView" runat="server"></asp:GridView>    
                </div>
                
                

            
            
            


            <div align="right">
                <button type="button" class="btn ">
                    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/UI/Default.aspx" runat="server"> Back</asp:HyperLink></button>
            </div>

             <marquee style="color: blueviolet ;font-weight: bold;"> Developed By MD Mahfuzur Rahman</marquee>

        </div>
    </form>
</body>
</html>
