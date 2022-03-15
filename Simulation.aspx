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
            <h4 align="center">Date remboursement :</h4>
        </div>
        <div class="col-md-3">
            <h4 align="center">Nombre jeton :</h4>
        </div>
        <div class="col-md-3">
            
        </div>
        <div class="col-md-3">
            
        </div>
    </div>
    <% for (int i = 0; i < plan1.Length; i++) { %>
    <div class="col-md-12">
        <div class="col-md-3">
            <p align="center"><input type="date" name="inputDate" value=<%= plan1[i].getDateRemboursement() %>></p>
        </div>
        <div class="col-md-3">
            <p align="center"><input type="text" name="inputText" value=<%= plan1[i].getJetonSansInteret() %>></p>
        </div>
        <div class="col-md-3">
            <p align="center"><input type="hidden" name="inputId" value=<%= plan1[i].getId() %>></p>
        </div>
        <div class="col-md-3">
            <h4 align="left">Jeton avec intérêt : <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h4>
        </div>
    </div>
    <% } %>
    <div class="col-md-12">
        <div class="col-md-6">
            <asp:Panel ID="Panel1" runat="server" align="center">
                <asp:Button ID="Button1" runat="server" Text="Simuler" OnClick="Button1_Click" />
            </asp:Panel>
        </div>
        <div class="col-md-6">
            
        </div>
    </div>
    </form>
</body>
</html>
