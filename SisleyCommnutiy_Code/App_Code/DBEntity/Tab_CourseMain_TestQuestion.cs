using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_CourseMain_TestQuestion
	 {
		 public System.Int32? Idx { get; set; }
		 public System.Int32? CourseMainIdx_Fx { get; set; }
		 public System.String QuestionText { get; set; }
		 public System.String Aquestion { get; set; }
		 public System.String Bquestion { get; set; }
		 public System.String Cquestion { get; set; }
		 public System.String Dquestion { get; set; }
		 public System.String Answer { get; set; }
		 public System.DateTime? CreatedDate { get; set; }

	 public int AddNew(Tab_CourseMain_TestQuestion model) 
 	 {
		string sql = "insert into Tab_CourseMain_TestQuestion(CourseMainIdx_Fx,QuestionText,Aquestion,Bquestion,Cquestion,Dquestion,Answer,CreatedDate)  values(@CourseMainIdx_Fx,@QuestionText,@Aquestion,@Bquestion,@Cquestion,@Dquestion,@Answer,@CreatedDate); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@CourseMainIdx_Fx", model.CourseMainIdx_Fx)
			,new SqlParameter("@QuestionText", model.QuestionText)
			,new SqlParameter("@Aquestion", model.Aquestion)
			,new SqlParameter("@Bquestion", model.Bquestion)
			,new SqlParameter("@Cquestion", model.Cquestion)
			,new SqlParameter("@Dquestion", model.Dquestion)
			,new SqlParameter("@Answer", model.Answer)
			,new SqlParameter("@CreatedDate", model.CreatedDate)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_CourseMain_TestQuestion model) 
 	 {
		 string sql = "update Tab_CourseMain_TestQuestion set CourseMainIdx_Fx=@CourseMainIdx_Fx,QuestionText=@QuestionText,Aquestion=@Aquestion,Bquestion=@Bquestion,Cquestion=@Cquestion,Dquestion=@Dquestion,Answer=@Answer,CreatedDate=@CreatedDate where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@CourseMainIdx_Fx", model.CourseMainIdx_Fx)
			 ,new SqlParameter("@QuestionText", model.QuestionText)
			 ,new SqlParameter("@Aquestion", model.Aquestion)
			 ,new SqlParameter("@Bquestion", model.Bquestion)
			 ,new SqlParameter("@Cquestion", model.Cquestion)
			 ,new SqlParameter("@Dquestion", model.Dquestion)
			 ,new SqlParameter("@Answer", model.Answer)
			 ,new SqlParameter("@CreatedDate", model.CreatedDate)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_CourseMain_TestQuestion where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_CourseMain_TestQuestion ToModel(DataRow row)
	{
		Tab_CourseMain_TestQuestion model = new Tab_CourseMain_TestQuestion();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.CourseMainIdx_Fx = row.IsNull("CourseMainIdx_Fx")?null:(System.Int32?)row["CourseMainIdx_Fx"];
		model.QuestionText = row.IsNull("QuestionText")?null:(System.String)row["QuestionText"];
		model.Aquestion = row.IsNull("Aquestion")?null:(System.String)row["Aquestion"];
		model.Bquestion = row.IsNull("Bquestion")?null:(System.String)row["Bquestion"];
		model.Cquestion = row.IsNull("Cquestion")?null:(System.String)row["Cquestion"];
		model.Dquestion = row.IsNull("Dquestion")?null:(System.String)row["Dquestion"];
		model.Answer = row.IsNull("Answer")?null:(System.String)row["Answer"];
		model.CreatedDate = row.IsNull("CreatedDate")?null:(System.DateTime?)row["CreatedDate"];
		return model;
	}

	public Tab_CourseMain_TestQuestion Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_CourseMain_TestQuestion  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_CourseMain_TestQuestion model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_CourseMain_TestQuestion> ListAll()
	{
		List<Tab_CourseMain_TestQuestion> list = new List<Tab_CourseMain_TestQuestion>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_CourseMain_TestQuestion").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_CourseMain_TestQuestion> ListAll(string strSql)
	{
		List<Tab_CourseMain_TestQuestion> list = new List<Tab_CourseMain_TestQuestion>();
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
		string strSql = " select * from Tab_CourseMain_TestQuestion";
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
