<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SimulationRetard.aspx.cs" Inherits="PariFoot.SimulationRetard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Simulation Retard</title>
    <link rel="stylesheet" href="html/css/bootstrap.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <h1 align="center">Simulation retard</h1>
    <div class="col-md-12">
        <div class="col-md-3">
            <asp:Panel ID="Panel1" runat="server" align="center">
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            </asp:Panel>
        </div>
        <div class="col-md-6">
            <h3 align="center"><asp:Label ID="Label5" runat="server" Text="Label"></asp:Label> - Date retard : <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h3>
            <h3 align="center"><asp:Label ID="Label6" runat="server" Text="Label"></asp:Label> - Date remboursement : <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></h3>
        </div>
        <div class="col-md-3">
            <h3 align="center">Jeton avec penalite : <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></h3>
            <h3 align="center">Jeton avec interet : <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></h3>
        </div>
    </div>
    <div class="col-md-12">
        <div class="col-md-3">
            <asp:Panel ID="Panel2" runat="server" align="center">
                <asp:Button ID="Button1" runat="server" Text="Simuler" OnClick="Button1_Click" />
            </asp:Panel>
        </div>
        <div class="col-md-9">
            <asp:Panel ID="Panel3" runat="server" align="center">
                <asp:Button ID="Button2" runat="server" Text="Valider" OnClick="Button2_Click" />
            </asp:Panel>
        </div>
    </div>
    </form>
</body>
</html>
