using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_Y_Article_ViewLog
	 {
		 public System.Int32? Idx { get; set; }
		 public System.Int32? yArticleIdx_Fx { get; set; }
		 public System.String yUserInfo { get; set; }
		 public System.String yIpAddress { get; set; }
		 public System.String yRemark { get; set; }
		 public System.DateTime? yCreatedate { get; set; }

	 public int AddNew(Tab_Y_Article_ViewLog model) 
 	 {
		string sql = "insert into Tab_Y_Article_ViewLog(yArticleIdx_Fx,yUserInfo,yIpAddress,yRemark,yCreatedate)  values(@yArticleIdx_Fx,@yUserInfo,@yIpAddress,@yRemark,@yCreatedate); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@yArticleIdx_Fx", model.yArticleIdx_Fx)
			,new SqlParameter("@yUserInfo", model.yUserInfo)
			,new SqlParameter("@yIpAddress", model.yIpAddress)
			,new SqlParameter("@yRemark", model.yRemark)
			,new SqlParameter("@yCreatedate", model.yCreatedate)
			 ));
		 return Idx;
	 }

        /// <summary>
         /// 添加阅读日志到 Tab_Y_Article_ViewLog
        /// </summary>
        /// <param name="Request_ArticleIdx">文章Idx</param>
        /// <param name="IpAddress">Ip地址</param>
        /// <param name="remark"></param>
     public static void Add_Y_Article_ViewLog(string Request_ArticleIdx,string IpAddress, string remark)
     {
         
         try
         {
             DBEntity.Tab_Y_Article_ViewLog ent1 = new DBEntity.Tab_Y_Article_ViewLog();
             //写入阅读的日志表
             ent1.yArticleIdx_Fx = Convert.ToInt32(Request_ArticleIdx);
             ent1.yUserInfo = Cmn.Cookies.Get("login_UserEmail");
             ent1.yIpAddress = IpAddress;
             ent1.yCreatedate = DateTime.Now;
             ent1.yRemark = remark;
             ent1.AddNew(ent1);
         }
         catch(Exception exp)
         {
             Cmn.Log.Write(exp.ToString());
         }
      
     }

	 public bool Update(Tab_Y_Article_ViewLog model) 
 	 {
		 string sql = "update Tab_Y_Article_ViewLog set yArticleIdx_Fx=@yArticleIdx_Fx,yUserInfo=@yUserInfo,yIpAddress=@yIpAddress,yRemark=@yRemark,yCreatedate=@yCreatedate where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@yArticleIdx_Fx", model.yArticleIdx_Fx)
			 ,new SqlParameter("@yUserInfo", model.yUserInfo)
			 ,new SqlParameter("@yIpAddress", model.yIpAddress)
			 ,new SqlParameter("@yRemark", model.yRemark)
			 ,new SqlParameter("@yCreatedate", model.yCreatedate)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_Y_Article_ViewLog where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_Y_Article_ViewLog ToModel(DataRow row)
	{
		Tab_Y_Article_ViewLog model = new Tab_Y_Article_ViewLog();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.yArticleIdx_Fx = row.IsNull("yArticleIdx_Fx")?null:(System.Int32?)row["yArticleIdx_Fx"];
		model.yUserInfo = row.IsNull("yUserInfo")?null:(System.String)row["yUserInfo"];
		model.yIpAddress = row.IsNull("yIpAddress")?null:(System.String)row["yIpAddress"];
		model.yRemark = row.IsNull("yRemark")?null:(System.String)row["yRemark"];
		model.yCreatedate = row.IsNull("yCreatedate")?null:(System.DateTime?)row["yCreatedate"];
		return model;
	}

	public Tab_Y_Article_ViewLog Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Y_Article_ViewLog  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_Y_Article_ViewLog model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_Y_Article_ViewLog> ListAll()
	{
		List<Tab_Y_Article_ViewLog> list = new List<Tab_Y_Article_ViewLog>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Y_Article_ViewLog").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_Y_Article_ViewLog> ListAll(string strSql)
	{
		List<Tab_Y_Article_ViewLog> list = new List<Tab_Y_Article_ViewLog>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,strSql).Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public static DataSet GetDs_Where(string beginDate,string endDate,string keywords)
	{
		List<SqlParameter> spsList = new List<SqlParameter>();
		string strSql = " select * from Tab_Y_Article_ViewLog";
		string strWhere = " where 1=1 ";
	if (!String.IsNullOrEmpty(beginDate)) 
	{
		strWhere = strWhere + " and courseCreatedDate >= @beginDate";
		spsList.Add(new SqlParameter("@beginDate", beginDate));
	}
		if (!String.IsNullOrEmpty(endDate)) 
		{
			strWhere = strWhere + " and courseCreatedDate <= @endDate";
			spsList.Add(new SqlParameter("@endDate", endDate + " 23:59:59"));
		}
		if (!String.IsNullOrEmpty(keywords)) 
		{
			keywords = keywords.Replace("'", "''");
			strWhere = strWhere + " and (courseTitle like @keywords or courseText like @keywords)";
			spsList.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
		}
		strSql = strSql + strWhere + " order by courseCreatedDate desc";
		 DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql, spsList.ToArray());
		return ds; 
	}
   } 
}
