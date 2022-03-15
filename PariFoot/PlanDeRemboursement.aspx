<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanDeRemboursement.aspx.cs" Inherits="PariFoot.PlanDeRemboursement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Plan</title>
    <link rel="stylesheet" href="html/css/bootstrap.min.css"/>
</head>
<body>
    
    <form id="form1" runat="server" method="post">
    <% int nbrPayem = int.Parse(Request.QueryString["nbrPayem"]); %>
    <h1 align="center">Plan De Remboursement</h1><br/>
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
    <div class="col-md-12">
        <div class="col-md-3">
            <asp:Panel ID="Panel1" runat="server" align="center">
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            </asp:Panel>
            <br/>
        </div>
        <div class="col-md-3">
            <asp:Panel ID="Panel2" runat="server" align="center">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </asp:Panel>
        </div>
        <div class="col-md-3">
            <h4 align="center">Jeton avec intérêt :</h4>
        </div>
        <div class="col-md-3">
            <h4 align="left"><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h4>
        </div>
    </div>
    <% if (nbrPayem >= 2)
        { %>
    <div class="col-md-12">
        <div class="col-md-3">
            <asp:Panel ID="Panel3" runat="server" align="center">
                <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
            </asp:Panel>
            <br/>
        </div>
        <div class="col-md-3">
            <asp:Panel ID="Panel4" runat="server" align="center">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </asp:Panel>
        </div>
        <div class="col-md-3">
            <h4 align="center">Jeton avec intérêt :</h4>
        </div>
        <div class="col-md-3">
            <h4 align="left"><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></h4>
        </div>
    </div>
    <% if (nbrPayem >= 3)
        { %>
    <div class="col-md-12">
        <div class="col-md-3">
            <asp:Panel ID="Panel5" runat="server" align="center">
                <asp:Calendar ID="Calendar3" runat="server"></asp:Calendar>
            </asp:Panel>
            <br/>
        </div>
        <div class="col-md-3">
            <asp:Panel ID="Panel6" runat="server" align="center">
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </asp:Panel>
        </div>
        <div class="col-md-3">
            <h4 align="center">Jeton avec intérêt :</h4>
        </div>
        <div class="col-md-3">
            <h4 align="left"><asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></h4>
        </div>
    </div>
    <% if (nbrPayem >= 4) { %>
    <div class="col-md-12">
        <div class="col-md-3">
            <asp:Panel ID="Panel7" runat="server" align="center">
                <asp:Calendar ID="Calendar4" runat="server"></asp:Calendar>
            </asp:Panel>
            <br/>
        </div>
        <div class="col-md-3">
            <asp:Panel ID="Panel8" runat="server" align="center">
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </asp:Panel>
        </div>
        <div class="col-md-3">
            <h4 align="center">Jeton avec intérêt :</h4>
        </div>
        <div class="col-md-3">
            <h4 align="left"><asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></h4>
        </div>
    </div>
    <% 
                }
            }
        }
    %>
    <div class="col-md-12">
        <div class="col-md-3">
            
        </div>
        <div class="col-md-3">
            <asp:Panel ID="Panel9" runat="server" align="center">
                <asp:Button ID="Button1" runat="server" Text="Valider" OnClick="Button1_Click" Width="128px" />
            </asp:Panel>
        </div>
        <div class="col-md-6">
            <asp:Panel ID="Panel10" runat="server" align="center">
                <asp:Button ID="Button2" runat="server" Text="Accepter" Width="128px" OnClick="Button2_Click" />
            </asp:Panel>
        </div>
    </div>
    <br />
    </form>
</body>
</html>
