using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBEntity;



public partial class GiftCart : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {        
        Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
        Response.Expires = 0;
        Response.CacheControl = "no-cache"; 

        if (!VerfiyAdmin.CheckVIPUserLogin(this)) {
            Response.Write(DateTime.Now.ToString("mm:ss:fff ")+ "not vip login"); 
            Response.End(); return; }
        Tab_UserCommunity lgnUsr = Session[VerfiyAdmin.LoginUserKey] as Tab_UserCommunity;

        
        //未登录.或不是VIP
        if (null == lgnUsr || "yes"!=lgnUsr.VipBool.ToLower()) {
            Response.Write(DateTime.Now.ToString("mm:ss:fff ") + "not vip login");

            Response.End(); return; }
        var GiftId = Request["GiftID"];//礼品ID
        var GiftCount = Request["GiftCount"];//礼品数量
        int gftCount = 1;//礼品数量


        if (string.IsNullOrEmpty(GiftCount) || !Int32.TryParse(GiftCount, out gftCount)) gftCount = 1;
        int gftIdx = 0;
        if (string.IsNullOrEmpty(GiftId) || !Int32.TryParse(GiftId,out gftIdx))
        {
            //Response.Write("not valid GiftId");
            Response.End();
            return;
        }

        Cmn.Log.Write(string.Format("GIFT:{0} COUNT:{1}", gftIdx, gftCount));
        //添加礼品信息至Session
        Dictionary<int, SessGiftData> dic = Session[VerfiyAdmin.GiftCartSessKey] as Dictionary<int, SessGiftData>;
        dic = dic ?? new Dictionary<int, SessGiftData>();
        Cmn.Log.Write(string.Format("Gift:{0} Count:{1}", gftIdx, gftCount));
        if (!dic.ContainsKey(gftIdx))
            dic.Add(gftIdx, new SessGiftData
            {
                GiftIdx = gftIdx,
                GiftCount = gftCount,
                PerGiftData = new DBEntity.Tab_Order2Gift().Get(gftIdx.ToString())
                
            });
        else
        {
            dic[gftIdx].GiftCount += gftCount;
            if (dic[gftIdx].GiftCount <= 0) dic.Remove(gftIdx);
            Cmn.Log.Write(string.Format("EXISTS-GIFT:{0} COUNT:{1}", gftIdx, dic[gftIdx].GiftCount));
        }
        Session[VerfiyAdmin.GiftCartSessKey] = dic;
        Response.Write(DateTime.Now.ToString("mm:ss:fff ") + "Success"); Response.End(); return;
    }
}