<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListeProposition.aspx.cs" Inherits="PariFoot.ListeProposition" %>
<%@ Import namespace="PariFoot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Liste Proposition</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="col-md-12">
            <h1 align="center">Liste des propositions</h1>
        </div>
        <div class="col-md-12">
            <asp:Panel ID="Panel1" runat="server" align="center">
                <table border="1">
                    <%
                        int id = int.Parse(Request.QueryString["idUtil"]);
                        int idMatch = int.Parse(Request.QueryString["idMatch"]);
                        String categorie = Request.QueryString["categorie"];
                        PariDAO listeProposition = new PariDAO();
                        Pari[] listeProposition1 = listeProposition.findProposition(idMatch, categorie);
                    %>
                        <tr>
                            <th class="auto-style4" style="text-align:center">Id Match</th>
                            <th class="auto-style5" style="text-align:center">Nom Utilisateur</th>
                            <th class="auto-style4" style="text-align:center">Nom Equipe</th>
                            <th class="auto-style4" style="text-align:center">Type Pari</th>
                            <th class="auto-style6" style="text-align:center">Categorie Pari</th>
                            <th class="auto-style6" style="text-align:center">Compensation</th>
                            <th class="auto-style6" style="text-align:center">Jetons</th>
                            <th class="auto-style6" style="text-align:center">Forfaits</th>
                        </tr>
                    <%
                        for (int i=0; i<listeProposition1.Length; i++)
                        {
                    %>
                            <tr>
                                <td class="auto-style7" style="text-align:center"><% Response.Write(listeProposition1[i].getIdMatch()); %></td>
                                <td class="auto-style8" style="text-align:center"><% Response.Write(listeProposition1[i].getNomUtilisateur()); %></td>
                                <td class="auto-style7" style="text-align:center"><% Response.Write(listeProposition1[i].getNomEquipe()); %></td>
                                <td class="auto-style7" style="text-align:center"><% Response.Write(listeProposition1[i].getTypePari()); %></td>
                                <td class="auto-style7" style="text-align:center"><% Response.Write(listeProposition1[i].getCategoriePari()); %></td>
                                <td class="auto-style7" style="text-align:center"><% Response.Write(listeProposition1[i].getCompensation()); %></td>
                                <td class="auto-style7" style="text-align:center"><% Response.Write(listeProposition1[i].getMontant()); %></td>
                                <td class="auto-style7" style="text-align:center"><% Response.Write(listeProposition1[i].getForfait()); %></td>
                                <td class="auto-style9" style="text-align:center"><a href="Suivre.aspx?idPari=<% Response.Write(listeProposition1[i].getId()); %>&idUtil=<% Response.Write(id); %>&idMatch=<% Response.Write(idMatch); %>&categorie=<% Response.Write(categorie); %>">Suivre</a></td>
                            </tr>
                    <% } %>
                </table>
            </asp:Panel>
        </div>
    </div>
    </form>
</body>
</html>
