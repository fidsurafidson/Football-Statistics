<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigurationPari.aspx.cs" Inherits="PariFoot.ConfigurationPari" %>
<%@ Import namespace="PariFoot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Configuration</title>
    <link rel="stylesheet" href="html/css/bootstrap.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <%
        int idMatch = int.Parse(Request.QueryString["idMatch"]);
        ListeMatchDAO listeMatch = new ListeMatchDAO();
        ListeMatch[] listeMatch1 = listeMatch.findListeMatchById(idMatch);
        String equipe1 = null;
        String equipe2 = null;
        for (int i=0; i<listeMatch1.Length; i++)
        {
            equipe1 = listeMatch1[i].getNomEquipe1();
            equipe2 = listeMatch1[i].getNomEquipe2();
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
                <asp:Button ID="Button3" runat="server" Text="Proposer" OnClick="Button3_Click" Width="150px"/>
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
            <asp:Panel ID="Panel1" runat="server" align="center">
                <h4>Type Pari :</h4><asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>Total</asp:ListItem>
                <asp:ListItem>Quantitatif</asp:ListItem>
                </asp:DropDownList>
            </asp:Panel>
        </div>
    </div>
    </br>
    <div class="col-md-12">
        <div class="col-md-2">
            <h4 align="right">Compensation :</h4>
        </div>
        <div class="col-md-5">
            <asp:Panel ID="Panel2" runat="server" align="center">
                <asp:TextBox ID="TextBox1" runat="server" align="center" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </asp:Panel>
        </div>
        <div class="col-md-5">
            <asp:Panel ID="Panel3" runat="server" align="center">
                <asp:TextBox ID="TextBox2" runat="server" align="center"></asp:TextBox>
            </asp:Panel>
        </div>
    </div>
    <div class="col-md-12">
        <div class="col-md-2">
            <h4 align="right">Jetons :</h4>
        </div>
        <div class="col-md-5">
            <asp:Panel ID="Panel4" runat="server" align="center">
                <asp:TextBox ID="TextBox3" runat="server" align="center"></asp:TextBox>
            </asp:Panel>
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
            <asp:Panel ID="Panel6" runat="server" align="center">
                <asp:TextBox ID="TextBox5" runat="server" align="center"></asp:TextBox>
            </asp:Panel>
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
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" align="center">
                <asp:ListItem Value="1"> Equipe 1 </asp:ListItem>
                <asp:ListItem Value="2"> Equipe 2 </asp:ListItem>
                <asp:ListItem Value="0"> Null </asp:ListItem>
            </asp:CheckBoxList>
        </div>
    </div>

    <div class="col-md-12">
        <div class="col-md-2">
            
        </div>
        <div class="col-md-5">
            <asp:Panel ID="Panel11" runat="server" align="center">
                <asp:Button ID="Button1" runat="server" Text="Parier" Width="125px" OnClick="Button1_Click" />
            </asp:Panel>
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
