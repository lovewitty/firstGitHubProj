using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBEntity;

public partial class GetNewActId : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var de = DateTime.Now;
        if (!DateTime.TryParse(Request.QueryString["de"], out de)) { Response.Write("0"); Response.End(); return; }
        //最新活动
        var ect = new Tab_Activity().ListAll("select top 1 * from Tab_Activity where '" +
            de.ToString("yyyy-MM-dd HH:mm:ss")
            +"' between activityStartDate and ActivityEndDate order by Idx Desc");
        //当天无活动
        if (null == ect || ect.Count() < 1) { Response.Write("0"); Response.End(); return; }
        Response.Write(ect.First().Idx.ToString()); Response.End();
    }
}