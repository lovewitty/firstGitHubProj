using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AdminManage_UserArticle_AddNew : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string strSql = "select * from Tab_UserArticle_ProductType order by 2";
            DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,strSql).Tables[0];
            this.ProductCategoryIdx_Fx.DataSource = dt;
            this.ProductCategoryIdx_Fx.DataTextField = "ProductCategoryName";
            this.ProductCategoryIdx_Fx.DataValueField = "Idx";
            this.ProductCategoryIdx_Fx.DataBind();

            ProductCategoryIdx_Fx.Items.Insert(0, new ListItem("请选择",""));
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Cmn.uploadFile upF = new Cmn.uploadFile();
        string[] allowExtensions = { ".jpg", ".gif", ".png" };
        int maxSize = Convert.ToInt32(Cmn.WebConfig.getApp("app_MaxSizeUpload"));
        string savePath = Request.MapPath("~/upload/Article/");
        string fileName = myFileUpload.FileName;
        try
        {
            upF.Upload(this.myFileUpload, allowExtensions, maxSize, savePath, fileName);
        }
        catch (Exception exp)
        {
            Cmn.Js.ShowAlert(exp.Message);
            return;
        }

        DBEntity.Tab_UserArticle ent = new DBEntity.Tab_UserArticle();
        ent.UserUId_Fx = int.Parse(this.uId.Text);
        ent.ForProductBool = this.rdType.SelectedValue;
        ent.ArticleTitle = wenZhangTitle.Text;
        ent.ArticleContent = articleContent.Text;
        ent.CreatedDate = DateTime.Now;
        ent.PreviewAlternatePicture = fileName;
        
        if (this.rdType.SelectedValue == "产品测试")
        {
            ent.ProductScore = this.RadioButtonList1.SelectedItem.Text;
            ent.ProductImpression = this.ProductImpression.SelectedItem.Text;
            ent.ProductTryIdx_Fx = int.Parse(this.ProductTitle.SelectedValue); 
        }

        ent.AddNew(ent);

        Cmn.Js.ShowAlert("操作成功！");
        Cmn.Js.ExeScript("location.href='UserArticle_Manage.aspx'");
    }
   
    protected void rdType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.rdType.SelectedValue == "产品测试")
        {
            this.Panel1.Visible = true;
        }
        else
        {
            this.Panel1.Visible = false;
        }
    }
    protected void ProductCategoryIdx_Fx_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strSql = string.Format("select * from Tab_UserArticle_Product where ProductCategoryIdx_Fx={0} order by 2", this.ProductCategoryIdx_Fx.SelectedValue);
        DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        this.ProductTitle.DataSource = dt;
        this.ProductTitle.DataTextField = "ProductTitle";
        this.ProductTitle.DataValueField = "Idx";
        this.ProductTitle.DataBind();
        this.ProductTitle.Items.Insert(0, new ListItem("请选择",""));
    }
    protected void ProductTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBEntity.Tab_UserArticle_Product ent = new DBEntity.Tab_UserArticle_Product();
        ent = ent.Get(this.ProductTitle.SelectedValue);
        this.ProductPictures.ImageUrl = string.Format("~/upload/UserProduct/{0}", ent.ProductPictures);

       ProductImpression.Items.Clear();
        for (int i = 0; i < ent.ProductImpression.Split('|').Count(); i++)
        {
            this.ProductImpression.Items.Add(ent.ProductImpression.Split('|')[i].ToString() + "分");
        }
        
        RadioButtonList1.Items.Clear();
        for (int i = 1; i <= 5; i++)
        {
            this.RadioButtonList1.Items.Add(i.ToString() + "分");
        }
    }
}