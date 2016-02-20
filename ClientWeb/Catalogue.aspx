<%@ page title="" language="C#" masterpagefile="~/General.Master" autoeventwireup="true" codebehind="Catalogue.aspx.cs" inherits="ClientWeb.Catalogue" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:content id="Content4" contentplaceholderid="main" runat="server">

    <figure>
    </figure>

<form id="form2" runat="server">
  
        <div id="main">
            <div class="container wrap">

				<div id="searchform" class="panel">
					<div class="marger">
                        <asp:Label ID="dbg" runat="server" Text="Label"></asp:Label>
						<input type="checkbox" id="searchtype" checked name="searchtype" value="simple" />
						<div id="simpleSearch">
						
							<div class="flex-line">

									<asp:TextBox ID="RechercheTitre_simple" class="boxinput extend" AutoPostBack="false" runat="server" />
                                
									<asp:Button Text="Rechercher" class="boxsubmit" runat="server" />

							</div>

							<hr />

							<label class="serachtype_selector" for="searchtype">Recherche avancée</label>

						</div>
						

						<div id="advancedSearch">
									


							<label class="serachtype_selector" for="searchtype">Revenir à la recherche simple</label>
							<hr />
							<asp:Button Text="Rechercher" class="boxsubmit" runat="server" />
							<hr />

							<fieldset>
								<legend>Informations générales</legend>

								<table>
									<tr>
										<td>Titre</td>
										<td>
											<asp:TextBox ID="RechercheTitre_adv" class="boxinput" AutoPostBack="false" runat="server" />
										</td>
									</tr>
									<tr>
										<td>Description</td>
										<td>
											<asp:TextBox ID="RechercheDescription"  class="boxinput" AutoPostBack="false" runat="server" />
										</td>
									</tr>
									<tr>
										<td>Type</td>
										<td>
											<asp:DropDownList ID="DropDownListTypeBien"  class="boxdropdown" type="number" runat="server">
											</asp:DropDownList>										</td>
									</tr>
								</table>

							</fieldset>

							<fieldset>
								<legend>Lieux</legend>

								<table>
									<tr>
										<td>Adresse</td>
										<td>
											<asp:TextBox ID="RechercheAdresse" class="boxinput" AutoPostBack="false" runat="server" />
										</td>
									</tr>
									<tr>
										<td>Code postale</td>
										<td>
											<asp:TextBox ID="RechercheCodePostal"  class="boxinput" type="number" AutoPostBack="false" runat="server" />
										</td>
									</tr>
									<tr>
										<td>Ville</td>
										<td>
											<asp:TextBox ID="RechercheVille"  class="boxinput" type="number" AutoPostBack="false" runat="server" />
										</td>
									</tr>

								</table>

							</fieldset>

							<fieldset>
								<legend>Prix (€)</legend>

								<table>
									<tr>
										<td>Minimum</td>
										<td>
											<asp:TextBox ID="RecherchePrixMin" class="boxinput" type="number" AutoPostBack="false" runat="server" />
										</td>
									</tr>
									<tr>
										<td>Maximum</td>
										<td>
											<asp:TextBox ID="RecherchePrixMax" class="boxinput" type="number" AutoPostBack="false" runat="server" />
										</td>
									</tr>

								</table>

							</fieldset>

							<fieldset>
								<legend>Surface (m²)</legend>

								<table>
									<tr>
										<td>Minimum</td>
										<td>
											<asp:TextBox ID="RechercheSurfaceMin" class="boxinput" type="number" AutoPostBack="false" runat="server" />
										</td>
									</tr>
									<tr>
										<td>Maximum</td>
										<td>
											<asp:TextBox ID="RechercheSurfaceMax" class="boxinput" type="number"  AutoPostBack="false" runat="server" />
										</td>
									</tr>

								</table>

							</fieldset>
							<fieldset>
								<legend>Nombre de pièces</legend>

								<table>
									<tr>
										<td>Minimum</td>
										<td>
											<asp:TextBox ID="RecherchePieceMin" class="boxinput" type="number" AutoPostBack="false" runat="server" />
										</td>
									</tr>
									<tr>
										<td>Maximum</td>
										<td>
											<asp:TextBox ID="RecherchePieceMax" class="boxinput" type="number" AutoPostBack="false" runat="server" />
										</td>
									</tr>

								</table>

							</fieldset>
							<fieldset>
								<legend>Nombres d'étages</legend>

								<table>
									<tr>
										<td>Minimum</td>
										<td>
											<asp:TextBox ID="RechercheEtageMin" class="boxinput" type="number" AutoPostBack="false" runat="server" />
										</td>
									</tr>
									<tr>
										<td>Maximum</td>
										<td>
											 <asp:TextBox ID="RechercheEtageMax" class="boxinput" type="number" AutoPostBack="false" runat="server" />
										</td>
									</tr>

								</table>

							</fieldset>
							<fieldset>
								<legend>Chauffage</legend>

								<table>
									<tr>
										<td>Type</td>
										<td>
											<asp:DropDownList ID="DropDownListTypeChauffage" class="boxdropdown" runat="server">
											</asp:DropDownList>
										</td>
									</tr>
                                    <tr>
										<td>Type d'énergie</td>
										<td>
											<asp:DropDownList ID="DropDownListEnergieChauffage" class="boxdropdown" runat="server">
											</asp:DropDownList>
										</td>
									</tr>

								</table>

							</fieldset>

							<hr />
							<asp:Button Text="Rechercher" class="boxsubmit" runat="server" />
							<hr />

						</div>

					</div>
				</div>

</form>

                <div class="row">

                    <asp:Repeater ID="rpResultats" runat="server">
					<ItemTemplate>
                     
						<div class="tilecolumn">
                            <asp:Label visible="false" ID="IsImage" Text='<%# Eval("PhotoPrincipaleBase64").ToString().CompareTo("") == 0 ? "False" : "True"%>' runat="server"></asp:Label>
                            <%    
                                   if (true==false)
                                   { // Il n'y a pas de photo

                            %>
                            <a href=<%# "/Bien.aspx?id="+Eval("Id").ToString()%> class="tile" style="background-image:url(/images/AucuneImage.jpg)">
                            <% 
                                }
                                else
                                {
                            %>
                                <a href=<%# "/Bien.aspx?id="+Eval("Id").ToString()%> class="tile" style="background-image:<%# "url(data:image/png;base64,"+ Eval("PhotoPrincipaleBase64")+ ")" %>">
                            <%
                                }
                            %>

							
								<div class="informations">
									<div class="title">
										<div class="onerow"><span><%# Eval("Titre") %></span></div>
									</div>
									<div class="clear">
										<div class="onerow" class="onerow"><span><%# Eval("Ville") %></span></div>
									</div>
									<div class="clear">
										<div class="tworow">xx m²</div>
										<div class="tworow"><%# ((double)Eval("Prix")==0) ? "Pas de prix" : Eval("Prix").ToString() %></div>
									</div>
									<div class="clear">
										<div class="on">
											<div class="tworow">5<sup>ème</sup> étage</div>
											<div class="tworow">6 pièces<sup>&nbsp;</sup></div>
										</div>
										<div class="off">
											<div class="center onerow"><span>Cliquer pour en voir plus<sup>&nbsp;</sup></span></div>
										</div>
									</div>
								
								</div>
							</a>
					
						</div>

					</ItemTemplate>
					<SeparatorTemplate>
					</SeparatorTemplate>
				</asp:Repeater>

                </div>

                <div class="clear"></div>

            </div>


        </div>
    
</asp:content>
