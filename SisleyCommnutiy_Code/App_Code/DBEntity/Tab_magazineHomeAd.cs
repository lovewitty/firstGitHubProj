using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_magazineHomeAd
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String DownlowdRarPath { get; set; }
		 public System.String BrowserUrl { get; set; }

	 public int AddNew(Tab_magazineHomeAd model) 
 	 {
		string sql = "insert into Tab_magazineHomeAd(DownlowdRarPath,BrowserUrl)  values(@DownlowdRarPath,@BrowserUrl); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@DownlowdRarPath", model.DownlowdRarPath)
			,new SqlParameter("@BrowserUrl", model.BrowserUrl)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_magazineHomeAd model) 
 	 {
		 string sql = "update Tab_magazineHomeAd set DownlowdRarPath=@DownlowdRarPath,BrowserUrl=@BrowserUrl where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@DownlowdRarPath", model.DownlowdRarPath)
			 ,new SqlParameter("@BrowserUrl", model.BrowserUrl)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_magazineHomeAd where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_magazineHomeAd ToModel(DataRow row)
	{
		Tab_magazineHomeAd model = new Tab_magazineHomeAd();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.DownlowdRarPath = row.IsNull("DownlowdRarPath")?null:(System.String)row["DownlowdRarPath"];
		model.BrowserUrl = row.IsNull("BrowserUrl")?null:(System.String)row["BrowserUrl"];
		return model;
	}

	public Tab_magazineHomeAd Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_magazineHomeAd  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_magazineHomeAd model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_magazineHomeAd> ListAll()
	{
		List<Tab_magazineHomeAd> list = new List<Tab_magazineHomeAd>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_magazineHomeAd").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_magazineHomeAd> ListAll(string strSql)
	{
		List<Tab_magazineHomeAd> list = new List<Tab_magazineHomeAd>();
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
		string strSql = " select * from Tab_magazineHomeAd";
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
