using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_TryProduct
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String ProductTitle { get; set; }
		 public System.String ProductPictures { get; set; }
		 public System.String ProductPictures2 { get; set; }
		 public System.String ProductPictures3 { get; set; }
		 public System.String ProductPictures4 { get; set; }
		 public System.String ProductDescription { get; set; }
		 public System.Int32? TotalCount { get; set; }
		 public System.Int32? LeftCount { get; set; }
		 public System.DateTime? DateCreated { get; set; }
		 public System.String currentBool { get; set; }

	 public int AddNew(Tab_TryProduct model) 
 	 {
		string sql = "insert into Tab_TryProduct(ProductTitle,ProductPictures,ProductPictures2,ProductPictures3,ProductPictures4,ProductDescription,TotalCount,LeftCount,DateCreated,currentBool)  values(@ProductTitle,@ProductPictures,@ProductPictures2,@ProductPictures3,@ProductPictures4,@ProductDescription,@TotalCount,@LeftCount,@DateCreated,@currentBool); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@ProductTitle", model.ProductTitle)
			,new SqlParameter("@ProductPictures", model.ProductPictures)
			,new SqlParameter("@ProductPictures2", model.ProductPictures2)
			,new SqlParameter("@ProductPictures3", model.ProductPictures3)
			,new SqlParameter("@ProductPictures4", model.ProductPictures4)
			,new SqlParameter("@ProductDescription", model.ProductDescription)
			,new SqlParameter("@TotalCount", model.TotalCount)
			,new SqlParameter("@LeftCount", model.LeftCount)
			,new SqlParameter("@DateCreated", model.DateCreated)
			,new SqlParameter("@currentBool", model.currentBool)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_TryProduct model) 
 	 {
		 string sql = "update Tab_TryProduct set ProductTitle=@ProductTitle,ProductPictures=@ProductPictures,ProductPictures2=@ProductPictures2,ProductPictures3=@ProductPictures3,ProductPictures4=@ProductPictures4,ProductDescription=@ProductDescription,TotalCount=@TotalCount,LeftCount=@LeftCount,DateCreated=@DateCreated,currentBool=@currentBool where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@ProductTitle", model.ProductTitle)
			 ,new SqlParameter("@ProductPictures", model.ProductPictures)
			 ,new SqlParameter("@ProductPictures2", model.ProductPictures2)
			 ,new SqlParameter("@ProductPictures3", model.ProductPictures3)
			 ,new SqlParameter("@ProductPictures4", model.ProductPictures4)
			 ,new SqlParameter("@ProductDescription", model.ProductDescription)
			 ,new SqlParameter("@TotalCount", model.TotalCount)
			 ,new SqlParameter("@LeftCount", model.LeftCount)
			 ,new SqlParameter("@DateCreated", model.DateCreated)
			 ,new SqlParameter("@currentBool", model.currentBool)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_TryProduct where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_TryProduct ToModel(DataRow row)
	{
		Tab_TryProduct model = new Tab_TryProduct();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.ProductTitle = row.IsNull("ProductTitle")?null:(System.String)row["ProductTitle"];
		model.ProductPictures = row.IsNull("ProductPictures")?null:(System.String)row["ProductPictures"];
		model.ProductPictures2 = row.IsNull("ProductPictures2")?null:(System.String)row["ProductPictures2"];
		model.ProductPictures3 = row.IsNull("ProductPictures3")?null:(System.String)row["ProductPictures3"];
		model.ProductPictures4 = row.IsNull("ProductPictures4")?null:(System.String)row["ProductPictures4"];
		model.ProductDescription = row.IsNull("ProductDescription")?null:(System.String)row["ProductDescription"];
		model.TotalCount = row.IsNull("TotalCount")?null:(System.Int32?)row["TotalCount"];
		model.LeftCount = row.IsNull("LeftCount")?null:(System.Int32?)row["LeftCount"];
		model.DateCreated = row.IsNull("DateCreated")?null:(System.DateTime?)row["DateCreated"];
		model.currentBool = row.IsNull("currentBool")?null:(System.String)row["currentBool"];
		return model;
	}

	public Tab_TryProduct Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_TryProduct  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_TryProduct model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_TryProduct> ListAll()
	{
		List<Tab_TryProduct> list = new List<Tab_TryProduct>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_TryProduct").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_TryProduct> ListAll(string strSql)
	{
		List<Tab_TryProduct> list = new List<Tab_TryProduct>();
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
		string strSql = " select * from Tab_TryProduct";
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
