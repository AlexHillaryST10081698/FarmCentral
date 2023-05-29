<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="PROGTask2.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>/*Css         I used a bit of chatgpt to help with the css and styling of the UI */
        /* boarder around the contact the contact details*/
        .contact-container {
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
            background-color: #f1f1f1;
            border-radius: 5px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
            display: inline-block;
            vertical-align: top;
            text-align: left;
            margin-left: 125px;
        }

        .title {
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

        .contact-info {
            margin-top: 20px;
            font-size: 18px;
        }

        .contact-info p {
            margin-bottom: 5px;
        }

        .contact-info abbr {
            font-weight: bold;
            text-decoration: none; 
        }

        .contact-icon {
            display: inline-block;
            width: 20px;
            height: 20px;
            margin-right: 5px;
            vertical-align: middle;
        }
        /*Css for the icons*/
        /*Reference for Icons: fontawesome.com. (n.d.). Free Icons | Font Awesome. [online] Available at: https://fontawesome.com/search?o=r&m=free [Accessed 28 May 2023]*/
        /*The Phone Icon*/
        .phone-icon {
            background-image: url(Icons/phone-solid.svg);
        }
        /*The Email Icon*/
        .email-icon {
            background-image: url(Icons/envelope-solid.svg);
        }
        /*The Address Icon*/
        .address-icon {
            background-image: url(Icons/address-book-solid.svg);
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
        <img src="Pictures/Contact.jpg" alt="Your Image" style="max-width: 325px; margin-bottom: 20px;" />
        <div class="contact-container">
            <h2 id="aspnetTitle" class="title"><%: Title %>.</h2>
            <h3 class="subtitle">Please See Contact Details Below:</h3>
            <div class="contact-info">
                <p>
                    <span class="contact-icon phone-icon"></span>
                    <abbr title="Phone">Phone Number:</abbr>
                    0826740244
                </p>
                <p>
                    <span class="contact-icon email-icon"></span>
                    <abbr title="Email">Email:</abbr>
                    ST10081698@vcconnect.edu.za
                </p>
                <p>
                    <span class="contact-icon address-icon"></span>
                    <abbr title="Address">Address:</abbr>
                    The Quadrant, 146 Campground Rd, Newlands, Cape Town, 7708
                </p>
            </div>
        </div>
    </main>  
</asp:Content>















