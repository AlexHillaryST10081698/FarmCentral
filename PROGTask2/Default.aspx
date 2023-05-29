<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PROGTask2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /*Css*/
        /*for my Button*/
        .btn-custom {
            border: 2px solid #333;
            background-color: #013A20;
            color: #ffffff;
            padding: 10px 20px;
            text-decoration: none;
            font-weight: bold;
            display: inline-block;
            transition: background-color 0.3s;
        }
        /*When a user hovers over a Button*/
        .btn-custom:hover {
            background-color: #478C5C;
            color: #ffffff;
        }
        
        .image-container {
            float: right;
            margin-left: 20px;
        }
        
        .content-container {
            overflow: hidden;
        }
        
        #userrole {
            font-size: 33px;
            background-color: #e5f7e5;
            padding: 10px;
            margin: 10px 0;
            display: inline-block;
            border: none;
            border-bottom: 1px solid #c1e0c1;
        }
        /*Title*/
        #aspnetTitle {
            
            background-color: #e5f7e5;
            padding: 10px;
            margin: 10px 0;
            display: inline-block;
            border: none;
            border-bottom: 1px solid #c1e0c1;
        }
        main {
            margin-top: 50px;
        }

        h2 {
            font-size: 24px;
            margin-bottom: 10px;
        }

        p {
            font-size: 16px;
            line-height: 1.6;
        }
    </style>
    <main>
        <section class="row" aria-labelledby="aspnetTitle" style="text-align: center;">
            <h1 id="aspnetTitle">Welcome To Farm Central</h1>
        </section>
        <h1 id="userrole">User Role Login:</h1>
        <div class="content-container">
            <div class="image-container">
                <img src="Pictures/plant.jpg" alt="Home Image" width="450" height="250">
            </div>
            <div class="row">
                <section class="col-md-6" aria-labelledby="farmersTitle">
                    <h2 id="farmersTitle">Farmers</h2>
                    <p>
                        Welcome! Click the button below to proceed to the Farmer Login.
                    </p>
                    <p>
                        <a href="FarmerLoginForm.aspx" class="btn btn-custom" href="farmers.aspx">Continue as Farmer &raquo;</a>
                    </p>
                </section>
                <section class="col-md-6" aria-labelledby="employeesTitle">
                    <h2 id="employeesTitle">Employees</h2>
                    <p>
                        Welcome! Click the button below to proceed to the Employee Login.
                    </p>
                    <p> 
                        <a href="EmployeeLoginForm.aspx" class="btn btn-custom" href="employees.aspx">Continue as Employee &raquo;</a>
                    </p>
                </section>
            </div>
        </div>
    </main>
</asp:Content>






