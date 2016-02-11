<%@ Page Title="" Language="C#" MasterPageFile="~/General.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ClientWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:TextBox ID="Recherche"  AutoPostBack="false" runat="server" />
    <asp:TextBox ID="RechercheAPrixMin"  AutoPostBack="false" runat="server" />
    <asp:TextBox ID="RechercheAPrixMax"  AutoPostBack="false" runat="server" />
    <asp:Button Text="Recherche" runat="server" />

    <asp:Repeater ID="rpResultats" runat="server">
        <ItemTemplate>
            <table>
                <tr>
                    <td>Titre :</td>
                    <td><%# Eval("Titre") %></td>
                </tr>
                <tr>
                    <td>Img :</td>
                    <td><img src="<%# "data:image/png;base64,"+ Eval("PhotoPrincipaleBase64") %>" /></td>
                </tr>
                <tr>
                    <td>Titre :</td>
                    <td><%# ((double)Eval("Prix")==0) ? "Pas de prix" : Eval("Prix").ToString() %></td>
                </tr>
                

            </table>
        </ItemTemplate>
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>
    </asp:Repeater>



</asp:Content>
