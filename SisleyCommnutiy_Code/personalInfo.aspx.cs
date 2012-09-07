using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class personalInfo : System.Web.UI.Page
{

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string fileName = "";

        if (!FileUpload1.HasFile)
        {
            Cmn.Js.ShowAlert("请上传您的照片!");
        }

        fileName = Cmn.Date.ToDateStr2(DateTime.Now)+"_"+this.FileUpload1.FileName ;
        new Cmn.uploadFile().Upload(this.FileUpload1
            , Cmn.WebConfig.getApp("app_ImgUpload").Split('|')
            , int.Parse(Cmn.WebConfig.getApp("app_MaxSizeUpload"))
            , Server.MapPath(string.Format("~/upload/userHearderImg/"))
            , fileName);

        string uIdx = Cmn.Cookies.Get("login_UserIdx");
        string strSql = string.Format("update Tab_UserCommunity set HeadPhoto='{0}' where Idx={1}", fileName, uIdx);
        SqlHelper.ExecuteNonQuery(CommandType.Text,strSql);

        Response.Redirect("personalInfo.aspx");

    }
    protected void btnChekVipCardNo_Click(object sender, EventArgs e)
    {
        string strSql = "select count(1) from Tab_UserVipCardNo where VipCardNo='{0}' and VipMobile='{1}' and VipHasUseBool='no'";
        strSql = string.Format(strSql,this.uCard.Value,this.uMobile.Value);
        int iResult =  Convert.ToInt32( SqlHelper.ExecuteScalar(CommandType.Text, strSql));
        if (iResult > 0)
        {//更改VIP卡的状态
            strSql = "update Tab_UserVipCardNo set  VipHasUseBool='yes',remark='{2}' where VipCardNo='{0}' and VipMobile='{1}'";
            strSql = string.Format(strSql, this.uCard.Value, this.uMobile.Value, Cmn.Cookies.Get("login_UserEmail"));
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);
            Cmn.Js.ShowAlert("您的VIP卡号已经激活！");
           
            //更改该社区用户的VIP标示为yes
            strSql = string.Format("update Tab_UserCommunity set VipBool='yes' where Idx={0}", Cmn.Cookies.Get("login_UserIdx"));
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);
            //更改cookies的login_VipBool，以可以直接打开至尊专享页面
            Cmn.Cookies.Set("login_VipBool", "yes", 7);
            Cmn.Js.ExeScript("location.href='personalInfo.aspx'");
        }
        else
        {
            Cmn.Js.ShowAlert("请核实您的卡号和手机号");
            this.uCard.Value="";
            this.uMobile.Value = "";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (string.IsNullOrEmpty(VerfiyAdmin.LoginUser.UserEmail))
        //{
        //    Response.Redirect("login.aspx");
        //}
    }
}