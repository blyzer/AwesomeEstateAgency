<%@ page title="" language="C#" masterpagefile="~/General.Master" autoeventwireup="true" codebehind="Connexion.aspx.cs" inherits="ClientWeb.Connexion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:content id="Content2" contentplaceholderid="main" runat="server">

    <figure></figure>

    <form id="form2" runat="server">
        <div id="main">
			<div class="container wrap">
				<div id="userform" class="panel">
					<div class="marger">
						<h3>Connexion</h3>

						<asp:TextBox ID="Email" placeholder="Addresse e-mail" class="boxinput" AutoPostBack="false" runat="server"  />
						<asp:TextBox TextMode="Password" ID="Password" class="boxinput" placeholder="Mot de passe"  AutoPostBack="false" runat="server"  />

						<asp:Button class="boxsubmit" Text="Connexion" runat="server" />

						<hr />

						<a href="Inscription.aspx">Vous n'avez pas de compte ? Inscrivez-vous !</a>
					</div>
				</div>
			</div>
			<div class="clear"></div>
		</div>
	</form>

</asp:content>
