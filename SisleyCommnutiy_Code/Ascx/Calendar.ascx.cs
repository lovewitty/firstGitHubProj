using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBEntity;

public partial class Ascx_Calendar : System.Web.UI.UserControl
{
    public int artId = 0;//最新创建的文章Id
    public int actyId = 0;//最新活动Id

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //最新文章
            var ets = new Tab_Article().ListAll("select top 1 * from Tab_Article where HomeShowsBool='Yes' order by 1 desc");
            if (null != ets && ets.Count() > 0) artId = ets.First().Idx.Value;
            
        }
    }
}