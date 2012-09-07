using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DBEntity;

public partial class AdminManage_ProductTypeEdit : System.Web.UI.Page
{
    protected readonly int OrdsecDef = 1;//默认排序值为1（如果用户没有填入排充值的话）


    protected void Page_Load(object sender, EventArgs e)
    {
        VerfiyAdmin.CheckAdminLogin(this);
        if (!IsPostBack)
        {
            string idx = Request["Idx"];
            if(!string.IsNullOrEmpty(idx)){
                var ent =new Tab_Y_ProductType().Get(idx);
                this.txtOrdSec.Text = ent.OrdSec.ToString();
                this.txtTypeName.Text = ent.TypeName;
            }
        }
    }

    protected void btnEdt_Click(object sender, EventArgs e)
    {
        int ordsec = 1;
        if (!Int32.TryParse(txtOrdSec.Text.Trim(), out ordsec))
            ordsec = OrdsecDef;
        string strSql = ("update Tab_Y_ProductType set TypeName=@typename , OrdSec=@ordsec where Idx=@idx");
        SqlHelper.ExecuteNonQuery(CommandType.Text, strSql,
            new SqlParameter("@typename", txtTypeName.Text.Trim()),
            new SqlParameter("@ordsec", ordsec),
            new SqlParameter("@idx", Request["Idx"]));

        Cmn.Js.ShowAlert("操作成功！");
        Cmn.Js.ExeScript("location.href='ProductTypeManage.aspx'");
    }
}