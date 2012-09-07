using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_Y_ProductType
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String TypeName { get; set; }
		 public System.Int32? OrdSec { get; set; }
		 public System.DateTime? CreateDate { get; set; }

	 public int AddNew(Tab_Y_ProductType model) 
 	 {
		string sql = "insert into Tab_Y_ProductType(TypeName,OrdSec,CreateDate)  values(@TypeName,@OrdSec,@CreateDate); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@TypeName", model.TypeName)
			,new SqlParameter("@OrdSec", model.OrdSec)
			,new SqlParameter("@CreateDate", model.CreateDate)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_Y_ProductType model) 
 	 {
		 string sql = "update Tab_Y_ProductType set TypeName=@TypeName,OrdSec=@OrdSec,CreateDate=@CreateDate where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@TypeName", model.TypeName)
			 ,new SqlParameter("@OrdSec", model.OrdSec)
			 ,new SqlParameter("@CreateDate", model.CreateDate)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_Y_ProductType where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_Y_ProductType ToModel(DataRow row)
	{
		Tab_Y_ProductType model = new Tab_Y_ProductType();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.TypeName = row.IsNull("TypeName")?null:(System.String)row["TypeName"];
		model.OrdSec = row.IsNull("OrdSec")?null:(System.Int32?)row["OrdSec"];
		model.CreateDate = row.IsNull("CreateDate")?null:(System.DateTime?)row["CreateDate"];
		return model;
	}

	public Tab_Y_ProductType Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Y_ProductType  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_Y_ProductType model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_Y_ProductType> ListAll()
	{
		List<Tab_Y_ProductType> list = new List<Tab_Y_ProductType>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Y_ProductType").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_Y_ProductType> ListAll(string strSql)
	{
		List<Tab_Y_ProductType> list = new List<Tab_Y_ProductType>();
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
		string strSql = " select * from Tab_Y_ProductType";
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
