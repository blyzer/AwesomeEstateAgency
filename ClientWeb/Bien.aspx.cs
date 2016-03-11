using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWeb
{
    public partial class Bien : System.Web.UI.Page
    {
        public string BienTitre;
        public string BienAdresse;
        public string BienCP;
        public string BienDesc;
        public string BienPrix;
        public string BienVille;
        public string BienDateMiseEnTransaction;
        public string BienEnergieChauffage;
        public string BienMontantCharges;
        public string BienNbEtages;
        public string BienNbPieces;
        public string BienNumEtage;
        public string BienSurface;
        public string BienTypeChauffage;
        public string BienTypeBien;
        public string BienImage;
        public string BienImage1;
        public string BienImage2;
        public string BienImage3;

        protected void Page_Load(object sender, EventArgs e)
        {
			if (IsPostBack)
			{
				if (Nom.Text.Length > 0 && Email.Text.Length > 0 && Numero.Text.Length > 0 && Message.Text.Length > 0)
				{

					Console.Write(Nom.Text);
					Console.Write(Email.Text);
					Console.Write(Numero.Text);
					Console.Write(Message.Text);
				}
			}

            ServiceAgence.BienImmobilier bien;
            using (ServiceAgence.AgenceClient client = new ServiceAgence.AgenceClient())
            {
				if (IsPostBack)
				{
                    /*
					SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

					smtpClient.Port = 587;
					smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
					smtpClient.UseDefaultCredentials = false;
					System.Net.NetworkCredential credentials =
						new System.Net.NetworkCredential("kyx.team@gmail.com", "");
					smtpClient.EnableSsl = true;
					smtpClient.Credentials = credentials;

					MailMessage mail = new MailMessage();

					//Setting From , To and CC
					mail.From = new MailAddress("contact@awesome-estate-agency.com", "The Awesome Estate Agency");
					mail.To.Add(new MailAddress(Email.Text));
					mail.Subject = "yolo";
					mail.Body = "Hé ho ! Yolo ! Hé hé !";

					smtpClient.Send(mail);
                    
                    */
                    EnvoyerMail();


                }

                client.Open();

                ServiceAgence.ResultatBienImmobilier res = client.LireDetailsBienImmobilier(Request.QueryString["id"]);
                bien = res.Bien;
                if (bien == null)
                {
                    Response.Redirect("~/erreur.aspx");
                }

                //Titre :
                BienTitre = bien.Titre.ToString();

                //Info generale :
                BienTypeBien = bien.TypeBien.ToString();
                BienNbEtages = bien.NbEtages.ToString();
                BienNbPieces = bien.NbPieces.ToString();
                BienSurface = bien.Surface.ToString() + " m²";

                //Prix :
                BienMontantCharges = bien.MontantCharges.ToString() + " €";
                BienPrix = bien.Prix.ToString() + " €";

                //Coordonnées :
                BienAdresse = bien.Adresse.ToString();
                BienCP = bien.CodePostal.ToString();
                BienVille = bien.Ville.ToString();

                //Description :
                BienDesc = bien.Description.ToString();

                //Chauffage :
                BienEnergieChauffage = bien.EnergieChauffage.ToString();
                BienTypeChauffage = bien.TypeChauffage.ToString();

                //Info complémentaires :
                BienDateMiseEnTransaction = bien.DateMiseEnTransaction.ToString();
                BienNumEtage = bien.NumEtage.ToString();

                //Image :
                BienImage = bien.PhotoPrincipaleBase64;
                try
                {
                    if (bien.PhotosBase64.ElementAt(0) != "")
                        BienImage1 = bien.PhotosBase64.ElementAt(0);
                }
                catch(ArgumentOutOfRangeException)
                {
                    BienImage1 = "";
                }

                try
                {
                    if (bien.PhotosBase64.ElementAt(1) != "")
                        BienImage2 = bien.PhotosBase64.ElementAt(1);
                }
                catch (ArgumentOutOfRangeException)
                {
                    BienImage2 = "";
                }

                try
                {
                    if (bien.PhotosBase64.ElementAt(2) != "")
                        BienImage3 = bien.PhotosBase64.ElementAt(2);
                }
                catch (ArgumentOutOfRangeException)
                {
                    BienImage3 = "";
                }

                client.Close();
            }
        }

        private bool EnvoyerMail()
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            System.Net.Mail.MailAddress expediteur = new System.Net.Mail.MailAddress(Email.Text);
            System.Net.Mail.MailAddress destinataire = new System.Net.Mail.MailAddress("anthony.loup01@gmail.com");


            // Adresse mail de l'expediteur
            message.From = expediteur;
            // Adresse mail du destinataire
            message.To.Add(destinataire);
            // Sujet
            message.Subject = "Contact TAE";
            // Corps
            message.IsBodyHtml = true;
            message.Body = @"<html><head></head><body><p>"+ "Message de : "+Nom.Text+"<br/>"+Message.Text+"<br/>"+"Numero de telephone :"+Numero.Text+"</p></body></html>";

            // Client SMTP
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 25);
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("aspbronet@gmail.com", "aspbronet01");

            // Envoi du message
            client.Send(message);

            return true;
        }


    }
}