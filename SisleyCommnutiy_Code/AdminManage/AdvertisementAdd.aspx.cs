using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminManage_AdvertisementAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {

        //string exts = ".jpg|.gif|.png|.bmp";
        //if (!Cmn.UploadNew.IsAllowedExtension(this.myFileUpload, exts))
        //{
        //    Cmn.Js.ShowAlert("文件格式不符，可以上传的文件格式为：" + exts);
        //    return;
        //}

        //decimal MaxSize = Convert.ToDecimal(Cmn.WebConfig.getApp("app_MaxSizeUpload"));
        //if (!Cmn.UploadNew.IsAllowedMaxSize(this.myFileUpload, MaxSize)) ;
        //{
        //    Cmn.Js.ShowAlert(string.Format("只能上传小于{0}M的文件！", MaxSize));
        //    return;
        //}


        Cmn.uploadFile upF = new Cmn.uploadFile();
        string[] allowExtensions= { ".jpg", ".gif",".png" };
        int maxSize = Convert.ToInt32(Cmn.WebConfig.getApp("app_MaxSizeUpload"));
        string savePath = Request.MapPath("~/upload/Advertisement/");
        string fileName = myFileUpload.FileName;
        try
        {
            upF.Upload(this.myFileUpload, allowExtensions, maxSize, savePath, fileName);
        }
        catch(Exception exp)
        {
            Cmn.Js.ShowAlert(exp.Message);
            return;
        }


        DBEntity.Tab_Advertisement ent = new DBEntity.Tab_Advertisement();
        ent.AdPostion = this.AdPostion.Text;
        ent.AdImg = fileName;
        ent.AdDescription = this.AdDescription.Text;
        ent.Links = this.Links.Text;
        ent.OrderNumb = Convert.ToInt32(this.OrderNumb.Text);

        ent.AddNew(ent);
        Cmn.Js.ShowAlert("操作成功！");
        Cmn.Js.ExeScript("location.href='AdvertisementManage.aspx'");
    }

    
}