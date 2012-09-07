using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_UserArticle_ViewLog
	 {
		 public System.Int32? Idx { get; set; }
		 public System.Int32? UserArticlesId_Fx { get; set; }
		 public System.String IpAddress { get; set; }
		 public System.DateTime? AccessDate { get; set; }

	 public int AddNew(Tab_UserArticle_ViewLog model) 
 	 {
		string sql = "insert into Tab_UserArticle_ViewLog(UserArticlesId_Fx,IpAddress,AccessDate)  values(@UserArticlesId_Fx,@IpAddress,@AccessDate); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@UserArticlesId_Fx", model.UserArticlesId_Fx)
			,new SqlParameter("@IpAddress", model.IpAddress)
			,new SqlParameter("@AccessDate", model.AccessDate)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_UserArticle_ViewLog model) 
 	 {
		 string sql = "update Tab_UserArticle_ViewLog set UserArticlesId_Fx=@UserArticlesId_Fx,IpAddress=@IpAddress,AccessDate=@AccessDate where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@UserArticlesId_Fx", model.UserArticlesId_Fx)
			 ,new SqlParameter("@IpAddress", model.IpAddress)
			 ,new SqlParameter("@AccessDate", model.AccessDate)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_UserArticle_ViewLog where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_UserArticle_ViewLog ToModel(DataRow row)
	{
		Tab_UserArticle_ViewLog model = new Tab_UserArticle_ViewLog();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.UserArticlesId_Fx = row.IsNull("UserArticlesId_Fx")?null:(System.Int32?)row["UserArticlesId_Fx"];
		model.IpAddress = row.IsNull("IpAddress")?null:(System.String)row["IpAddress"];
		model.AccessDate = row.IsNull("AccessDate")?null:(System.DateTime?)row["AccessDate"];
		return model;
	}

	public Tab_UserArticle_ViewLog Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_UserArticle_ViewLog  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_UserArticle_ViewLog model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_UserArticle_ViewLog> ListAll()
	{
		List<Tab_UserArticle_ViewLog> list = new List<Tab_UserArticle_ViewLog>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_UserArticle_ViewLog").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_UserArticle_ViewLog> ListAll(string strSql)
	{
		List<Tab_UserArticle_ViewLog> list = new List<Tab_UserArticle_ViewLog>();
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
		string strSql = " select * from Tab_UserArticle_ViewLog";
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
