using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_SuperStarProduct
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String ProductTitle { get; set; }
		 public System.String ProductPictures { get; set; }
		 public System.String ProductDescription { get; set; }
		 public System.DateTime? DateCreated { get; set; }

	 public int AddNew(Tab_SuperStarProduct model) 
 	 {
		string sql = "insert into Tab_SuperStarProduct(ProductTitle,ProductPictures,ProductDescription,DateCreated)  values(@ProductTitle,@ProductPictures,@ProductDescription,@DateCreated); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@ProductTitle", model.ProductTitle)
			,new SqlParameter("@ProductPictures", model.ProductPictures)
			,new SqlParameter("@ProductDescription", model.ProductDescription)
			,new SqlParameter("@DateCreated", model.DateCreated)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_SuperStarProduct model) 
 	 {
		 string sql = "update Tab_SuperStarProduct set ProductTitle=@ProductTitle,ProductPictures=@ProductPictures,ProductDescription=@ProductDescription,DateCreated=@DateCreated where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@ProductTitle", model.ProductTitle)
			 ,new SqlParameter("@ProductPictures", model.ProductPictures)
			 ,new SqlParameter("@ProductDescription", model.ProductDescription)
			 ,new SqlParameter("@DateCreated", model.DateCreated)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_SuperStarProduct where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_SuperStarProduct ToModel(DataRow row)
	{
		Tab_SuperStarProduct model = new Tab_SuperStarProduct();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.ProductTitle = row.IsNull("ProductTitle")?null:(System.String)row["ProductTitle"];
		model.ProductPictures = row.IsNull("ProductPictures")?null:(System.String)row["ProductPictures"];
		model.ProductDescription = row.IsNull("ProductDescription")?null:(System.String)row["ProductDescription"];
		model.DateCreated = row.IsNull("DateCreated")?null:(System.DateTime?)row["DateCreated"];
		return model;
	}

	public Tab_SuperStarProduct Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_SuperStarProduct  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_SuperStarProduct model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_SuperStarProduct> ListAll()
	{
		List<Tab_SuperStarProduct> list = new List<Tab_SuperStarProduct>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_SuperStarProduct").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_SuperStarProduct> ListAll(string strSql)
	{
		List<Tab_SuperStarProduct> list = new List<Tab_SuperStarProduct>();
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
		string strSql = " select * from Tab_SuperStarProduct";
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
