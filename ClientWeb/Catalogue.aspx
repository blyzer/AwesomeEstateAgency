<%@ Page Title="" Language="C#" MasterPageFile="~/General.Master" AutoEventWireup="true" CodeBehind="Catalogue.aspx.cs" Inherits="ClientWeb.Catalogue" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <figure></figure>

    <form id="form2" runat="server">
        <div id="main">
            <div class="tilecontainer wrap">

                <h2>Les derniers biens</h2>

                <div class="row">

                    <asp:TextBox ID="Recherche" class="" AutoPostBack="false" runat="server" />
                    <asp:Button Text="Recherche" runat="server" />

                    <h3>Recherche :</h3>
                    <asp:TextBox ID="TextBox1" AutoPostBack="false" runat="server" />
                    <br />
                    <h3>Recherche avancée:</h3>
                    <br />
                    <p>RechercheAdresse:</p>
                    <asp:TextBox ID="RechercheAdresse" class="" AutoPostBack="false" runat="server" />
                    <br />
                    <p>RechercheCodePostal:</p>
                    <asp:TextBox ID="RechercheCodePostal" class="" AutoPostBack="false" runat="server" />
                    <br />
                    <p>RechercheDescription:</p>
                    <asp:TextBox ID="RechercheDescription" class="" AutoPostBack="false" runat="server" />
                    <br />
                    <p>RechercheVille:</p>
                    <asp:TextBox ID="RechercheVille" class="" AutoPostBack="false" runat="server" />
                    <br />
                    
                    

                    <p>Prix min :</p>
                    <asp:TextBox ID="RecherchePrixMin" AutoPostBack="false" runat="server" />
                    <p>Prix max :</p>
                    <asp:TextBox ID="RecherchePrixMax" AutoPostBack="false" runat="server" />

                    <p>Surface min :</p>
                    <asp:TextBox ID="RechercheSurfaceMin" AutoPostBack="false" runat="server" />
                    <p>Surface max :</p>
                    <asp:TextBox ID="RechercheSurfaceMax" AutoPostBack="false" runat="server" />

                    <p>NbEtage min :</p>
                    <asp:TextBox ID="RechercheEtageMin" AutoPostBack="false" runat="server" />
                    <p>NbEtage max :</p>
                    <asp:TextBox ID="RechercheEtageMax" AutoPostBack="false" runat="server" />

                    <p>NbPiece min :</p>
                    <asp:TextBox ID="RecherchePieceMin" AutoPostBack="false" runat="server" />
                    <p>NbPiece max :</p>
                    <asp:TextBox ID="RecherchePieceMax" AutoPostBack="false" runat="server" />
                    

                    <p>Type Bien :</p>
                    <asp:DropDownList ID="DropDownListTypeBien" runat="server">
                    </asp:DropDownList>
                    <p>Type Chauffage :</p>
                    <asp:DropDownList ID="DropDownListTypeChauffage" runat="server">
                    </asp:DropDownList>
                    <br />
                    <asp:Button Text="Recherche" runat="server" />


                    <asp:Repeater ID="rpResultats" runat="server">
                        <ItemTemplate>

                            <div class="tilecolumn">

                                <a href="" class="tile" style="background-image: url(<%# "data:image/png;base64,"+ Eval("PhotoPrincipaleBase64") %>);">
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

            </div>


        </div>
    </form>
</asp:Content>