using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class json_GetCounterAddr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VerfiyAdmin.CheckUserLogin(this);
        if (!string.IsNullOrEmpty(Request["clr"]))//清除购物车
        {
            VerfiyAdmin.ClearGiftCart(); Response.End();
            return;
        }
        if (string.IsNullOrEmpty(Request["city"])) { Response.End(); return; }
        var et = VerfiyAdmin.GetCounterAddr(Request["city"]);
        if(null==et||et.Count<1){ Response.End(); return; }
        jsoncity jcy = new jsoncity { name = et[0].name };
        List<jsonaddr> jdr = et.Select(k => new jsonaddr { name = k.address, Idx = k.Idx.ToString() }).ToList();
        jcy.address = jdr;
        jsonCcity jc = new jsonCcity(); jc.city =  new List<jsoncity> { jcy };
        var jstr = JsonConvert.SerializeObject(jc);
        Response.Write(jstr); Response.End();
    }

    [Serializable]
    class jsonaddr
    {
        public string name { get; set; }

        public string Idx { get; set; }
    }

    class jsonCcity
    {
        public List<jsoncity> city { get; set; }
    }

    [Serializable]
    class jsoncity
    {
        public string name { get; set; }

        public List<jsonaddr> address { get; set; }
    }
}