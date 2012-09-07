using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdminManage_sisleyQA_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            BindQaTypeList();
            BindQaSubTypeList(null);
            this.DateAsk.Value = DateTime.Now.ToString();

            string idx = Request["Idx"];
            if (!String.IsNullOrEmpty(idx))
            {
                 string strSql  = string.Format("select * from v_QA_Sisley where Idx = '{0}'", idx);
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    var iRow = ds.Tables[0].Rows[0];
                    this.ContentQuestion.Text = iRow["ContentQuestion"].ToString();
                    this.ContentAnswer.Text = iRow["ContentAnswer"].ToString();
                    this.PassBool.Text = iRow["PassBool"].ToString();
                    this.DateAsk.Value = iRow["DateAsk"].ToString();


                    for (int i = 0; i < QaTypeIdx_Fx.Items.Count; i++)
                    {
                        if (QaTypeIdx_Fx.Items[i].Value == iRow["QaTypeIdx_Fx"].ToString())
                        {
                            QaTypeIdx_Fx.Items[i].Selected = true;
                            break;
                        }
                    }

                    for (int i = 0; i < QuestionSubTypeIdx_Fx.Items.Count; i++)
                    {
                        if (QuestionSubTypeIdx_Fx.Items[i].Value == iRow["QuestionSubTypeIdx_Fx"].ToString())
                        {
                            QuestionSubTypeIdx_Fx.Items[i].Selected = true;
                            break;
                        }
                    }
                }

                ltlPageTitle.Text = "Sisley问答-编辑";
            }
            else
            {
                ltlPageTitle.Text = "Sisley问答--添加";
            }
        }
    }

    // 绑定问题大类别- 列表
    private void BindQaTypeList()
    {
        string strSql = "select * from Tab_QA_Type order by 2";
        this.QaTypeIdx_Fx.DataSource = SqlHelper.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        this.QaTypeIdx_Fx.DataTextField = "QaTypeName";
        this.QaTypeIdx_Fx.DataValueField = "Idx";
        this.QaTypeIdx_Fx.DataBind();
        this.QaTypeIdx_Fx.Items.Insert(0, "请选择");
     
      
    }

    // 绑定问题子类别- 列表
    private void BindQaSubTypeList(string QaTypeIdx_Fx)
    {
        string strSql = string.Format("select * from Tab_QA_SubType where QaTypeIdx_Fx='{0}' order by 2", QaTypeIdx_Fx);
        if (string.IsNullOrEmpty(QaTypeIdx_Fx))
        {
            strSql = "select * from Tab_QA_SubType order by 2";            
        }

        this.QuestionSubTypeIdx_Fx.DataSource = SqlHelper.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        this.QuestionSubTypeIdx_Fx.DataTextField = "QaSubTypeName";
        this.QuestionSubTypeIdx_Fx.DataValueField = "Idx";
        this.QuestionSubTypeIdx_Fx.DataBind();
        if (string.IsNullOrEmpty(QaTypeIdx_Fx))
        {
            this.QuestionSubTypeIdx_Fx.Items.Insert(0, "请选择");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string idx = Request["Idx"];

        DBEntity.Tab_QA_Sisley ent = new DBEntity.Tab_QA_Sisley();
        ent.PassBool = this.PassBool.Text;
        ent.QuestionSubTypeIdx_Fx = Convert.ToInt32(this.QuestionSubTypeIdx_Fx.SelectedValue);
        ent.ContentAnswer = this.ContentAnswer.Text;
        ent.ContentQuestion = this.ContentQuestion.Text;
        ent.DateAsk = Convert.ToDateTime(this.DateAsk.Value);
        ent.ManagerUserName = "admin";
        ent.DateAnswer = DateTime.Now;

        if (string.IsNullOrEmpty(idx))
        {
            ent.AddNew(ent);
        }
        else
        {
            ent.Idx = Convert.ToInt32(idx);
            ent.Update(ent);
        }

       //Cmn.Js.ShowAlert("操作成功！");
        Cmn.Js.ExeScript("location.href='sisleyQA_Manage.aspx'");
    }
    protected void QaTypeIdx_Fx_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strSql = string.Format("select * from Tab_QA_SubType where QaTypeIdx_Fx='{0}'",this.QaTypeIdx_Fx.SelectedValue);
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);
        if (ds.Tables[0].Rows.Count == 0)
        {
            QuestionSubTypeIdx_Fx.Items.Clear();
            this.QuestionSubTypeIdx_Fx.Items.Insert(0, "空");
            return;
        }

        this.QuestionSubTypeIdx_Fx.DataSource = ds;
        this.QuestionSubTypeIdx_Fx.DataTextField = "QaSubTypeName";
        this.QuestionSubTypeIdx_Fx.DataValueField = "Idx";
        this.QuestionSubTypeIdx_Fx.DataBind();
    }


}