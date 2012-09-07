using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBEntity;
using System.Data;
using System.Text;
using System.Data.SqlClient;

public partial class fcheck_info : System.Web.UI.Page
{
    protected readonly string SourcesDataSTR = "W";

    protected decimal? UserAvaPoint = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        VerfiyAdmin.CheckVIPUserLogin(this);
        UserAvaPoint = VerfiyAdmin.LoginUser.AvailablePoints;
        if (!IsPostBack)
        {

            var usr = VerfiyAdmin.LoginUser;
            if (null == usr) return;
            lblAddr.Text = usr.Address;
            lblRealName.Text = usr.RealName;
            lblProv.Text = usr.Province;
            lblCity.Text = usr.City;
            lblMail.Text = usr.UserEmail;
            lblMobile.Text = usr.MobilePhone;
            lblPostCode.Text = usr.ZipCode;
        }
        else//提交
        {
            //1.检查积分兑换商品是否超出积分了
            //2.保存相关数据至订单主从表中
            //3.扣减当前会员可用积分
            var gifts = VerfiyAdmin.GetGiftCart();
            if (null == gifts || gifts.Count < 1) return;
            var payforPoint = gifts.Sum(k => k.GiftCount * k.PerGiftData.NeedPoint);//得到总共兑换礼品需要消耗的积分总数
            var counterIdx = Request["counterIdx"];//柜台
            int ctridx=-1;bool b=Int32.TryParse(counterIdx,out ctridx);
            if (string.IsNullOrEmpty(counterIdx) ||!b )//柜台未选择
            {
                Cmn.Js.ShowAlert("你还没有选择兑换礼品的柜台!");
                return;
            }
            var usr = VerfiyAdmin.LoginUser; if (null == usr) return;
            if (usr.AvailablePoints - payforPoint <= 0)//积分不足
            {
                Cmn.Js.ShowAlert("你的可用积分不足以兑换所有礼品!");
                return;
            }
            var OrdNo = VerfiyAdmin.GenGiftOrderNo();//订单号

            var OrdIdx = new Tab_Order4Total().AddNew(new Tab_Order4Total
            {
                OrderNo = OrdNo,
                OrderStatus = string.Empty,
                CounterNo = string.Empty,//柜台号
                CounterIdx=Int32.Parse( counterIdx),//柜台IDX
                DateCreated = DateTime.Now,
                SourcesData = SourcesDataSTR,
                TotalPoints = payforPoint,
                UserIdx_Fx = usr.Idx
            });

            var subOrd = new Tab_Order3Detail();
            //创建子订单数据
            foreach (var item in gifts)
            {
                subOrd.AddNew(new Tab_Order3Detail
                {
                    CreatedDate = DateTime.Now,
                    GiftCount = item.GiftCount,
                    GiftIdx_Fx = item.GiftIdx,
                    NeedPoint = item.PerGiftData.NeedPoint,
                    OrdersIdx_Fx = OrdIdx,
                    OrderStatus = string.Empty,
                    OrderUUID = Guid.NewGuid(),
                    SourcesData = SourcesDataSTR,
                    CounterIdx_Fx =counterIdx,//柜台IDX
                });
            }

            //扣减当前会员可用积分
            SqlHelper.ExecuteNonQuery(CommandType.Text,Sql_UpdateUsrPoint,
                new SqlParameter("@prm", payforPoint), new SqlParameter("@idx", VerfiyAdmin.LoginUser.Idx));
            Session[VerfiyAdmin.LoginUserKey] = new Tab_UserCommunity().Get(VerfiyAdmin.LoginUser.Idx.ToString());
            
            //发送邮件
            VerfiyAdmin.SendGiftOrderMail(OrdNo);
            Response.Redirect("fexchange_success.aspx?Id=" + OrdIdx.ToString());

        }
    }

    string Sql_UpdateUsrPoint
    {
        get
        {
            StringBuilder sb=new StringBuilder();
            sb.Append("update Tab_UserCommunity                 \n");
            sb.Append("set AvailablePoints=AvailablePoints-@prm \n");
            sb.Append(",RedemptionPoints=IsNull(RedemptionPoints+@prm,@prm)  \n");
            sb.Append("where Idx=@idx                           \n");
            return sb.ToString();
        }
    }
}