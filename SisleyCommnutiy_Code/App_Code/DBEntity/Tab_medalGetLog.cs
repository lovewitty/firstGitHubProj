using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_medalGetLog
	 {
		 public System.Int32? Idx { get; set; }
		 public System.Int32? UserIdx_Fx { get; set; }
		 public System.Int32? MedalIdx_Fx { get; set; }
		 public System.String GetEvent { get; set; }
		 public System.Int32? MedalNumber { get; set; }
		 public System.DateTime? GetTheDate { get; set; }

	 public int AddNew(Tab_medalGetLog model) 
 	 {
		string sql = "insert into Tab_medalGetLog(UserIdx_Fx,MedalIdx_Fx,GetEvent,MedalNumber,GetTheDate)  values(@UserIdx_Fx,@MedalIdx_Fx,@GetEvent,@MedalNumber,@GetTheDate); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@UserIdx_Fx", model.UserIdx_Fx)
			,new SqlParameter("@MedalIdx_Fx", model.MedalIdx_Fx)
			,new SqlParameter("@GetEvent", model.GetEvent)
			,new SqlParameter("@MedalNumber", model.MedalNumber)
			,new SqlParameter("@GetTheDate", model.GetTheDate)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_medalGetLog model) 
 	 {
		 string sql = "update Tab_medalGetLog set UserIdx_Fx=@UserIdx_Fx,MedalIdx_Fx=@MedalIdx_Fx,GetEvent=@GetEvent,MedalNumber=@MedalNumber,GetTheDate=@GetTheDate where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@UserIdx_Fx", model.UserIdx_Fx)
			 ,new SqlParameter("@MedalIdx_Fx", model.MedalIdx_Fx)
			 ,new SqlParameter("@GetEvent", model.GetEvent)
			 ,new SqlParameter("@MedalNumber", model.MedalNumber)
			 ,new SqlParameter("@GetTheDate", model.GetTheDate)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_medalGetLog where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_medalGetLog ToModel(DataRow row)
	{
		Tab_medalGetLog model = new Tab_medalGetLog();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.UserIdx_Fx = row.IsNull("UserIdx_Fx")?null:(System.Int32?)row["UserIdx_Fx"];
		model.MedalIdx_Fx = row.IsNull("MedalIdx_Fx")?null:(System.Int32?)row["MedalIdx_Fx"];
		model.GetEvent = row.IsNull("GetEvent")?null:(System.String)row["GetEvent"];
		model.MedalNumber = row.IsNull("MedalNumber")?null:(System.Int32?)row["MedalNumber"];
		model.GetTheDate = row.IsNull("GetTheDate")?null:(System.DateTime?)row["GetTheDate"];
		return model;
	}

	public Tab_medalGetLog Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_medalGetLog  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_medalGetLog model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_medalGetLog> ListAll()
	{
		List<Tab_medalGetLog> list = new List<Tab_medalGetLog>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_medalGetLog").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_medalGetLog> ListAll(string strSql)
	{
		List<Tab_medalGetLog> list = new List<Tab_medalGetLog>();
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
		string strSql = " select * from Tab_medalGetLog";
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
