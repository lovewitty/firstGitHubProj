using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminManage_AdvertisementEditMagazine : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            DBEntity.Tab_magazineHomeAd ent = new DBEntity.Tab_magazineHomeAd();
            ent = ent.Get("1");
            this.BrowserUrl.Text = ent.BrowserUrl;
            this.DownlowdRarPath.Text = ent.DownlowdRarPath;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DBEntity.Tab_magazineHomeAd ent = new DBEntity.Tab_magazineHomeAd();
        ent.Idx = 1;
        ent.BrowserUrl = this.BrowserUrl.Text;
        ent.DownlowdRarPath = this.DownlowdRarPath.Text;
        ent.Update(ent);

        Cmn.Js.ShowAlert("操作成功！");
        Cmn.Js.ExeScript("location.href='AdvertisementEditMagazine.aspx'");
    }
}