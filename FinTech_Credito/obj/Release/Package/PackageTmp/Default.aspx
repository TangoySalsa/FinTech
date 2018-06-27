<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Dashboard_Bajas_Carrier._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="col-md-offset-5 col-md-3">
            <div class="form-login">               
                <br />                 
                <img src="Icon/2fun2me_.png" class="img-rounded" alt="2fun2me"  style="width: 316px; height: 100px">      
                <br />
                <h4>Bienvenido</h4>
                <br />
                <asp:TextBox runat="server" ID="txtUser" CssClass="form_control input-sm chat-input" ValidateRequestMode="Enabled"></asp:TextBox>                
                <br />
                <br />
                <asp:TextBox runat="server" ID="txtPass" CssClass="form_control input-sm chat-input" ValidateRequestMode="Enabled" TextMode="Password"></asp:TextBox>                
                <br />
                <br />
                <div class="wrapper">                 
                    <asp:Button runat="server" ID="btnLogin" Text="Login" CssClass="btn btn-primary btn-md" OnClick="btnLogin_Click" />                    
                </div>                
            </div>
        </div>
    </div> 

</asp:Content>
