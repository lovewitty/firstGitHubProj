using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_ArticleLog
	 {
		 public System.Int32? Idx { get; set; }
		 public System.Int32? UId_Fx { get; set; }
		 public System.Int32? ArticleId_Fx { get; set; }
		 public System.String IpAddress { get; set; }
		 public System.DateTime? DateCreated { get; set; }

	 public int AddNew(Tab_ArticleLog model) 
 	 {
		string sql = "insert into Tab_ArticleLog(UId_Fx,ArticleId_Fx,IpAddress,DateCreated)  values(@UId_Fx,@ArticleId_Fx,@IpAddress,@DateCreated); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@UId_Fx", model.UId_Fx)
			,new SqlParameter("@ArticleId_Fx", model.ArticleId_Fx)
			,new SqlParameter("@IpAddress", model.IpAddress)
			,new SqlParameter("@DateCreated", model.DateCreated)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_ArticleLog model) 
 	 {
		 string sql = "update Tab_ArticleLog set UId_Fx=@UId_Fx,ArticleId_Fx=@ArticleId_Fx,IpAddress=@IpAddress,DateCreated=@DateCreated where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@UId_Fx", model.UId_Fx)
			 ,new SqlParameter("@ArticleId_Fx", model.ArticleId_Fx)
			 ,new SqlParameter("@IpAddress", model.IpAddress)
			 ,new SqlParameter("@DateCreated", model.DateCreated)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_ArticleLog where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_ArticleLog ToModel(DataRow row)
	{
		Tab_ArticleLog model = new Tab_ArticleLog();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.UId_Fx = row.IsNull("UId_Fx")?null:(System.Int32?)row["UId_Fx"];
		model.ArticleId_Fx = row.IsNull("ArticleId_Fx")?null:(System.Int32?)row["ArticleId_Fx"];
		model.IpAddress = row.IsNull("IpAddress")?null:(System.String)row["IpAddress"];
		model.DateCreated = row.IsNull("DateCreated")?null:(System.DateTime?)row["DateCreated"];
		return model;
	}

	public Tab_ArticleLog Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_ArticleLog  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_ArticleLog model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_ArticleLog> ListAll()
	{
		List<Tab_ArticleLog> list = new List<Tab_ArticleLog>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_ArticleLog").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_ArticleLog> ListAll(string strSql)
	{
		List<Tab_ArticleLog> list = new List<Tab_ArticleLog>();
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
		string strSql = " select * from v_ArticleLog";
		string strWhere = " where 1=1 ";
	if (!String.IsNullOrEmpty(beginDate)) 
	{
        strWhere = strWhere + " and DateCreated >= @beginDate";
		spsList.Add(new SqlParameter("@beginDate", beginDate));
	}
		if (!String.IsNullOrEmpty(endDate)) 
		{
            strWhere = strWhere + " and DateCreated <= @endDate";
			spsList.Add(new SqlParameter("@endDate", endDate + " 23:59:59"));
		}
		if (!String.IsNullOrEmpty(keywords)) 
		{
			keywords = keywords.Replace("'", "''");
            strWhere = strWhere + " and (UserEmail like @keywords or Title like @keywords)";
			spsList.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
		}
        strSql = strSql + strWhere + " order by DateCreated desc";
		 DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql, spsList.ToArray());
		return ds; 
	}
   } 
}
