using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_SmartPerson_QA
	 {
		 public System.Int32? Idx { get; set; }
		 public System.Int32? UserUId_Fx { get; set; }
		 public System.Int32? QuestionTypeId_FxIdx { get; set; }
		 public System.String AnswerContent { get; set; }
		 public System.DateTime? AnswerDate { get; set; }
		 public System.String QuestionContent { get; set; }
		 public System.DateTime? QuestionDate { get; set; }
		 public System.String StateBool { get; set; }
		 public System.Int32? SmartPersonIdx_Fx { get; set; }

	 public int AddNew(Tab_SmartPerson_QA model) 
 	 {
		string sql = "insert into Tab_SmartPerson_QA(UserUId_Fx,QuestionTypeId_FxIdx,AnswerContent,AnswerDate,QuestionContent,QuestionDate,StateBool,SmartPersonIdx_Fx)  values(@UserUId_Fx,@QuestionTypeId_FxIdx,@AnswerContent,@AnswerDate,@QuestionContent,@QuestionDate,@StateBool,@SmartPersonIdx_Fx); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@UserUId_Fx", model.UserUId_Fx)
			,new SqlParameter("@QuestionTypeId_FxIdx", model.QuestionTypeId_FxIdx)
			,new SqlParameter("@AnswerContent", model.AnswerContent)
			,new SqlParameter("@AnswerDate", model.AnswerDate)
			,new SqlParameter("@QuestionContent", model.QuestionContent)
			,new SqlParameter("@QuestionDate", model.QuestionDate)
			,new SqlParameter("@StateBool", model.StateBool)
			,new SqlParameter("@SmartPersonIdx_Fx", model.SmartPersonIdx_Fx)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_SmartPerson_QA model) 
 	 {
		 string sql = "update Tab_SmartPerson_QA set UserUId_Fx=@UserUId_Fx,QuestionTypeId_FxIdx=@QuestionTypeId_FxIdx,AnswerContent=@AnswerContent,AnswerDate=@AnswerDate,QuestionContent=@QuestionContent,QuestionDate=@QuestionDate,StateBool=@StateBool,SmartPersonIdx_Fx=@SmartPersonIdx_Fx where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@UserUId_Fx", model.UserUId_Fx)
			 ,new SqlParameter("@QuestionTypeId_FxIdx", model.QuestionTypeId_FxIdx)
			 ,new SqlParameter("@AnswerContent", model.AnswerContent)
			 ,new SqlParameter("@AnswerDate", model.AnswerDate)
			 ,new SqlParameter("@QuestionContent", model.QuestionContent)
			 ,new SqlParameter("@QuestionDate", model.QuestionDate)
			 ,new SqlParameter("@StateBool", model.StateBool)
			 ,new SqlParameter("@SmartPersonIdx_Fx", model.SmartPersonIdx_Fx)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_SmartPerson_QA where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_SmartPerson_QA ToModel(DataRow row)
	{
		Tab_SmartPerson_QA model = new Tab_SmartPerson_QA();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.UserUId_Fx = row.IsNull("UserUId_Fx")?null:(System.Int32?)row["UserUId_Fx"];
		model.QuestionTypeId_FxIdx = row.IsNull("QuestionTypeId_FxIdx")?null:(System.Int32?)row["QuestionTypeId_FxIdx"];
		model.AnswerContent = row.IsNull("AnswerContent")?null:(System.String)row["AnswerContent"];
		model.AnswerDate = row.IsNull("AnswerDate")?null:(System.DateTime?)row["AnswerDate"];
		model.QuestionContent = row.IsNull("QuestionContent")?null:(System.String)row["QuestionContent"];
		model.QuestionDate = row.IsNull("QuestionDate")?null:(System.DateTime?)row["QuestionDate"];
		model.StateBool = row.IsNull("StateBool")?null:(System.String)row["StateBool"];
		model.SmartPersonIdx_Fx = row.IsNull("SmartPersonIdx_Fx")?null:(System.Int32?)row["SmartPersonIdx_Fx"];
		return model;
	}

	public Tab_SmartPerson_QA Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_SmartPerson_QA  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_SmartPerson_QA model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_SmartPerson_QA> ListAll()
	{
		List<Tab_SmartPerson_QA> list = new List<Tab_SmartPerson_QA>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_SmartPerson_QA").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_SmartPerson_QA> ListAll(string strSql)
	{
		List<Tab_SmartPerson_QA> list = new List<Tab_SmartPerson_QA>();
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
        string strSql = " select * from v_SmartPerson_QA ";
		string strWhere = " where 1=1 ";
	if (!String.IsNullOrEmpty(beginDate)) 
	{
        strWhere = strWhere + " and QuestionDate >= @beginDate";
		spsList.Add(new SqlParameter("@beginDate", beginDate));
	}
		if (!String.IsNullOrEmpty(endDate)) 
		{
            strWhere = strWhere + " and QuestionDate <= @endDate";
			spsList.Add(new SqlParameter("@endDate", endDate + " 23:59:59"));
		}
		if (!String.IsNullOrEmpty(keywords)) 
		{
			keywords = keywords.Replace("'", "''");
            strWhere = strWhere + " and (AnswerContent like @keywords or QuestionContent like @keywords)";
			spsList.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
		}
        strSql = strSql + strWhere + " order by QuestionDate desc";
		 DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql, spsList.ToArray());
		return ds; 
	}
   } 
}
