<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFarmer.aspx.cs" Inherits="PROGTask2.AddFarmer" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Farmer</title>
    <style>
        /*I used a bit of chatgpt to help with the styling and layout of UI*/
        /*css styling*/
        body {
            font-family: Arial, sans-serif;
            background-color: #f1f1f1;
        }

        .container {
            max-width: 400px;
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

        .form-control {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 3px;
            box-sizing: border-box;
        }

        .btn {
            display: block;
            width: 100%;
            padding: 10px;
            border: none;
            background-color: #013A20;
            color: #ffffff;
            border-radius: 3px;
            cursor: pointer;
            margin-bottom: 10px; 
        }

        .btn:hover {
            background-color: #478C5C;
        }
    </style>
</head>
<body>
    <form runat="server">
        <div class="container">
            <h2>Add Farmer</h2>
            <div class="form-group">
                <label for="txtUsername">Username:</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtName">Name:</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtSurname">Surname:</label>
                <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtPassword">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtConfirmPassword">Confirm Password:</label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control" required></asp:TextBox>
            </div>
            <asp:Button ID="btnAddFarmer" runat="server" Text="Add Farmer" OnClick="BtnAddFarmer_Click" CssClass="btn" />
            <button type="button" onclick="location.href='EmployeeDashboard.aspx'" class="btn" id="btnReturn">Return to Dashboard</button>
        </div>
    </form>
</body>
</html>







