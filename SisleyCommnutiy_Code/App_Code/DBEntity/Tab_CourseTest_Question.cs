using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_CourseTest_Question
	 {
		 public System.Int32? Idx { get; set; }
		 public System.Int32? CourseMainIdx_Fx { get; set; }
		 public System.String QuestionText { get; set; }
		 public System.String Aquestion { get; set; }
		 public System.String Bquestion { get; set; }
		 public System.String Cquestion { get; set; }
		 public System.String Dquestion { get; set; }
		 public System.String Answer { get; set; }

	 public int AddNew(Tab_CourseTest_Question model) 
 	 {
		string sql = "insert into Tab_CourseTest_Question(CourseMainIdx_Fx,QuestionText,Aquestion,Bquestion,Cquestion,Dquestion,Answer)  values(@CourseMainIdx_Fx,@QuestionText,@Aquestion,@Bquestion,@Cquestion,@Dquestion,@Answer); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@CourseMainIdx_Fx", model.CourseMainIdx_Fx)
			,new SqlParameter("@QuestionText", model.QuestionText)
			,new SqlParameter("@Aquestion", model.Aquestion)
			,new SqlParameter("@Bquestion", model.Bquestion)
			,new SqlParameter("@Cquestion", model.Cquestion)
			,new SqlParameter("@Dquestion", model.Dquestion)
			,new SqlParameter("@Answer", model.Answer)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_CourseTest_Question model) 
 	 {
		 string sql = "update Tab_CourseTest_Question set CourseMainIdx_Fx=@CourseMainIdx_Fx,QuestionText=@QuestionText,Aquestion=@Aquestion,Bquestion=@Bquestion,Cquestion=@Cquestion,Dquestion=@Dquestion,Answer=@Answer where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@CourseMainIdx_Fx", model.CourseMainIdx_Fx)
			 ,new SqlParameter("@QuestionText", model.QuestionText)
			 ,new SqlParameter("@Aquestion", model.Aquestion)
			 ,new SqlParameter("@Bquestion", model.Bquestion)
			 ,new SqlParameter("@Cquestion", model.Cquestion)
			 ,new SqlParameter("@Dquestion", model.Dquestion)
			 ,new SqlParameter("@Answer", model.Answer)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_CourseTest_Question where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_CourseTest_Question ToModel(DataRow row)
	{
		Tab_CourseTest_Question model = new Tab_CourseTest_Question();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.CourseMainIdx_Fx = row.IsNull("CourseMainIdx_Fx")?null:(System.Int32?)row["CourseMainIdx_Fx"];
		model.QuestionText = row.IsNull("QuestionText")?null:(System.String)row["QuestionText"];
		model.Aquestion = row.IsNull("Aquestion")?null:(System.String)row["Aquestion"];
		model.Bquestion = row.IsNull("Bquestion")?null:(System.String)row["Bquestion"];
		model.Cquestion = row.IsNull("Cquestion")?null:(System.String)row["Cquestion"];
		model.Dquestion = row.IsNull("Dquestion")?null:(System.String)row["Dquestion"];
		model.Answer = row.IsNull("Answer")?null:(System.String)row["Answer"];
		return model;
	}

	public Tab_CourseTest_Question Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_CourseTest_Question  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_CourseTest_Question model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_CourseTest_Question> ListAll()
	{
		List<Tab_CourseTest_Question> list = new List<Tab_CourseTest_Question>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_CourseTest_Question").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_CourseTest_Question> ListAll(string strSql)
	{
		List<Tab_CourseTest_Question> list = new List<Tab_CourseTest_Question>();
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
        string strSql = " select * from v_CourseMain_TestQuestion";
		string strWhere = " where 1=1 ";
	if (!String.IsNullOrEmpty(beginDate)) 
	{
        strWhere = strWhere + " and CreatedDate >= @beginDate";
		spsList.Add(new SqlParameter("@beginDate", beginDate));
	}
		if (!String.IsNullOrEmpty(endDate)) 
		{
            strWhere = strWhere + " and CreatedDate <= @endDate";
			spsList.Add(new SqlParameter("@endDate", endDate + " 23:59:59"));
		}
		if (!String.IsNullOrEmpty(keywords)) 
		{
			keywords = keywords.Replace("'", "''");
            strWhere = strWhere + " and (CourseMainTitle like @keywords or CourseMainType like @keywords or QuestionText like @keywords)";
			spsList.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
		}
        strSql = strSql + strWhere + " order by CourseMainType,CourseMainTitle,QuestionText";
		 DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql, spsList.ToArray());
		return ds; 
	}
   } 
}
