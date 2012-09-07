using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_Smart_QA_Type
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String AskTypeName { get; set; }

	 public int AddNew(Tab_Smart_QA_Type model) 
 	 {
		string sql = "insert into Tab_Smart_QA_Type(AskTypeName)  values(@AskTypeName); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@AskTypeName", model.AskTypeName)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_Smart_QA_Type model) 
 	 {
		 string sql = "update Tab_Smart_QA_Type set AskTypeName=@AskTypeName where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@AskTypeName", model.AskTypeName)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_Smart_QA_Type where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_Smart_QA_Type ToModel(DataRow row)
	{
		Tab_Smart_QA_Type model = new Tab_Smart_QA_Type();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.AskTypeName = row.IsNull("AskTypeName")?null:(System.String)row["AskTypeName"];
		return model;
	}

	public Tab_Smart_QA_Type Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Smart_QA_Type  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_Smart_QA_Type model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_Smart_QA_Type> ListAll()
	{
		List<Tab_Smart_QA_Type> list = new List<Tab_Smart_QA_Type>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Smart_QA_Type").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_Smart_QA_Type> ListAll(string strSql)
	{
		List<Tab_Smart_QA_Type> list = new List<Tab_Smart_QA_Type>();
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
		string strSql = " select * from Tab_Smart_QA_Type";
		string strWhere = " where 1=1 ";
    
		strSql = strSql + strWhere + " order by 2 ";
		 DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql, spsList.ToArray());
		return ds; 
	}
   } 
}
