using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_UserArticle_Reply
	 {
		 public System.Int32? Idx { get; set; }
		 public System.Int32? UserArticlesIdx_fx { get; set; }
		 public System.String ReplyContent { get; set; }
		 public System.String DisplayBool { get; set; }
		 public System.String ReplyTime { get; set; }

	 public int AddNew(Tab_UserArticle_Reply model) 
 	 {
		string sql = "insert into Tab_UserArticle_Reply(UserArticlesIdx_fx,ReplyContent,DisplayBool,ReplyTime)  values(@UserArticlesIdx_fx,@ReplyContent,@DisplayBool,@ReplyTime); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@UserArticlesIdx_fx", model.UserArticlesIdx_fx)
			,new SqlParameter("@ReplyContent", model.ReplyContent)
			,new SqlParameter("@DisplayBool", model.DisplayBool)
			,new SqlParameter("@ReplyTime", model.ReplyTime)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_UserArticle_Reply model) 
 	 {
		 string sql = "update Tab_UserArticle_Reply set UserArticlesIdx_fx=@UserArticlesIdx_fx,ReplyContent=@ReplyContent,DisplayBool=@DisplayBool,ReplyTime=@ReplyTime where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@UserArticlesIdx_fx", model.UserArticlesIdx_fx)
			 ,new SqlParameter("@ReplyContent", model.ReplyContent)
			 ,new SqlParameter("@DisplayBool", model.DisplayBool)
			 ,new SqlParameter("@ReplyTime", model.ReplyTime)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_UserArticle_Reply where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_UserArticle_Reply ToModel(DataRow row)
	{
		Tab_UserArticle_Reply model = new Tab_UserArticle_Reply();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.UserArticlesIdx_fx = row.IsNull("UserArticlesIdx_fx")?null:(System.Int32?)row["UserArticlesIdx_fx"];
		model.ReplyContent = row.IsNull("ReplyContent")?null:(System.String)row["ReplyContent"];
		model.DisplayBool = row.IsNull("DisplayBool")?null:(System.String)row["DisplayBool"];
		model.ReplyTime = row.IsNull("ReplyTime")?null:(System.String)row["ReplyTime"];
		return model;
	}

	public Tab_UserArticle_Reply Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_UserArticle_Reply  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_UserArticle_Reply model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_UserArticle_Reply> ListAll()
	{
		List<Tab_UserArticle_Reply> list = new List<Tab_UserArticle_Reply>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_UserArticle_Reply").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_UserArticle_Reply> ListAll(string strSql)
	{
		List<Tab_UserArticle_Reply> list = new List<Tab_UserArticle_Reply>();
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
		string strSql = " select * from Tab_UserArticle_Reply";
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
