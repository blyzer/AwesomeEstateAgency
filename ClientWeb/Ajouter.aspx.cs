using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWeb
{
	public partial class Ajouter : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!this.IsPostBack)
            {
                Catalogue obj= new Catalogue();
                obj.Load_DropDownListItem<ServiceAgence.BienImmobilierBase.eTypeBien>(DropDownListTypeBien, false);
                obj.Load_DropDownListItem<ServiceAgence.BienImmobilierBase.eTypeChauffage>(DropDownListTypeChauffage, false);
                obj.Load_DropDownListItem<ServiceAgence.BienImmobilierBase.eEnergieChauffage>(DropDownListEnergieChauffage, false);

                DropDownListTypeBien.SelectedValue = "0";
                DropDownListEnergieChauffage.SelectedValue = "0";
                DropDownListTypeChauffage.SelectedValue = "1";

            }
        }
	}
}