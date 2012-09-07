using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_MedalProduct
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String ProductName { get; set; }
		 public System.String ProductDescription { get; set; }
		 public System.String ProductNeed_Medal { get; set; }
		 public System.Int32? NeedMedalCount { get; set; }
		 public System.DateTime? CreatedDate { get; set; }

	 public int AddNew(Tab_MedalProduct model) 
 	 {
		string sql = "insert into Tab_MedalProduct(ProductName,ProductDescription,ProductNeed_Medal,NeedMedalCount,CreatedDate)  values(@ProductName,@ProductDescription,@ProductNeed_Medal,@NeedMedalCount,@CreatedDate); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@ProductName", model.ProductName)
			,new SqlParameter("@ProductDescription", model.ProductDescription)
			,new SqlParameter("@ProductNeed_Medal", model.ProductNeed_Medal)
			,new SqlParameter("@NeedMedalCount", model.NeedMedalCount)
			,new SqlParameter("@CreatedDate", model.CreatedDate)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_MedalProduct model) 
 	 {
		 string sql = "update Tab_MedalProduct set ProductName=@ProductName,ProductDescription=@ProductDescription,ProductNeed_Medal=@ProductNeed_Medal,NeedMedalCount=@NeedMedalCount,CreatedDate=@CreatedDate where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@ProductName", model.ProductName)
			 ,new SqlParameter("@ProductDescription", model.ProductDescription)
			 ,new SqlParameter("@ProductNeed_Medal", model.ProductNeed_Medal)
			 ,new SqlParameter("@NeedMedalCount", model.NeedMedalCount)
			 ,new SqlParameter("@CreatedDate", model.CreatedDate)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_MedalProduct where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_MedalProduct ToModel(DataRow row)
	{
		Tab_MedalProduct model = new Tab_MedalProduct();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.ProductName = row.IsNull("ProductName")?null:(System.String)row["ProductName"];
		model.ProductDescription = row.IsNull("ProductDescription")?null:(System.String)row["ProductDescription"];
		model.ProductNeed_Medal = row.IsNull("ProductNeed_Medal")?null:(System.String)row["ProductNeed_Medal"];
		model.NeedMedalCount = row.IsNull("NeedMedalCount")?null:(System.Int32?)row["NeedMedalCount"];
		model.CreatedDate = row.IsNull("CreatedDate")?null:(System.DateTime?)row["CreatedDate"];
		return model;
	}

	public Tab_MedalProduct Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_MedalProduct  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_MedalProduct model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_MedalProduct> ListAll()
	{
		List<Tab_MedalProduct> list = new List<Tab_MedalProduct>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_MedalProduct").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_MedalProduct> ListAll(string strSql)
	{
		List<Tab_MedalProduct> list = new List<Tab_MedalProduct>();
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
		string strSql = " select * from Tab_MedalProduct";
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
