using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_Order2Gift
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String GiftTypeName { get; set; }
		 public System.String GiftSKU { get; set; }
		 public System.String SkuProperty { get; set; }
		 public System.String GiftNumber { get; set; }
		 public System.String GiftName { get; set; }
		 public System.String GiftImgBig { get; set; }
		 public System.String GiftImgSmall { get; set; }
		 public System.String GiftDescription { get; set; }
		 public System.String ArticleDigest { get; set; }
		 public System.Int32? NeedPoint { get; set; }
		 public System.String GifShowBool { get; set; }
		 public System.DateTime? CreatedDate { get; set; }
		 public System.DateTime? ExpirationDate { get; set; }
		 public System.String ColorTitle { get; set; }
		 public System.String ColorTitleImg { get; set; }

	 public int AddNew(Tab_Order2Gift model) 
 	 {
		string sql = "insert into Tab_Order2Gift(GiftTypeName,GiftSKU,SkuProperty,GiftNumber,GiftName,GiftImgBig,GiftImgSmall,GiftDescription,ArticleDigest,NeedPoint,GifShowBool,CreatedDate,ExpirationDate,ColorTitle,ColorTitleImg)  values(@GiftTypeName,@GiftSKU,@SkuProperty,@GiftNumber,@GiftName,@GiftImgBig,@GiftImgSmall,@GiftDescription,@ArticleDigest,@NeedPoint,@GifShowBool,@CreatedDate,@ExpirationDate,@ColorTitle,@ColorTitleImg); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@GiftTypeName", model.GiftTypeName)
			,new SqlParameter("@GiftSKU", model.GiftSKU)
			,new SqlParameter("@SkuProperty", model.SkuProperty)
			,new SqlParameter("@GiftNumber", model.GiftNumber)
			,new SqlParameter("@GiftName", model.GiftName)
			,new SqlParameter("@GiftImgBig", model.GiftImgBig)
			,new SqlParameter("@GiftImgSmall", model.GiftImgSmall)
			,new SqlParameter("@GiftDescription", model.GiftDescription)
			,new SqlParameter("@ArticleDigest", model.ArticleDigest)
			,new SqlParameter("@NeedPoint", model.NeedPoint)
			,new SqlParameter("@GifShowBool", model.GifShowBool)
			,new SqlParameter("@CreatedDate", model.CreatedDate)
			,new SqlParameter("@ExpirationDate", model.ExpirationDate)
			,new SqlParameter("@ColorTitle", model.ColorTitle)
			,new SqlParameter("@ColorTitleImg", model.ColorTitleImg)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_Order2Gift model) 
 	 {
		 string sql = "update Tab_Order2Gift set GiftTypeName=@GiftTypeName,GiftSKU=@GiftSKU,SkuProperty=@SkuProperty,GiftNumber=@GiftNumber,GiftName=@GiftName,GiftImgBig=@GiftImgBig,GiftImgSmall=@GiftImgSmall,GiftDescription=@GiftDescription,ArticleDigest=@ArticleDigest,NeedPoint=@NeedPoint,GifShowBool=@GifShowBool,CreatedDate=@CreatedDate,ExpirationDate=@ExpirationDate,ColorTitle=@ColorTitle,ColorTitleImg=@ColorTitleImg where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@GiftTypeName", model.GiftTypeName)
			 ,new SqlParameter("@GiftSKU", model.GiftSKU)
			 ,new SqlParameter("@SkuProperty", model.SkuProperty)
			 ,new SqlParameter("@GiftNumber", model.GiftNumber)
			 ,new SqlParameter("@GiftName", model.GiftName)
			 ,new SqlParameter("@GiftImgBig", model.GiftImgBig)
			 ,new SqlParameter("@GiftImgSmall", model.GiftImgSmall)
			 ,new SqlParameter("@GiftDescription", model.GiftDescription)
			 ,new SqlParameter("@ArticleDigest", model.ArticleDigest)
			 ,new SqlParameter("@NeedPoint", model.NeedPoint)
			 ,new SqlParameter("@GifShowBool", model.GifShowBool)
			 ,new SqlParameter("@CreatedDate", model.CreatedDate)
			 ,new SqlParameter("@ExpirationDate", model.ExpirationDate)
			 ,new SqlParameter("@ColorTitle", model.ColorTitle)
			 ,new SqlParameter("@ColorTitleImg", model.ColorTitleImg)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_Order2Gift where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_Order2Gift ToModel(DataRow row)
	{
		Tab_Order2Gift model = new Tab_Order2Gift();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.GiftTypeName = row.IsNull("GiftTypeName")?null:(System.String)row["GiftTypeName"];
		model.GiftSKU = row.IsNull("GiftSKU")?null:(System.String)row["GiftSKU"];
		model.SkuProperty = row.IsNull("SkuProperty")?null:(System.String)row["SkuProperty"];
		model.GiftNumber = row.IsNull("GiftNumber")?null:(System.String)row["GiftNumber"];
		model.GiftName = row.IsNull("GiftName")?null:(System.String)row["GiftName"];
		model.GiftImgBig = row.IsNull("GiftImgBig")?null:(System.String)row["GiftImgBig"];
		model.GiftImgSmall = row.IsNull("GiftImgSmall")?null:(System.String)row["GiftImgSmall"];
		model.GiftDescription = row.IsNull("GiftDescription")?null:(System.String)row["GiftDescription"];
		model.ArticleDigest = row.IsNull("ArticleDigest")?null:(System.String)row["ArticleDigest"];
		model.NeedPoint = row.IsNull("NeedPoint")?null:(System.Int32?)row["NeedPoint"];
		model.GifShowBool = row.IsNull("GifShowBool")?null:(System.String)row["GifShowBool"];
		model.CreatedDate = row.IsNull("CreatedDate")?null:(System.DateTime?)row["CreatedDate"];
		model.ExpirationDate = row.IsNull("ExpirationDate")?null:(System.DateTime?)row["ExpirationDate"];
		model.ColorTitle = row.IsNull("ColorTitle")?null:(System.String)row["ColorTitle"];
		model.ColorTitleImg = row.IsNull("ColorTitleImg")?null:(System.String)row["ColorTitleImg"];
		return model;
	}

	public Tab_Order2Gift Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Order2Gift  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_Order2Gift model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_Order2Gift> ListAll()
	{
		List<Tab_Order2Gift> list = new List<Tab_Order2Gift>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Order2Gift").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_Order2Gift> ListAll(string strSql)
	{
		List<Tab_Order2Gift> list = new List<Tab_Order2Gift>();
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
		string strSql = " select * from Tab_Order2Gift";
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
