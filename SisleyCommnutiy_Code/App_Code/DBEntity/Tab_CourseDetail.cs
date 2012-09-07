using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_CourseDetail
	 {
		 public System.Int32? Idx { get; set; }
		 public System.Int32? CourseMainIdx_FxIdx { get; set; }
		 public System.String MediaCategory { get; set; }
		 public System.String MediaFilePath { get; set; }
		 public System.Object Content { get; set; }
		 public System.Int32? SortNumbers { get; set; }
		 public System.DateTime? DateCreated { get; set; }

	 public int AddNew(Tab_CourseDetail model) 
 	 {
		string sql = "insert into Tab_CourseDetail(CourseMainIdx_FxIdx,MediaCategory,MediaFilePath,Content,SortNumbers,DateCreated)  values(@CourseMainIdx_FxIdx,@MediaCategory,@MediaFilePath,@Content,@SortNumbers,@DateCreated); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@CourseMainIdx_FxIdx", model.CourseMainIdx_FxIdx)
			,new SqlParameter("@MediaCategory", model.MediaCategory)
			,new SqlParameter("@MediaFilePath", model.MediaFilePath)
			,new SqlParameter("@Content", model.Content)
			,new SqlParameter("@SortNumbers", model.SortNumbers)
			,new SqlParameter("@DateCreated", model.DateCreated)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_CourseDetail model) 
 	 {
		 string sql = "update Tab_CourseDetail set CourseMainIdx_FxIdx=@CourseMainIdx_FxIdx,MediaCategory=@MediaCategory,MediaFilePath=@MediaFilePath,Content=@Content,SortNumbers=@SortNumbers,DateCreated=@DateCreated where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@CourseMainIdx_FxIdx", model.CourseMainIdx_FxIdx)
			 ,new SqlParameter("@MediaCategory", model.MediaCategory)
			 ,new SqlParameter("@MediaFilePath", model.MediaFilePath)
			 ,new SqlParameter("@Content", model.Content)
			 ,new SqlParameter("@SortNumbers", model.SortNumbers)
			 ,new SqlParameter("@DateCreated", model.DateCreated)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_CourseDetail where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_CourseDetail ToModel(DataRow row)
	{
		Tab_CourseDetail model = new Tab_CourseDetail();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.CourseMainIdx_FxIdx = row.IsNull("CourseMainIdx_FxIdx")?null:(System.Int32?)row["CourseMainIdx_FxIdx"];
		model.MediaCategory = row.IsNull("MediaCategory")?null:(System.String)row["MediaCategory"];
		model.MediaFilePath = row.IsNull("MediaFilePath")?null:(System.String)row["MediaFilePath"];
		model.Content = row.IsNull("Content")?null:(System.Object)row["Content"];
		model.SortNumbers = row.IsNull("SortNumbers")?null:(System.Int32?)row["SortNumbers"];
		model.DateCreated = row.IsNull("DateCreated")?null:(System.DateTime?)row["DateCreated"];
		return model;
	}

	public Tab_CourseDetail Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_CourseDetail  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_CourseDetail model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_CourseDetail> ListAll()
	{
		List<Tab_CourseDetail> list = new List<Tab_CourseDetail>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_CourseDetail").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_CourseDetail> ListAll(string strSql)
	{
		List<Tab_CourseDetail> list = new List<Tab_CourseDetail>();
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
        string strSql = " select * from  v_CourseDetail";
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
            strWhere = strWhere + " and (CourseMainType like @keywords or Title like @keywords )";
			spsList.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
		}
        strSql = strSql + strWhere + " order by SortNumbers, DateCreated desc";
		 DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql, spsList.ToArray());
		return ds; 
	}
   } 
}
