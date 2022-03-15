<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Suivre.aspx.cs" Inherits="PariFoot.Suivre" %>
<%@ Import namespace="PariFoot" %>
<%@ Import namespace="Foot" %>
<%@ Assembly name="Foot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Suivre</title>
    <link rel="stylesheet" href="html/css/bootstrap.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <%
        /*int idMatch = int.Parse(Request.QueryString["idMatch"]);
        ListeMatchDAO listeMatch = new ListeMatchDAO();
        ListeMatch[] listeMatch1 = listeMatch.findListeMatchById(idMatch);
        String equipe1 = null;
        String equipe2 = null;
        for (int i=0; i<listeMatch1.Length; i++)
        {
            equipe1 = listeMatch1[i].getNomEquipe1();
            equipe2 = listeMatch1[i].getNomEquipe2();
        }*/

        int idPari = int.Parse(Request.QueryString["idPari"]);
        PariDAO pari = new PariDAO();
        Pari[] pari1 = pari.findPariById(idPari);
        int idEquipe1 = 0;
        String typePari = null;
        int compensation1 = 0;
        int jeton1 = 0;
        int forfait1 = 0;
        int matchNul = 0;
        for (int i=0; i<pari1.Length; i++)
        {
            idEquipe1 = pari1[i].getIdEquipe();
            typePari = pari1[i].getTypePari();
            compensation1 = pari1[i].getCompensation();
            jeton1 = pari1[i].getMontant();
            forfait1 = pari1[i].getForfait();
            matchNul = pari1[i].getMatchNul();
        }

        String equipe1 = null;
        EquipeDAO liste = new EquipeDAO();
        Equipe[] liste1 = liste.findEquipe(idEquipe1);
        for (int i=0; i<liste1.Length; i++)
        {
            equipe1 = liste1[i].getNom();
        }

        int idPari2 = idPari + 1;
        Pari[] pari2 = pari.findPariById(idPari2);
        int idEquipe2 = 0;
        int compensation2 = 0;
        int jeton2 = 0;
        int forfait2 = 0;
        for (int i=0; i<pari2.Length; i++)
        {
            idEquipe2 = pari2[i].getIdEquipe();
            compensation2 = pari2[i].getCompensation();
            jeton2 = pari2[i].getMontant();
            forfait2 = pari2[i].getForfait();
        }

        String equipe2 = null;
        Equipe[] liste2 = liste.findEquipe(idEquipe2);
        for (int i=0; i<liste2.Length; i++)
        {
            equipe2 = liste2[i].getNom();
        }
    %>
    <div class="col-md-12">
        <div class="col-md-2">
            
        </div>
        <div class="col-md-10">
            <h1 align="center">Configuration Pari</h1>
        </div>
    </div>
    <div class="col-md-12">
        <div class="col-md-2">
            <asp:Panel ID="Panel8" runat="server" align="center">
                <asp:Button ID="Button3" runat="server" Text="Proposer" Width="150px"/>
            </asp:Panel>
        </div>
        <div class="col-md-5">
            <h3 align="center"><% Response.Write(equipe1); %></h3>
        </div>
        <div class="col-md-5">
            <h3 align="center"><% Response.Write(equipe2); %></h3>
        </div>
    </div>
    <div class="col-md-12">
        <div class="col-md-2">

        </div>
        <div class="col-md-10">
            <h4 align="center">Type Pari : <% Response.Write(typePari); %></h4>
        </div>
    </div>
    </br>
    <div class="col-md-12">
        <div class="col-md-2">
            <h4 align="right">Compensation :</h4>
        </div>
        <div class="col-md-5">
            <h4 align="center"><% Response.Write(compensation1); %></h4>
        </div>
        <div class="col-md-5">
            <asp:Panel ID="Panel3" runat="server" align="center">
                <asp:TextBox ID="TextBox2" runat="server" align="center" value=""></asp:TextBox>
            </asp:Panel>
        </div>
    </div>
    <div class="col-md-12">
        <div class="col-md-2">
            <h4 align="right">Jetons :</h4>
        </div>
        <div class="col-md-5">
            <h4 align="center"><% Response.Write(jeton1); %></h4>
        </div>
        <div class="col-md-5">
            <asp:Panel ID="Panel5" runat="server" align="center">
                <asp:TextBox ID="TextBox4" runat="server" align="center"></asp:TextBox>
            </asp:Panel>
        </div>
    </div>
    <div class="col-md-12">
        <div class="col-md-2">
            <h4 align="right">Forfait (plafond) :</h4>
        </div>
        <div class="col-md-5">
            <h4 align="center"><% Response.Write(forfait1); %></h4>
        </div>
        <div class="col-md-5">
            <asp:Panel ID="Panel7" runat="server" align="center">
                <asp:TextBox ID="TextBox6" runat="server" align="center"></asp:TextBox>
            </asp:Panel>
        </div>
    </div>
    <div class="col-md-12">
        <div class="col-md-2">
            <h4 align="right">Match nul :</h4>
        </div>
        <div class="col-md-10">
            <h4 align="center"><% Response.Write(matchNul); %></h4>
        </div>
    </div>

    <div class="col-md-12">
        <div class="col-md-2">
            
        </div>
        <div class="col-md-5">
            
        </div>
        <div class="col-md-5">
            <asp:Panel ID="Panel12" runat="server" align="center">
                <asp:Button ID="Button2" runat="server" Text="Parier" Width="125px" OnClick="Button2_Click" />
            </asp:Panel>
        </div>
    </div>
    </form>
</body>
</html>
