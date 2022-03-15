<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pret.aspx.cs" Inherits="PariFoot.Pret" %>

<%@ Import namespace="PariFoot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="col-md-12">
        <h1 align="center">Liste de vos demandes de prêt</h1>
    </div>
    <div class="col-md-12">
        <asp:Panel ID="Panel1" runat="server" align="center">
            <table border="1">
                <%
                    int idUtilisateur = int.Parse(Request.QueryString["idUtil"]);
                    DemandePretDAO listDemande = new DemandePretDAO();
                    DemandePret[] listDemande1 = listDemande.findDemandeByUtil(idUtilisateur);
                %>
                    <tr>
                        <th style="text-align:center">Utilisateur</th>
                        <th style="text-align:center">Date deblocage</th>
                        <th style="text-align:center">Jeton</th>
                    </tr>
                <%
                    for (int i=0; i<listDemande1.Length; i++)
                    {
                %>
                        <tr>
                            <td style="text-align:center"><% Response.Write(listDemande1[i].getIdUtilisateur()); %></td>
                            <td style="text-align:center"><% Response.Write(listDemande1[i].getDateDeblocage()); %></td>
                            <td style="text-align:center"><% Response.Write(listDemande1[i].getJeton()); %></td>
                            <td style="text-align:center"><a href="Simulation.aspx?idUtil=<% Response.Write(listDemande1[i].getIdUtilisateur()); %>&idDemande=<% Response.Write(listDemande1[i].getId()); %>"><input type="button" style="color:white;background-color:blue" value="Simuler"/></a></td>
                        </tr>
                <% } %>
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
