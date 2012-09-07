using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_Activity_Apply
	 {
		 public System.Int32? Idx { get; set; }
		 public System.Int32? UserUIdx_Fx { get; set; }
		 public System.Int32? ActivitiesIdx_Fx { get; set; }
		 public System.DateTime? DateOfApplication { get; set; }
		 public System.String ApprovalStatus { get; set; }

	 public int AddNew(Tab_Activity_Apply model) 
 	 {
		string sql = "insert into Tab_Activity_Apply(UserUIdx_Fx,ActivitiesIdx_Fx,DateOfApplication,ApprovalStatus)  values(@UserUIdx_Fx,@ActivitiesIdx_Fx,@DateOfApplication,@ApprovalStatus); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@UserUIdx_Fx", model.UserUIdx_Fx)
			,new SqlParameter("@ActivitiesIdx_Fx", model.ActivitiesIdx_Fx)
			,new SqlParameter("@DateOfApplication", model.DateOfApplication)
			,new SqlParameter("@ApprovalStatus", model.ApprovalStatus)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_Activity_Apply model) 
 	 {
		 string sql = "update Tab_Activity_Apply set UserUIdx_Fx=@UserUIdx_Fx,ActivitiesIdx_Fx=@ActivitiesIdx_Fx,DateOfApplication=@DateOfApplication,ApprovalStatus=@ApprovalStatus where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@UserUIdx_Fx", model.UserUIdx_Fx)
			 ,new SqlParameter("@ActivitiesIdx_Fx", model.ActivitiesIdx_Fx)
			 ,new SqlParameter("@DateOfApplication", model.DateOfApplication)
			 ,new SqlParameter("@ApprovalStatus", model.ApprovalStatus)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_Activity_Apply where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_Activity_Apply ToModel(DataRow row)
	{
		Tab_Activity_Apply model = new Tab_Activity_Apply();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.UserUIdx_Fx = row.IsNull("UserUIdx_Fx")?null:(System.Int32?)row["UserUIdx_Fx"];
		model.ActivitiesIdx_Fx = row.IsNull("ActivitiesIdx_Fx")?null:(System.Int32?)row["ActivitiesIdx_Fx"];
		model.DateOfApplication = row.IsNull("DateOfApplication")?null:(System.DateTime?)row["DateOfApplication"];
		model.ApprovalStatus = row.IsNull("ApprovalStatus")?null:(System.String)row["ApprovalStatus"];
		return model;
	}

	public Tab_Activity_Apply Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Activity_Apply  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_Activity_Apply model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_Activity_Apply> ListAll()
	{
		List<Tab_Activity_Apply> list = new List<Tab_Activity_Apply>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Activity_Apply").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_Activity_Apply> ListAll(string strSql)
	{
		List<Tab_Activity_Apply> list = new List<Tab_Activity_Apply>();
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
		string strSql = " select * from v_Activity_Apply";
		string strWhere = " where 1=1 ";
	if (!String.IsNullOrEmpty(beginDate)) 
	{
        strWhere = strWhere + " and DateOfApplication >= @beginDate";
		spsList.Add(new SqlParameter("@beginDate", beginDate));
	}
		if (!String.IsNullOrEmpty(endDate)) 
		{
            strWhere = strWhere + " and DateOfApplication <= @endDate";
			spsList.Add(new SqlParameter("@endDate", endDate + " 23:59:59"));
		}
		if (!String.IsNullOrEmpty(keywords)) 
		{
			keywords = keywords.Replace("'", "''");
            strWhere = strWhere + " and (UserEmail like @keywords or ActiveTitle like @keywords)";
			spsList.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
		}
        strSql = strSql + strWhere + " order by DateOfApplication desc";
		 DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql, spsList.ToArray());
		return ds; 
	}
   } 
}
