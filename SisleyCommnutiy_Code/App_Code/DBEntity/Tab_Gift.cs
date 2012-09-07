using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_Gift
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String GiftName { get; set; }
		 public System.String GiftImgSmall { get; set; }
		 public System.String GiftImgBig { get; set; }
		 public System.String GiftDescription { get; set; }
		 public System.Int32? NeedPoint { get; set; }
		 public System.DateTime? CreatedDate { get; set; }
		 public System.DateTime? ExpirationDate { get; set; }

	 public int AddNew(Tab_Gift model) 
 	 {
		string sql = "insert into Tab_Gift(GiftName,GiftImgSmall,GiftImgBig,GiftDescription,NeedPoint,CreatedDate,ExpirationDate)  values(@GiftName,@GiftImgSmall,@GiftImgBig,@GiftDescription,@NeedPoint,@CreatedDate,@ExpirationDate); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@GiftName", model.GiftName)
			,new SqlParameter("@GiftImgSmall", model.GiftImgSmall)
			,new SqlParameter("@GiftImgBig", model.GiftImgBig)
			,new SqlParameter("@GiftDescription", model.GiftDescription)
			,new SqlParameter("@NeedPoint", model.NeedPoint)
			,new SqlParameter("@CreatedDate", model.CreatedDate)
			,new SqlParameter("@ExpirationDate", model.ExpirationDate)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_Gift model) 
 	 {
		 string sql = "update Tab_Gift set GiftName=@GiftName,GiftImgSmall=@GiftImgSmall,GiftImgBig=@GiftImgBig,GiftDescription=@GiftDescription,NeedPoint=@NeedPoint,CreatedDate=@CreatedDate,ExpirationDate=@ExpirationDate where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@GiftName", model.GiftName)
			 ,new SqlParameter("@GiftImgSmall", model.GiftImgSmall)
			 ,new SqlParameter("@GiftImgBig", model.GiftImgBig)
			 ,new SqlParameter("@GiftDescription", model.GiftDescription)
			 ,new SqlParameter("@NeedPoint", model.NeedPoint)
			 ,new SqlParameter("@CreatedDate", model.CreatedDate)
			 ,new SqlParameter("@ExpirationDate", model.ExpirationDate)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_Gift where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_Gift ToModel(DataRow row)
	{
		Tab_Gift model = new Tab_Gift();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.GiftName = row.IsNull("GiftName")?null:(System.String)row["GiftName"];
		model.GiftImgSmall = row.IsNull("GiftImgSmall")?null:(System.String)row["GiftImgSmall"];
		model.GiftImgBig = row.IsNull("GiftImgBig")?null:(System.String)row["GiftImgBig"];
		model.GiftDescription = row.IsNull("GiftDescription")?null:(System.String)row["GiftDescription"];
		model.NeedPoint = row.IsNull("NeedPoint")?null:(System.Int32?)row["NeedPoint"];
		model.CreatedDate = row.IsNull("CreatedDate")?null:(System.DateTime?)row["CreatedDate"];
		model.ExpirationDate = row.IsNull("ExpirationDate")?null:(System.DateTime?)row["ExpirationDate"];
		return model;
	}

	public Tab_Gift Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Gift  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_Gift model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_Gift> ListAll()
	{
		List<Tab_Gift> list = new List<Tab_Gift>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Gift").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_Gift> ListAll(string strSql)
	{
		List<Tab_Gift> list = new List<Tab_Gift>();
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
		string strSql = " select * from Tab_Gift";
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
