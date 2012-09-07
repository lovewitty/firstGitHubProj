using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_QuestionAndAnswer
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String ContentQuestion { get; set; }
		 public System.String ContentAnswer { get; set; }
		 public System.DateTime? DateAsk { get; set; }
		 public System.DateTime? DateAnswer { get; set; }
		 public System.Int32? PassBool { get; set; }
		 public System.Int32? AskUserId_Fx { get; set; }
		 public System.Int32? ManagerUserIdx_Fx { get; set; }
		 public System.Int32? QuestionSubTypeIdx_Fx { get; set; }

	 public int AddNew(Tab_QuestionAndAnswer model) 
 	 {
		string sql = "insert into Tab_QuestionAndAnswer(ContentQuestion,ContentAnswer,DateAsk,DateAnswer,PassBool,AskUserId_Fx,ManagerUserIdx_Fx,QuestionSubTypeIdx_Fx)  values(@ContentQuestion,@ContentAnswer,@DateAsk,@DateAnswer,@PassBool,@AskUserId_Fx,@ManagerUserIdx_Fx,@QuestionSubTypeIdx_Fx); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@ContentQuestion", model.ContentQuestion)
			,new SqlParameter("@ContentAnswer", model.ContentAnswer)
			,new SqlParameter("@DateAsk", model.DateAsk)
			,new SqlParameter("@DateAnswer", model.DateAnswer)
			,new SqlParameter("@PassBool", model.PassBool)
			,new SqlParameter("@AskUserId_Fx", model.AskUserId_Fx)
			,new SqlParameter("@ManagerUserIdx_Fx", model.ManagerUserIdx_Fx)
			,new SqlParameter("@QuestionSubTypeIdx_Fx", model.QuestionSubTypeIdx_Fx)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_QuestionAndAnswer model) 
 	 {
		 string sql = "update Tab_QuestionAndAnswer set ContentQuestion=@ContentQuestion,ContentAnswer=@ContentAnswer,DateAsk=@DateAsk,DateAnswer=@DateAnswer,PassBool=@PassBool,AskUserId_Fx=@AskUserId_Fx,ManagerUserIdx_Fx=@ManagerUserIdx_Fx,QuestionSubTypeIdx_Fx=@QuestionSubTypeIdx_Fx where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@ContentQuestion", model.ContentQuestion)
			 ,new SqlParameter("@ContentAnswer", model.ContentAnswer)
			 ,new SqlParameter("@DateAsk", model.DateAsk)
			 ,new SqlParameter("@DateAnswer", model.DateAnswer)
			 ,new SqlParameter("@PassBool", model.PassBool)
			 ,new SqlParameter("@AskUserId_Fx", model.AskUserId_Fx)
			 ,new SqlParameter("@ManagerUserIdx_Fx", model.ManagerUserIdx_Fx)
			 ,new SqlParameter("@QuestionSubTypeIdx_Fx", model.QuestionSubTypeIdx_Fx)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_QuestionAndAnswer where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_QuestionAndAnswer ToModel(DataRow row)
	{
		Tab_QuestionAndAnswer model = new Tab_QuestionAndAnswer();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.ContentQuestion = row.IsNull("ContentQuestion")?null:(System.String)row["ContentQuestion"];
		model.ContentAnswer = row.IsNull("ContentAnswer")?null:(System.String)row["ContentAnswer"];
		model.DateAsk = row.IsNull("DateAsk")?null:(System.DateTime?)row["DateAsk"];
		model.DateAnswer = row.IsNull("DateAnswer")?null:(System.DateTime?)row["DateAnswer"];
		model.PassBool = row.IsNull("PassBool")?null:(System.Int32?)row["PassBool"];
		model.AskUserId_Fx = row.IsNull("AskUserId_Fx")?null:(System.Int32?)row["AskUserId_Fx"];
		model.ManagerUserIdx_Fx = row.IsNull("ManagerUserIdx_Fx")?null:(System.Int32?)row["ManagerUserIdx_Fx"];
		model.QuestionSubTypeIdx_Fx = row.IsNull("QuestionSubTypeIdx_Fx")?null:(System.Int32?)row["QuestionSubTypeIdx_Fx"];
		return model;
	}

	public Tab_QuestionAndAnswer Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_QuestionAndAnswer  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_QuestionAndAnswer model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_QuestionAndAnswer> ListAll()
	{
		List<Tab_QuestionAndAnswer> list = new List<Tab_QuestionAndAnswer>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_QuestionAndAnswer").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_QuestionAndAnswer> ListAll(string strSql)
	{
		List<Tab_QuestionAndAnswer> list = new List<Tab_QuestionAndAnswer>();
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
		string strSql = " select * from Tab_QuestionAndAnswer";
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
