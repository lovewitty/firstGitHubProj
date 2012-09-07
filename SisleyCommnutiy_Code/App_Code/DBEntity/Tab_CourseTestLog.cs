using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_CourseTestLog
	 {
		 public System.Int32? Idx { get; set; }
		 public System.Int32? UserIdx_Fx { get; set; }
		 public System.Int32? CourseMainIdx_Fx { get; set; }
		 public System.String TestAnswer { get; set; }
		 public System.String PassBool { get; set; }
		 public System.DateTime? CreatedDate { get; set; }

	 public int AddNew(Tab_CourseTestLog model) 
 	 {
		string sql = "insert into Tab_CourseTestLog(UserIdx_Fx,CourseMainIdx_Fx,TestAnswer,PassBool,CreatedDate)  values(@UserIdx_Fx,@CourseMainIdx_Fx,@TestAnswer,@PassBool,@CreatedDate); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@UserIdx_Fx", model.UserIdx_Fx)
			,new SqlParameter("@CourseMainIdx_Fx", model.CourseMainIdx_Fx)
			,new SqlParameter("@TestAnswer", model.TestAnswer)
			,new SqlParameter("@PassBool", model.PassBool)
			,new SqlParameter("@CreatedDate", model.CreatedDate)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_CourseTestLog model) 
 	 {
		 string sql = "update Tab_CourseTestLog set UserIdx_Fx=@UserIdx_Fx,CourseMainIdx_Fx=@CourseMainIdx_Fx,TestAnswer=@TestAnswer,PassBool=@PassBool,CreatedDate=@CreatedDate where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@UserIdx_Fx", model.UserIdx_Fx)
			 ,new SqlParameter("@CourseMainIdx_Fx", model.CourseMainIdx_Fx)
			 ,new SqlParameter("@TestAnswer", model.TestAnswer)
			 ,new SqlParameter("@PassBool", model.PassBool)
			 ,new SqlParameter("@CreatedDate", model.CreatedDate)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_CourseTestLog where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_CourseTestLog ToModel(DataRow row)
	{
		Tab_CourseTestLog model = new Tab_CourseTestLog();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.UserIdx_Fx = row.IsNull("UserIdx_Fx")?null:(System.Int32?)row["UserIdx_Fx"];
		model.CourseMainIdx_Fx = row.IsNull("CourseMainIdx_Fx")?null:(System.Int32?)row["CourseMainIdx_Fx"];
		model.TestAnswer = row.IsNull("TestAnswer")?null:(System.String)row["TestAnswer"];
		model.PassBool = row.IsNull("PassBool")?null:(System.String)row["PassBool"];
		model.CreatedDate = row.IsNull("CreatedDate")?null:(System.DateTime?)row["CreatedDate"];
		return model;
	}

	public Tab_CourseTestLog Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_CourseTestLog  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_CourseTestLog model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_CourseTestLog> ListAll()
	{
		List<Tab_CourseTestLog> list = new List<Tab_CourseTestLog>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_CourseTestLog").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_CourseTestLog> ListAll(string strSql)
	{
		List<Tab_CourseTestLog> list = new List<Tab_CourseTestLog>();
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
		string strSql = " select * from Tab_CourseTestLog";
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
