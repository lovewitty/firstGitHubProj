using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_HomeWeibo
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String EditName { get; set; }
		 public System.String HeaderImg { get; set; }
		 public System.String WeiboContent { get; set; }
		 public System.Int32? SortNo { get; set; }
		 public System.DateTime? DateCreated { get; set; }
		 public System.String HomeShowBool { get; set; }

	 public int AddNew(Tab_HomeWeibo model) 
 	 {
		string sql = "insert into Tab_HomeWeibo(EditName,HeaderImg,WeiboContent,SortNo,HomeShowBool)  values(@EditName,@HeaderImg,@WeiboContent,@SortNo,@HomeShowBool); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@EditName", model.EditName)
			,new SqlParameter("@HeaderImg", model.HeaderImg)
			,new SqlParameter("@WeiboContent", model.WeiboContent)
			,new SqlParameter("@SortNo", model.SortNo)
		
			,new SqlParameter("@HomeShowBool", model.HomeShowBool)
			 ));
		 return Idx;
	 }

	 public bool Update(Tab_HomeWeibo model) 
 	 {
		 string sql = "update Tab_HomeWeibo set EditName=@EditName,HeaderImg=@HeaderImg,WeiboContent=@WeiboContent,SortNo=@SortNo,DateCreated=@DateCreated,HomeShowBool=@HomeShowBool where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@EditName", model.EditName)
			 ,new SqlParameter("@HeaderImg", model.HeaderImg)
			 ,new SqlParameter("@WeiboContent", model.WeiboContent)
			 ,new SqlParameter("@SortNo", model.SortNo)
			 ,new SqlParameter("@DateCreated", model.DateCreated)
			 ,new SqlParameter("@HomeShowBool", model.HomeShowBool)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_HomeWeibo where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_HomeWeibo ToModel(DataRow row)
	{
		Tab_HomeWeibo model = new Tab_HomeWeibo();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.EditName = row.IsNull("EditName")?null:(System.String)row["EditName"];
		model.HeaderImg = row.IsNull("HeaderImg")?null:(System.String)row["HeaderImg"];
		model.WeiboContent = row.IsNull("WeiboContent")?null:(System.String)row["WeiboContent"];
		model.SortNo = row.IsNull("SortNo")?null:(System.Int32?)row["SortNo"];
		model.DateCreated = row.IsNull("DateCreated")?null:(System.DateTime?)row["DateCreated"];
		model.HomeShowBool = row.IsNull("HomeShowBool")?null:(System.String)row["HomeShowBool"];
		return model;
	}

	public Tab_HomeWeibo Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_HomeWeibo  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_HomeWeibo model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_HomeWeibo> ListAll()
	{
		List<Tab_HomeWeibo> list = new List<Tab_HomeWeibo>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_HomeWeibo").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_HomeWeibo> ListAll(string strSql)
	{
		List<Tab_HomeWeibo> list = new List<Tab_HomeWeibo>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,strSql).Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

    public static DataSet GetDs_Where(string beginDate, string endDate, string keywords)
    {
        List<SqlParameter> spsList = new List<SqlParameter>();
        string strSql = " select * from Tab_HomeWeibo";
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
            strWhere = strWhere + " and (EditName like @keywords or WeiboContent like @keywords)";
            spsList.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
        }
        strSql = strSql + strWhere + " order by DateCreated desc";
        DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, strSql, spsList.ToArray());
        return ds;
    }
   } 
}
