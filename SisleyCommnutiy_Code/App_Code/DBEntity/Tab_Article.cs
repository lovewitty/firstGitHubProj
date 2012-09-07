using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_Article
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String Title { get; set; }
		 public System.String PreviewPicture { get; set; }
		 public System.String Content { get; set; }
		 public System.DateTime? CreatedDate { get; set; }
		 public System.DateTime? ReleaseDate { get; set; }
		 public System.String HomeShowsBool { get; set; }

	 public int AddNew(Tab_Article model) 
 	 {
		string sql = "insert into Tab_Article(Title,PreviewPicture,Content,CreatedDate,ReleaseDate,HomeShowsBool)  values(@Title,@PreviewPicture,@Content,getdate(),@ReleaseDate,@HomeShowsBool); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@Title", model.Title)
			,new SqlParameter("@PreviewPicture", model.PreviewPicture)
			,new SqlParameter("@Content", model.Content)

			,new SqlParameter("@ReleaseDate", model.ReleaseDate)
			,new SqlParameter("@HomeShowsBool", model.HomeShowsBool)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_Article model) 
 	 {
		 string sql = "update Tab_Article set Title=@Title,PreviewPicture=@PreviewPicture,Content=@Content,ReleaseDate=@ReleaseDate,HomeShowsBool=@HomeShowsBool where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@Title", model.Title)
			 ,new SqlParameter("@PreviewPicture", model.PreviewPicture)
			 ,new SqlParameter("@Content", model.Content)
			 ,new SqlParameter("@ReleaseDate", model.ReleaseDate)
			 ,new SqlParameter("@HomeShowsBool", model.HomeShowsBool)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_Article where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_Article ToModel(DataRow row)
	{
		Tab_Article model = new Tab_Article();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.Title = row.IsNull("Title")?null:(System.String)row["Title"];
		model.PreviewPicture = row.IsNull("PreviewPicture")?null:(System.String)row["PreviewPicture"];
		model.Content = row.IsNull("Content")?null:(System.String)row["Content"];
		model.CreatedDate = row.IsNull("CreatedDate")?null:(System.DateTime?)row["CreatedDate"];
		model.ReleaseDate = row.IsNull("ReleaseDate")?null:(System.DateTime?)row["ReleaseDate"];
		model.HomeShowsBool = row.IsNull("HomeShowsBool")?null:(System.String)row["HomeShowsBool"];
		return model;
	}

	public Tab_Article Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Article  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_Article model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_Article> ListAll()
	{
		List<Tab_Article> list = new List<Tab_Article>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Article").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_Article> ListAll(string strSql)
	{
		List<Tab_Article> list = new List<Tab_Article>();
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
		string strSql = " select * from Tab_Article";
		string strWhere = " where 1=1 ";
	if (!String.IsNullOrEmpty(beginDate)) 
	{
        strWhere = strWhere + " and CreatedDate >= @beginDate";
		spsList.Add(new SqlParameter("@beginDate", beginDate));
	}
		if (!String.IsNullOrEmpty(endDate)) 
		{
            strWhere = strWhere + " and CreatedDate <= @endDate";
			spsList.Add(new SqlParameter("@endDate", endDate + " 23:59:59"));
		}
		if (!String.IsNullOrEmpty(keywords)) 
		{
			keywords = keywords.Replace("'", "''");
            strWhere = strWhere + " and (Title like @keywords or [Content] like @keywords)";
			spsList.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
		}
        strSql = strSql + strWhere + " order by CreatedDate desc";
		 DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql, spsList.ToArray());
		return ds; 
	}
   } 
}
