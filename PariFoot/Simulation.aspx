<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Simulation.aspx.cs" Inherits="PariFoot.Simulation" %>
<%@ Import namespace="PariFoot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Simulation</title>
    <link rel="stylesheet" href="html/css/bootstrap.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <% 
        int idUtilisateur = int.Parse(Request.QueryString["idUtil"]);
        int idDemande = int.Parse(Request.QueryString["idDemande"]);
        PlanRemboursementAvecInteretDAO plan = new PlanRemboursementAvecInteretDAO();
        PlanRemboursementAvecInteret[] plan1 = plan.findPlanByIdDemande(idDemande);
        int nbr = plan1.Length;
    %>
    <h1 align="center">Simulation Plan De Remboursement</h1><br/>
    <div class="col-md-12">
        <div class="col-md-3">
            <h4 align="center">Date du remboursement :</h4>
        </div>
        <div class="col-md-3">
            <asp:Panel ID="Panel2" runat="server">
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            </asp:Panel><br/>
        </div>
        <div class="col-md-3">
            <asp:Label ID="Label1" runat="server" Text="Date du remboursement"></asp:Label><br/>
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
        </div>
        <div class="col-md-3">
            <asp:Label ID="Label2" runat="server" Text="Jeton a payer"></asp:Label><br/>
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="col-md-12">
        <div class="col-md-3">
            <h4 align="center">Jeton :</h4>
        </div>
        <div class="col-md-3">
            <asp:Panel ID="Panel1" runat="server">
                <asp:TextBox ID="TextBox1" runat="server" align="center"></asp:TextBox>
            </asp:Panel>
        </div>
        <div class="col-md-3">
            
        </div>
        <div class="col-md-3">
            
        </div>
    </div>
    <div class="col-md-12">
        <div class="col-md-2">

        </div>
        <div class="col-md-4">
            
        </div>
        <div class="col-md-4">
            <asp:Panel ID="Panel3" runat="server">
                <asp:Button ID="Button1" runat="server" Text="Simuler" Width="128px" OnClick="Button1_Click1" />
            </asp:Panel>
        </div>
        <div class="col-md-2">

        </div>
    </div>
    </form>
</body>
</html>
