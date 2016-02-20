<%@ Page Title="" Language="C#" MasterPageFile="~/General.Master" AutoEventWireup="true" CodeBehind="Bien.aspx.cs" Inherits="ClientWeb.Bien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
	<figure></figure>

	<div id="main">
		<div id="good" class="container wrap panel">

			<div class="image">
				<div id="look">&#x2B1C;</div>
				<div style="background-image:url(/images/jumbotron.jpg)" class="background"></div>
				<img src="/images/jumbotron.jpg" />
				
				<div class="title"><%= this.BienTitre.ToString() %></div>
			</div>

			<div id="infos" class="categories">

				<div class="category">
					<fieldset>
						<legend>Information générale</legend>
						<table>
							<tr>
								<td>Id :</td>
								<td><%=Request.QueryString["id"]%></td>
							</tr>
                            <tr>
								<td>Type de bien :</td>
                                <td><%= this.BienTypeBien%></td>
							</tr>
                            <%
                                if (Convert.ToInt32(this.BienNbEtages) != 0)
                                {
                            %>
                                <tr>
								<td>Nombre d'étages :</td>
                                <td><%= this.BienNbEtages%></td>
							    </tr>
                            <%
                                }
                            %>

                            <%
                                if (Convert.ToInt32(this.BienNbPieces) != 0)
                                {
                            %>
                                <tr>
								<td>Nombre de pièces :</td>
                                <td><%= this.BienNbPieces%></td>
							    </tr>
                            <%
                                }
                            %>
                            <tr>
								<td>Surface :</td>
                                <td><%= this.BienSurface%></td>
							</tr>
						</table>
					</fieldset>
				</div>
				<div class="category">
					<fieldset>
						<legend>Description</legend>
						<td><%= this.BienDesc %></td>
					</fieldset>
				</div>
				<div class="category">
					<fieldset>
						<legend>Coordonnées</legend>
						<table>

                            <tr>
								<td>Ville : </td>
								<td><%= this.BienVille %></td>
							</tr>

							<tr>
                                <td>Adresse : </td>
								<td><%= this.BienAdresse %></td>
							</tr>
                            
							<tr>
								<td>Code Postal : </td>
								<td><%= this.BienCP %></td>
							</tr>
                            
						</table>
					</fieldset>
				</div>
				<div class="category">
					<fieldset>
						<legend>Prix</legend>
						<table>
							<tr>
								<td>Prix : </td>
								<td><%= this.BienPrix%></td>
							</tr>
							<tr>
                                <td>Montant des charges : </td>
                                <td><%= this.BienMontantCharges%></td>
							</tr>
						</table>
					</fieldset>
				</div>
				<div class="category">
					<fieldset>
						<legend>Chauffage</legend>
						<table>
                            <tr>
                                <td>Type : </td>
                                <td><%= this.BienTypeChauffage%></td>
							</tr>
							<tr>
								<td>Energie : </td>
								<td><%= this.BienEnergieChauffage%></td>
							</tr>
						</table>
					</fieldset>
				</div>
				<div class="category">
					<fieldset>
						<legend>Info complémentaires</legend>
						<table>
							<tr>
                                <td>Mise en ligne le : </td>
                                <td><%= this.BienDateMiseEnTransaction%></td>
							</tr>
                            <%
                                if (Convert.ToInt32(this.BienNumEtage) != 0)
                                {
                            %>
							<tr>
								<td>Etage numero : </td>
								<td><%= this.BienNumEtage%></td>
							</tr>
                            <%
                                }
                            %>
						</table>
					</fieldset>
				</div>

			</div>

			<div class="clear"></div>

		</div>
	</div>
</asp:Content>
