using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_magazineDetail
	 {
		 public System.Int32? Idx { get; set; }
		 public System.Int32? MagazineIdx_Fx { get; set; }
		 public System.String MultimediaCategory { get; set; }
		 public System.String Path { get; set; }
		 public System.DateTime? CreatedDate { get; set; }

	 public int AddNew(Tab_magazineDetail model) 
 	 {
		string sql = "insert into Tab_magazineDetail(MagazineIdx_Fx,MultimediaCategory,Path,CreatedDate)  values(@MagazineIdx_Fx,@MultimediaCategory,@Path,@CreatedDate); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@MagazineIdx_Fx", model.MagazineIdx_Fx)
			,new SqlParameter("@MultimediaCategory", model.MultimediaCategory)
			,new SqlParameter("@Path", model.Path)
			,new SqlParameter("@CreatedDate", model.CreatedDate)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_magazineDetail model) 
 	 {
		 string sql = "update Tab_magazineDetail set MagazineIdx_Fx=@MagazineIdx_Fx,MultimediaCategory=@MultimediaCategory,Path=@Path,CreatedDate=@CreatedDate where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@MagazineIdx_Fx", model.MagazineIdx_Fx)
			 ,new SqlParameter("@MultimediaCategory", model.MultimediaCategory)
			 ,new SqlParameter("@Path", model.Path)
			 ,new SqlParameter("@CreatedDate", model.CreatedDate)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_magazineDetail where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_magazineDetail ToModel(DataRow row)
	{
		Tab_magazineDetail model = new Tab_magazineDetail();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.MagazineIdx_Fx = row.IsNull("MagazineIdx_Fx")?null:(System.Int32?)row["MagazineIdx_Fx"];
		model.MultimediaCategory = row.IsNull("MultimediaCategory")?null:(System.String)row["MultimediaCategory"];
		model.Path = row.IsNull("Path")?null:(System.String)row["Path"];
		model.CreatedDate = row.IsNull("CreatedDate")?null:(System.DateTime?)row["CreatedDate"];
		return model;
	}

	public Tab_magazineDetail Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_magazineDetail  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_magazineDetail model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_magazineDetail> ListAll()
	{
		List<Tab_magazineDetail> list = new List<Tab_magazineDetail>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_magazineDetail").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_magazineDetail> ListAll(string strSql)
	{
		List<Tab_magazineDetail> list = new List<Tab_magazineDetail>();
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
		string strSql = " select * from Tab_magazineDetail";
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
