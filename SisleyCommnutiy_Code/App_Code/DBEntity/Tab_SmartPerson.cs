using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_SmartPerson
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String DarenName { get; set; }
		 public System.String HeaderImg { get; set; }
		 public System.String Title { get; set; }
		 public System.String BeautyResume { get; set; }
		 public System.String BeautyShare { get; set; }
		 public System.String SinaShareContent { get; set; }
		 public System.DateTime? CreatedDate { get; set; }
		 public System.String showPageBool { get; set; }

	 public int AddNew(Tab_SmartPerson model) 
 	 {
		string sql = "insert into Tab_SmartPerson(DarenName,HeaderImg,Title,BeautyResume,BeautyShare,SinaShareContent,CreatedDate,showPageBool)  values(@DarenName,@HeaderImg,@Title,@BeautyResume,@BeautyShare,@SinaShareContent,@CreatedDate,@showPageBool); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@DarenName", model.DarenName)
			,new SqlParameter("@HeaderImg", model.HeaderImg)
			,new SqlParameter("@Title", model.Title)
			,new SqlParameter("@BeautyResume", model.BeautyResume)
			,new SqlParameter("@BeautyShare", model.BeautyShare)
			,new SqlParameter("@SinaShareContent", model.SinaShareContent)
			,new SqlParameter("@CreatedDate", model.CreatedDate)
			,new SqlParameter("@showPageBool", model.showPageBool)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_SmartPerson model) 
 	 {
		 string sql = "update Tab_SmartPerson set DarenName=@DarenName,HeaderImg=@HeaderImg,Title=@Title,BeautyResume=@BeautyResume,BeautyShare=@BeautyShare,SinaShareContent=@SinaShareContent,CreatedDate=@CreatedDate,showPageBool=@showPageBool where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@DarenName", model.DarenName)
			 ,new SqlParameter("@HeaderImg", model.HeaderImg)
			 ,new SqlParameter("@Title", model.Title)
			 ,new SqlParameter("@BeautyResume", model.BeautyResume)
			 ,new SqlParameter("@BeautyShare", model.BeautyShare)
			 ,new SqlParameter("@SinaShareContent", model.SinaShareContent)
			 ,new SqlParameter("@CreatedDate", model.CreatedDate)
			 ,new SqlParameter("@showPageBool", model.showPageBool)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_SmartPerson where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_SmartPerson ToModel(DataRow row)
	{
		Tab_SmartPerson model = new Tab_SmartPerson();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.DarenName = row.IsNull("DarenName")?null:(System.String)row["DarenName"];
		model.HeaderImg = row.IsNull("HeaderImg")?null:(System.String)row["HeaderImg"];
		model.Title = row.IsNull("Title")?null:(System.String)row["Title"];
		model.BeautyResume = row.IsNull("BeautyResume")?null:(System.String)row["BeautyResume"];
		model.BeautyShare = row.IsNull("BeautyShare")?null:(System.String)row["BeautyShare"];
		model.SinaShareContent = row.IsNull("SinaShareContent")?null:(System.String)row["SinaShareContent"];
		model.CreatedDate = row.IsNull("CreatedDate")?null:(System.DateTime?)row["CreatedDate"];
		model.showPageBool = row.IsNull("showPageBool")?null:(System.String)row["showPageBool"];
		return model;
	}

	public Tab_SmartPerson Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_SmartPerson  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_SmartPerson model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_SmartPerson> ListAll()
	{
		List<Tab_SmartPerson> list = new List<Tab_SmartPerson>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_SmartPerson").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_SmartPerson> ListAll(string strSql)
	{
		List<Tab_SmartPerson> list = new List<Tab_SmartPerson>();
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
		string strSql = " select * from Tab_SmartPerson";
		string strWhere = " where 1=1 ";
	if (!String.IsNullOrEmpty(beginDate)) 
	{
        strWhere = strWhere + " and QuestionDate >= @beginDate";
		spsList.Add(new SqlParameter("@beginDate", beginDate));
	}
		if (!String.IsNullOrEmpty(endDate)) 
		{
            strWhere = strWhere + " and QuestionDate <= @endDate";
			spsList.Add(new SqlParameter("@endDate", endDate + " 23:59:59"));
		}
		if (!String.IsNullOrEmpty(keywords)) 
		{
			keywords = keywords.Replace("'", "''");
            strWhere = strWhere + " and (AnswerContent like @keywords or QuestionContent like @keywords)";
			spsList.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
		}
        strSql = strSql + strWhere + " order by QuestionDate desc";
		 DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql, spsList.ToArray());
		return ds; 
	}
   } 
}
