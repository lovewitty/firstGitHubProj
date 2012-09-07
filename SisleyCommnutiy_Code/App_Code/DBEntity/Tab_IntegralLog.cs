using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_IntegralLog
	 {
		 public System.Int32? Idx { get; set; }
		 public System.Int32? UserUId_Fx { get; set; }
		 public System.Int32? IntegralValues { get; set; }
		 public System.Object EventsOverview { get; set; }
		 public System.DateTime? Date { get; set; }

	 public int AddNew(Tab_IntegralLog model) 
 	 {
		string sql = "insert into Tab_IntegralLog(UserUId_Fx,IntegralValues,EventsOverview,Date)  values(@UserUId_Fx,@IntegralValues,@EventsOverview,@Date); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@UserUId_Fx", model.UserUId_Fx)
			,new SqlParameter("@IntegralValues", model.IntegralValues)
			,new SqlParameter("@EventsOverview", model.EventsOverview)
			,new SqlParameter("@Date", model.Date)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_IntegralLog model) 
 	 {
		 string sql = "update Tab_IntegralLog set UserUId_Fx=@UserUId_Fx,IntegralValues=@IntegralValues,EventsOverview=@EventsOverview,Date=@Date where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@UserUId_Fx", model.UserUId_Fx)
			 ,new SqlParameter("@IntegralValues", model.IntegralValues)
			 ,new SqlParameter("@EventsOverview", model.EventsOverview)
			 ,new SqlParameter("@Date", model.Date)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_IntegralLog where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_IntegralLog ToModel(DataRow row)
	{
		Tab_IntegralLog model = new Tab_IntegralLog();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.UserUId_Fx = row.IsNull("UserUId_Fx")?null:(System.Int32?)row["UserUId_Fx"];
		model.IntegralValues = row.IsNull("IntegralValues")?null:(System.Int32?)row["IntegralValues"];
		model.EventsOverview = row.IsNull("EventsOverview")?null:(System.Object)row["EventsOverview"];
		model.Date = row.IsNull("Date")?null:(System.DateTime?)row["Date"];
		return model;
	}

	public Tab_IntegralLog Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_IntegralLog  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_IntegralLog model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_IntegralLog> ListAll()
	{
		List<Tab_IntegralLog> list = new List<Tab_IntegralLog>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_IntegralLog").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_IntegralLog> ListAll(string strSql)
	{
		List<Tab_IntegralLog> list = new List<Tab_IntegralLog>();
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
		string strSql = " select * from Tab_IntegralLog";
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
