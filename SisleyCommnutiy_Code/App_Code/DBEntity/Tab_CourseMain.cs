using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_CourseMain
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String PreviewImg { get; set; }
		 public System.String Title { get; set; }
		 public System.String CourseContent { get; set; }
		 public System.Int32? SortNo { get; set; }
		 public System.DateTime? DateCreated { get; set; }
		 public System.DateTime? ReleaseDate { get; set; }
		 public System.String HomeShowBool { get; set; }
         public System.Int32? CourseMainTypeIdx_Fx { get; set; }

	 public int AddNew(Tab_CourseMain model) 
 	 {
         string sql = "insert into Tab_CourseMain(PreviewImg,Title,CourseContent,SortNo,ReleaseDate,HomeShowBool,CourseMainTypeIdx_Fx)  values(@PreviewImg,@Title,@CourseContent,@SortNo,@ReleaseDate,@HomeShowBool,@CourseMainTypeIdx_Fx); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@PreviewImg", model.PreviewImg)
			,new SqlParameter("@Title", model.Title)
			,new SqlParameter("@CourseContent", model.CourseContent)
			,new SqlParameter("@SortNo", model.SortNo)
	
			,new SqlParameter("@ReleaseDate", model.ReleaseDate)
			,new SqlParameter("@HomeShowBool", model.HomeShowBool)
            , new SqlParameter("@CourseMainTypeIdx_Fx", model.CourseMainTypeIdx_Fx)            
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_CourseMain model) 
 	 {
         string sql = "update Tab_CourseMain set PreviewImg=@PreviewImg,Title=@Title,CourseContent=@CourseContent,SortNo=@SortNo,DateCreated=getdate(),ReleaseDate=@ReleaseDate,HomeShowBool=@HomeShowBool,CourseMainTypeIdx_Fx=@CourseMainTypeIdx_Fx where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@PreviewImg", model.PreviewImg)
			 ,new SqlParameter("@Title", model.Title)
			 ,new SqlParameter("@CourseContent", model.CourseContent)
			 ,new SqlParameter("@SortNo", model.SortNo)

			 ,new SqlParameter("@ReleaseDate", model.ReleaseDate)
			 ,new SqlParameter("@HomeShowBool", model.HomeShowBool)
              , new SqlParameter("@CourseMainTypeIdx_Fx", model.CourseMainTypeIdx_Fx)
             
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_CourseMain where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_CourseMain ToModel(DataRow row)
	{
		Tab_CourseMain model = new Tab_CourseMain();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.PreviewImg = row.IsNull("PreviewImg")?null:(System.String)row["PreviewImg"];
		model.Title = row.IsNull("Title")?null:(System.String)row["Title"];
		model.CourseContent = row.IsNull("CourseContent")?null:(System.String)row["CourseContent"];
		model.SortNo = row.IsNull("SortNo")?null:(System.Int32?)row["SortNo"];
		model.DateCreated = row.IsNull("DateCreated")?null:(System.DateTime?)row["DateCreated"];
		model.ReleaseDate = row.IsNull("ReleaseDate")?null:(System.DateTime?)row["ReleaseDate"];
		model.HomeShowBool = row.IsNull("HomeShowBool")?null:(System.String)row["HomeShowBool"];

        model.CourseMainTypeIdx_Fx = row.IsNull("CourseMainTypeIdx_Fx") ? null : (System.Int32?)row["CourseMainTypeIdx_Fx"];
        
		return model;
	}

	public Tab_CourseMain Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_CourseMain  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_CourseMain model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_CourseMain> ListAll()
	{
		List<Tab_CourseMain> list = new List<Tab_CourseMain>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_CourseMain").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_CourseMain> ListAll(string strSql)
	{
		List<Tab_CourseMain> list = new List<Tab_CourseMain>();
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
        string strSql = " select * from v_CourseMain";
		string strWhere = " where 1=1 ";
	if (!String.IsNullOrEmpty(beginDate)) 
	{
        strWhere = strWhere + " and DateCreated >= @beginDate";
		spsList.Add(new SqlParameter("@beginDate", beginDate));
	}
		if (!String.IsNullOrEmpty(endDate)) 
		{
            strWhere = strWhere + " and DateCreated <= @endDate";
			spsList.Add(new SqlParameter("@endDate", endDate + " 23:59:59"));
		}
		if (!String.IsNullOrEmpty(keywords)) 
		{
			keywords = keywords.Replace("'", "''");
            strWhere = strWhere + " and (Title like @keywords or CourseContent like @keywords or CourseMainType like @keywords)";
			spsList.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
		}
        strSql = strSql + strWhere + " order by CourseMainType, SortNo , DateCreated desc";
		 DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql, spsList.ToArray());
		return ds; 
	}
   } 
}
