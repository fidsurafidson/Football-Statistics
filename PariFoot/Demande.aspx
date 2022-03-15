<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demande.aspx.cs" Inherits="PariFoot.Demande" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Demande Prêt</title>
    <link rel="stylesheet" href="html/css/bootstrap.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <h1 align="center">Demande Prêt</h1><br/>
    <div class="col-md-12">
        <div class="col-md-2">

        </div>
        <div class="col-md-4">
            <h4 align="center">Date de deblocage :</h4>
        </div>
        <div class="col-md-4">
            <asp:Panel ID="Panel2" runat="server">
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            </asp:Panel><br/>
        </div>
        <div class="col-md-2">

        </div>
    </div>
    <div class="col-md-12">
        <div class="col-md-2">

        </div>
        <div class="col-md-4">
            <h4 align="center">Jeton :</h4>
        </div>
        <div class="col-md-4">
            <asp:Panel ID="Panel1" runat="server">
                <asp:TextBox ID="TextBox1" runat="server" align="center"></asp:TextBox>
            </asp:Panel>
        </div>
        <div class="col-md-2">

        </div>
    </div>
    <div class="col-md-12">
        <div class="col-md-2">

        </div>
        <div class="col-md-4">
            <h4 align="center">Payer :</h4>
        </div>
        <div class="col-md-4">
            <asp:Panel ID="Panel4" runat="server">
                <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="1">1 fois</asp:ListItem>
                <asp:ListItem Value="2">2 fois</asp:ListItem>
                <asp:ListItem Value="3">3 fois</asp:ListItem>
                <asp:ListItem Value="4">4 fois</asp:ListItem>
                </asp:DropDownList>
            </asp:Panel>
        </div>
    </div>
    <div class="col-md-12">
        <div class="col-md-2">

        </div>
        <div class="col-md-4">
            
        </div>
        <div class="col-md-4">
            <asp:Panel ID="Panel3" runat="server">
                <asp:Button ID="Button1" runat="server" Text="Valider" Width="128px" OnClick="Button1_Click" />
            </asp:Panel>
        </div>
        <div class="col-md-2">

        </div>
    </div>
    </form>
</body>
</html>
