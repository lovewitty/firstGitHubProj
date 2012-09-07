using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_UserLevel
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String UserLevelName { get; set; }
		 public System.Int32? SortNo { get; set; }

	 public int AddNew(Tab_UserLevel model) 
 	 {
		string sql = "insert into Tab_UserLevel(UserLevelName,SortNo)  values(@UserLevelName,@SortNo); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@UserLevelName", model.UserLevelName)
			,new SqlParameter("@SortNo", model.SortNo)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_UserLevel model) 
 	 {
		 string sql = "update Tab_UserLevel set UserLevelName=@UserLevelName,SortNo=@SortNo where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@UserLevelName", model.UserLevelName)
			 ,new SqlParameter("@SortNo", model.SortNo)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_UserLevel where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_UserLevel ToModel(DataRow row)
	{
		Tab_UserLevel model = new Tab_UserLevel();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.UserLevelName = row.IsNull("UserLevelName")?null:(System.String)row["UserLevelName"];
		model.SortNo = row.IsNull("SortNo")?null:(System.Int32?)row["SortNo"];
		return model;
	}

	public Tab_UserLevel Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_UserLevel  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_UserLevel model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_UserLevel> ListAll()
	{
		List<Tab_UserLevel> list = new List<Tab_UserLevel>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_UserLevel").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_UserLevel> ListAll(string strSql)
	{
		List<Tab_UserLevel> list = new List<Tab_UserLevel>();
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
		string strSql = " select * from Tab_UserLevel";
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
