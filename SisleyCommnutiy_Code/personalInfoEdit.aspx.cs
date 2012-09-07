using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class personalInfoEdit : System.Web.UI.Page
{
   public   string strVip = "普通会员  <input type='button' value='升级VIP' class='btnUpgrade' />";
   public string strPosion = "希思黎俱乐部";
   public string strTopClass = "subTit commTit";
   public  string strSiteMsgNumber = "6";
   public DBEntity.Tab_UserCommunity ent = new DBEntity.Tab_UserCommunity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (string.IsNullOrEmpty(Cmn.Cookies.Get("login_UserIdx")))
            {
                Response.Redirect("login.aspx?from=" + Request.Url.ToString());
            }

            int uIdx = int.Parse(Cmn.Cookies.Get("login_UserIdx"));
            ent = ent.Get(uIdx);

            if (ent.VipBool == "yes")
            {
                strVip = "VIP 会员";
                strPosion = "至臻坊会员专享";
                strTopClass = "subTit vipTit";
            }

            this.RealName.Value = ent.RealName;
            this.MobilePhone.Value = ent.MobilePhone;
            this.Hidden1.Value = ent.Province;
            this.City.Value = ent.City;
            this.Address.Value = ent.Address;
            this.ZipCode.Value = ent.ZipCode;

        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string fileName = "";

        if (!FileUpload1.HasFile)
        {
            Cmn.Js.ShowAlert("请上传您的照片!");
        }

        fileName = Cmn.Date.ToDateStr2(DateTime.Now) + "_" + this.FileUpload1.FileName;
        new Cmn.uploadFile().Upload(this.FileUpload1
            , Cmn.WebConfig.getApp("app_ImgUpload").Split('|')
            , int.Parse(Cmn.WebConfig.getApp("app_MaxSizeUpload"))
            , Server.MapPath(string.Format("~/upload/userHearderImg/"))
            , fileName);

        string uIdx = Cmn.Cookies.Get("login_UserIdx");
        string strSql = string.Format("update Tab_UserCommunity set HeadPhoto='{0}' where Idx={1}", fileName, uIdx);
        SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);

        Response.Redirect("personalInfo.aspx");

    }
    protected void ltnEditPersonInfo_Click(object sender, EventArgs e)
    {
        string strSql = @"update Tab_UserCommunity set 
                                                RealName=@RealName,
                                                MobilePhone=@MobilePhone,
                                                Province=@Province,
                                                City=@City,
                                                Address=@Address,
                                                ZipCode=@ZipCode
                                            where Idx = @Idx";

       int iResult =   SqlHelper.ExecuteNonQuery(CommandType.Text, strSql
                , new SqlParameter("RealName", this.RealName.Value)
                , new SqlParameter("MobilePhone", this.MobilePhone.Value)
                , new SqlParameter("Province", this.Hidden1.Value)
                , new SqlParameter("City", this.City.Value)
                , new SqlParameter("Address", this.Address.Value)
                , new SqlParameter("ZipCode", this.ZipCode.Value)
                , new SqlParameter("Idx", Cmn.Cookies.Get("login_UserIdx")));

       Cmn.Js.ShowAlert("修改成功！");
     
      Response.Redirect("personalInfo.aspx");

    }
}