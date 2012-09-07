using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_CourseMain_ViewLog
	 {
		 public System.Int32? Idx { get; set; }
		 public System.Int32? UIdx { get; set; }
		 public System.Int32? CourseMainIdx { get; set; }
		 public System.String IpAddress { get; set; }
		 public System.DateTime? CreatedDate { get; set; }

	 public int AddNew(Tab_CourseMain_ViewLog model) 
 	 {
		string sql = "insert into Tab_CourseMain_ViewLog(UIdx,CourseMainIdx,IpAddress,CreatedDate)  values(@UIdx,@CourseMainIdx,@IpAddress,@CreatedDate); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@UIdx", model.UIdx)
			,new SqlParameter("@CourseMainIdx", model.CourseMainIdx)
			,new SqlParameter("@IpAddress", model.IpAddress)
			,new SqlParameter("@CreatedDate", model.CreatedDate)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_CourseMain_ViewLog model) 
 	 {
		 string sql = "update Tab_CourseMain_ViewLog set UIdx=@UIdx,CourseMainIdx=@CourseMainIdx,IpAddress=@IpAddress,CreatedDate=@CreatedDate where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@UIdx", model.UIdx)
			 ,new SqlParameter("@CourseMainIdx", model.CourseMainIdx)
			 ,new SqlParameter("@IpAddress", model.IpAddress)
			 ,new SqlParameter("@CreatedDate", model.CreatedDate)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_CourseMain_ViewLog where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_CourseMain_ViewLog ToModel(DataRow row)
	{
		Tab_CourseMain_ViewLog model = new Tab_CourseMain_ViewLog();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.UIdx = row.IsNull("UIdx")?null:(System.Int32?)row["UIdx"];
		model.CourseMainIdx = row.IsNull("CourseMainIdx")?null:(System.Int32?)row["CourseMainIdx"];
		model.IpAddress = row.IsNull("IpAddress")?null:(System.String)row["IpAddress"];
		model.CreatedDate = row.IsNull("CreatedDate")?null:(System.DateTime?)row["CreatedDate"];
		return model;
	}

	public Tab_CourseMain_ViewLog Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_CourseMain_ViewLog  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_CourseMain_ViewLog model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_CourseMain_ViewLog> ListAll()
	{
		List<Tab_CourseMain_ViewLog> list = new List<Tab_CourseMain_ViewLog>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_CourseMain_ViewLog").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_CourseMain_ViewLog> ListAll(string strSql)
	{
		List<Tab_CourseMain_ViewLog> list = new List<Tab_CourseMain_ViewLog>();
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
		string strSql = " select * from Tab_CourseMain_ViewLog";
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
