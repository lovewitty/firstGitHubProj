using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class rule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            try
            {
                DBEntity.Tab_Advertisement ent = AdHelper.GetAd("Ad_rule1");
                DBEntity.Tab_Advertisement ent2 = AdHelper.GetAd("Ad_rule2");
                this.Ad_rule1.Text = string.Format(" <a href='{0}' target='_blank'><img src='upload/Advertisement/{1}' width='448' height='254'   /></a>", ent.Links, ent.AdImg);
                this.Ad_rule2.Text = string.Format(" <a href='{0}' target='_blank'><img src='upload/Advertisement/{1}' width='448' height='254'  /></a>", ent2.Links, ent2.AdImg);
            }
            catch (Exception ex)
            {
                Cmn.Log.Write(ex.ToString());
            }
        }
    }
}