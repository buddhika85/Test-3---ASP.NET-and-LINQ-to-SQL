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
    </style>
</head>
<body>
    <h5>Test 3 - ASP.NET and LINQ to SQL</h5>
    <p>Below application demonstrates the usage of ASP.NET and LINQ to SQL</p>
    <form id="form1" runat="server">
    <div>
    
        <table style="width: 100%;">
            <tr>
                <td class="auto-style1">&nbsp;Select a country : </td>
                <td>&nbsp;

                    <asp:DropDownList ID="CountriesDDL" runat="server">
                    </asp:DropDownList>

                    <asp:LinqDataSource ID="LinqDataSourceCountries" runat="server">
                    </asp:LinqDataSource>

                </td>                
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:GridView ID="CustomerByCountryGrid" runat="server" Width="530px">
                    </asp:GridView>
                    <asp:LinqDataSource ID="LinqDataSourceCustomersByCountry" runat="server">
                    </asp:LinqDataSource>
                </td>                              
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;
                    <asp:DetailsView ID="CustomerDetailView" runat="server" Height="50px" Width="125px"></asp:DetailsView>
                    <asp:LinqDataSource ID="LinqDataSourceCustomerDetails" runat="server">
                    </asp:LinqDataSource>
                </td>                                
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
