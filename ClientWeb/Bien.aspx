<%@ Page Title="" Language="C#" MasterPageFile="~/General.Master" AutoEventWireup="true" CodeBehind="Bien.aspx.cs" Inherits="ClientWeb.Bien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
	<figure></figure>

	<div id="main">
		<div id="good" class="container wrap panel">
            <ul id="imgData">
                <% if (this.BienImage1 != null && this.BienImage1 != "")
                         { %>
                <li name=<% Response.Write("data:image/png;base64," + this.BienImage1);%>></li>
                <%} %>

                <% if (this.BienImage2 != null && this.BienImage2 != "")
                { %>
                <li name=<% Response.Write("data:image/png;base64," + this.BienImage2);%>></li>
                <%} %>


                <% if (this.BienImage3 != null && this.BienImage3 != "")
                         { %>
                <li name=<% Response.Write("data:image/png;base64," + this.BienImage3);%>></li>
                <%} %>

            </ul>
			<div class="image">
				
                 
				<!-- <div style="background-image:url(/images/jumbotron.jpg)" class="background"></div> -->
                <%
                    if (this.BienImage=="")
                    {

                %>
                <div style="background-color: #8bc34a;  background-image: url(/images/nothumbnail.png); background-position: 50% 75%;    background-repeat: no-repeat;  background-size: auto auto;" class="background"></div>
                <% 
                    }
                    else
                    {
                %>
				<div id="next">&gt;</div>
				<div id="look">&#x2B1C;</div>
				
                <div id="currImgBg" style=<% Response.Write("background-image:" + "url(data:image/png;base64," + this.BienImage + ")");%> class="background"></div>
				<img id="currImg" src="<% Response.Write("data:image/png;base64," +this.BienImage);%>" />
				

                <%
                    }
                %>
				<!--<img src=<% Response.Write("url(data:image/png;base64," + this.BienImage + ")");%> /> -->
				
				<div class="title"><%= this.BienTitre %></div>
			</div>

			<script>

				for (var i = 0; i < document.getElementById("imgData").children.length;i++) {

					if (document.getElementById("imgData").children[i].getAttribute("name").length < 100) {
						document.getElementById("imgData").removeChild(document.getElementById("imgData").children[i]);
					}
				}

				document.getElementById("next").onclick = function () { 

				var current_image = document.getElementById("currImg").src;

				var images = document.getElementById("imgData").children;

				var next_image = current_image;

				var curr_index = -2;

				for (var i = 0; i < images.length; i++) {

					if (images[i].getAttribute("name") == current_image) {
						curr_index = i;
						break;
					}

				}

				curr_index++;

				if (curr_index == -1)
					curr_index--;

				else if (curr_index == images.length)
					curr_index = 0;

				document.getElementById("currImg").src = images[curr_index].getAttribute("name");
				document.getElementById("currImgBg").style.backgroundImage = "url(" + images[curr_index].getAttribute("name") + ")";


				};

			</script>

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
						<td><span class="justify"><%= this.BienDesc %></span></td>
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
								<td>Énergie : </td>
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
								<td>Étage numéro : </td>
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

		<div id="contactform" class="container wrap panel">
			<h1>Contacter le vendeur</h1>
			<hr />
			<form id="form" runat="server">
			<div class="categories">

				<div class="category">
					<fieldset>
						<legend>Vos informations de contact</legend>
						<table>
							<tr>
								<td>Nom</td>
								<td>
									<asp:TextBox ID="Nom" class="boxinput" type="text" AutoPostBack="false" runat="server" />
								</td>
								<td id="contactclip" class="clip" rowspan="3">
									Vous n'avez jamais été si proche du bien de votre rêve
								</td>
							</tr>
							<tr>
								<td>E-mail</td>
								<td>
									<asp:TextBox ID="Email" class="boxinput" type="text" AutoPostBack="false" runat="server" />
								</td>
							</tr>
							<tr>
								<td>Numéro de téléphone</td>
								<td>
									<asp:TextBox ID="Numero" class="boxinput" type="text" AutoPostBack="false" runat="server" />
								</td>
							</tr>
							
						</table>
					</fieldset>
				</div>
				<div class="category">
					<fieldset>
						<legend>Votre message</legend>
						<asp:TextBox class="boxarea" id="Message" rows="5" TextMode="multiline" runat="server" />
					</fieldset>
				</div>

			</div>
			<div id="submit" class="clear">
				<input type="submit" value="Contacter"  class="boxsubmit"/>
			</div>
			</form>
			<div class="clear"></div>

		</div>
	</div>
</asp:Content>
