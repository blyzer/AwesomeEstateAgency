<%@ page title="" language="C#" masterpagefile="~/General.Master" autoeventwireup="true" codebehind="Administration.aspx.cs" inherits="ClientWeb.Administration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:content id="Content2" contentplaceholderid="main" runat="server">
	<figure></figure>
	<form id="form" runat="server">

        <div id="main">
			<div class="container wrap">
				<div id="adminform" class="panel">
					<div class="marger">

						<fieldset>
							<legend>Filtrer</legend>
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
				</div>
						</fieldset>
						<div id="result">

							<asp:GridView ID="gvDisplay" runat="server" AutoGenerateColumns="false"
								OnRowEditing="gvDisplay_RowEditing"
								OnRowCancelingEdit="gvDisplay_RowCancelingEdit"
								OnRowUpdating="gvDisplay_RowUpdating"
								OnRowDeleting="gvDisplay_RowDeleting"
								>
								<Columns>

									<asp:TemplateField HeaderText="Id">
										<ItemTemplate>
											
											<asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>' />

										</ItemTemplate>

									</asp:TemplateField>

									<asp:TemplateField HeaderText="Titre">
										<ItemTemplate>
											
											<%# Eval("Titre") %>

										</ItemTemplate>
										<EditItemTemplate>
											<div class="flex-row">
												<asp:TextBox class="boxinput extend" ID="txtTitre" Text='<%# Eval("Titre") %>' runat="server" />
											</div>
										</EditItemTemplate>
									</asp:TemplateField>



									<asp:TemplateField HeaderText="Prix">
										<ItemTemplate>
											
											<%# Eval("Prix") + " €" %>

										</ItemTemplate>
										<EditItemTemplate>
											<div class="flex-row">
												<asp:TextBox class="boxinput extend" ID="txtPrix" Text='<%# Eval("Prix") %>' runat="server" />
											</div>
										</EditItemTemplate>
									</asp:TemplateField>

									<asp:TemplateField HeaderText="MontantCharges">
										<ItemTemplate>
											
											<%# Eval("MontantCharges") + " €" %>

										</ItemTemplate>
										<EditItemTemplate>
											<div class="flex-row">
												<asp:TextBox class="boxinput extend" ID="txtMontantCharges" Text='<%# Eval("MontantCharges") %>' runat="server" />
											</div>
										</EditItemTemplate>
									</asp:TemplateField>



									<asp:TemplateField HeaderText="Actions">
										<ItemTemplate>
											<div class="flex-line">


											<input type="button" value="" class="boxsubmit extend marged viewBtn" onclick="location.href = 'Bien.aspx?id=<%# Eval("Id") %>';" />

											<asp:Button ID="lnkEdit" text="" class="boxsubmit extend marged editBtn"
												CommandName="Edit" runat="server"></asp:Button>

											<asp:Button ID="lnkDelete" text="" class="boxsubmit extend marged deleteBtn" 
												CommandName="Delete" runat="server"></asp:Button>
                                            </div>
										</ItemTemplate>
										<EditItemTemplate>
											<div class="flex-line">
											<asp:Button ID="lnkSave" text="" class="boxsubmit extend marged saveBtn" 
												CommandName="Update" runat="server"></asp:Button>

											<asp:Button ID="lnkCancel" text="" class="boxsubmit extend marged cancelBtn"
												CommandName="Cancel" runat="server"></asp:Button>
										
										</div>
										</EditItemTemplate>
									</asp:TemplateField>



								</Columns>

							</asp:GridView>

						

						</div>
					</div>
				</div>
			</div>
		</div>
		
	</form>

</asp:content>
