using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_Activity
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String ActiveTitle { get; set; }
		 public System.String PreviewImg { get; set; }
		 public System.DateTime? ActivityStartDate { get; set; }
		 public System.DateTime? ActivityEndDate { get; set; }
		 public System.String Rules { get; set; }
		 public System.String Platform { get; set; }
		 public System.String Prizes { get; set; }
		 public System.String SharingCopyContent { get; set; }
		 public System.DateTime? DateCreated { get; set; }
		 public System.String DisplayHomeBool { get; set; }
		 public System.String DisplayHomePreview { get; set; }

	 public int AddNew(Tab_Activity model) 
 	 {
		string sql = "insert into Tab_Activity(ActiveTitle,PreviewImg,ActivityStartDate,ActivityEndDate,Rules,Platform,Prizes,SharingCopyContent,DisplayHomeBool,DisplayHomePreview)  values(@ActiveTitle,@PreviewImg,@ActivityStartDate,@ActivityEndDate,@Rules,@Platform,@Prizes,@SharingCopyContent,@DisplayHomeBool,@DisplayHomePreview); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@ActiveTitle", model.ActiveTitle)
			,new SqlParameter("@PreviewImg", model.PreviewImg)
			,new SqlParameter("@ActivityStartDate", model.ActivityStartDate)
			,new SqlParameter("@ActivityEndDate", model.ActivityEndDate)
			,new SqlParameter("@Rules", model.Rules)
			,new SqlParameter("@Platform", model.Platform)
			,new SqlParameter("@Prizes", model.Prizes)
			,new SqlParameter("@SharingCopyContent", model.SharingCopyContent)

			,new SqlParameter("@DisplayHomeBool", model.DisplayHomeBool)
			,new SqlParameter("@DisplayHomePreview", model.DisplayHomePreview)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_Activity model) 
 	 {
		 string sql = "update Tab_Activity set ActiveTitle=@ActiveTitle,PreviewImg=@PreviewImg,ActivityStartDate=@ActivityStartDate,ActivityEndDate=@ActivityEndDate,Rules=@Rules,Platform=@Platform,Prizes=@Prizes,SharingCopyContent=@SharingCopyContent,DisplayHomeBool=@DisplayHomeBool,DisplayHomePreview=@DisplayHomePreview where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@ActiveTitle", model.ActiveTitle)
			 ,new SqlParameter("@PreviewImg", model.PreviewImg)
			 ,new SqlParameter("@ActivityStartDate", model.ActivityStartDate)
			 ,new SqlParameter("@ActivityEndDate", model.ActivityEndDate)
			 ,new SqlParameter("@Rules", model.Rules)
			 ,new SqlParameter("@Platform", model.Platform)
			 ,new SqlParameter("@Prizes", model.Prizes)
			 ,new SqlParameter("@SharingCopyContent", model.SharingCopyContent)

			 ,new SqlParameter("@DisplayHomeBool", model.DisplayHomeBool)
			 ,new SqlParameter("@DisplayHomePreview", model.DisplayHomePreview)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_Activity where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_Activity ToModel(DataRow row)
	{
		Tab_Activity model = new Tab_Activity();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.ActiveTitle = row.IsNull("ActiveTitle")?null:(System.String)row["ActiveTitle"];
		model.PreviewImg = row.IsNull("PreviewImg")?null:(System.String)row["PreviewImg"];
		model.ActivityStartDate = row.IsNull("ActivityStartDate")?null:(System.DateTime?)row["ActivityStartDate"];
		model.ActivityEndDate = row.IsNull("ActivityEndDate")?null:(System.DateTime?)row["ActivityEndDate"];
		model.Rules = row.IsNull("Rules")?null:(System.String)row["Rules"];
		model.Platform = row.IsNull("Platform")?null:(System.String)row["Platform"];
		model.Prizes = row.IsNull("Prizes")?null:(System.String)row["Prizes"];
		model.SharingCopyContent = row.IsNull("SharingCopyContent")?null:(System.String)row["SharingCopyContent"];
		model.DateCreated = row.IsNull("DateCreated")?null:(System.DateTime?)row["DateCreated"];
		model.DisplayHomeBool = row.IsNull("DisplayHomeBool")?null:(System.String)row["DisplayHomeBool"];
		model.DisplayHomePreview = row.IsNull("DisplayHomePreview")?null:(System.String)row["DisplayHomePreview"];
		return model;
	}

	public Tab_Activity Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Activity  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_Activity model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_Activity> ListAll()
	{
		List<Tab_Activity> list = new List<Tab_Activity>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Activity").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_Activity> ListAll(string strSql)
	{
		List<Tab_Activity> list = new List<Tab_Activity>();
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
		string strSql = " select * from Tab_Activity";
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
            strWhere = strWhere + " and (ActiveTitle like @keywords )";
			spsList.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
		}
        strSql = strSql + strWhere + " order by DisplayHomeBool desc,ActivityEndDate desc";
		 DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql, spsList.ToArray());
		return ds; 
	}
   } 
}
