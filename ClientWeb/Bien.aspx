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
				
				<div class="title"><asp:Label ID="BienTitre" runat="server" Text="BienTitre"></asp:Label></div>
			</div>

			<div id="infos">

				<div class="info">
					<fieldset>
						<legend>Information générale</legend>
						<table>
							<tr>
								<td>Id :</td>
								<td>leul</td>
							</tr>
							
						</table>
					</fieldset>
				</div>
				<div class="info">
					<fieldset>
						<legend>Description</legend>
						<asp:Label ID="BienDesc" runat="server" Text="BienDesc"></asp:Label>
					</fieldset>
				</div>
				<div class="info">
					<fieldset>
						<legend>Coordonnées</legend>
						<table>
							<tr>
								<td>Adresse :</td>
								<asp:Label ID="BienAdresse" runat="server" Text="BienAdresse"></asp:Label>
							</tr>
							<tr>
								<td>Code Postal : </td>
								<asp:Label ID="BienCP" runat="server" Text="BienCP"></asp:Label>
							</tr>
						</table>
					</fieldset>
				</div>
				<div class="info">
					<fieldset>
						<legend>Information générale</legend>
						<table>
							<tr>
								<td>habba</td>
								<td>babba</td>
							</tr>
							<tr>
								<td>habba</td>
								<td>babba</td>
							</tr>
						</table>
					</fieldset>
				</div>
				<div class="info">
					<fieldset>
						<legend>Information générale</legend>
						<table>
							<tr>
								<td>habba</td>
								<td>babba</td>
							</tr>
							<tr>
								<td>habba</td>
								<td>babba</td>
							</tr>
						</table>
					</fieldset>
				</div>
				<div class="info">
					<fieldset>
						<legend>Information générale</legend>
						<table>
							<tr>
								<td>habba</td>
								<td>babba</td>
							</tr>
							<tr>
								<td>habba</td>
								<td>babba</td>
							</tr>
						</table>
					</fieldset>
				</div>

			</div>

			<div class="clear"></div>

		</div>
	</div>
</asp:Content>
