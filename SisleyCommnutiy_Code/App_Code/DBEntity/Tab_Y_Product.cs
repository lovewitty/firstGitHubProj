using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_Y_Product
	 {
		 public System.Int32? Idx { get; set; }
		 public System.Int32? ProductTypeIdx { get; set; }
		 public System.String ProductNo { get; set; }
		 public System.String Title { get; set; }
		 public System.String ImagePath1 { get; set; }
		 public System.String ImagePath2 { get; set; }
		 public System.String ImagePath3 { get; set; }
		 public System.String Descript { get; set; }

	 public int AddNew(Tab_Y_Product model) 
 	 {
		string sql = "insert into Tab_Y_Product(ProductTypeIdx,ProductNo,Title,ImagePath1,ImagePath2,ImagePath3,Descript)  values(@ProductTypeIdx,@ProductNo,@Title,@ImagePath1,@ImagePath2,@ImagePath3,@Descript); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@ProductTypeIdx", model.ProductTypeIdx)
			,new SqlParameter("@ProductNo", model.ProductNo)
			,new SqlParameter("@Title", model.Title)
			,new SqlParameter("@ImagePath1", model.ImagePath1)
			,new SqlParameter("@ImagePath2", model.ImagePath2)
			,new SqlParameter("@ImagePath3", model.ImagePath3)
			,new SqlParameter("@Descript", model.Descript)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_Y_Product model) 
 	 {
		 string sql = "update Tab_Y_Product set ProductTypeIdx=@ProductTypeIdx,ProductNo=@ProductNo,Title=@Title,ImagePath1=@ImagePath1,ImagePath2=@ImagePath2,ImagePath3=@ImagePath3,Descript=@Descript where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@ProductTypeIdx", model.ProductTypeIdx)
			 ,new SqlParameter("@ProductNo", model.ProductNo)
			 ,new SqlParameter("@Title", model.Title)
			 ,new SqlParameter("@ImagePath1", model.ImagePath1)
			 ,new SqlParameter("@ImagePath2", model.ImagePath2)
			 ,new SqlParameter("@ImagePath3", model.ImagePath3)
			 ,new SqlParameter("@Descript", model.Descript)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_Y_Product where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_Y_Product ToModel(DataRow row)
	{
		Tab_Y_Product model = new Tab_Y_Product();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.ProductTypeIdx = row.IsNull("ProductTypeIdx")?null:(System.Int32?)row["ProductTypeIdx"];
		model.ProductNo = row.IsNull("ProductNo")?null:(System.String)row["ProductNo"];
		model.Title = row.IsNull("Title")?null:(System.String)row["Title"];
		model.ImagePath1 = row.IsNull("ImagePath1")?null:(System.String)row["ImagePath1"];
		model.ImagePath2 = row.IsNull("ImagePath2")?null:(System.String)row["ImagePath2"];
		model.ImagePath3 = row.IsNull("ImagePath3")?null:(System.String)row["ImagePath3"];
		model.Descript = row.IsNull("Descript")?null:(System.String)row["Descript"];
		return model;
	}

	public Tab_Y_Product Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Y_Product  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_Y_Product model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_Y_Product> ListAll()
	{
		List<Tab_Y_Product> list = new List<Tab_Y_Product>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_Y_Product").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_Y_Product> ListAll(string strSql)
	{
		List<Tab_Y_Product> list = new List<Tab_Y_Product>();
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
		string strSql = " select * from Tab_Y_Product";
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
