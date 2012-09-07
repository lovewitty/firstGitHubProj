using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_QA_SubType
	 {
		 public System.Int32? Idx { get; set; }
		 public System.Int32? QaTypeIdx_Fx { get; set; }
		 public System.String QaSubTypeName { get; set; }

	 public int AddNew(Tab_QA_SubType model) 
 	 {
		string sql = "insert into Tab_QA_SubType(QaTypeIdx_Fx,QaSubTypeName)  values(@QaTypeIdx_Fx,@QaSubTypeName); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@QaTypeIdx_Fx", model.QaTypeIdx_Fx)
			,new SqlParameter("@QaSubTypeName", model.QaSubTypeName)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_QA_SubType model) 
 	 {
		 string sql = "update Tab_QA_SubType set QaTypeIdx_Fx=@QaTypeIdx_Fx,QaSubTypeName=@QaSubTypeName where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@QaTypeIdx_Fx", model.QaTypeIdx_Fx)
			 ,new SqlParameter("@QaSubTypeName", model.QaSubTypeName)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_QA_SubType where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_QA_SubType ToModel(DataRow row)
	{
		Tab_QA_SubType model = new Tab_QA_SubType();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.QaTypeIdx_Fx = row.IsNull("QaTypeIdx_Fx")?null:(System.Int32?)row["QaTypeIdx_Fx"];
		model.QaSubTypeName = row.IsNull("QaSubTypeName")?null:(System.String)row["QaSubTypeName"];
		return model;
	}

	public Tab_QA_SubType Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_QA_SubType  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_QA_SubType model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_QA_SubType> ListAll()
	{
		List<Tab_QA_SubType> list = new List<Tab_QA_SubType>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_QA_SubType").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_QA_SubType> ListAll(string strSql)
	{
		List<Tab_QA_SubType> list = new List<Tab_QA_SubType>();
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
		string strSql = " select * from Tab_QA_SubType";
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
