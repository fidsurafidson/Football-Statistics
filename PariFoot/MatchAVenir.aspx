<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MatchAVenir.aspx.cs" Inherits="PariFoot.MatchAVenir" %>
<%@ Assembly Name="Foot" %>
<%@ Import namespace="Foot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Liste Match</title>
    <link rel="stylesheet" href="html/css/bootstrap.min.css"/>
    <style type="text/css">
        .auto-style4 {
            width: 140px;
            height: 30px;
        }
        .auto-style5 {
            height: 30px;
            width: 37px;
        }
        .auto-style6 {
            width: 65px;
            height: 30px;
        }
        .auto-style7 {
            width: 140px;
            height: 35px;
        }
        .auto-style8 {
            height: 35px;
            width: 37px;
        }
        .auto-style9 {
            width: 65px;
            height: 35px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="col-md-12">
            <h1 align="center">Liste match à venir</h1>
        </div>
        <div class="col-md-12">
            <asp:Panel ID="Panel1" runat="server" align="center">
                <table>
                    <%
                        int id = int.Parse(Request.QueryString["idUtil"]);
                        ListeMatchDAO listematch = new ListeMatchDAO();
                        ListeMatch[] listematch1 = listematch.findListeMatch();
                    %>
                        <tr>
                            <th class="auto-style4" style="text-align:center">Equipe 1</th>
                            <th style="text-align:center" class="auto-style5">VS</th>
                            <th class="auto-style4" style="text-align:center">Equipe 2</th>
                            <th class="auto-style4" style="text-align:center">Date du match</th>
                            <th class="auto-style6" style="text-align:center"></th>
                        </tr>
                    <%
                        for (int i=0; i<listematch1.Length; i++)
                        {
                    %>
                            <tr>
                                <td class="auto-style7" style="text-align:center"><% Response.Write(listematch1[i].getNomEquipe1()); %></td>
                                <td style="text-align:center" class="auto-style8">VS</td>
                                <td class="auto-style7" style="text-align:center"><% Response.Write(listematch1[i].getNomEquipe2()); %></td>
                                <td class="auto-style7" style="text-align:center"><% Response.Write(listematch1[i].getDateMatch()); %></td>
                                <td class="auto-style9" style="text-align:center"><a href="ChoixCategoriePari.aspx?idUtil=<% Response.Write(id); %>&idMatch=<% Response.Write(listematch1[i].getId()); %>">Parier</a></td>
                            </tr>
                    <% } %>
                </table>
            </asp:Panel>
        </div>
        <div class="col-md-12">
            <asp:Button ID="Button2" runat="server" Text="Voir prêt" Width="150px" OnClick="Button2_Click" />
        </div>
        <div class="col-md-12">
            <asp:Button ID="Button1" runat="server" Text="Emprunter" OnClick="Button1_Click" Width="150px" />
        </div>
        <div class="col-md-12">
            <asp:Button ID="Button3" runat="server" Text="Simulation retard" OnClick="Button3_Click" />
        </div>
    </div>
    </form>
</body>
</html>
