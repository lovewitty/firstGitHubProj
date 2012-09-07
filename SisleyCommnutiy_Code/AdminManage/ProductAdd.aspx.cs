using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBEntity;
using System.IO;

public partial class AdminManage_ProductAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VerfiyAdmin.CheckAdminLogin(this);

        if (!IsPostBack) BindProType();
    }

    protected readonly string UpLoadDir = "~/upload/Product/";

    /// <summary>
    /// 添加产品
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdt_Click(object sender, EventArgs e)
    {
        new Tab_Y_Product().AddNew(new Tab_Y_Product { 
            ProductNo=txtProNo.Text.Trim(),
            Title=txtTitle.Text.Trim(),
            ProductTypeIdx=Int32.Parse(ddlProType.SelectedValue),
            ImagePath1 = SaveFile(this.fileProImg),
            Descript=Server.HtmlEncode(txtDesc.Text.Trim())
        });
        Cmn.Js.ShowAlert("操作成功！");
        Cmn.Js.ExeScript("location.href='ProductManage.aspx'");
    }

    /// <summary>
    /// 生成服务器端保存的上传文件名称
    /// </summary>
    /// <returns></returns>
    protected string GenFileName()
    {
        return Guid.NewGuid().ToString().Replace("-", string.Empty);
    }

    /// <summary>
    /// 保存上传文件
    /// </summary>
    /// <param name="fip"></param>
    /// <returns></returns>
    protected string SaveFile(FileUpload fip)
    {
        if (null == fip) return string.Empty;
        var dir = Server.MapPath(UpLoadDir);
        if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
        var rtName=string.Empty;
        var fiName = UpLoadDir + (rtName=GenFileName()+".jpg");
        fip.SaveAs(Server.MapPath(fiName));
        return rtName;
    }

    protected void BindProType()
    {
        var ents =new Tab_Y_ProductType().ListAll();
        if (null != ents && ents.Count() > 0)
        {
            ddlProType.Items.Clear();
            ListItem[] itms = ents.Select(k => new ListItem {Text=k.TypeName,Value=k.Idx.ToString() }).ToArray();
            ddlProType.Items.AddRange(itms);
        }
    }
}