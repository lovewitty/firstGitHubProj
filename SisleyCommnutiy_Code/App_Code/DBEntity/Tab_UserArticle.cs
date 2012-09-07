using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_UserArticle
	 {
		 public System.Int32? Idx { get; set; }
		 public System.Int32? UserUId_Fx { get; set; }
		 public System.String ForProductBool { get; set; }
		 public System.String ArticleTitle { get; set; }
		 public System.String ArticleContent { get; set; }
		 public System.DateTime? CreatedDate { get; set; }
		 public System.String PreviewAlternatePicture { get; set; }
		 public System.String ProductScore { get; set; }
		 public System.String ProductImpression { get; set; }
		 public System.Int32? ProductTryIdx_Fx { get; set; }

	 public int AddNew(Tab_UserArticle model) 
 	 {
		string sql = "insert into Tab_UserArticle(UserUId_Fx,ForProductBool,ArticleTitle,ArticleContent,CreatedDate,PreviewAlternatePicture,ProductScore,ProductImpression,ProductTryIdx_Fx)  values(@UserUId_Fx,@ForProductBool,@ArticleTitle,@ArticleContent,@CreatedDate,@PreviewAlternatePicture,@ProductScore,@ProductImpression,@ProductTryIdx_Fx); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@UserUId_Fx", model.UserUId_Fx)
			,new SqlParameter("@ForProductBool", model.ForProductBool)
			,new SqlParameter("@ArticleTitle", model.ArticleTitle)
			,new SqlParameter("@ArticleContent", model.ArticleContent)
			,new SqlParameter("@CreatedDate", model.CreatedDate)
			,new SqlParameter("@PreviewAlternatePicture", model.PreviewAlternatePicture)
			,new SqlParameter("@ProductScore", model.ProductScore)
			,new SqlParameter("@ProductImpression", model.ProductImpression)
			,new SqlParameter("@ProductTryIdx_Fx", model.ProductTryIdx_Fx)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_UserArticle model) 
 	 {
		 string sql = "update Tab_UserArticle set UserUId_Fx=@UserUId_Fx,ForProductBool=@ForProductBool,ArticleTitle=@ArticleTitle,ArticleContent=@ArticleContent,CreatedDate=@CreatedDate,PreviewAlternatePicture=@PreviewAlternatePicture,ProductScore=@ProductScore,ProductImpression=@ProductImpression,ProductTryIdx_Fx=@ProductTryIdx_Fx where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@UserUId_Fx", model.UserUId_Fx)
			 ,new SqlParameter("@ForProductBool", model.ForProductBool)
			 ,new SqlParameter("@ArticleTitle", model.ArticleTitle)
			 ,new SqlParameter("@ArticleContent", model.ArticleContent)
			 ,new SqlParameter("@CreatedDate", model.CreatedDate)
			 ,new SqlParameter("@PreviewAlternatePicture", model.PreviewAlternatePicture)
			 ,new SqlParameter("@ProductScore", model.ProductScore)
			 ,new SqlParameter("@ProductImpression", model.ProductImpression)
			 ,new SqlParameter("@ProductTryIdx_Fx", model.ProductTryIdx_Fx)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_UserArticle where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_UserArticle ToModel(DataRow row)
	{
		Tab_UserArticle model = new Tab_UserArticle();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.UserUId_Fx = row.IsNull("UserUId_Fx")?null:(System.Int32?)row["UserUId_Fx"];
		model.ForProductBool = row.IsNull("ForProductBool")?null:(System.String)row["ForProductBool"];
		model.ArticleTitle = row.IsNull("ArticleTitle")?null:(System.String)row["ArticleTitle"];
		model.ArticleContent = row.IsNull("ArticleContent")?null:(System.String)row["ArticleContent"];
		model.CreatedDate = row.IsNull("CreatedDate")?null:(System.DateTime?)row["CreatedDate"];
		model.PreviewAlternatePicture = row.IsNull("PreviewAlternatePicture")?null:(System.String)row["PreviewAlternatePicture"];
		model.ProductScore = row.IsNull("ProductScore")?null:(System.String)row["ProductScore"];
		model.ProductImpression = row.IsNull("ProductImpression")?null:(System.String)row["ProductImpression"];
		model.ProductTryIdx_Fx = row.IsNull("ProductTryIdx_Fx")?null:(System.Int32?)row["ProductTryIdx_Fx"];
		return model;
	}

	public Tab_UserArticle Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_UserArticle  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_UserArticle model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_UserArticle> ListAll()
	{
		List<Tab_UserArticle> list = new List<Tab_UserArticle>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_UserArticle").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_UserArticle> ListAll(string strSql)
	{
		List<Tab_UserArticle> list = new List<Tab_UserArticle>();
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
		string strSql = " select * from Tab_UserArticle";
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
