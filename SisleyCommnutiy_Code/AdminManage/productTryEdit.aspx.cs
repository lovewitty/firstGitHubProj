using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdminManage_productTryEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.DateCreated.Text = DateTime.Now.ToString();
            if (!string.IsNullOrEmpty(Request["Idx"]))
            {
                this.Image1.Visible = true;
                this.Image2.Visible = true;
                this.Image3.Visible = true;
                this.Image4.Visible = true;
                DBEntity.Tab_TryProduct ent = new DBEntity.Tab_TryProduct();
                ent = ent.Get(Request["Idx"]);
                this.ProductTitle.Text = ent.ProductTitle;
                this.ProductDescription.Text = ent.ProductDescription;
                this.Image1.ImageUrl = string.Format("~/upload/ProductTry/{0}", ent.ProductPictures);
                this.Image2.ImageUrl = string.Format("~/upload/ProductTry/{0}", ent.ProductPictures2);
                this.Image3.ImageUrl = string.Format("~/upload/ProductTry/{0}", ent.ProductPictures3);
                this.Image4.ImageUrl = string.Format("~/upload/ProductTry/{0}", ent.ProductPictures4);
                this.TotalCount.Text = ent.TotalCount.ToString();
                this.LeftCount.Text = ent.LeftCount.ToString();
                this.DateCreated.Text = ent.DateCreated.ToString();

                for (int i = 0; i < currentBool.Items.Count; i++)
                {
                    if (currentBool.Items[i].Value == ent.currentBool)
                    {
                        currentBool.Items[i].Selected = true;
                        break;
                    }
                }

                //保存编辑的时候使用
                this.hiddenFileName.Value = ent.ProductPictures;
                this.hiddenFileName2.Value = ent.ProductPictures2;
                this.hiddenFileName3.Value = ent.ProductPictures3;
                this.hiddenFileName4.Value = ent.ProductPictures4;
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string fileName = this.hiddenFileName.Value;
        string fileName2 = this.hiddenFileName2.Value;
        string fileName3 = this.hiddenFileName3.Value;
        string fileName4 = this.hiddenFileName4.Value;

        if (myFileUpload.HasFile)
        {
            Cmn.uploadFile upF = new Cmn.uploadFile();
            string[] allowExtensions = { ".jpg", ".gif", ".png" };
            int maxSize = Convert.ToInt32(Cmn.WebConfig.getApp("app_MaxSizeUpload"));
            string savePath = Request.MapPath("~/upload/ProductTry/");
            fileName = Cmn.Rand.GetGuid().Replace("-","") +"_"+ myFileUpload.FileName;
            try
            {
                upF.Upload(this.myFileUpload, allowExtensions, maxSize, savePath, fileName);
            }
            catch (Exception exp)
            {
                Cmn.Js.ShowAlert(exp.Message);
                return;
            }
        }

        if (myFileUpload2.HasFile)
        {
            Cmn.uploadFile upF = new Cmn.uploadFile();
            string[] allowExtensions = { ".jpg", ".gif", ".png" };
            int maxSize = Convert.ToInt32(Cmn.WebConfig.getApp("app_MaxSizeUpload"));
            string savePath = Request.MapPath("~/upload/ProductTry/");
            fileName2 = Cmn.Rand.GetGuid().Replace("-", "") + "_" + myFileUpload2.FileName;
            try
            {
                upF.Upload(this.myFileUpload2, allowExtensions, maxSize, savePath, fileName2);
            }
            catch (Exception exp)
            {
                Cmn.Js.ShowAlert(exp.Message);
                return;
            }
        }

        if (myFileUpload3.HasFile)
        {
            Cmn.uploadFile upF = new Cmn.uploadFile();
            string[] allowExtensions = { ".jpg", ".gif", ".png" };
            int maxSize = Convert.ToInt32(Cmn.WebConfig.getApp("app_MaxSizeUpload"));
            string savePath = Request.MapPath("~/upload/ProductTry/");
            fileName3 = Cmn.Rand.GetGuid().Replace("-", "") + "_" + myFileUpload3.FileName;
            try
            {
                upF.Upload(this.myFileUpload3, allowExtensions, maxSize, savePath, fileName3);
            }
            catch (Exception exp)
            {
                Cmn.Js.ShowAlert(exp.Message);
                return;
            }
        }

        if (myFileUpload4.HasFile)
        {
            Cmn.uploadFile upF = new Cmn.uploadFile();
            string[] allowExtensions = { ".jpg", ".gif", ".png" };
            int maxSize = Convert.ToInt32(Cmn.WebConfig.getApp("app_MaxSizeUpload"));
            string savePath = Request.MapPath("~/upload/ProductTry/");
            fileName4 = Cmn.Rand.GetGuid().Replace("-", "") + "_" + myFileUpload4.FileName;
            try
            {
                upF.Upload(this.myFileUpload4, allowExtensions, maxSize, savePath, fileName4);
            }
            catch (Exception exp)
            {
                Cmn.Js.ShowAlert(exp.Message);
                return;
            }
        }

        if (string.IsNullOrEmpty(Request["Idx"]))
        {
            string strSql = @"INSERT INTO Tab_TryProduct (ProductTitle ,ProductPictures ,ProductDescription ,TotalCount ,LeftCount ,DateCreated,currentBool,ProductPictures2,ProductPictures3,ProductPictures4) 
                                            VALUES ('{0}' ,'{1}' , '{2}','{3}' ,'{4}',getdate(),'{5}' ,'{6}','{7}','{8}'); select @@identity";
            strSql = string.Format(strSql, ProductTitle.Text, fileName, ProductDescription.Text, TotalCount.Text, LeftCount.Text, this.currentBool.SelectedValue,fileName2,fileName3,fileName4);
            //Cmn.Log.Write(strSql);
           string idx =   SqlHelper.ExecuteScalar(CommandType.Text, strSql).ToString();
         
            if (this.currentBool.SelectedValue == "yes")
           {//更新
               strSql = "update Tab_TryProduct set currentBool='no' where idx <>" + idx;
               SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);
           }
        }
        else
        {
            string strSql = @"update Tab_TryProduct set ProductTitle ='{0}' ,ProductPictures ='{1}',ProductDescription  ='{2}',TotalCount ='{3}' ,LeftCount  ='{4}',currentBool='{6}',ProductPictures2='{7}',ProductPictures3='{8}',ProductPictures4='{9}' where Idx='{5}'";
            strSql = string.Format(strSql, ProductTitle.Text, fileName, ProductDescription.Text, TotalCount.Text, LeftCount.Text, Request["Idx"], this.currentBool.SelectedItem.Value,fileName2, fileName3, fileName4);
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);

            if (this.currentBool.SelectedValue == "yes")
            {//更新
                strSql = "update Tab_TryProduct set currentBool='no' where idx <>" + Request["Idx"];
                SqlHelper.ExecuteNonQuery(CommandType.Text, strSql);
            }
        }

      

        Cmn.Js.ShowAlert("操作成功");
        Cmn.Js.ExeScript("location.href='productTryManage.aspx'");
    }
}