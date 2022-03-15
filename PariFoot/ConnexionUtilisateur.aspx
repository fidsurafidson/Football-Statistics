<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConnexionUtilisateur.aspx.cs" Inherits="PariFoot.ConnexionUtilisateur" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Connexion</title>
    <link rel="stylesheet" href="html/css/bootstrap.min.css"/>
    <style type="text/css">
        .auto-style1 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 100%;
            margin-bottom: 30px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="auto-style1">
            <h1 align="center">Se connecter</h1>
        </div>
        <div class="col-md-12">
            <div class="col-md-3">

            </div>
            <div class="col-md-3">
                <h4 align="right">Nom d'utilisateur :</h4>
            </div>
            <div class="col-md-3">
                <asp:Panel ID="Panel1" runat="server" align="left">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </asp:Panel>
            </div>
             <div class="col-md-3">

            </div>
        </div>
        <div class="col-md-12">
            <div class="col-md-3">

            </div>
            <div class="col-md-3">
                <h4 align="right">Mot de passe :</h4>
            </div>
            <div class="col-md-3">
                <asp:Panel ID="Panel2" runat="server" align="left">
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                </asp:Panel>
            </div>
             <div class="col-md-3">

            </div>
        </div>
        <div class="col-md-12">
            <div class="col-md-3">

            </div>
            <div class="col-md-3">
                
            </div>
            <div class="col-md-3">
                <asp:Panel ID="Panel3" runat="server" align="left">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Connexion" Width="185px" />
                </asp:Panel>
            </div>
             <div class="col-md-3">

            </div>
        </div>
        
    </div>
    </form>
</body>
</html>
