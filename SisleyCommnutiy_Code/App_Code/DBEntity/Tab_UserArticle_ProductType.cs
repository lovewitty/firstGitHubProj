using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_UserArticle_ProductType
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String ProductCategoryName { get; set; }

	 public int AddNew(Tab_UserArticle_ProductType model) 
 	 {
		string sql = "insert into Tab_UserArticle_ProductType(ProductCategoryName)  values(@ProductCategoryName); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@ProductCategoryName", model.ProductCategoryName)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_UserArticle_ProductType model) 
 	 {
		 string sql = "update Tab_UserArticle_ProductType set ProductCategoryName=@ProductCategoryName where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@ProductCategoryName", model.ProductCategoryName)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_UserArticle_ProductType where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_UserArticle_ProductType ToModel(DataRow row)
	{
		Tab_UserArticle_ProductType model = new Tab_UserArticle_ProductType();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.ProductCategoryName = row.IsNull("ProductCategoryName")?null:(System.String)row["ProductCategoryName"];
		return model;
	}

	public Tab_UserArticle_ProductType Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_UserArticle_ProductType  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_UserArticle_ProductType model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_UserArticle_ProductType> ListAll()
	{
		List<Tab_UserArticle_ProductType> list = new List<Tab_UserArticle_ProductType>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_UserArticle_ProductType").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_UserArticle_ProductType> ListAll(string strSql)
	{
		List<Tab_UserArticle_ProductType> list = new List<Tab_UserArticle_ProductType>();
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
		string strSql = " select * from Tab_UserArticle_ProductType";
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
