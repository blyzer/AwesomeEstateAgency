<%@ page title="" language="C#" masterpagefile="~/General.Master" autoeventwireup="true" codebehind="Ajouter.aspx.cs" inherits="ClientWeb.Ajouter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:content id="Content2" contentplaceholderid="main" runat="server">
	<figure></figure>

	<div id="main">
		<div id="add" class="container wrap panel">
			

			<h1>Ajouter un bien</h1>

			<hr />

            <form id="form2" runat="server">
<div class="categories">
			<div class="category">
			<fieldset>
				<legend>Votre bien</legend>

				<table>
					<tr>
						<td>Type</td>
					<td>
						<asp:DropDownList ID="DropDownListTypeBien"  class="boxdropdown" type="number" runat="server">
						</asp:DropDownList>	

					</td>
					</tr>
					<tr>
						<td>Titre</td>
						<td>
							<asp:TextBox ID="Titre" class="boxinput extend" AutoPostBack="false" runat="server" />
						</td>
					</tr>
				</table>
			</fieldset>
			</div>

    <div class="category">
			<fieldset>
				<legend>Image</legend>
                <asp:FileUpload ID="Image" runat="server" />
			</fieldset>
			</div>

			<div class="category">
			<fieldset>
				<legend>Prix</legend>

				<table>
					<tr>
						<td>Prix :</td>
						<td>
							<asp:TextBox ID="Prix" class="boxinput" type="number" AutoPostBack="false" runat="server" />
						</td>
					</tr>
					<tr>
						<td>Montant des charges :</td>
						<td>
							<asp:TextBox ID="MontantCharges" class="boxinput" type="number" AutoPostBack="false" runat="server" />
						</td>
					</tr>
                    <tr>
						<td>Type de transaction :</td>
						<td>
							<asp:DropDownList ID="DropDownListTypeTransaction"  class="boxdropdown" type="number" runat="server">
                                </asp:DropDownList>	
						</td>
					</tr>
				</table>
			</fieldset>
                </div>
    <div class="category">
                <fieldset>
				<legend>Coordonnées</legend>

				<table>
					<tr>
						<td>Ville</td>
						<td>
							<asp:TextBox ID="Ville" class="boxinput extend" AutoPostBack="false" runat="server" />
						</td>
					</tr>
					<tr>
						<td>Code postal</td>
						<td>
							<asp:TextBox ID="CP" class="boxinput extend" AutoPostBack="false" runat="server" />
						</td>
					</tr>
					<tr>
						<td>Adresse</td>
						<td>
							<asp:TextBox ID="Adresse" class="boxinput extend" AutoPostBack="false" runat="server" />
						</td>
					</tr>
				</table>
			</fieldset>

			</div>
    			<div class="category">
			<fieldset>
				<legend>Informations générale</legend>

				<table>
					<tr>
						<td>Surface</td>
						<td>
							<asp:TextBox ID="Surface" class="boxinput" type="number" AutoPostBack="false" runat="server" />
						</td>
					</tr>
					<tr>
						<td>Nombre d'etage</td>
						<td>
							<asp:TextBox ID="NombreEtage" class="boxinput" type="number" AutoPostBack="false" runat="server" />
						</td>
					</tr>
					<tr>
						<td>Etages numero</td>
						<td>
							<asp:TextBox ID="NumeroEtage" class="boxinput" type="number" AutoPostBack="false" runat="server" />
						</td>
					</tr>
                    <tr>
						<td>Nombre de pieces</td>
						<td>
							<asp:TextBox ID="NombrePiece" class="boxinput" type="number" AutoPostBack="false" runat="server" />
						</td>
					</tr>
				</table>
			</fieldset>
                    </div>
                <fieldset>
				<legend>Description</legend>
                    <asp:TextBox id="Description" rows="5" TextMode="multiline" runat="server" />
			</fieldset>

			</div>			<div class="category">
			<fieldset>
				<legend>Chauffage</legend>

				<table>
					<tr>
						<td>Type</td>
					<td>
						<asp:DropDownList ID="DropDownListTypeChauffage"  class="boxdropdown" type="number" runat="server">
						</asp:DropDownList>	

					</td>
					</tr>
					<tr>
						<td>Energie</td>
					<td>
						<asp:DropDownList ID="DropDownListEnergieChauffage"  class="boxdropdown" type="number" runat="server">
						</asp:DropDownList>	

					</td>
				</table>
			</fieldset>
			</div>

				<div class="clear"></div>

			<hr />

			<div id="submit" class="clear">

				<input type="submit" value="Ajouter"  class="boxsubmit"/>

			</div>

				<div class="clear"></div>
</div>
                </form>
			</div>
		

	</div>
</asp:content>
