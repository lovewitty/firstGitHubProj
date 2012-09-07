using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_magazine
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String MagazineQiKan { get; set; }
		 public System.String MagazineImg { get; set; }
		 public System.String MagazineRar { get; set; }
		 public System.DateTime? DateCreated { get; set; }

	 public int AddNew(Tab_magazine model) 
 	 {
		string sql = "insert into Tab_magazine(MagazineQiKan,MagazineImg,MagazineRar,DateCreated)  values(@MagazineQiKan,@MagazineImg,@MagazineRar,@DateCreated); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@MagazineQiKan", model.MagazineQiKan)
			,new SqlParameter("@MagazineImg", model.MagazineImg)
			,new SqlParameter("@MagazineRar", model.MagazineRar)
			,new SqlParameter("@DateCreated", model.DateCreated)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_magazine model) 
 	 {
		 string sql = "update Tab_magazine set MagazineQiKan=@MagazineQiKan,MagazineImg=@MagazineImg,MagazineRar=@MagazineRar,DateCreated=@DateCreated where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@MagazineQiKan", model.MagazineQiKan)
			 ,new SqlParameter("@MagazineImg", model.MagazineImg)
			 ,new SqlParameter("@MagazineRar", model.MagazineRar)
			 ,new SqlParameter("@DateCreated", model.DateCreated)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_magazine where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_magazine ToModel(DataRow row)
	{
		Tab_magazine model = new Tab_magazine();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.MagazineQiKan = row.IsNull("MagazineQiKan")?null:(System.String)row["MagazineQiKan"];
		model.MagazineImg = row.IsNull("MagazineImg")?null:(System.String)row["MagazineImg"];
		model.MagazineRar = row.IsNull("MagazineRar")?null:(System.String)row["MagazineRar"];
		model.DateCreated = row.IsNull("DateCreated")?null:(System.DateTime?)row["DateCreated"];
		return model;
	}

	public Tab_magazine Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_magazine  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_magazine model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_magazine> ListAll()
	{
		List<Tab_magazine> list = new List<Tab_magazine>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_magazine").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_magazine> ListAll(string strSql)
	{
		List<Tab_magazine> list = new List<Tab_magazine>();
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
		string strSql = " select * from Tab_magazine";
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
