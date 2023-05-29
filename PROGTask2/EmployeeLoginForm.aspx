<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeLoginForm.aspx.cs" Inherits="PROGTask2.Farmer" %>

<!DOCTYPE html>
<html>
<head>
  <title>Login</title>
  <style>
      /*I used a bit of chatgpt to help me with the css for the buttons images and colours*/
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
    /* css for the password textbox*/
    input[type="text"],
    input[type="password"] {
      width: 100%;
      padding: 10px;
      border: 1px solid #ccc;
      border-radius: 3px;
      box-sizing: border-box;
    }
    /*Css for the login Button*/
    #btnLogin {
      display: block;
      width: 100%;
      padding: 10px;
      border: none;
      background-color: #013A20;
      color: #ffffff;
      border-radius: 3px;
      cursor: pointer;
    }

    #btnLogin:hover {
      background-color: #478C5C;
    }
    /*Css for the login Icon*/
    .login-icon {
      display: inline-block;
      vertical-align: middle;
      width: 20px;
      height: 20px;
      margin-right: 10px;
    }
  </style>
</head>
<body>
  <div class="container">
      <h2><img src="Icons/LoginIcon.svg" alt="Login Icon" class="login-icon">Employee Login</h2>
    <form runat="server">
      <div class="form-group">
        <label for="lblUsername">Enter Your Username:</label>
        <asp:TextBox ID="txtUsername" runat="server" TextMode="SingleLine" CssClass="form-control" required></asp:TextBox>
      </div>
      <div class="form-group">
        <label for="lblPassword">Enter Your Password:</label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" required></asp:TextBox>
      </div>
      <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" CssClass="btn btn-primary" />
    </form>
  </div>
</body>
</html>


















