<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListeDemande.aspx.cs" Inherits="PariFoot.ListeDemande" %>
<%@ Import namespace="PariFoot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="col-md-12">
            <h1 align="center">Liste des demandes de prêt</h1>
        </div>
        <div class="col-md-12">
            <asp:Panel ID="Panel1" runat="server" align="center">
                <table border="1">
                    <%
                        DemandePretDAO listDemande = new DemandePretDAO();
                        DemandePret[] listDemande1 = listDemande.findDemandeNonValide();
                    %>
                        <tr>
                            <th style="text-align:center">Utilisateur</th>
                            <th style="text-align:center">Date remboursement</th>
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
                                <td style="text-align:center"><a href="ValiderDemande.aspx?idUtil=<% Response.Write(listDemande1[i].getIdUtilisateur()); %>&idDemande=<% Response.Write(listDemande1[i].getId()); %>"><input type="button" style="color:white;background-color:blue" value="Valider"/></a></td>
                            </tr>
                    <% } %>
                </table>
            </asp:Panel>
        </div>
    </div>
    </form>
</body>
</html>
