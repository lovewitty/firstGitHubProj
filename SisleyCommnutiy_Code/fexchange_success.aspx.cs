using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBEntity;

public partial class fexchange_success : System.Web.UI.Page
{
    protected decimal? UserAvaPoint = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        VerfiyAdmin.CheckVIPUserLogin(this);
        UserAvaPoint = VerfiyAdmin.LoginUser.AvailablePoints;
        if (!IsPostBack)
        {
            var Id = 0;
            var idx = Request["Id"];
            if (string.IsNullOrEmpty(idx) || !Int32.TryParse(idx, out Id)) return;
            var et = new Tab_Order4Total().Get(Id.ToString());
            if (null == et) return;
            lblOrdNo.Text = et.OrderNo;

            var usr = VerfiyAdmin.LoginUser; if (null == usr) return;
            lblMail.Text = usr.UserEmail;

            var counter= new Tab_Order1Counter().Get(et.CounterIdx.ToString());
            if (null == counter) return;
            lblCounterName.Text = counter.CounterName;
            lblCounterPhone.Text = counter.CounterPhone;
            lblAddr.Text = counter.CounterAddr;

            
        }

        //子订单数据获取应该从库中来
        //柜台
    }
}