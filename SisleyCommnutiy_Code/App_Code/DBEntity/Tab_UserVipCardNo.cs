using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBEntity
{
	public partial class Tab_UserVipCardNo
	 {
		 public System.Int32? Idx { get; set; }
		 public System.String VipCardNo { get; set; }
		 public System.String VipHasUseBool { get; set; }
		 public System.DateTime? VipEditDateTime { get; set; }

	 public int AddNew(Tab_UserVipCardNo model) 
 	 {
		string sql = "insert into Tab_UserVipCardNo(VipCardNo,VipHasUseBool,VipEditDateTime)  values(@VipCardNo,@VipHasUseBool,@VipEditDateTime); select @@identity ;";
		 int Idx =Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text,sql
			,new SqlParameter("@VipCardNo", model.VipCardNo)
			,new SqlParameter("@VipHasUseBool", model.VipHasUseBool)
			,new SqlParameter("@VipEditDateTime", model.VipEditDateTime)
			 ));
		 return Idx;
	 }

    /// <summary>
    /// ºÏ≤‚VipCardNo
    /// </summary>
    /// <param name="VipCardNo"></param>
    /// <returns></returns>
     public static int ChkVipCard(string VipCardNo)
     {
         string strSql = "select count(1) from Tab_UserVipCardNo where VipCardNo=@VipCardNo";
         return  Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, strSql, new SqlParameter("@VipCardNo", VipCardNo)));
     }

     public static int HasCardNo(string VipCardNo)
     {
         string strSql = "select count(1) from Tab_UserVipCardNo where VipCardNo=@VipCardNo and VipHasUseBool='yes'";
         return  Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, strSql, new SqlParameter("@VipCardNo", VipCardNo)));
     }



        
	 public bool Update(Tab_UserVipCardNo model) 
 	 {
		 string sql = "update Tab_UserVipCardNo set VipCardNo=@VipCardNo,VipHasUseBool=@VipHasUseBool,VipEditDateTime=@VipEditDateTime where Idx=@Idx";
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, sql
			 ,new SqlParameter("@VipCardNo", model.VipCardNo)
			 ,new SqlParameter("@VipHasUseBool", model.VipHasUseBool)
			 ,new SqlParameter("@VipEditDateTime", model.VipEditDateTime)
			 ,new SqlParameter("Idx",model.Idx)
			 );
		 return rows > 0; 
 	}

	 public bool Delete(string Idx) 
 	 {
		 int rows = SqlHelper.ExecuteNonQuery(CommandType.Text," delete from Tab_UserVipCardNo where Idx=@Idx",
			  new SqlParameter("Idx",Idx));
		 return rows > 0; 
 	 }

	private static Tab_UserVipCardNo ToModel(DataRow row)
	{
		Tab_UserVipCardNo model = new Tab_UserVipCardNo();
		model.Idx = row.IsNull("Idx")?null:(System.Int32?)row["Idx"];
		model.VipCardNo = row.IsNull("VipCardNo")?null:(System.String)row["VipCardNo"];
		model.VipHasUseBool = row.IsNull("VipHasUseBool")?null:(System.String)row["VipHasUseBool"];
		model.VipEditDateTime = row.IsNull("VipEditDateTime")?null:(System.DateTime?)row["VipEditDateTime"];
		return model;
	}

	public Tab_UserVipCardNo Get(string Idx)
	{
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_UserVipCardNo  where Idx=@Idx",
				new SqlParameter("Idx",Idx)).Tables[0];
		if (dt.Rows.Count > 1)
		{throw new Exception("more than 1 row was found");}

		if (dt.Rows.Count <= 0){return null;}

		DataRow row = dt.Rows[0];
		Tab_UserVipCardNo model = ToModel(row);
		return model;
	}

	public IEnumerable<Tab_UserVipCardNo> ListAll()
	{
		List<Tab_UserVipCardNo> list = new List<Tab_UserVipCardNo>();
		DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text,"select * from Tab_UserVipCardNo").Tables[0];
		foreach (DataRow row in dt.Rows)
		{
			list.Add(ToModel(row));
		}
		return list;
	}

	public IEnumerable<Tab_UserVipCardNo> ListAll(string strSql)
	{
		List<Tab_UserVipCardNo> list = new List<Tab_UserVipCardNo>();
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
		string strSql = " select * from Tab_UserVipCardNo";
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
