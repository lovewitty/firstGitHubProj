using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_UserArticle_Product
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String ProductPictures { get; set; }
		 public System.String ProductTitle { get; set; }
		 public System.String ProductOverview { get; set; }
		 public System.String ProductCategoryIdx_Fx { get; set; }
		 public System.String ProductImpression { get; set; }

	 public int AddNew(Tab_UserArticle_Product model) 
 	 {
		string sql = "insert into Tab_UserArticle_Product(ProductPictures,ProductTitle,ProductOverview,ProductCategoryIdx_Fx,ProductImpression)  values(@ProductPictures,@ProductTitle,@ProductOverview,@ProductCategoryIdx_Fx,@ProductImpression); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@ProductPictures", model.ProductPictures)
			,new SqlParameter("@ProductTitle", model.ProductTitle)
			,new SqlParameter("@ProductOverview", model.ProductOverview)
			,new SqlParameter("@ProductCategoryIdx_Fx", model.ProductCategoryIdx_Fx)
			,new SqlParameter("@ProductImpression", model.ProductImpression)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_UserArticle_Product model) 
 	 {
		 string sql = "update Tab_UserArticle_Product set ProductPictures=@ProductPictures,ProductTitle=@ProductTitle,ProductOverview=@ProductOverview,ProductCategoryIdx_Fx=@ProductCategoryIdx_Fx,ProductImpression=@ProductImpression where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@ProductPictures", model.ProductPictures)
			 ,new SqlParameter("@ProductTitle", model.ProductTitle)
			 ,new SqlParameter("@ProductOverview", model.ProductOverview)
			 ,new SqlParameter("@ProductCategoryIdx_Fx", model.ProductCategoryIdx_Fx)
			 ,new SqlParameter("@ProductImpression", model.ProductImpression)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_UserArticle_Product where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_UserArticle_Product ToModel(DataRow row)
	{
		Tab_UserArticle_Product model = new Tab_UserArticle_Product();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.ProductPictures = row.IsNull("ProductPictures")?null:(System.String)row["ProductPictures"];
		model.ProductTitle = row.IsNull("ProductTitle")?null:(System.String)row["ProductTitle"];
		model.ProductOverview = row.IsNull("ProductOverview")?null:(System.String)row["ProductOverview"];
		model.ProductCategoryIdx_Fx = row.IsNull("ProductCategoryIdx_Fx")?null:(System.String)row["ProductCategoryIdx_Fx"];
		model.ProductImpression = row.IsNull("ProductImpression")?null:(System.String)row["ProductImpression"];
		return model;
	}

	public Tab_UserArticle_Product Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_UserArticle_Product  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_UserArticle_Product model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_UserArticle_Product> ListAll()
	{
		List<Tab_UserArticle_Product> list = new List<Tab_UserArticle_Product>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_UserArticle_Product").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_UserArticle_Product> ListAll(string strSql)
	{
		List<Tab_UserArticle_Product> list = new List<Tab_UserArticle_Product>();
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
		string strSql = " select * from Tab_UserArticle_Product";
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
