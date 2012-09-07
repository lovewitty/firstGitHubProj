using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBEntity;

public partial class exchange_record : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VerfiyAdmin.CheckVIPUserLogin(this);
    }

    

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
           var lbl= e.Item.FindControl("lblState") as Label;
           
           var da = e.Item.DataItem as Tab_Order4Total;
           if (null != lbl && da!=null)
           {
               switch (da.OrderStatus)
               {
                   case "":
                       lbl.Text = "未处理";
                       break;
                   case "1":
                       lbl.Text = "全部成功";
                       break;
                   case "2":
                       lbl.Text = "全部失败";
                       break;
                   case "3":
                       lbl.Text = "部分成功";
                       break;
                   default:
                       break;
               }
           }
           var lblCreatedate = e.Item.FindControl("lblCreateDate") as Label;
           if (null != lblCreatedate && da != null)
               lblCreatedate.Text = da.DateCreated.Value.ToString("yyyy年MM月dd日 HH时mm分");
        }
    }
}