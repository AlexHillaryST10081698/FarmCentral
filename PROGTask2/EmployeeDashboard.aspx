<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDashboard.aspx.cs" Inherits="PROGTask2.Employee" %>

<!DOCTYPE html>
<html>
<head>
    <title>Employee Dashboard</title>
    <style>
        /*I used chat to help with the styling, css as well as the datatable*/
        body {
            font-family: Arial, sans-serif;
            background-color: #f1f1f1;
        }

        .container {
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 5px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        }

        h2 {
            text-align: center;
            margin-bottom: 20px;
        }

        .form-group {
            margin-bottom: 15px;
        }

        label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
        }

        input[type="text"],
        input[type="password"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 3px;
            box-sizing: border-box;
        }

        .btn-custom {
            border: 2px solid #333;
            background-color: #013A20;
            color: #ffffff;
            padding: 10px 20px;
            text-decoration: none;
            font-weight: bold;
            display: block;
            width: 100%; 
            transition: background-color 0.3s;
            margin-bottom: 10px;
        }

        .btn-custom:hover {
            background-color: #478C5C;
            color: #ffffff;
        }

        .table-container {
            margin-top: 20px;
        }

        table {
            width: 100%;
            border-collapse: collapse;
        }

        th, td {
            padding: 8px;
            border-bottom: 1px solid #ddd;
            text-align: left;
        }

        th {
            background-color: #013A20;
            color: #ffffff;
        }

        .filter-section {
            margin-top: 20px;
            padding: 10px;
            background-color: #f9f9f9;
            border-radius: 5px;
        }

        .filter-section h3 {
            margin: 0;
        }

        .filter-section .form-group {
            display: inline-block;
            margin-right: 10px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <div class="container">
            <h2>Employee Dashboard</h2>
            <div class="form-group">
                <label for="ddlFarmers">Select a Farmer:</label>
                <asp:DropDownList ID="List1SelectFarmers" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="List1SelectFarmers_SelectedIndexChanged" DataSourceID="SqlDataSource1" DataTextField="FarmerUsername" DataValueField="FarmerUsername">
                    <asp:ListItem Text="-- Select Farmer --" Value=""></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [FarmerUsername] FROM [FarmerTable]"></asp:SqlDataSource>
            </div>
            <asp:Button ID="btnViewProducts" runat="server" Text="View Products" OnClick="btnViewProducts_Click" CssClass="btn-custom" />

            <!-- Filter section -->
            <div class="filter-section">
                <h3>Filter Products</h3>
                <div class="form-group">
                    <label for="ddlProductType">Product Type:</label>
                    <asp:DropDownList ID="ddlProductType" runat="server" CssClass="form-control">
                        <asp:ListItem Text="-- Select Product Type --" Value=""></asp:ListItem>
                        <asp:ListItem Text="Vegetables" Value="Vegetables"></asp:ListItem>
                        <asp:ListItem Text="Dairy" Value="Dairy"></asp:ListItem>
                        <asp:ListItem Text="Grains" Value="Grains"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:Button ID="btnFilterProducts" runat="server" Text="Filter" OnClick="btnFilterProducts_Click" CssClass="btn-custom" />
            </div>

            <div class="table-container">
                <asp:DataList ID="dataListProducts" runat="server" CssClass="table">
                    <HeaderTemplate>
                        <table>
                            <thead>
                                <tr>
                                    <th>Product Barcode</th>
                                    <th>Product Name</th>
                                    <th>Product Price</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("ProductBarcode") %></td>
                            <td><%# Eval("ProductName") %></td>
                            <td><%# Eval("ProductPrice") %></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                            </tbody>
                        </table>
                    </FooterTemplate>
                </asp:DataList>
            </div>

            <h2>Add New Farmer</h2>
            <button type="button" class="btn-custom" onclick="location.href='AddFarmer.aspx'">Add New Farmer</button>

            <!-- Logout button -->
            <button type="button" class="btn-custom" onclick="location.href='Default.aspx'" id="LogoutBtn">Logout</button>
        </div>
    </form>
</body>
</html>









