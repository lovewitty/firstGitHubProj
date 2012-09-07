using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_Medal
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String MedalName { get; set; }
		 public System.String MedalImg { get; set; }
		 public System.String Notes { get; set; }

	 public int AddNew(Tab_Medal model) 
 	 {
		string sql = "insert into Tab_Medal(MedalName,MedalImg,Notes)  values(@MedalName,@MedalImg,@Notes); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@MedalName", model.MedalName)
			,new SqlParameter("@MedalImg", model.MedalImg)
			,new SqlParameter("@Notes", model.Notes)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_Medal model) 
 	 {
		 string sql = "update Tab_Medal set MedalName=@MedalName,MedalImg=@MedalImg,Notes=@Notes where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@MedalName", model.MedalName)
			 ,new SqlParameter("@MedalImg", model.MedalImg)
			 ,new SqlParameter("@Notes", model.Notes)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_Medal where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_Medal ToModel(DataRow row)
	{
		Tab_Medal model = new Tab_Medal();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.MedalName = row.IsNull("MedalName")?null:(System.String)row["MedalName"];
		model.MedalImg = row.IsNull("MedalImg")?null:(System.String)row["MedalImg"];
		model.Notes = row.IsNull("Notes")?null:(System.String)row["Notes"];
		return model;
	}

	public Tab_Medal Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Medal  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_Medal model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_Medal> ListAll()
	{
		List<Tab_Medal> list = new List<Tab_Medal>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Medal").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_Medal> ListAll(string strSql)
	{
		List<Tab_Medal> list = new List<Tab_Medal>();
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
		string strSql = " select * from Tab_Medal";
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
