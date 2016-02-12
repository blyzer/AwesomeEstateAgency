<%@ page title="" language="C#" masterpagefile="~/General.Master" autoeventwireup="true" codebehind="Default.aspx.cs" inherits="ClientWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:content id="Content2" contentplaceholderid="main" runat="server">


	<figure class="fullscreen">
		<h1>L'incroyable agence immobilière !</h1>
		<div id="searchbox">
			<form action="Catalogue.aspx" runat="server">
				<asp:TextBox ID="Searchterm" placeholder="Quel est votre rêve ?" class="" AutoPostBack="false" runat="server"  />
				<asp:Button Text="&#x1f50d;" runat="server" />
			</form>
		</div>
	</figure>
		

	<div id="main">
		<div class="tilecontainer wrap">
			
			<h2>Les derniers biens</h2>
			
			<div class="row">


				<asp:Repeater ID="rpResultats" runat="server">
					<ItemTemplate>

						<div class="tilecolumn">
					
							<a href="" class="tile" style="background-image:<%# "url(data:image/png;base64,"+ Eval("PhotoPrincipaleBase64")+ ")" %>">
								<div class="informations">
									<div class="title">
										<div class="onerow"><span><%# Eval("Titre") %></span></div>
									</div>
									<div class="clear">
										<div class="onerow" class="onerow"><span>&#x1F3E0; New York city STATE, 42 Wallstreet av</span></div>
									</div>
									<div class="clear">
										<div class="tworow">65 m²</div>
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
				
			<div id="more">
				<a href="">Tout notre catalogue</a>
			</div>
				
		</div>
			

	</div>

</asp:content>
