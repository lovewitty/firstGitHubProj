using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_CourseMain_Type
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String CourseMainType { get; set; }
		 public System.DateTime? CreatedDate { get; set; }

	 public int AddNew(Tab_CourseMain_Type model) 
 	 {
		string sql = "insert into Tab_CourseMain_Type(CourseMainType,CreatedDate)  values(@CourseMainType,@CreatedDate); select @@identity ;";
		 int idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@CourseMainType", model.CourseMainType)
			,new SqlParameter("@CreatedDate", model.CreatedDate)
			 ));
		 return idx;
	 }

	 public bool Update(Tab_CourseMain_Type model) 
 	 {
		 string sql = "update Tab_CourseMain_Type set CourseMainType=@CourseMainType,CreatedDate=@CreatedDate where idx=@idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@CourseMainType", model.CourseMainType)
			 ,new SqlParameter("@CreatedDate", model.CreatedDate)
			 ,new SqlParameter("idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_CourseMain_Type where idx=@idx",
			  new SqlParameter("idx",idx));
		 return rows > 0; 
 	 }

	private static Tab_CourseMain_Type ToModel(DataRow row)
	{
		Tab_CourseMain_Type model = new Tab_CourseMain_Type();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.CourseMainType = row.IsNull("CourseMainType")?null:(System.String)row["CourseMainType"];
		model.CreatedDate = row.IsNull("CreatedDate")?null:(System.DateTime?)row["CreatedDate"];
		return model;
	}

    public Tab_CourseMain_Type Get(string idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_CourseMain_Type  where idx=@idx",
				new SqlParameter("idx",idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_CourseMain_Type model = ToModel(row);
		return model;
	}

  

	public IEnumerable<Tab_CourseMain_Type> ListAll()
	{
		List<Tab_CourseMain_Type> list = new List<Tab_CourseMain_Type>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_CourseMain_Type").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_CourseMain_Type> ListAll(string strSql)
	{
		List<Tab_CourseMain_Type> list = new List<Tab_CourseMain_Type>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,strSql).Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

    public static DataSet GetDs()
    {
        string strSql = " select * from Tab_CourseMain_Type order by 2";
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql);
        return ds; 
    }

	public static DataSet GetDs_Where(string beginDate,string endDate,string keywords)
	{
		List<SqlParameter> spsList = new List<SqlParameter>();
		string strSql = " select * from Tab_CourseMain_Type";
		string strWhere = " where 1=1 ";
	if (!String.IsNullOrEmpty(beginDate)) 
	{
        strWhere = strWhere + " and CreatedDate >= @beginDate";
		spsList.Add(new SqlParameter("@beginDate", beginDate));
	}
		if (!String.IsNullOrEmpty(endDate)) 
		{
            strWhere = strWhere + " and CreatedDate >= @endDate";
			spsList.Add(new SqlParameter("@endDate", endDate + " 23:59:59"));
		}
		if (!String.IsNullOrEmpty(keywords)) 
		{
			keywords = keywords.Replace("'", "''");
            strWhere = strWhere + " and (CourseMainType like @keywords)";
			spsList.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
		}
        strSql = strSql + strWhere + " order by CreatedDate desc";
		 DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql, spsList.ToArray());
		return ds; 
	}
   } 
}
