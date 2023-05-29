<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PROGTask2.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>/*I used a bit of chatgpt to help with the css and styling of the UI*/
        /*CSS*/
        .about-container {
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
            background-color: #f1f1f1;
            border-radius: 5px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
            text-align: center;
        }

        .title {
            text-align: center;
            margin-bottom: 20px;
        }

        .subtitle {
            font-size: 24px;
            margin-bottom: 10px;
        }

        .description {
            font-size: 16px;
            color: #333333;
        }

        .image-container {
            margin-top: 20px;
            text-align: center;
        }

        .image-container img {
            max-width: 100%;
            height: 300px;
        }
        /*Css For the title of the page*/
        #aspnetTitle {
            
            background-color: #e5f7e5;
            padding: 10px;
            margin: 10px 0;
            display: inline-block;
            border: none;
            border-bottom: 1px solid #c1e0c1;
        }
    </style>
    <main>
        <section class="row" aria-labelledby="aspnetTitle" style="text-align: center;">
            <h1 id="aspnetTitle">About Us</h1>
        </section>
        <h3 class="subtitle">Stock Management Website.</h3>
        <p class="description">The website will track incoming and outgoing stock and which farmer each item belongs to.</p>
        <p class="description">The website will allow users the option to add products to their profile and be able to filter product type.</p>
        <div class="image-container">
            <img src="Pictures/About.png" alt="Image Description">
        </div>
    </main>

</asp:Content>

