<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FarmerDashboard.aspx.cs" Inherits="PROGTask2.Farmer1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Farmer Dashboard</title>
    <!--Used a bit of chatgpt to help me with the CSS and styling of buttons and texts---->
    <!-- CSS Methods-->
    <style>
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

        button[type="submit"] {
            display: block;
            width: 100%;
            padding: 10px;
            border: none;
            background-color: #013A20;
            color: #ffffff;
            border-radius: 3px;
            cursor: pointer;
        }

        button[type="submit"]:hover {
            background-color: #478C5C;
        }

        .table-container {
            margin-top: 20px;
        }

        table {
            width: 100%;
            border-collapse: collapse;
        }

        th,
        td {
            padding: 8px;
            border-bottom: 1px solid #ddd;
            text-align: left;
        }

        th {
            background-color: #013A20;
            color: #ffffff;
        }
        /* Add Products and logout Button Css*/
        .btn-custom {
            border: 2px solid #333;
            background-color: #013A20;
            color: #ffffff;
            padding: 10px 20px;
            text-decoration: none;
            font-weight: bold;
            display: inline-block;
            transition: background-color 0.3s;
            margin-bottom: 10px; 
        }

        .btn-custom:hover {
            background-color: #478C5C;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2 id="BtnLogout">Farmer Dashboard</h2>

            
            <h3>Add New Product</h3>
            <div class="form-group">
                <div class="form-group">
                <label for="lblProductBarcode">Product Barcode:</label>
                <asp:TextBox ID="txtProductBarcode" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
                <div class="form-group">
                <label for="ddlFarmers">Product Type:</label>
                <asp:DropDownList ID="ListProductType" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlProductType_SelectedIndexChanged">
                    <asp:ListItem Text="--Select Product Type--" Value=""></asp:ListItem>
                    <asp:ListItem Text="Vegetables" Value="Vegetables"></asp:ListItem>
                    <asp:ListItem Text="Dairy" Value="Dairy"></asp:ListItem>
                    <asp:ListItem Text="Grains" Value="Grains"></asp:ListItem>
                </asp:DropDownList>

            </div>
                <label for="lblProductName" id="lblProductName">Product Name:</label>
                <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="lblProductPrice">Product Price:</label>
                <asp:TextBox ID="txtProductPrice" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" OnClick="BtnAddProduct_Click" CssClass="btn-custom" />

            <!-- Logout button -->
            <button type="button" class="btn-custom" onclick="location.href='Default.aspx'" id="btnLogout">Logout</button>
        </div>
    </form>
</body>
</html>





