using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_UserCertificate
	 {
		 public System.Int32? Idx { get; set; }
		 public System.Int32? UserIdx_FxIdx { get; set; }
		 public System.String CertificateMap { get; set; }
		 public System.DateTime? GetTheDate { get; set; }

	 public int AddNew(Tab_UserCertificate model) 
 	 {
		string sql = "insert into Tab_UserCertificate(UserIdx_FxIdx,CertificateMap,GetTheDate)  values(@UserIdx_FxIdx,@CertificateMap,@GetTheDate); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@UserIdx_FxIdx", model.UserIdx_FxIdx)
			,new SqlParameter("@CertificateMap", model.CertificateMap)
			,new SqlParameter("@GetTheDate", model.GetTheDate)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_UserCertificate model) 
 	 {
		 string sql = "update Tab_UserCertificate set UserIdx_FxIdx=@UserIdx_FxIdx,CertificateMap=@CertificateMap,GetTheDate=@GetTheDate where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@UserIdx_FxIdx", model.UserIdx_FxIdx)
			 ,new SqlParameter("@CertificateMap", model.CertificateMap)
			 ,new SqlParameter("@GetTheDate", model.GetTheDate)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_UserCertificate where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_UserCertificate ToModel(DataRow row)
	{
		Tab_UserCertificate model = new Tab_UserCertificate();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.UserIdx_FxIdx = row.IsNull("UserIdx_FxIdx")?null:(System.Int32?)row["UserIdx_FxIdx"];
		model.CertificateMap = row.IsNull("CertificateMap")?null:(System.String)row["CertificateMap"];
		model.GetTheDate = row.IsNull("GetTheDate")?null:(System.DateTime?)row["GetTheDate"];
		return model;
	}

	public Tab_UserCertificate Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_UserCertificate  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_UserCertificate model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_UserCertificate> ListAll()
	{
		List<Tab_UserCertificate> list = new List<Tab_UserCertificate>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_UserCertificate").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_UserCertificate> ListAll(string strSql)
	{
		List<Tab_UserCertificate> list = new List<Tab_UserCertificate>();
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
		string strSql = " select * from Tab_UserCertificate";
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
