using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_QA_Type
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String QaTypeName { get; set; }
		 public System.Int32? SortNumb { get; set; }

	 public int AddNew(Tab_QA_Type model) 
 	 {
		string sql = "insert into Tab_QA_Type(QaTypeName,SortNumb)  values(@QaTypeName,@SortNumb); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@QaTypeName", model.QaTypeName)
			,new SqlParameter("@SortNumb", model.SortNumb)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_QA_Type model) 
 	 {
		 string sql = "update Tab_QA_Type set QaTypeName=@QaTypeName,SortNumb=@SortNumb where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@QaTypeName", model.QaTypeName)
			 ,new SqlParameter("@SortNumb", model.SortNumb)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_QA_Type where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_QA_Type ToModel(DataRow row)
	{
		Tab_QA_Type model = new Tab_QA_Type();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.QaTypeName = row.IsNull("QaTypeName")?null:(System.String)row["QaTypeName"];
		model.SortNumb = row.IsNull("SortNumb")?null:(System.Int32?)row["SortNumb"];
		return model;
	}

	public Tab_QA_Type Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_QA_Type  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_QA_Type model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_QA_Type> ListAll()
	{
		List<Tab_QA_Type> list = new List<Tab_QA_Type>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_QA_Type").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_QA_Type> ListAll(string strSql)
	{
		List<Tab_QA_Type> list = new List<Tab_QA_Type>();
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
		string strSql = " select * from Tab_QA_Type";
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
