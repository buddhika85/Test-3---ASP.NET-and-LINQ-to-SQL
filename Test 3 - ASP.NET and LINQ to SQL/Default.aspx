<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Test_3___ASP.NET_and_LINQ_to_SQL.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test 3 - ASP.NET and LINQ to SQL</title>
    <style type="text/css">
        body {
            font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
            align-content:center;
        }
        .auto-style1 {
            width: 166px;
        }
        form {
            font-size : small;
        }
    </style>
</head>
<body>
    <h1>Test 3 - ASP.NET and LINQ to SQL</h1>
    <p>Below application demonstrates the usage of ASP.NET and LINQ to SQL</p>
    <br />
    <form id="form1" runat="server">
    <div>
    
        <table style="width: 100%;">
            <tr>
                <td class="auto-style1">
                    &nbsp;
                    Select a country : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="CountriesDDL" runat="server">
                    </asp:DropDownList>
                </td>            
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:GridView ID="CustomerByCountryGrid" runat="server" 
                        Width="530px" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />
                    </asp:GridView>
                </td>                              
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;
                    <asp:DetailsView ID="CustomerDetailView" runat="server" Height="50px" Width="125px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                        <EditRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                    </asp:DetailsView>
                </td>                                
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
